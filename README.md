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
