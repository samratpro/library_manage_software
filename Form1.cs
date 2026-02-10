using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;

namespace LibraryBookManager
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Data Source=library.db;Version=3;";

        public Form1()
        {
            InitializeComponent();
            CreateDatabaseAndTable();
            LoadBooks();
            LoadBorrowingHistory();
        }

        private void CreateDatabaseAndTable()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Create Books table with copy tracking
                string sqlBooks = @"
                    CREATE TABLE IF NOT EXISTS Books (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        Isbn TEXT,
                        TotalCopies INTEGER NOT NULL DEFAULT 1,
                        AvailableCopies INTEGER NOT NULL DEFAULT 1
                    );";

                // Create BorrowingHistory table
                string sqlHistory = @"
                    CREATE TABLE IF NOT EXISTS BorrowingHistory (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        BookId INTEGER NOT NULL,
                        BookTitle TEXT NOT NULL,
                        BorrowerName TEXT NOT NULL,
                        BorrowedDate TEXT NOT NULL,
                        ReturnedDate TEXT,
                        Status TEXT NOT NULL,
                        FOREIGN KEY (BookId) REFERENCES Books(Id)
                    );";

                using (SQLiteCommand cmd = new SQLiteCommand(sqlBooks, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SQLiteCommand cmd = new SQLiteCommand(sqlHistory, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Migrate existing data if needed
                MigrateExistingData(conn);
            }
        }

        private void MigrateExistingData(SQLiteConnection conn)
        {
            // Check if TotalCopies column exists
            string checkColumn = "PRAGMA table_info(Books)";
            bool hasTotalCopies = false;

            using (SQLiteCommand cmd = new SQLiteCommand(checkColumn, conn))
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["name"].ToString() == "TotalCopies")
                    {
                        hasTotalCopies = true;
                        break;
                    }
                }
            }

            if (!hasTotalCopies)
            {
                // Add new columns to existing table
                string alterTable = @"
                    ALTER TABLE Books ADD COLUMN TotalCopies INTEGER NOT NULL DEFAULT 1;
                    ALTER TABLE Books ADD COLUMN AvailableCopies INTEGER NOT NULL DEFAULT 1;";

                try
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(alterTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    // Columns might already exist
                }
            }
        }

        private void LoadBooks(string search = "")
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string sql = "SELECT Id, Title, Author, Isbn, TotalCopies, AvailableCopies FROM Books";
                if (!string.IsNullOrEmpty(search))
                {
                    sql += " WHERE Title LIKE @search OR Author LIKE @search OR Isbn LIKE @search";
                }
                sql += " ORDER BY Title";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    if (!string.IsNullOrEmpty(search))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Add a computed column for status
                    dt.Columns.Add("Status", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        int available = Convert.ToInt32(row["AvailableCopies"]);
                        int total = Convert.ToInt32(row["TotalCopies"]);

                        if (available == 0)
                            row["Status"] = "All Borrowed";
                        else if (available < total)
                            row["Status"] = "Partially Available";
                        else
                            row["Status"] = "Available";
                    }

                    dataGridViewBooks.DataSource = dt;
                }
            }
        }

        private void LoadBorrowingHistory()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"SELECT Id, BookId, BookTitle as 'Book Title', BorrowerName as 'Borrower', 
                              BorrowedDate as 'Borrowed Date', ReturnedDate as 'Returned Date', Status 
                              FROM BorrowingHistory ORDER BY Id DESC LIMIT 100";

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewHistory.DataSource = dt;
                    
                    // Hide the Id and BookId columns (used internally)
                    if (dataGridViewHistory.Columns.Contains("Id"))
                        dataGridViewHistory.Columns["Id"].Visible = false;
                    if (dataGridViewHistory.Columns.Contains("BookId"))
                        dataGridViewHistory.Columns["BookId"].Visible = false;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Title and Author are required!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalCopies = 1;
            if (!string.IsNullOrWhiteSpace(txtTotalCopies.Text))
            {
                if (!int.TryParse(txtTotalCopies.Text, out totalCopies) || totalCopies < 1)
                {
                    MessageBox.Show("Total Copies must be a positive number!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Books (Title, Author, Isbn, TotalCopies, AvailableCopies) VALUES (@title, @author, @isbn, @total, @available)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@isbn", txtIsbn.Text?.Trim() ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@total", totalCopies);
                    cmd.Parameters.AddWithValue("@available", totalCopies);
                    cmd.ExecuteNonQuery();
                }
            }

            ClearFields();
            LoadBooks();
            MessageBox.Show($"Book added successfully with {totalCopies} copies!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please select a book to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalCopies = 1;
            if (!string.IsNullOrWhiteSpace(txtTotalCopies.Text))
            {
                if (!int.TryParse(txtTotalCopies.Text, out totalCopies) || totalCopies < 1)
                {
                    MessageBox.Show("Total Copies must be a positive number!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Get current available copies
                int currentAvailable = 0;
                int currentTotal = 0;
                string getQuery = "SELECT TotalCopies, AvailableCopies FROM Books WHERE Id = @id";
                using (SQLiteCommand getCmd = new SQLiteCommand(getQuery, conn))
                {
                    getCmd.Parameters.AddWithValue("@id", txtId.Text);
                    using (SQLiteDataReader reader = getCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            currentTotal = reader.GetInt32(0);
                            currentAvailable = reader.GetInt32(1);
                        }
                    }
                }

                // Calculate new available copies
                int borrowed = currentTotal - currentAvailable;
                int newAvailable = totalCopies - borrowed;

                if (newAvailable < 0)
                {
                    MessageBox.Show($"Cannot reduce total copies below {borrowed} (currently borrowed)!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sql = "UPDATE Books SET Title = @title, Author = @author, Isbn = @isbn, TotalCopies = @total, AvailableCopies = @available WHERE Id = @id";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@isbn", txtIsbn.Text?.Trim() ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@total", totalCopies);
                    cmd.Parameters.AddWithValue("@available", newAvailable);
                    cmd.ExecuteNonQuery();
                }
            }

            ClearFields();
            LoadBooks();
            MessageBox.Show("Book updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Please select a book to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this book?\nThis will also delete all borrowing history for this book.", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    // Delete borrowing history first
                    string deleteHistory = "DELETE FROM BorrowingHistory WHERE BookId = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteHistory, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete the book
                    string sql = "DELETE FROM Books WHERE Id = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", txtId.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                ClearFields();
                LoadBooks();
                LoadBorrowingHistory();
                MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridViewBooks.Rows.Count)
                {
                    DataGridViewRow row = dataGridViewBooks.Rows[e.RowIndex];

                    if (row != null && !row.IsNewRow)
                    {
                        // Safely get cell values with column and cell existence checks
                        if (dataGridViewBooks.Columns.Contains("Id") && row.Cells["Id"] != null && row.Cells["Id"].Value != null)
                            txtId.Text = row.Cells["Id"].Value.ToString();
                        else
                            txtId.Text = "";

                        if (dataGridViewBooks.Columns.Contains("Title") && row.Cells["Title"] != null && row.Cells["Title"].Value != null)
                            txtTitle.Text = row.Cells["Title"].Value.ToString();
                        else
                            txtTitle.Text = "";

                        if (dataGridViewBooks.Columns.Contains("Author") && row.Cells["Author"] != null && row.Cells["Author"].Value != null)
                            txtAuthor.Text = row.Cells["Author"].Value.ToString();
                        else
                            txtAuthor.Text = "";

                        if (dataGridViewBooks.Columns.Contains("Isbn") && row.Cells["Isbn"] != null && row.Cells["Isbn"].Value != null)
                            txtIsbn.Text = row.Cells["Isbn"].Value.ToString();
                        else
                            txtIsbn.Text = "";

                        if (dataGridViewBooks.Columns.Contains("TotalCopies") && row.Cells["TotalCopies"] != null && row.Cells["TotalCopies"].Value != null)
                            txtTotalCopies.Text = row.Cells["TotalCopies"].Value.ToString();
                        else
                            txtTotalCopies.Text = "1";

                        // Update status label with column and cell existence checks
                        if (dataGridViewBooks.Columns.Contains("AvailableCopies") &&
                            dataGridViewBooks.Columns.Contains("TotalCopies") &&
                            row.Cells["AvailableCopies"] != null &&
                            row.Cells["TotalCopies"] != null &&
                            row.Cells["AvailableCopies"].Value != null &&
                            row.Cells["TotalCopies"].Value != null)
                        {
                            int available = Convert.ToInt32(row.Cells["AvailableCopies"].Value);
                            int total = Convert.ToInt32(row.Cells["TotalCopies"].Value);
                            lblAvailability.Text = $"Available: {available} / {total}";

                            if (available == 0)
                            {
                                lblAvailability.ForeColor = Color.Red;
                            }
                            else if (available < total)
                            {
                                lblAvailability.ForeColor = Color.Orange;
                            }
                            else
                            {
                                lblAvailability.ForeColor = Color.Green;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Silently handle any errors when clicking on grid cells
                // This prevents crashes from null references or invalid data
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBooks(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadBooks();
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtIsbn.Clear();
            txtSearch.Clear();
            txtTotalCopies.Text = "1";
            txtBorrower.Clear();
            lblAvailability.Text = "";
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridViewHistory.Rows.Count)
                {
                    DataGridViewRow historyRow = dataGridViewHistory.Rows[e.RowIndex];

                    if (historyRow != null && !historyRow.IsNewRow)
                    {
                        // Get BookId and Borrower name from the history row
                        string bookId = "";
                        string borrowerName = "";

                        if (dataGridViewHistory.Columns.Contains("BookId") && historyRow.Cells["BookId"] != null && historyRow.Cells["BookId"].Value != null)
                            bookId = historyRow.Cells["BookId"].Value.ToString();

                        if (dataGridViewHistory.Columns.Contains("Borrower") && historyRow.Cells["Borrower"] != null && historyRow.Cells["Borrower"].Value != null)
                            borrowerName = historyRow.Cells["Borrower"].Value.ToString();

                        // Fill in the borrower name
                        if (!string.IsNullOrEmpty(borrowerName))
                        {
                            txtBorrower.Text = borrowerName;
                        }

                        // Find and select the corresponding book in the books grid
                        if (!string.IsNullOrEmpty(bookId))
                        {
                            foreach (DataGridViewRow bookRow in dataGridViewBooks.Rows)
                            {
                                if (bookRow.Cells["Id"] != null && bookRow.Cells["Id"].Value != null)
                                {
                                    if (bookRow.Cells["Id"].Value.ToString() == bookId)
                                    {
                                        // Clear current selection
                                        dataGridViewBooks.ClearSelection();
                                        
                                        // Select the book row
                                        bookRow.Selected = true;
                                        
                                        // Ensure the row is visible
                                        dataGridViewBooks.FirstDisplayedScrollingRowIndex = bookRow.Index;
                                        
                                        // Trigger the cell click event to populate the form fields
                                        dataGridViewBooks_CellClick(dataGridViewBooks, new DataGridViewCellEventArgs(0, bookRow.Index));
                                        
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Silently handle any errors when clicking on history grid cells
            }
        }
    }
}