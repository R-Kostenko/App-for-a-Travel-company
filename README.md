# Application for a Travel company
Application for a travel company, created in **Windows Froms** using **Microsoft SQL Server Management 18**. **Fully commented**, without installer.

## Description
This is a desktop application for a travel company, developed using **Windows Forms** and **Microsoft SQL Server Management 18**. The application allows users to view and order tours, as well as provides administration functionalities for managing tours and users. The project is **fully commented** and does not come with an installer.

![Program](TravelAgency_temp/Pictures/MainForm(after_login).JPG)

## Project Overview
This application was developed as my first relatively large-scale **pet project** in a short period of time for a summer internship assignment. The main objectives of this project were to enhance my skills in **C# programming**, **Windows Forms**, and **Microsoft SQL Server database management**. The application consists of features for user registration and authentication, input validation using the **"Chain of Responsibility" pattern**, password encryption based on the **MD5 algorithm**, and implementation of the **"Singleton" pattern** for database connection.

## Key Features
- **Registration and authorization system** with the use of regular expressions for data validation.
- Implementation of the **"Chain of Responsibility" pattern** for validating user and tour data.
- Password encryption using the **MD5 algorithm** for enhanced security.
- **User roles**: regular user and administrator.
- **Profile viewing** and user data modification.
- Custom class and event handlers for **viewing tour details**.
- **E-mail functionality** for user confirmation (registration and tour ordering/cancellation), user notification (tour ordering/cancellation), and communication with the administration using **Gmail SMTP server**.
- Advanced **tour search** capabilities.
- Tour ordering, modification, and creation by the administrator.
- **View ordered tours** with the ability to cancel them.

## Getting Started
To run the program on your device, follow these steps:

1. Ensure you have a **code compiler**, **SQL server**, and an **e-mail account** set up (used for administration and user communication).
1. **Download the folder 'TravelAgency_temp'**.
1. Modify the **database connection string** in 'DataBaseConnection' class, details in the [**README**](TravelAgency_temp/Classes/README(Database_creation).md) file located inside the folder.
1. Update the data in the 'Sender' class to match the e-mail settings in the [**README**](TravelAgency_temp/Classes/README(Deployment).md#sendercs) file.
1. After making these changes, you can fully utilize the program's functionalities.

## Future Enhancements
Currently, the application requires local access to the database and an SMTP server for e-mail communication. In the future, I plan to implement remote database access and SMTP server integration. Once these enhancements are in place, I will create a program installer for easier deployment.

For detailed instructions on configuring the program and running it on your device, refer to the README files located within the project folders.

Feel free to explore the code, use it for learning purposes, and provide any feedback or suggestions for improvement. 

**Happy coding!**
