# Application for a Travel company
Application for a travel company, created in Windows Froms using Microsoft SQL Server Management 18. Fully commented, without installer.

## Description
This is my first relatively large-scale pet project, which I made in a short period of time as a result of an assignment given by universities for a summer internship. I did it in order to improve my skills in using C# language, Windows Forms and Microsoft SQL Server database. The application is made as a desktop application for viewing and ordering tours, as well as administering tours and users. Unfortunately, at least for now, I have not implemented remote access to my database, so the application has no installer - you will have to have a code editor (e.g. Microsoft Visual Studio) and a local database (e.g. Microsoft SQL Server Management 18). Instructions for configuring the application to work on your computer will of course be provided.

## Functionality in brief
- Registration and authorization system (regular expressions are used);
- implementation of "Chain of Responsibility" pattern for user and tour data input checks;
- a class for password encryption based on MD5 algorithm;
- implementation of the "Singleton" pattern for the class of connection to the database;
- realization of user roles: regular user and administrator;
- viewing profile and changing user data;
- creation of a class and event handlers for it to view the tour;
- realization of class of sending e-mails to confirm user actions (registration and ordering/cancellation of tour), notify user (ordering/cancellation of tour) and communication with administration using Gmail SMTP server;
- implementation of tour search;
- ordering tours and modifying them by the administrator (creation also);
- viewing of ordered tours with the possibility of canceling them;

## Preparing the program for use
Here is a brief summary of what you will need to do to make the program work on your device fully, I used Visual Studio 2022 and Miscrosoft SQL Server Management 18. In the README files inside the folders will be step-by-step instructions for configuring the program to work. In the future it is planned to implement remote work with my database and SMTP server, after that I will create a program installer (then this section will be replaced by a brief description of the program installation).

1. You need to have an installed code compiler, SQL server and e-mail (administration mail from which you will send letters to users and to which you will receive messages from them).
1. Download the folder TravelAgency_temp
1. You will need to change the database connection string (README)
1. Also, you will need to change the data in Sender class for sending letters to e-mail (README).
1. After all these changes you will be able to fully use the program
