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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TravelAgency_temp
{
    // UnSignTourForm is used to view the details of an ordered tour and allows the user to unsubscribe(cancel) the order.
    public partial class UnSignTourForm : Form
    {
        DataBaseConnection dataBase = DataBaseConnection.GetInstance();

        readonly string ID_Tour;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        public UnSignTourForm(string id_tour)
        {
            InitializeComponent();
            this.ID_Tour = id_tour;
        }


        private void UnSignTourForm_Load(object sender, EventArgs e)
        {
            // Check if the tour ID is null; if so, close the form.
            if (ID_Tour == null) Close();

            // Query to select the tour details from the database based on the tour ID.
            string querySelectTour = $"select tour_name, tour_description, tour_start_date, tour_end_date, tour_price from tours where id_tour = '{ID_Tour}'";

            SqlCommand commandSelectTour = new SqlCommand(querySelectTour, dataBase.getConnection());   // Query to select the tour details from the database based on the tour ID.

            try
            {
                // Open the database connection and read the tour details.
                dataBase.openConnection();
                SqlDataReader reader = commandSelectTour.ExecuteReader();
                while (reader.Read())
                {
                    this.Name = $"Тур: {reader[0].ToString()}";

                    // Populate the form fields with the tour details.
                    textBox_Name.Text = reader[0].ToString();
                    textBox_Description.Text = reader[1].ToString();
                    DateTime startDate = reader.GetDateTime(reader.GetOrdinal("tour_start_date"));
                    textBox_StartDate.Text = startDate.ToString("d MMMM yyyy");
                    DateTime endDate = reader.GetDateTime(reader.GetOrdinal("tour_end_date"));
                    textBox_EndDate.Text = endDate.ToString("d MMMM yyyy");
                    textBox_Price.Text = reader[4].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при отриманні данних про тур.\nПомилка: {ex.Message}", "Відписка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally { dataBase.closeConnection(); } // Close the database connection after reading the tour details.
        }


        // Called when the "Close" button is clicked.
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Called when the panel is clicked and dragged with the mouse.
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

        // Called when the "Save" button is clicked.
        // Initiates the process of unsubscribing the user from the ordered tour.
        // Asks for confirmation from the user and sends an email confirmation.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Ask for confirmation from the user using a message box.
            DialogResult result;
            result = MessageBox.Show("Ви впевнені, що хочете відмовитися від туру?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Retrieve the user's email address from the database.
                string Email = string.Empty;
                string querySelEmail = $"select user_email from register where id_user = '{DataStorage.idUser}'";
                SqlCommand commandSelEmail = new SqlCommand(querySelEmail, dataBase.getConnection());

                try
                {
                    dataBase.openConnection();
                    SqlDataReader reader = commandSelEmail.ExecuteReader();
                    if (reader.Read())
                    {
                        Email = reader.GetString(0);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сталася помилка під час запиту email.\nПомилка: {ex.Message}", "Відписка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataBase.closeConnection();
                    return;
                }
                finally { dataBase.closeConnection(); }

                // Display a confirmation form to the user to re-confirm the unsubscription via email.
                ConfirmationForm confirmation = new ConfirmationForm(Email, "Підтвердіть вашу відписку.");
                confirmation.ShowDialog();

                // If the user confirmed the unsubscription, proceed with the process.
                if (!confirmation.Confirmed)
                {
                    return;
                }

                // Construct and execute the SQL query to delete the user's order for the tour from the database.
                string queryDelete = $"delete from orders where id_user = '{DataStorage.idUser}' and id_tour = '{ID_Tour}'";
                SqlCommand commandDelete = new SqlCommand(queryDelete, dataBase.getConnection());

                try
                {
                    dataBase.openConnection();
                    commandDelete.ExecuteNonQuery();

                    // Show a success message to the user after unsubscribing.
                    MessageBox.Show("Ви були успішно відписані від туру", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Send an email to the user confirming the unsubscription.
                    Sender.Email("Відписка від туру.", $"Вітаємо, вас було відписано від туру \"{textBox_Name.Text}\".");
                    dataBase.closeConnection();
                    Close();    // Close the form after successful unsubscription.
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Виникла помилка при видаленні вашого замовлення.\nПомилка: {ex.Message}", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    dataBase.closeConnection();
                }
            }
        }
    }
}
