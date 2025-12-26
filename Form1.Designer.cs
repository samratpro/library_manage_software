namespace LibraryBookManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtId = new TextBox();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtIsbn = new TextBox();
            txtSearch = new TextBox();
            txtBorrower = new TextBox();
            txtTotalCopies = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnSearch = new Button();
            btnBorrow = new Button();
            btnReturn = new Button();
            dataGridViewBooks = new DataGridView();
            dataGridViewHistory = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            lblAvailability = new Label();
            groupBoxBookManagement = new GroupBox();
            groupBoxBorrowing = new GroupBox();
            groupBoxSearch = new GroupBox();
            tabControl = new TabControl();
            tabPageBooks = new TabPage();
            tabPageHistory = new TabPage();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).BeginInit();
            groupBoxBookManagement.SuspendLayout();
            groupBoxBorrowing.SuspendLayout();
            groupBoxSearch.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageBooks.SuspendLayout();
            tabPageHistory.SuspendLayout();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 10F);
            txtId.Location = new Point(18, 161);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(176, 25);
            txtId.TabIndex = 0;
            txtId.Visible = false;
            txtId.TextChanged += txtId_TextChanged;
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 10F);
            txtTitle.Location = new Point(18, 41);
            txtTitle.Margin = new Padding(3, 2, 3, 2);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(298, 25);
            txtTitle.TabIndex = 1;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // txtAuthor
            // 
            txtAuthor.Font = new Font("Segoe UI", 10F);
            txtAuthor.Location = new Point(18, 86);
            txtAuthor.Margin = new Padding(3, 2, 3, 2);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(298, 25);
            txtAuthor.TabIndex = 2;
            txtAuthor.TextChanged += txtAuthor_TextChanged;
            // 
            // txtIsbn
            // 
            txtIsbn.Font = new Font("Segoe UI", 10F);
            txtIsbn.Location = new Point(18, 131);
            txtIsbn.Margin = new Padding(3, 2, 3, 2);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(176, 25);
            txtIsbn.TabIndex = 3;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(18, 22);
            txtSearch.Margin = new Padding(3, 2, 3, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by title, author, or ISBN...";
            txtSearch.Size = new Size(394, 25);
            txtSearch.TabIndex = 4;
            // 
            // txtBorrower
            // 
            txtBorrower.Font = new Font("Segoe UI", 10F);
            txtBorrower.Location = new Point(18, 41);
            txtBorrower.Margin = new Padding(3, 2, 3, 2);
            txtBorrower.Name = "txtBorrower";
            txtBorrower.PlaceholderText = "Enter borrower name...";
            txtBorrower.Size = new Size(298, 25);
            txtBorrower.TabIndex = 16;
            // 
            // txtTotalCopies
            // 
            txtTotalCopies.Font = new Font("Segoe UI", 10F);
            txtTotalCopies.Location = new Point(210, 131);
            txtTotalCopies.Margin = new Padding(3, 2, 3, 2);
            txtTotalCopies.Name = "txtTotalCopies";
            txtTotalCopies.Size = new Size(106, 25);
            txtTotalCopies.TabIndex = 20;
            txtTotalCopies.Text = "1";
            txtTotalCopies.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 125, 50);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(18, 188);
            btnAdd.Margin = new Padding(3, 2, 3, 2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 30);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "➕ Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(25, 118, 210);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(122, 188);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(96, 30);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "✏️ Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(211, 47, 47);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(228, 188);
            btnDelete.Margin = new Padding(3, 2, 3, 2);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 30);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "🗑️ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(117, 117, 117);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(516, 19);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(96, 30);
            btnClear.TabIndex = 8;
            btnClear.Text = "🔄 Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(69, 90, 100);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(420, 19);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(88, 30);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "🔍 Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnBorrow
            // 
            btnBorrow.BackColor = Color.FromArgb(156, 39, 176);
            btnBorrow.FlatAppearance.BorderSize = 0;
            btnBorrow.FlatStyle = FlatStyle.Flat;
            btnBorrow.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBorrow.ForeColor = Color.White;
            btnBorrow.Location = new Point(18, 75);
            btnBorrow.Margin = new Padding(3, 2, 3, 2);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(140, 30);
            btnBorrow.TabIndex = 17;
            btnBorrow.Text = "📤 Borrow Book";
            btnBorrow.UseVisualStyleBackColor = false;
            btnBorrow.Click += btnBorrow_Click;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(255, 152, 0);
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(175, 75);
            btnReturn.Margin = new Padding(3, 2, 3, 2);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(140, 30);
            btnReturn.TabIndex = 18;
            btnReturn.Text = "📥 Return Book";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // dataGridViewBooks
            // 
            dataGridViewBooks.AllowUserToAddRows = false;
            dataGridViewBooks.AllowUserToDeleteRows = false;
            dataGridViewBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBooks.BackgroundColor = Color.White;
            dataGridViewBooks.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewBooks.ColumnHeadersHeight = 35;
            dataGridViewBooks.Dock = DockStyle.Fill;
            dataGridViewBooks.Location = new Point(3, 2);
            dataGridViewBooks.Margin = new Padding(3, 2, 3, 2);
            dataGridViewBooks.Name = "dataGridViewBooks";
            dataGridViewBooks.ReadOnly = true;
            dataGridViewBooks.RowHeadersWidth = 51;
            dataGridViewBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBooks.Size = new Size(1032, 244);
            dataGridViewBooks.TabIndex = 10;
            dataGridViewBooks.CellClick += dataGridViewBooks_CellClick;
            // 
            // dataGridViewHistory
            // 
            dataGridViewHistory.AllowUserToAddRows = false;
            dataGridViewHistory.AllowUserToDeleteRows = false;
            dataGridViewHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHistory.BackgroundColor = Color.White;
            dataGridViewHistory.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewHistory.ColumnHeadersHeight = 35;
            dataGridViewHistory.Dock = DockStyle.Fill;
            dataGridViewHistory.Location = new Point(3, 2);
            dataGridViewHistory.Margin = new Padding(3, 2, 3, 2);
            dataGridViewHistory.Name = "dataGridViewHistory";
            dataGridViewHistory.ReadOnly = true;
            dataGridViewHistory.RowHeadersWidth = 51;
            dataGridViewHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHistory.Size = new Size(1032, 244);
            dataGridViewHistory.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(33, 33, 33);
            label1.Location = new Point(18, 22);
            label1.Name = "label1";
            label1.Size = new Size(77, 19);
            label1.TabIndex = 11;
            label1.Text = "Book Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(33, 33, 33);
            label2.Location = new Point(18, 68);
            label2.Name = "label2";
            label2.Size = new Size(55, 19);
            label2.TabIndex = 12;
            label2.Text = "Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(33, 33, 33);
            label3.Location = new Point(18, 112);
            label3.Name = "label3";
            label3.Size = new Size(41, 19);
            label3.TabIndex = 13;
            label3.Text = "ISBN";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(33, 33, 33);
            label4.Location = new Point(20, 20);
            label4.Name = "label4";
            label4.Size = new Size(138, 28);
            label4.TabIndex = 14;
            label4.Text = "Search Books";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(25, 118, 210);
            label5.Location = new Point(18, 9);
            label5.Name = "label5";
            label5.Size = new Size(378, 32);
            label5.TabIndex = 15;
            label5.Text = "📚 Library Management System";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(33, 33, 33);
            label6.Location = new Point(18, 22);
            label6.Name = "label6";
            label6.Size = new Size(117, 19);
            label6.TabIndex = 19;
            label6.Text = "Borrower Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(33, 33, 33);
            label7.Location = new Point(210, 112);
            label7.Name = "label7";
            label7.Size = new Size(91, 19);
            label7.TabIndex = 21;
            label7.Text = "Total Copies";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(33, 33, 33);
            label8.Location = new Point(10, 10);
            label8.Name = "label8";
            label8.Size = new Size(174, 25);
            label8.TabIndex = 22;
            label8.Text = "Book Management";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(33, 33, 33);
            label9.Location = new Point(10, 10);
            label9.Name = "label9";
            label9.Size = new Size(100, 25);
            label9.TabIndex = 23;
            label9.Text = "Borrowing";
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAvailability.ForeColor = Color.Green;
            lblAvailability.Location = new Point(18, 161);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(0, 19);
            lblAvailability.TabIndex = 24;
            // 
            // groupBoxBookManagement
            // 
            groupBoxBookManagement.Controls.Add(txtId);
            groupBoxBookManagement.Controls.Add(label1);
            groupBoxBookManagement.Controls.Add(txtTitle);
            groupBoxBookManagement.Controls.Add(label2);
            groupBoxBookManagement.Controls.Add(txtAuthor);
            groupBoxBookManagement.Controls.Add(label3);
            groupBoxBookManagement.Controls.Add(txtIsbn);
            groupBoxBookManagement.Controls.Add(label7);
            groupBoxBookManagement.Controls.Add(txtTotalCopies);
            groupBoxBookManagement.Controls.Add(lblAvailability);
            groupBoxBookManagement.Controls.Add(btnAdd);
            groupBoxBookManagement.Controls.Add(btnUpdate);
            groupBoxBookManagement.Controls.Add(btnDelete);
            groupBoxBookManagement.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxBookManagement.Location = new Point(18, 60);
            groupBoxBookManagement.Margin = new Padding(3, 2, 3, 2);
            groupBoxBookManagement.Name = "groupBoxBookManagement";
            groupBoxBookManagement.Padding = new Padding(3, 2, 3, 2);
            groupBoxBookManagement.Size = new Size(341, 232);
            groupBoxBookManagement.TabIndex = 25;
            groupBoxBookManagement.TabStop = false;
            groupBoxBookManagement.Text = "📖 Book Management";
            // 
            // groupBoxBorrowing
            // 
            groupBoxBorrowing.Controls.Add(label6);
            groupBoxBorrowing.Controls.Add(txtBorrower);
            groupBoxBorrowing.Controls.Add(btnBorrow);
            groupBoxBorrowing.Controls.Add(btnReturn);
            groupBoxBorrowing.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxBorrowing.Location = new Point(376, 60);
            groupBoxBorrowing.Margin = new Padding(3, 2, 3, 2);
            groupBoxBorrowing.Name = "groupBoxBorrowing";
            groupBoxBorrowing.Padding = new Padding(3, 2, 3, 2);
            groupBoxBorrowing.Size = new Size(341, 124);
            groupBoxBorrowing.TabIndex = 26;
            groupBoxBorrowing.TabStop = false;
            groupBoxBorrowing.Text = "📤 Borrowing Operations";
            // 
            // groupBoxSearch
            // 
            groupBoxSearch.Controls.Add(txtSearch);
            groupBoxSearch.Controls.Add(btnSearch);
            groupBoxSearch.Controls.Add(btnClear);
            groupBoxSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxSearch.Location = new Point(376, 195);
            groupBoxSearch.Margin = new Padding(3, 2, 3, 2);
            groupBoxSearch.Name = "groupBoxSearch";
            groupBoxSearch.Padding = new Padding(3, 2, 3, 2);
            groupBoxSearch.Size = new Size(630, 60);
            groupBoxSearch.TabIndex = 27;
            groupBoxSearch.TabStop = false;
            groupBoxSearch.Text = "🔍 Search Books";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageBooks);
            tabControl.Controls.Add(tabPageHistory);
            tabControl.Font = new Font("Segoe UI", 10F);
            tabControl.Location = new Point(18, 308);
            tabControl.Margin = new Padding(3, 2, 3, 2);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1046, 278);
            tabControl.TabIndex = 27;
            // 
            // tabPageBooks
            // 
            tabPageBooks.Controls.Add(dataGridViewBooks);
            tabPageBooks.Location = new Point(4, 26);
            tabPageBooks.Margin = new Padding(3, 2, 3, 2);
            tabPageBooks.Name = "tabPageBooks";
            tabPageBooks.Padding = new Padding(3, 2, 3, 2);
            tabPageBooks.Size = new Size(1038, 248);
            tabPageBooks.TabIndex = 0;
            tabPageBooks.Text = "📚 Books Inventory";
            tabPageBooks.UseVisualStyleBackColor = true;
            // 
            // tabPageHistory
            // 
            tabPageHistory.Controls.Add(dataGridViewHistory);
            tabPageHistory.Location = new Point(4, 26);
            tabPageHistory.Margin = new Padding(3, 2, 3, 2);
            tabPageHistory.Name = "tabPageHistory";
            tabPageHistory.Padding = new Padding(3, 2, 3, 2);
            tabPageHistory.Size = new Size(1038, 248);
            tabPageHistory.TabIndex = 1;
            tabPageHistory.Text = "📜 Borrowing History";
            tabPageHistory.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1076, 601);
            Controls.Add(tabControl);
            Controls.Add(groupBoxSearch);
            Controls.Add(groupBoxBorrowing);
            Controls.Add(groupBoxBookManagement);
            Controls.Add(label5);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Book Manager - Professional Edition";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistory).EndInit();
            groupBoxBookManagement.ResumeLayout(false);
            groupBoxBookManagement.PerformLayout();
            groupBoxBorrowing.ResumeLayout(false);
            groupBoxBorrowing.PerformLayout();
            groupBoxSearch.ResumeLayout(false);
            groupBoxSearch.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageBooks.ResumeLayout(false);
            tabPageHistory.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtBorrower;
        private System.Windows.Forms.TextBox txtTotalCopies;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAvailability;
        private System.Windows.Forms.GroupBox groupBoxBookManagement;
        private System.Windows.Forms.GroupBox groupBoxBorrowing;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageBooks;
        private System.Windows.Forms.TabPage tabPageHistory;
    }
}