using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_temp.Classes;

namespace TravelAgency_temp
{
    // The LoginForm class represents a form for user authentication (login).
    public partial class LoginForm : Form
    {
        DataBaseConnection dataBase = DataBaseConnection.GetInstance();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        // Event handler for the LoginForm_Load event.
        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBox_Password.PasswordChar = '\u25CF';
            textBox_Email.MaxLength = 50;
            textBox_Password.MaxLength = 256;
            textBox_Email.Select();
        }


        // Event handler for the Close button click.
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        // Event handler for the Login button click.
        // This performs the authentication process when the user clicks the Login button.
        private void button_Login_Click(object sender, EventArgs e)
        {
            // Check if both email and password fields are not empty.
            if (!string.IsNullOrEmpty(textBox_Email.Text) && !string.IsNullOrEmpty(textBox_Password.Text))
            {
                string hashPassword = md5.hashPassword(textBox_Password.Text);  // Hash the entered password using the MD5 algorithm.

                // Build the query to check if the user exists in the database with the provided email and password.
                var querySelectUser = $"select * from register where user_email = '{textBox_Email.Text}' and user_password = '{hashPassword}'";                
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();

                try
                {
                    SqlCommand command = new SqlCommand(querySelectUser, dataBase.getConnection());
                    adapter.SelectCommand = command;

                    adapter.Fill(table);    // Execute the query and fill the results in the DataTable.

                    // If the user is found, login and store the user data.
                    if (table.Rows.Count > 0)
                    {
                        // Build the query to get the user ID and admin status.
                        var queryGetId = $"select id_user, is_admin from register where user_email = '{textBox_Email.Text}'";
                        SqlCommand commandGetId = new SqlCommand(queryGetId, dataBase.getConnection());

                        try
                        {
                            dataBase.openConnection();
                            SqlDataReader reader = commandGetId.ExecuteReader();
                            while (reader.Read())
                            {
                                DataStorage.idUser = reader[0].ToString();
                                DataStorage.isAdmin = Convert.ToBoolean(reader[1]);
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            // Here program creates a new exception and throw it to the external catcher
                            string exceptionMessage = "Виникла помилка при отриманні данних користувача для занесення в DataStorage. " + ex.Message;
                            throw new Exception(exceptionMessage);
                        }
                        finally { dataBase.closeConnection(); }

                        // Clear the email and password fields and reset the "Show Password" checkbox.
                        textBox_Email.Clear();
                        textBox_Password.Clear();
                        checkBox_ShowPassword.Checked = false;

                        this.Close();   // Close the login form.
                    }
                    else
                    {
                        // If the user is not found, show an error message.
                        MessageBox.Show("Email або пароль неправильні. Спробуйте ще раз.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        textBox_Email.Focus();
                        textBox_Email.SelectAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Виникла помилка в процесі авторизації.\nПомилка: {ex.Message}", "Оновлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally { dataBase.closeConnection(); }
            }
            else
            {
                // If email or password is empty, show a message.
                MessageBox.Show("Будь ласка, введіть e-mail та пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_Email.Select();
            }
        }


        // Event handler for the Show Password checkbox state change.
        private void checkBox_ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_ShowPassword.Checked == false)
            {
                textBox_Password.UseSystemPasswordChar = false;
            }
            else textBox_Password.UseSystemPasswordChar= true;
        }


        // Event handler for the "Registration" link clicked.
        // This opens the RegistrationForm to allow users to register.
        private void linkLabel_Registration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            this.Hide();
            registrationForm.ShowDialog();
            this.Show();
            textBox_Email.Select();
        }
    }
}
