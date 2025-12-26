using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace LibraryBookManager
{
    public partial class Form1 : Form
    {
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please select a book to borrow!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtBorrower.Text))
            {
                MessageBox.Show("Please enter borrower name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                
                // Get book information
                string bookTitle = "";
                int availableCopies = 0;
                
                string checkSql = "SELECT Title, AvailableCopies FROM Books WHERE Id = @id";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", txtId.Text);
                    using (SQLiteDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bookTitle = reader.GetString(0);
                            availableCopies = reader.GetInt32(1);
                        }
                    }
                }
                
                if (availableCopies <= 0)
                {
                    MessageBox.Show("No copies available for borrowing!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                // Decrease available copies
                string updateSql = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE Id = @id";
                using (SQLiteCommand updateCmd = new SQLiteCommand(updateSql, conn))
                {
                    updateCmd.Parameters.AddWithValue("@id", txtId.Text);
                    updateCmd.ExecuteNonQuery();
                }
                
                // Add to borrowing history
                string historySql = @"INSERT INTO BorrowingHistory (BookId, BookTitle, BorrowerName, BorrowedDate, Status) 
                                     VALUES (@bookId, @bookTitle, @borrower, @date, @status)";
                using (SQLiteCommand historyCmd = new SQLiteCommand(historySql, conn))
                {
                    historyCmd.Parameters.AddWithValue("@bookId", txtId.Text);
                    historyCmd.Parameters.AddWithValue("@bookTitle", bookTitle);
                    historyCmd.Parameters.AddWithValue("@borrower", txtBorrower.Text.Trim());
                    historyCmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    historyCmd.Parameters.AddWithValue("@status", "Borrowed");
                    historyCmd.ExecuteNonQuery();
                }
            }

            txtBorrower.Clear();
            LoadBooks();
            LoadBorrowingHistory();
            MessageBox.Show($"Book borrowed successfully by {txtBorrower.Text}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please select a book to return!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                
                // Check if there are any borrowed copies
                int totalCopies = 0;
                int availableCopies = 0;
                
                string checkSql = "SELECT TotalCopies, AvailableCopies FROM Books WHERE Id = @id";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", txtId.Text);
                    using (SQLiteDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalCopies = reader.GetInt32(0);
                            availableCopies = reader.GetInt32(1);
                        }
                    }
                }
                
                if (availableCopies >= totalCopies)
                {
                    MessageBox.Show("All copies are already available. No books to return!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                // Find the most recent unreturned borrowing record
                int historyId = -1;
                string borrowerName = "";
                
                string findBorrowingSql = @"SELECT Id, BorrowerName FROM BorrowingHistory 
                                           WHERE BookId = @bookId AND Status = 'Borrowed' 
                                           ORDER BY Id DESC LIMIT 1";
                using (SQLiteCommand findCmd = new SQLiteCommand(findBorrowingSql, conn))
                {
                    findCmd.Parameters.AddWithValue("@bookId", txtId.Text);
                    using (SQLiteDataReader reader = findCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            historyId = reader.GetInt32(0);
                            borrowerName = reader.GetString(1);
                        }
                    }
                }
                
                if (historyId == -1)
                {
                    MessageBox.Show("No borrowing record found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // Increase available copies
                string updateSql = "UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE Id = @id";
                using (SQLiteCommand updateCmd = new SQLiteCommand(updateSql, conn))
                {
                    updateCmd.Parameters.AddWithValue("@id", txtId.Text);
                    updateCmd.ExecuteNonQuery();
                }
                
                // Update borrowing history
                string updateHistorySql = @"UPDATE BorrowingHistory 
                                           SET ReturnedDate = @returnDate, Status = 'Returned' 
                                           WHERE Id = @historyId";
                using (SQLiteCommand historyCmd = new SQLiteCommand(updateHistorySql, conn))
                {
                    historyCmd.Parameters.AddWithValue("@returnDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    historyCmd.Parameters.AddWithValue("@historyId", historyId);
                    historyCmd.ExecuteNonQuery();
                }
            }

            ClearFields();
            LoadBooks();
            LoadBorrowingHistory();
            MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
