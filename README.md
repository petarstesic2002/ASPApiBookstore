## ASP Bookstore API
1. Install Dependencies if needed
2. Make a Database in Microsoft SQL Server Management Studio named ASPBookstore
3. Update the connection string in DataAccessLayer in the ASPContext.cs File
4. Set DataAccessLayer project as the startup project and run Update-Database in the Package Manager Console
5. Set the API as the startup project and run it
6. Open localhost:7222/swagger/index.html 
7. USER - email: user@test.com, pass: userpass; ADMIN - email: admin@test.com, pass: adminpass;
8. Send a post request with the email and password to /api/auth and get the JWT token
9. Click authorize and enter Bearer <your_token>
10. Try out the API
