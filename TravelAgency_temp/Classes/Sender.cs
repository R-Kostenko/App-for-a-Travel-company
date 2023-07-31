using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TravelAgency_temp.Classes
{
    // A static class for creating and sending emails via SMTP server.
    public static class Sender
    {
        static DataBaseConnection dataBase = DataBaseConnection.GetInstance();

        // SMTP server settings.
        static string host = "smtp.gmail.com";
        static int smtpPort = 587;
        static string password = "mypdrjjwiaiwrmru";    // Replace with your actual email password.

        static string name = "Wanderlust Explorers";    // Display name for the sender's email.
        static string fromEmail = "wanderlustexplorersservice@gmail.com";   // Replace with your actual email address.
        static string toEmail = "";
        static string subject = "";
        static string body = "";

        // Method to send an email to the administrator.
        public static void EmailToAdmin(string Subject, string Body)
        {
            toEmail = fromEmail;
            Email(Subject, Body);
        }

        // Method to send an email to a specified email address.
        public static void Email(string email, string Subject, string Body)
        {
            toEmail = email;
            Email(Subject, Body);
        }

        // Method to send an email using the provided subject and body.
        public static void Email(string Subject, string Body)
        {
            subject = Subject;
            body = Body;

            try
            {
                // If the recipient email address is not specified, get it from the database using the user ID.
                if (toEmail == "")
                {
                    string selectEmail = $"select user_email from register where id_user = '{DataStorage.idUser}'";

                    SqlDataAdapter adapter = new SqlDataAdapter(selectEmail, dataBase.getConnection());
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        toEmail = row["user_email"].ToString();
                    }
                }

                // Creating a letter
                var from = new MailAddress(fromEmail, name);
                var to = new MailAddress(toEmail);
                var mail = new MailMessage(from, to)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                SmtpClient smtp = new SmtpClient(host, smtpPort)
                {
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true
                };

                // Sending
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                // Display an error message if there's an issue with sending the email.
                MessageBox.Show($"Сталася помилка у відправленні листа.\nПомилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
