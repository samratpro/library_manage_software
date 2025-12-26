# 📖 Quick Start Guide - Library Management System

## 🎯 Quick Overview

This system helps you manage library books with features for:
- Adding/editing/deleting books
- Tracking multiple copies of the same book
- Borrowing and returning books
- Viewing borrowing history

## 🚀 Getting Started in 3 Steps

### Step 1: Add Your First Book
1. Fill in the **Book Title** field (e.g., "Harry Potter")
2. Fill in the **Author** field (e.g., "J.K. Rowling")
3. (Optional) Fill in **ISBN** and **Total Copies**
4. Click the **➕ Add** button

### Step 2: Borrow a Book
1. Click on a book in the table to select it
2. Enter the **Borrower Name** (e.g., "John Doe")
3. Click the **📤 Borrow** button
4. Watch the "Available" count decrease!

### Step 3: Return a Book
1. Click on the borrowed book in the table
2. Click the **📥 Return** button
3. Watch the "Available" count increase!

## 💡 Pro Tips

### Managing Multiple Copies
- When adding a book, set **Total Copies** to the number you have
- Example: If you have 5 copies of "The Great Gatsby", enter 5
- The system will track how many are available vs. borrowed

### Understanding the Status Colors
- 🟢 **Green (Available)**: All copies are in the library
- 🟡 **Yellow (Partially Available)**: Some copies are borrowed
- 🔴 **Red (All Borrowed)**: No copies available

### Searching for Books
- Type in the search box (searches title, author, and ISBN)
- Click **🔍 Search** to filter
- Click **🔄 Clear** to see all books again

### Viewing History
- Click the **📜 Borrowing History** tab at the bottom
- See all past and current borrowings
- Check who borrowed what and when

## ⚠️ Common Scenarios

### "I can't borrow this book!"
- Check the **Available** column - it might be 0
- All copies are currently borrowed
- Wait for a return or add more copies

### "I want to add more copies of a book"
- Click the book in the table
- Increase the **Total Copies** number
- Click **✏️ Update**
- The available copies will increase automatically

### "I want to remove a book"
- Click the book in the table
- Click **🗑️ Delete**
- Confirm the deletion
- Note: This will also delete all borrowing history for that book

### "How do I see who borrowed a book?"
- Go to the **📜 Borrowing History** tab
- Look for the book title
- You'll see the borrower name and dates

## 🎨 Understanding the Interface

### Top Section
- **Search Bar**: Quick search across all books
- **Main Title**: Shows you're in the Library Management System

### Middle Section - Left Panel (Book Management)
- Add new books
- Update existing books
- Delete books
- Shows availability status when a book is selected

### Middle Section - Right Panel (Borrowing)
- Enter borrower name
- Borrow and return books

### Bottom Section - Tabs
- **📚 Books Inventory**: See all your books
- **📜 Borrowing History**: See all transactions

## 📊 Example Workflow

### Scenario: New Book Arrival
1. Library receives 3 copies of "1984" by George Orwell
2. Enter Title: "1984"
3. Enter Author: "George Orwell"
4. Enter Total Copies: 3
5. Click **➕ Add**
6. Result: Book appears with "Available: 3/3" and green status

### Scenario: Student Borrows Book
1. Student "Alice Smith" wants to borrow "1984"
2. Click on "1984" in the table
3. Enter Borrower Name: "Alice Smith"
4. Click **📤 Borrow**
5. Result: Available changes to "2/3", status turns yellow

### Scenario: Student Returns Book
1. Alice returns "1984"
2. Click on "1984" in the table
3. Click **📥 Return**
4. Result: Available changes back to "3/3", status turns green

### Scenario: Checking History
1. Click **📜 Borrowing History** tab
2. See entry: "1984" borrowed by "Alice Smith" on [date]
3. See return date when book was returned
4. Status shows "Returned"

## 🔧 Troubleshooting

### Problem: Can't see my book
**Solution**: Click **🔄 Clear** to reset search filter

### Problem: Wrong borrower name entered
**Solution**: Click **📥 Return** to return the book, then borrow again with correct name

### Problem: Need to update book information
**Solution**: Click the book, edit the fields, click **✏️ Update**

### Problem: Accidentally deleted a book
**Solution**: Unfortunately, you'll need to add it again. Deletion is permanent.

## 📱 Keyboard Shortcuts

- **Tab**: Move between fields
- **Enter**: (in search box) Perform search
- **Esc**: Clear selection

## 🎓 Best Practices

1. **Always enter borrower names clearly** - You'll need this for tracking
2. **Update total copies when you get new books** - Keeps inventory accurate
3. **Check borrowing history regularly** - Monitor overdue books
4. **Use the search feature** - Faster than scrolling through long lists
5. **Keep ISBN information** - Helps identify books uniquely

## 📞 Need Help?

- Check the README.md for detailed technical information
- Review the borrowing history to understand past transactions
- The system prevents invalid operations (like borrowing unavailable books)

---

**Happy Library Managing! 📚✨**
