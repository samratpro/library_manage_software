# 📚 Library Book Management System

A modern, professional Windows Forms application for managing library books with complete borrowing and return functionality.

---

## 📋 Table of Contents
- [Features](#-features)
- [Manual Design Guide](#-manual-design-guide-visual-studio-designer)
- [Database Schema](#️-database-schema)
- [How to Use](#-how-to-use)
- [Technical Details](#-technical-details)
- [Build and Run](#-build-and-run)

---

## ✨ Features

### 📖 Book Management
- **Add Books**: Add new books with title, author, ISBN, and specify the number of copies
- **Update Books**: Modify book information while respecting borrowed copies
- **Delete Books**: Remove books from the system (with borrowing history cleanup)
- **Search Books**: Search by title, author, or ISBN with real-time filtering
- **Copy Tracking**: Track total copies and available copies for each book

### 📤 Borrowing System
- **Borrow Books**: 
  - Automatically decreases available copies when a book is borrowed
  - Prevents borrowing when no copies are available
  - Records borrower name and timestamp
  - Creates borrowing history entry

- **Return Books**:
  - Automatically increases available copies when a book is returned
  - Updates borrowing history with return date
  - Validates that books are actually borrowed before allowing returns

### 📊 Visual Features
- **Color-Coded Status**: Books are color-coded based on availability:
  - 🟢 **Green**: All copies available
  - 🟡 **Yellow**: Partially available (some copies borrowed)
  - 🔴 **Red**: All copies borrowed

- **Availability Indicator**: Real-time display of available vs. total copies
- **Tabbed Interface**: 
  - 📚 Books Inventory tab
  - 📜 Borrowing History tab

### 🎨 Modern UI Design
- Professional color scheme with Material Design-inspired colors
- Organized GroupBox containers for different functions
- Emoji icons for better visual recognition
- Clean, modern typography using Segoe UI
- Flat design with color-coded action buttons

---

## 🎨 Manual Design Guide (Visual Studio Designer)

### 📐 Form Hierarchy and Element Selection

When designing this form manually in Visual Studio, follow this **exact hierarchy** to ensure proper organization:

```
Form1 (Main Form)
│
├── label5 (Title Label - "📚 Library Management System")
├── txtId (Hidden TextBox for ID)
│
├── groupBoxBookManagement (GroupBox)
│   ├── label1 (Label - "Book Title")
│   ├── txtTitle (TextBox)
│   ├── label2 (Label - "Author")
│   ├── txtAuthor (TextBox)
│   ├── label3 (Label - "ISBN")
│   ├── txtIsbn (TextBox)
│   ├── label7 (Label - "Total Copies")
│   ├── txtTotalCopies (TextBox)
│   ├── lblAvailability (Label - for showing availability status)
│   ├── btnAdd (Button)
│   ├── btnUpdate (Button)
│   └── btnDelete (Button)
│
├── groupBoxBorrowing (GroupBox)
│   ├── label6 (Label - "Borrower Name")
│   ├── txtBorrower (TextBox)
│   ├── btnBorrow (Button)
│   └── btnReturn (Button)
│
├── groupBoxSearch (GroupBox)
│   ├── txtSearch (TextBox)
│   ├── btnSearch (Button)
│   └── btnClear (Button)
│
└── tabControl (TabControl)
    ├── tabPageBooks (TabPage)
    │   └── dataGridViewBooks (DataGridView - Docked: Fill)
    └── tabPageHistory (TabPage)
        └── dataGridViewHistory (DataGridView - Docked: Fill)
```

---

## 🛠️ Step-by-Step Manual Design Instructions

### **Step 1: Create the Main Form**

1. **Open Visual Studio** and create a new Windows Forms App (.NET)
2. **Set Form Properties**:
   - Name: `Form1`
   - Text: `Library Book Manager - Professional Edition`
   - Size: `1234, 801`
   - StartPosition: `CenterScreen`
   - FormBorderStyle: `FixedSingle`
   - MaximizeBox: `False`
   - BackColor: `White`

---

### **Step 2: Add the Title Label**

1. **Drag a Label** from Toolbox to the form
2. **Set Properties**:
   - Name: `label5`
   - Text: `📚 Library Management System`
   - Location: `20, 20`
   - Font: `Segoe UI, 18pt, Bold`
   - ForeColor: `25, 118, 210` (Blue)
   - AutoSize: `True`

---

### **Step 3: Add Hidden ID TextBox**

1. **Drag a TextBox** from Toolbox
2. **Set Properties**:
   - Name: `txtId`
   - Location: `12, 12`
   - Size: `100, 27`
   - ReadOnly: `True`
   - Visible: `False`

---

### **Step 4: Create Book Management GroupBox**

1. **Drag a GroupBox** from Toolbox
2. **Set GroupBox Properties**:
   - Name: `groupBoxBookManagement`
   - Text: `📖 Book Management`
   - Location: `20, 80`
   - Size: `390, 310`
   - Font: `Segoe UI, 10pt, Bold`

3. **Inside this GroupBox, add the following controls** (drag them INTO the GroupBox):

   **a) Book Title Label and TextBox**
   - Label:
     - Name: `label1`
     - Text: `Book Title`
     - Location: `20, 30`
     - Font: `Segoe UI, 10pt, Bold`
     - ForeColor: `33, 33, 33`
   
   - TextBox:
     - Name: `txtTitle`
     - Location: `20, 55`
     - Size: `340, 30`
     - Font: `Segoe UI, 10pt`

   **b) Author Label and TextBox**
   - Label:
     - Name: `label2`
     - Text: `Author`
     - Location: `20, 90`
     - Font: `Segoe UI, 10pt, Bold`
   
   - TextBox:
     - Name: `txtAuthor`
     - Location: `20, 115`
     - Size: `340, 30`
     - Font: `Segoe UI, 10pt`

   **c) ISBN Label and TextBox**
   - Label:
     - Name: `label3`
     - Text: `ISBN`
     - Location: `20, 150`
     - Font: `Segoe UI, 10pt, Bold`
   
   - TextBox:
     - Name: `txtIsbn`
     - Location: `20, 175`
     - Size: `200, 30`
     - Font: `Segoe UI, 10pt`

   **d) Total Copies Label and TextBox**
   - Label:
     - Name: `label7`
     - Text: `Total Copies`
     - Location: `240, 150`
     - Font: `Segoe UI, 10pt, Bold`
   
   - TextBox:
     - Name: `txtTotalCopies`
     - Location: `240, 175`
     - Size: `120, 30`
     - Font: `Segoe UI, 10pt`
     - Text: `1`
     - TextAlign: `Center`

   **e) Availability Label**
   - Label:
     - Name: `lblAvailability`
     - Location: `20, 215`
     - Font: `Segoe UI, 10pt, Bold`
     - ForeColor: `0, 128, 0` (Green)
     - AutoSize: `True`

   **f) Action Buttons**
   - Button 1 (Add):
     - Name: `btnAdd`
     - Text: `➕ Add`
     - Location: `20, 250`
     - Size: `110, 40`
     - Font: `Segoe UI, 10pt, Bold`
     - BackColor: `46, 125, 50` (Green)
     - ForeColor: `White`
     - FlatStyle: `Flat`
     - FlatAppearance.BorderSize: `0`
   
   - Button 2 (Update):
     - Name: `btnUpdate`
     - Text: `✏️ Update`
     - Location: `140, 250`
     - Size: `110, 40`
     - Font: `Segoe UI, 10pt, Bold`
     - BackColor: `25, 118, 210` (Blue)
     - ForeColor: `White`
     - FlatStyle: `Flat`
     - FlatAppearance.BorderSize: `0`
   
   - Button 3 (Delete):
     - Name: `btnDelete`
     - Text: `🗑️ Delete`
     - Location: `260, 250`
     - Size: `110, 40`
     - Font: `Segoe UI, 10pt, Bold`
     - BackColor: `211, 47, 47` (Red)
     - ForeColor: `White`
     - FlatStyle: `Flat`
     - FlatAppearance.BorderSize: `0`

---

### **Step 5: Create Borrowing Operations GroupBox**

1. **Drag a GroupBox** from Toolbox
2. **Set GroupBox Properties**:
   - Name: `groupBoxBorrowing`
   - Text: `📤 Borrowing Operations`
   - Location: `430, 80`
   - Size: `390, 165`
   - Font: `Segoe UI, 10pt, Bold`

3. **Inside this GroupBox, add**:

   **a) Borrower Name Label and TextBox**
   - Label:
     - Name: `label6`
     - Text: `Borrower Name`
     - Location: `20, 30`
     - Font: `Segoe UI, 10pt, Bold`
   
   - TextBox:
     - Name: `txtBorrower`
     - Location: `20, 55`
     - Size: `340, 30`
     - Font: `Segoe UI, 10pt`
     - PlaceholderText: `Enter borrower name...`

   **b) Borrow and Return Buttons**
   - Button 1 (Borrow):
     - Name: `btnBorrow`
     - Text: `📤 Borrow Book`
     - Location: `20, 100`
     - Size: `160, 40`
     - Font: `Segoe UI, 10pt, Bold`
     - BackColor: `156, 39, 176` (Purple)
     - ForeColor: `White`
     - FlatStyle: `Flat`
     - FlatAppearance.BorderSize: `0`
   
   - Button 2 (Return):
     - Name: `btnReturn`
     - Text: `📥 Return Book`
     - Location: `200, 100`
     - Size: `160, 40`
     - Font: `Segoe UI, 10pt, Bold`
     - BackColor: `255, 152, 0` (Orange)
     - ForeColor: `White`
     - FlatStyle: `Flat`
     - FlatAppearance.BorderSize: `0`

---

### **Step 6: Create Search GroupBox**

1. **Drag a GroupBox** from Toolbox
2. **Set GroupBox Properties**:
   - Name: `groupBoxSearch`
   - Text: `🔍 Search Books`
   - Location: `430, 260`
   - Size: `720, 80`
   - Font: `Segoe UI, 10pt, Bold`

3. **Inside this GroupBox, add**:

   **a) Search TextBox**
   - TextBox:
     - Name: `txtSearch`
     - Location: `20, 30`
     - Size: `450, 30`
     - Font: `Segoe UI, 10pt`
     - PlaceholderText: `Search by title, author, or ISBN...`

   **b) Search and Clear Buttons**
   - Button 1 (Search):
     - Name: `btnSearch`
     - Text: `🔍 Search`
     - Location: `480, 25`
     - Size: `100, 40`
     - Font: `Segoe UI, 10pt, Bold`
     - BackColor: `69, 90, 100` (Dark Gray)
     - ForeColor: `White`
     - FlatStyle: `Flat`
     - FlatAppearance.BorderSize: `0`
   
   - Button 2 (Clear):
     - Name: `btnClear`
     - Text: `🔄 Clear`
     - Location: `590, 25`
     - Size: `110, 40`
     - Font: `Segoe UI, 10pt, Bold`
     - BackColor: `117, 117, 117` (Gray)
     - ForeColor: `White`
     - FlatStyle: `Flat`
     - FlatAppearance.BorderSize: `0`

---

### **Step 7: Create TabControl with DataGridViews**

1. **Drag a TabControl** from Toolbox
2. **Set TabControl Properties**:
   - Name: `tabControl`
   - Location: `20, 410`
   - Size: `1196, 370`
   - Font: `Segoe UI, 10pt`

3. **Configure Tab Pages**:

   **Tab Page 1 (Books Inventory)**
   - Right-click TabControl → Edit Tabs
   - Select first tab:
     - Name: `tabPageBooks`
     - Text: `📚 Books Inventory`
   
   - **Drag a DataGridView** into this tab:
     - Name: `dataGridViewBooks`
     - Dock: `Fill`
     - AllowUserToAddRows: `False`
     - AllowUserToDeleteRows: `False`
     - ReadOnly: `True`
     - SelectionMode: `FullRowSelect`
     - AutoSizeColumnsMode: `Fill`
     - BackgroundColor: `White`
     - BorderStyle: `Fixed3D`
     - ColumnHeadersHeight: `35`

   **Tab Page 2 (Borrowing History)**
   - Add second tab:
     - Name: `tabPageHistory`
     - Text: `📜 Borrowing History`
   
   - **Drag a DataGridView** into this tab:
     - Name: `dataGridViewHistory`
     - Dock: `Fill`
     - AllowUserToAddRows: `False`
     - AllowUserToDeleteRows: `False`
     - ReadOnly: `True`
     - SelectionMode: `FullRowSelect`
     - AutoSizeColumnsMode: `Fill`
     - BackgroundColor: `White`
     - BorderStyle: `Fixed3D`
     - ColumnHeadersHeight: `35`

---

## 🎯 Important Design Tips

### **Container Hierarchy**
- **Always drag controls INTO GroupBoxes** - Don't just place them on top
- To verify: Click a control and check the Properties window - it should show the GroupBox as the parent
- If a control is on the form instead of in the GroupBox, cut it (Ctrl+X) and paste it inside the GroupBox

### **Alignment Tools**
Use Visual Studio's alignment tools:
- **Format → Align** - Align multiple controls
- **Format → Make Same Size** - Uniform sizing
- **Format → Horizontal/Vertical Spacing** - Even spacing
- **View → Snap to Grid** - Enable grid snapping

### **Color Picker**
For custom colors (like RGB 25, 118, 210):
1. Click the color property
2. Select "Custom" tab
3. Enter RGB values manually

### **Testing the Layout**
- Press **F5** to run and see the actual appearance
- Check that GroupBoxes contain their controls (not just overlap)
- Verify tab order with Tab key

---

## 🗄️ Database Schema

### Books Table
```sql
CREATE TABLE Books (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Author TEXT NOT NULL,
    Isbn TEXT,
    TotalCopies INTEGER NOT NULL DEFAULT 1,
    AvailableCopies INTEGER NOT NULL DEFAULT 1
);
```

### BorrowingHistory Table
```sql
CREATE TABLE BorrowingHistory (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    BookId INTEGER NOT NULL,
    BookTitle TEXT NOT NULL,
    BorrowerName TEXT NOT NULL,
    BorrowedDate TEXT NOT NULL,
    ReturnedDate TEXT,
    Status TEXT NOT NULL,
    FOREIGN KEY (BookId) REFERENCES Books(Id)
);
```

---

## 🚀 How to Use

### Adding a Book
1. Enter the book title (required)
2. Enter the author name (required)
3. Enter ISBN (optional)
4. Specify total number of copies (default: 1)
5. Click **➕ Add** button

### Borrowing a Book
1. Select a book from the inventory grid
2. Enter the borrower's name
3. Click **📤 Borrow Book** button
4. The system will decrease available copies by 1

### Returning a Book
1. Select the borrowed book from the inventory grid
2. Click **📥 Return Book** button
3. The system will increase available copies by 1

### Searching for Books
1. Enter search term in the search box
2. Click **🔍 Search** button
3. Results will show books matching the title, author, or ISBN

### Viewing Borrowing History
1. Click on the **📜 Borrowing History** tab
2. View all borrowing transactions

---

## 🔧 Technical Details

### Technologies Used
- **.NET 10.0** - Windows Forms
- **SQLite** - Lightweight database
- **C#** - Programming language
- **System.Data.SQLite** - Database connectivity

### Key Features
- Automatic database creation and migration
- Copy tracking with automatic increment/decrement
- Color-coded status indicators
- Comprehensive borrowing history
- Input validation and error handling
- Null-safe operations

---

## 📦 Build and Run

### Prerequisites
- .NET 10.0 SDK or later
- Windows OS
- Visual Studio 2022 (for manual design)

### Build
```bash
dotnet build
```

### Run
```bash
dotnet run
```

---

## 🎨 Color Scheme Reference

| Element | Color Name | RGB | Hex |
|---------|-----------|-----|-----|
| Add Button | Success Green | 46, 125, 50 | #2E7D32 |
| Update Button | Info Blue | 25, 118, 210 | #1976D2 |
| Delete Button | Error Red | 211, 47, 47 | #D32F2F |
| Borrow Button | Purple | 156, 39, 176 | #9C27B0 |
| Return Button | Orange | 255, 152, 0 | #FF9800 |
| Search Button | Dark Gray | 69, 90, 100 | #455A64 |
| Clear Button | Gray | 117, 117, 117 | #757575 |
| Title | Primary Blue | 25, 118, 210 | #1976D2 |

---

## 📄 License

This is a demonstration project for library management systems.

---

**Made with ❤️ for efficient library management**
