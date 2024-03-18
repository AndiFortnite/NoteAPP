#Noteform Application
The Noteform application is a simple Windows Forms application that allows users to manage notes stored in a SQL Server database. It provides functionalities to create, view, and delete notes based on a header.

Features
Create Note: Users can create a new note by providing a note header and the content of the note.
View Note: Users can view a note by entering its header. If the note exists, its content will be displayed.
Delete Note: Users can delete a note by providing its header. If the note exists, it will be deleted from the database.
Installation
Clone this repository to your local machine:

bash
Copy code
git clone https://github.com/your-username/noteform.git
Open the solution file (Noteform.sln) in Visual Studio.

Build the solution to restore NuGet packages and compile the application.

Run the application by pressing F5 or clicking on the "Start" button in Visual Studio.

Configuration
Before running the application, ensure that you have a SQL Server instance set up with a database named NoteDB. You may need to adjust the connection string in the code (Form1.cs) to match your SQL Server configuration:

csharp
Copy code
string connectionString = @"Data Source=YOUR_SERVER_NAME; Initial Catalog=NoteDB; Integrated Security=True;";
Replace YOUR_SERVER_NAME with the name of your SQL Server instance.

Usage
Create Note:

Enter a note header in the provided text box.
Enter the content of the note in the rich text box.
Click the "Create" button to save the note to the database.
View Note:

Enter the header of the note you want to view in the text box.
Click the "View" button to display the content of the note.
Delete Note:

Enter the header of the note you want to delete in the text box.
Click the "Delete" button to remove the note from the database.
