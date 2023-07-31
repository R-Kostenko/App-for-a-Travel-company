using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_temp.Classes;

namespace TravelAgency_temp
{
    // The ProfileForm class represents a form where users can view and update their profile information.
    public partial class ProfileForm : Form
    {
        DataBaseConnection dataBase = DataBaseConnection.GetInstance();
        string Email;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        public ProfileForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void Profile_Load(object sender, EventArgs e)
        {
            // Set password character for password textboxes.
            textBox_FirstPassword.PasswordChar = '\u25CF';
            textBox_SecondPassword.PasswordChar = '\u25CF';

            // Set maximum length for input fields.
            textBox_LastName.MaxLength = 50;
            textBox_FirstName.MaxLength = 50;
            textBox_MiddleName.MaxLength = 50;
            textBox_FirstPassword.MaxLength = 256;
            textBox_SecondPassword.MaxLength = 256;
            textBox_Email.MaxLength = 50;
            textBox_PhoneNumber.MaxLength = 13;

            resetPanelsColors();    // Set initial colors for panels.

            GenderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;  // Set dropdown style for the GenderComboBox.

            // Check if there's a user logged in (id is not "0").
            if (DataStorage.idUser != "0")
            {
                // Retrieve user information from the database.
                string querySelect = $"select user_last_name, user_first_name, user_middle_name, user_gender, user_password, " +
                    $"user_email, user_phone_number from register where id_user = '{DataStorage.idUser}'";

                SqlCommand command = new SqlCommand(querySelect, dataBase.getConnection());

                try
                {
                    dataBase.openConnection();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Populate the input fields with the retrieved user data.
                        textBox_LastName.Text = reader[0].ToString();
                        textBox_FirstName.Text = reader[1].ToString();
                        textBox_MiddleName.Text = reader[2].ToString();
                        GenderComboBox.SelectedItem = reader[3].ToString();
                        textBox_Email.Text = reader[5].ToString();
                        Email = reader[5].ToString();
                        textBox_PhoneNumber.Text = reader[6].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сталася помилка при заповненні даних користувача.\nПомилка: {ex.Message}", "Відписка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally { dataBase.closeConnection(); }
            }
        }


        // Event handler for mouse down on the title bar.
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


        // Event handler for the Close button click.
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }


        // Event handler for the Show Password checkbox state change.
        // This toggles the visibility of the password characters in the password textboxes.
        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordCheckBox.Checked == false)
            {
                textBox_FirstPassword.UseSystemPasswordChar = false;
                textBox_SecondPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBox_FirstPassword.UseSystemPasswordChar = true;
                textBox_SecondPassword.UseSystemPasswordChar = true;
            }
        }


        // Method to check if any validation panels have a red color.
        private bool checkPanels()
        {
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                if (panel.BackColor == Color.Red) return true;
            }
            return false;
        }

        // Method to reset the color of the validation panels.
        private void resetPanelsColors()
        {
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                if (panel.Name != panel1.Name && panel.Name != panel4.Name) panel.BackColor = Color.YellowGreen;
            }
        }

        // Method to clear the input fields.
        private void clearControls()
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }
        }


        // Event handler for the Save button click.
        // This saves the updated profile information to the database.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            string caption = "Збереження даних";

            resetPanelsColors();

            // Validate input fields using different validation classes.
            var checkLN = new CheckName(textBox_LastName.Text, ref panelLastName);
            var checkFN = new CheckName(textBox_FirstName.Text, ref panelFirstName);
            var checkMN = new CheckName(textBox_MiddleName.Text, ref panelMiddleName);
            var checkGender = new CheckGender(GenderComboBox, ref panelGender);
            var checkEmail = new CheckEmail(textBox_Email.Text, ref panelEmail);
            var checkPhone = new CheckPhone(textBox_PhoneNumber.Text, ref panelPhoneNumber);

            // Set the validation order using the "Chain of Responsibility" design pattern.
            checkLN.setNext(checkFN);
            checkFN.setNext(checkMN);
            checkMN.setNext(checkGender);
            checkGender.setNext(checkEmail);
            checkEmail.setNext(checkPhone);

            checkLN.Check();    // Start the validation chain.

            // Check if the password fields are not empty and validate them if they are not.
            if (textBox_FirstPassword.Text != string.Empty && textBox_SecondPassword.Text != string.Empty)
            {
                // Validate passwords input using the "Chain of Responsibility"
                var checkFPassword = new CheckPassword(textBox_FirstPassword.Text, ref panelPassword);
                var checkSPassword = new CheckPassword(textBox_SecondPassword.Text, ref panelConfirmPassword);
                var checkPasswords = new CheckPasswords(textBox_FirstPassword.Text, textBox_SecondPassword.Text, ref panelConfirmPassword);

                checkFPassword.setNext(checkSPassword);
                checkSPassword.setNext(checkPasswords);

                checkFPassword.Check();                
            }

            // If there are any validation errors, return without saving.
            if (checkPanels())
            {
                return;
            }

            // Check if the email was changed, and if so, check if the new email is already in use.
            if (textBox_Email.Text != Email)
            {
                string queryString = $"select user_email from register where user_email = '{textBox_Email.Text}'";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, dataBase.getConnection());
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Inform that this email is aleady in use
                        MessageBox.Show("Цей Email вже використовується", "Помилка", btn, icon);
                        textBox_Email.SelectAll();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сталася помилка при перевірці email на оригінальність.\nПомилка: {ex.Message}", "Відписка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Ask for confirmation before saving changes to the database.
            DialogResult result;
            result = MessageBox.Show("Чи ви хочете змінити цей аккаунт?", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Build and execute the update query based on whether the password is changed or not.
                if (textBox_FirstPassword.Text != string.Empty && textBox_SecondPassword.Text != string.Empty)
                {
                    string queryUpdateAll = string.Empty;

                    string hashPassword = md5.hashPassword(textBox_FirstPassword.Text);

                    queryUpdateAll = $"UPDATE register SET user_last_name = '{textBox_LastName.Text}', " +
                             $"user_first_name = '{textBox_FirstName.Text}', " +
                             $"user_middle_name = '{textBox_MiddleName.Text}', " +
                             $"user_gender = '{GenderComboBox.SelectedItem.ToString()}', " +
                             $"user_password = '{hashPassword}', " +
                             $"user_email = '{textBox_Email.Text}', " +
                             $"user_phone_number = '{textBox_PhoneNumber.Text}' " +
                             $"WHERE id_user = '{DataStorage.idUser}'";

                    dataBase.openConnection();
                    SqlCommand command = new SqlCommand(queryUpdateAll, dataBase.getConnection());

                    try
                    {
                        command.ExecuteNonQuery();
                        dataBase.closeConnection();

                        MessageBox.Show("Аккаунт було оновлено успішно", caption, btn, icon);

                        clearControls();    // Clear the input fields and close the form.
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Сталася помилка під час оновлення даних користувача.\nПомилка: {ex.Message}", "Відписка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally { dataBase.closeConnection(); }
                }
                else
                {
                    string queryUpdateWithoutPassword = string.Empty;

                    queryUpdateWithoutPassword = $"UPDATE register SET user_last_name = '{textBox_LastName.Text}', " +
                             $"user_first_name = '{textBox_FirstName.Text}', " +
                             $"user_middle_name = '{textBox_MiddleName.Text}', " +
                             $"user_gender = '{GenderComboBox.SelectedItem.ToString()}', " +
                             $"user_email = '{textBox_Email.Text}', " +
                             $"user_phone_number = '{textBox_PhoneNumber.Text}' " +
                             $"WHERE id_user = '{DataStorage.idUser}'";

                    dataBase.openConnection();
                    SqlCommand command = new SqlCommand(queryUpdateWithoutPassword, dataBase.getConnection());

                    try
                    {
                        command.ExecuteNonQuery();
                        dataBase.closeConnection();

                        MessageBox.Show("Аккаунт було оновлено успішно", caption, btn, icon);

                        clearControls();    // Clear the input fields and close the form.
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Сталася помилка під час оновлення даних користувача(без паролів).\nПомилка: {ex.Message}", "Відписка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally { dataBase.closeConnection(); }
                }
            }
            else return;
        }
    }
}
