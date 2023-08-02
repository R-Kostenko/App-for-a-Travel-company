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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TravelAgency_temp
{
    // The RegistrationForm class represents a form for user registration.
    public partial class RegistrationForm : Form
    {
        DataBaseConnection dataBase = DataBaseConnection.GetInstance();

        // Constants and DLL imports for moving the form by clicking and dragging the title bar.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        // Constructor of RegistrationForm.
        public RegistrationForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
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


        // Event handler for the Close button click.
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }


        // Event handler for the RegistrationForm_Load event.
        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            // Set password characters for password textboxes.
            textBox_FirstPassword.PasswordChar = '\u25CF';
            textBox_SecondPassword.PasswordChar = '\u25CF';

            // Set maximum length for various input fields.
            textBox_LastName.MaxLength = 50;
            textBox_FirstName.MaxLength = 50;
            textBox_MiddleName.MaxLength = 50;
            textBox_FirstPassword.MaxLength = 256;
            textBox_SecondPassword.MaxLength = 256;
            textBox_Email.MaxLength = 50;
            textBox_PhoneNumber.MaxLength = 13;    // Change this number if your phone number is longer then 13 characters

            resetPanelsColors();    // Set default colors for input panels.

            GenderComboBox.DropDownStyle = ComboBoxStyle.DropDownList;  // Set the gender combobox to dropdown list style.

            textBox_LastName.Select();  // Set focus on the last name textbox when the form is loaded.
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


        // Event handler for the Save button click.
        // This performs validation checks and saves the user registration data if valid.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            string caption = "Збереження даних";

            resetPanelsColors();    // Reset the input panels' colors to the default.

            // Create instances of the validation classes for each input field.
            var checkLN = new CheckName(textBox_LastName.Text, ref panelLastName);
            var checkFN = new CheckName(textBox_FirstName.Text, ref panelFirstName);
            var checkMN = new CheckName(textBox_MiddleName.Text, ref panelMiddleName);
            var checkGender = new CheckGender(GenderComboBox, ref panelGender);
            var checkFPassword = new CheckPassword(textBox_FirstPassword.Text, ref panelPassword);
            var checkSPassword = new CheckPassword(textBox_SecondPassword.Text, ref panelConfirmPassword);
            var checkPasswords = new CheckPasswords(textBox_FirstPassword.Text, textBox_SecondPassword.Text, ref panelConfirmPassword);
            var checkEmail = new CheckEmail(textBox_Email.Text, ref panelEmail);
            var checkPhone = new CheckPhone(textBox_PhoneNumber.Text, ref panelPhoneNumber);

            // Set the validation order using the "Chain of Responsibility" design pattern.
            checkLN.setNext(checkFN);
            checkFN.setNext(checkMN);
            checkMN.setNext(checkGender);
            checkGender.setNext(checkFPassword);
            checkFPassword.setNext(checkSPassword);
            checkSPassword.setNext(checkPasswords);
            checkPasswords.setNext(checkEmail);
            checkEmail.setNext(checkPhone);

            checkLN.Check();    // Start the validation chain.

            if (checkPanels())  // Check if any input panels have a red background (indicating validation error).
            {
                return;
            }

            // Check if the entered email is already in use.
            string queryString = $"select user_email from register where user_email = '{textBox_Email.Text}'";

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, dataBase.getConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Цей Email вже використовується", "Помилка", btn, icon);
                    textBox_Email.SelectAll();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при перевірці чи вільний Email .\nПомилка: {ex.Message}", "Оновлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Display a confirmation form to confirm the email address.
            ConfirmationForm confirmation = new ConfirmationForm(textBox_Email.Text, "Підтвердіть ваш email.");
            confirmation.ShowDialog();

            if (!confirmation.Confirmed)
            {
                return;
            }

            // Ask for user confirmation to create the account.
            DialogResult result;
            result = MessageBox.Show("Чи ви хочете створити цей аккаунт?", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string queryAdd = string.Empty;

                string hashPassword = md5.hashPassword(textBox_FirstPassword.Text); // Hash the user's password using the MD5 algorithm.

                // Build the query to insert the user data into the database.
                queryAdd = $"insert into register (user_last_name, user_first_name, user_middle_name, user_gender, user_password, user_email, user_phone_number) " +
                    $"values ('{textBox_LastName.Text}', '{textBox_FirstName.Text}', '{textBox_MiddleName.Text}', '{GenderComboBox.SelectedItem.ToString()}'," +
                    $" '{hashPassword}', '{textBox_Email.Text}', '{textBox_PhoneNumber.Text}')";

                // Open a database connection and execute the query.
                dataBase.openConnection();

                try
                {
                    SqlCommand command = new SqlCommand(queryAdd, dataBase.getConnection());
                    command.ExecuteNonQuery();

                    MessageBox.Show("Аккаунт був створений успішно", caption, btn, icon);   // Show a success message.

                    // Clear the input controls and close the form.
                    clearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Виникла помилка при створенні аккаунту.\nПомилка: {ex.Message}", "Оновлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally { dataBase.closeConnection(); }

                Close();
            }
            else return;
        }


        // Method to check if any input panels have a red background (indicating validation error).
        private bool checkPanels()
        {
            foreach(Panel panel in Controls.OfType<Panel>())
            {
                if (panel.BackColor == Color.Red) return true;
            }
            return false;
        }


        // Reset the input panels' colors to the default.
        private void resetPanelsColors()
        {
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                if (panel.Name != panel1.Name && panel.Name != panel4.Name) panel.BackColor = Color.YellowGreen;
            }
        }


        // Clear the input controls.
        private void clearControls()
        {
            foreach(TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }
        }


        // Event handler for the Clear button click.
        // This clears the input controls and resets the input panels' colors.
        private void ClearButton_Click(object sender, EventArgs e)
        {
            clearControls();
            resetPanelsColors();
        }
    }
}
