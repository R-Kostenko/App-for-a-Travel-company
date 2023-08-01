# Deployment assistance
This README is created to help users with deploying the program on their devices. It will help with modifying the DataBaseConnection and Sender classes.

## DataBaseConnection.cs
Once you have **created a database** you need to change the connection string to it in the 'DataBaseConnection' class.

The only thing you need is the name of the server. Where to get it (I am working with **Microsoft SQL Server Management Studio 18**): 
- Run MSS -> when you log in you will be asked to connect to the server (this is where you can copy the server name)
- Or if you are already logged into MSS: go to the Object Explorer panel and right click on the server name -> the server properties window will open where you can copy the server name.

Now all you have to do is paste this name into the connection string `SqlConnection sqlConnection = new SqlConnection(@"Data Source=/*Name of your local server*/;Initial Catalog=DataTrevApp;Integrated Security=True");`

## Sender.cs
Well, you should create a new gmail account for the administration of your travel company (I remind you that it is needed only for sending emails from it to users and receiving emails from them), in extreme case you can use your previously created e-mail.

Now let's move on to the code. What we need to replace for 'Sender' class to work:
```
static string password = "/*Your app pasword for gmail account*/";    // Replace with your actual email password.
static string name = "Wanderlust Explorers";    // Display name for the sender's email.
static string fromEmail = "wanderlust***********@gmail.com";   // Replace with your actual email address.
```
Let's start with a simple one:

`"wanderlust***********@gmail.com"` Replace this address with your administration mail address;
`"Wanderlust Explorers"` Replace this with your actual name of your "company".

Where to get `password`:

Go to your google account **settings** -> Type **"App passwords"** in the settings search -> Select app: Other (Custom name) -> And **enter here the name** of the program (for example, I just named it "TravelAgency_temp") -> You will get a **16-digit password** that you need to enter into the `"/*Your app pasword for gmail account*/"`.

**Now you are ready to launch the application!**
