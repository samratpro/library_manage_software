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
                
                // Check if this borrower already has an unreturned copy of this book
                string checkBorrowerSql = @"SELECT COUNT(*) FROM BorrowingHistory 
                                           WHERE BookTitle = @bookTitle 
                                           AND BorrowerName = @borrower 
                                           AND Status = 'Borrowed'";
                using (SQLiteCommand checkBorrowerCmd = new SQLiteCommand(checkBorrowerSql, conn))
                {
                    checkBorrowerCmd.Parameters.AddWithValue("@bookTitle", bookTitle);
                    checkBorrowerCmd.Parameters.AddWithValue("@borrower", txtBorrower.Text.Trim());
                    
                    int existingBorrowings = Convert.ToInt32(checkBorrowerCmd.ExecuteScalar());
                    if (existingBorrowings > 0)
                    {
                        MessageBox.Show($"{txtBorrower.Text.Trim()} has already borrowed this book and hasn't returned it yet!\n\nOne person can only borrow one copy of each unique book.", 
                                      "Validation Error", 
                                      MessageBoxButtons.OK, 
                                      MessageBoxIcon.Warning);
                        return;
                    }
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

            string borrowerName = txtBorrower.Text.Trim();
            txtBorrower.Clear();
            LoadBooks();
            LoadBorrowingHistory();
            MessageBox.Show($"Book borrowed successfully by {borrowerName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please select a book to return!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txtBorrower.Text))
            {
                MessageBox.Show("Please enter the borrower name to return the book!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string borrowerName = "";

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                
                // Check if there are any borrowed copies
                int totalCopies = 0;
                int availableCopies = 0;
                string bookTitle = "";
                
                string checkSql = "SELECT Title, TotalCopies, AvailableCopies FROM Books WHERE Id = @id";
                using (SQLiteCommand checkCmd = new SQLiteCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", txtId.Text);
                    using (SQLiteDataReader reader = checkCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bookTitle = reader.GetString(0);
                            totalCopies = reader.GetInt32(1);
                            availableCopies = reader.GetInt32(2);
                        }
                    }
                }
                
                if (availableCopies >= totalCopies)
                {
                    MessageBox.Show("All copies are already available. No books to return!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                // Find the most recent unreturned borrowing record for this borrower
                int historyId = -1;
                
                string findBorrowingSql = @"SELECT Id, BorrowerName FROM BorrowingHistory 
                                           WHERE BookId = @bookId 
                                           AND BorrowerName = @borrower 
                                           AND Status = 'Borrowed' 
                                           ORDER BY Id DESC LIMIT 1";
                using (SQLiteCommand findCmd = new SQLiteCommand(findBorrowingSql, conn))
                {
                    findCmd.Parameters.AddWithValue("@bookId", txtId.Text);
                    findCmd.Parameters.AddWithValue("@borrower", txtBorrower.Text.Trim());
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
                    MessageBox.Show($"No borrowing record found for '{txtBorrower.Text.Trim()}' with this book!\n\nPlease verify:\n• The borrower name is correct\n• This person actually borrowed this book\n• The book hasn't already been returned", 
                                  "Validation Error", 
                                  MessageBoxButtons.OK, 
                                  MessageBoxIcon.Warning);
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
            MessageBox.Show($"Book returned successfully by {borrowerName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
