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
    // The SelectedTour class represents a form that displays the details of a selected tour.
    // The functionality of this form varies depending on the role of the user (administrator or regular user).
    public partial class SelectedTour : Form
    {
        DataBaseConnection dataBase = DataBaseConnection.GetInstance();

        readonly string ID_Tour;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        // Constructor of the SelectedTour form.
        // This form recieves ID of selected tour
        public SelectedTour(string id_tour)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.ID_Tour = id_tour;
        }


        // Event handler for the Close button click.
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
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


        // Event handler for the SelectedTour_Load event.
        private void SelectedTour_Load(object sender, EventArgs e)
        {
            checkUser();    // Check if the user is an admin or regular user and adjust the form accordingly.

            // Load the tour details from the database based on the provided tour ID.
            if (ID_Tour == null) Close();
            string querySelectTour = $"select tour_name, tour_description, tour_start_date, tour_end_date, tour_price, tour_max_count_users from tours where id_tour = '{ID_Tour}'";
            
            SqlCommand commandSelectTour = new SqlCommand(querySelectTour, dataBase.getConnection());
            dataBase.openConnection();

            try
            {
                SqlDataReader reader = commandSelectTour.ExecuteReader();
                while (reader.Read())
                {
                    this.Name = $"Тур: {reader[0].ToString()}";
                    textBox_Name.Text = reader[0].ToString();
                    textBox_Description.Text = reader[1].ToString();
                    DateTime startDate = reader.GetDateTime(reader.GetOrdinal("tour_start_date"));
                    textBox_StartDate.Text = startDate.ToString("d MMMM yyyy");
                    DateTime endDate = reader.GetDateTime(reader.GetOrdinal("tour_end_date"));
                    textBox_EndDate.Text = endDate.ToString("d MMMM yyyy");
                    textBox_Price.Text = reader[4].ToString();
                    textBox_Count.Text = reader[5].ToString();
                }
                reader.Close();
                dataBase.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при заповненні полів туру.\nПомилка: {ex.Message}", "Зміна даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally { dataBase.closeConnection(); }
        }


        // Method to check if the current user is an admin or a regular user.
        private void checkUser()
        {

            if (DataStorage.isAdmin)
            {
                // If the user is an admin, enable editing of tour details.
                textBox_Name.ReadOnly = false;
                textBox_Description.ReadOnly = false;
                textBox_StartDate.ReadOnly = false;
                textBox_EndDate.ReadOnly = false;
                textBox_Price.ReadOnly = false;

                OrderButton.Visible = false;
                DeleteButton.Visible = true;
                SaveButton.Visible = true;
                btnClean.Visible = true;
                labelCount.Visible = true;
                textBox_Count.Visible = true;

                panelName.Visible = true;
                panelDescription.Visible = true;
                panelStartDate.Visible = true;
                panelEndDate.Visible = true;
                panelPrice.Visible = true;
                panelCount.Visible = true;
            }
            else
            {
                // If the user is a regular user, disable editing of tour details.
                textBox_Name.ReadOnly = true;
                textBox_Description.ReadOnly = true;
                textBox_StartDate.ReadOnly = true;
                textBox_EndDate.ReadOnly = true;
                textBox_Price.ReadOnly = true;

                OrderButton.Visible = true;
                DeleteButton.Visible = false;
                SaveButton.Visible = false;
                btnClean.Visible = false;

                panelName.Visible = false;
                panelDescription.Visible = false;
                panelStartDate.Visible = false;
                panelEndDate.Visible = false;
                panelEndDate.Visible = false;
            }
        }


        // Event handler for the Delete button click.
        // This deletes the selected tour from the database.
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before deleting the tour.
            DialogResult result;
            result = MessageBox.Show("Ви впевнені, що хочете видалити цей тур?", "Зміна даних", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string queryDelete = $"delete from tours where id_tour = '{ID_Tour}'";
                SqlCommand commandDelete = new SqlCommand(queryDelete, dataBase.getConnection());
                dataBase.openConnection();

                try
                {
                    commandDelete.ExecuteNonQuery();
                    MessageBox.Show("Видалення пройшло успішно.", "Зміна даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataBase.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Видалення не виконане.\nПомилка: {ex.Message}", "Зміна даних", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    return;
                }
                finally { dataBase.closeConnection(); }

                Close();
            }
        }


        // Event handler for the Save button click.
        // This saves the changes made to the tour details in the database.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            resetPanelsColors();    // Reset panel colors for validation feedback.

            // Validate input fields using different validation classes.
            var checkTourName = new CheckTourNameOrSubject(textBox_Name.Text, ref panelName);
            var checkDescription = new CheckDescriptionOrBody(textBox_Description.Text, ref panelDescription);
            var checkCount = new CheckCountOrPrice(textBox_Count.Text, ref panelCount);
            var checkPrice = new CheckCountOrPrice(textBox_Price.Text, ref panelPrice);

            // Set the validation order using the "Chain of Responsibility" design pattern.
            checkTourName.setNext(checkDescription);
            checkDescription.setNext(checkCount);
            checkCount.setNext(checkPrice);

            checkTourName.Check();  // Start the validation chain.

            // Check for specific conditions related to date selection.
            if (Convert.ToDateTime(textBox_StartDate.Text) < DateTime.Now.AddDays(5))
            {
                panelStartDate.BackColor = Color.Red;
            }

            if(Convert.ToDateTime(textBox_EndDate.Text) < Convert.ToDateTime(textBox_StartDate.Text))
            {
                panelEndDate.BackColor = Color.Red;
            }

            if (Convert.ToDateTime(textBox_EndDate.Text) < DateTime.Now.AddDays(10))
            {
                panelEndDate.BackColor = Color.Red;
            }

            // If there are any validation errors, return without saving.
            if (checkPanels())
            {
                return;
            }

            // Ask for confirmation before saving the changes to the database.
            DialogResult result;
            result = MessageBox.Show("Ви впевнені, що хочете змінити запис?", "Зміна даних", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DateTime startDate = Convert.ToDateTime(textBox_StartDate.Text);
                DateTime endDate = Convert.ToDateTime(textBox_EndDate.Text);

                string queryChange = $"update tours set tour_name = '{textBox_Name.Text}', tour_description = '{textBox_Description.Text}', " +
                    $"tour_start_date = '{startDate}', tour_end_date = '{endDate}', tour_price = '{Convert.ToInt32(textBox_Price.Text)}', " +
                    $"tour_max_count_users = '{Convert.ToInt32(textBox_Count.Text)}' " +
                    $"where id_tour = '{ID_Tour}'";
                SqlCommand commandChange = new SqlCommand(queryChange, dataBase.getConnection());
                dataBase.openConnection();
                try
                {
                    commandChange.ExecuteNonQuery();
                    MessageBox.Show("Зміна пройшла успішно.", "Зміна даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Зміна невдала.\nПомилка: {ex.Message}", "Зміна даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataBase.closeConnection();
                    return;
                }
                finally { dataBase.closeConnection(); }

                Close();
            }
        }

        // Method to check if there are any panels with a red background color (validation error).
        private bool checkPanels()
        {
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                if (panel.BackColor == Color.Red) return true;
            }
            return false;
        }

        // Method to reset the background color of all panels except the title bar and Close button.
        private void resetPanelsColors()
        {
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                if (panel.Name != panel1.Name && panel.Name != panel4.Name) panel.BackColor = Color.YellowGreen;
            }
        }


        // Event handler for the Order button click.
        // This allows a regular user to order the selected tour.
        private void OrderButton_Click(object sender, EventArgs e)
        {
            // If the user is not logged in, prompt them to log in first.
            if (DataStorage.idUser == "0")
            {
                DialogResult result;
                result = MessageBox.Show("Авторизуйтеся для продовження будь ласка.", "Авторизація", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result == DialogResult.Yes)
                {
                    LoginForm loginForm = new LoginForm();
                    loginForm.ShowDialog();
                    checkUser();
                    if (!DataStorage.isAdmin)
                    {
                        OrderTour();
                    }
                }
            }
            else OrderTour();
        }

        // Method to order the tour for a regular user.
        private void OrderTour()
        {
            // Check if the user is already signed up for the selected tour.
            string queryСheck1 = $"select * from orders where id_user = '{DataStorage.idUser}' and id_tour = '{ID_Tour}'";
            
            SqlDataAdapter adapter = new SqlDataAdapter(queryСheck1, dataBase.getConnection());
            DataTable dt = new DataTable();

            try
            {
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Ви вже записані до туру", "Замовлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при перевірці чи записаний користувач до туру.\nПомилка: {ex.Message}", "Зміна даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Check if the selected tour is already full (reached the maximum number of participants).
            string queryCheck3 = $"select * from orders where id_tour = '{ID_Tour}'";
            int usersSignedTour = 0;


            SqlDataAdapter adapter1 = new SqlDataAdapter(queryCheck3 , dataBase.getConnection());
            DataTable dt2 = new DataTable();

            try
            {
                adapter1.Fill(dt2);
                usersSignedTour = dt2.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при отриманні кількості записаних до туру користувачів.\nПомилка: {ex.Message}", "Зміна даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            string queryCheck4 = $"select tour_max_count_users from tours where id_tour = '{ID_Tour}'";

            SqlCommand commandCheck4 = new SqlCommand(queryCheck4, dataBase.getConnection());
            try
            {
                dataBase.openConnection();
                int maxUsersCount = 0;
                SqlDataReader reader = commandCheck4.ExecuteReader();
                if (reader.Read())
                {
                    maxUsersCount = reader.GetInt32(0);
                }
                reader.Close();
                
                if (maxUsersCount == 0)
                {
                    throw new Exception("Виникла помилка при отриманні максимально можливої кількості користувачів для туру, або в турі записане неприпустиме значення 0");
                }

                if(usersSignedTour >= maxUsersCount)
                {
                    MessageBox.Show($"Нажаль для вас немає місця", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                dataBase.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при перевірці туру на переповнення.\nПомилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            finally { dataBase.closeConnection(); }

            // Check if the user has booked any other tours during the same time period.
            string queryСheck2 = $"select id_tour from orders where id_user = '{DataStorage.idUser}'";

            SqlCommand commandCheck2 = new SqlCommand(queryСheck2, dataBase.getConnection());
            dataBase.openConnection();

            try
            {
                SqlDataAdapter adapter2 = new SqlDataAdapter(commandCheck2);
                DataTable ordersTable = new DataTable();
                adapter2.Fill(ordersTable);

                DateTime thisTourStart = Convert.ToDateTime(textBox_StartDate.Text);
                DateTime thisTourEnd = Convert.ToDateTime(textBox_EndDate.Text);

                foreach (DataRow row in ordersTable.Rows)
                {
                    string tourId = row["id_tour"].ToString();

                    if (tourId != ID_Tour)
                    {
                        DateTime? checkTourStart = null;
                        DateTime? checkTourEnd = null;

                        try
                        {
                            string queryGetDates = $"select tour_start_date, tour_end_date from tours where id_tour = '{tourId}'";

                            SqlCommand commandGetDates = new SqlCommand(queryGetDates, dataBase.getConnection());
                            SqlDataReader getReader = commandGetDates.ExecuteReader();
                            while (getReader.Read())
                            {
                                checkTourStart = Convert.ToDateTime(getReader[0]);
                                checkTourEnd = Convert.ToDateTime(getReader[1]);
                            }
                            getReader.Close();
                        }
                        catch (Exception ex)
                        {
                            string exceptionMessage = "Помилка при запиті дат туру. " + ex.Message;
                            throw new Exception(exceptionMessage);
                        }
                        finally
                        {
                            dataBase.closeConnection();
                        }

                        // Check for date overlaps with other booked tours.
                        if (checkTourStart != null && checkTourEnd != null)
                        {
                            if ((thisTourStart <= checkTourEnd && thisTourEnd >= checkTourStart) || (checkTourStart <= thisTourEnd && checkTourEnd >= thisTourStart))
                            {
                                MessageBox.Show("Цей тур пересікається з раніше замовленим вами туром.", "Замовлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка підчас перевірки дат турів\nПомилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataBase.closeConnection();
                return;
            }
            finally { dataBase.closeConnection(); }


            // Ask for confirmation before ordering the tour.
            DialogResult result;
            result = MessageBox.Show("Впевнені, що хочете замовити цей тур?", "Замовлення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                // Get the user's email for sending a confirmation email.
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
                    MessageBox.Show($"Сталася помилка під час запиту email.\nПомилка: {ex.Message}", "Замовлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataBase.closeConnection();
                    return;
                }
                finally { dataBase.closeConnection(); }

                // Show a confirmation form to the user to validate the email address.
                ConfirmationForm confirmation = new ConfirmationForm(Email, "Підтвердіть ваше замовлення.");
                confirmation.ShowDialog();

                // If the user didn't confirm the email, cancel the order.
                if (!confirmation.Confirmed)
                {
                    return;
                }

                // Insert the order into the database.
                string queryOrder = $"insert into orders (id_user, id_tour, order_date) values ('{DataStorage.idUser}', '{ID_Tour}', '{DateTime.Now}')";

                SqlCommand commandOrder = new SqlCommand(queryOrder, dataBase.getConnection());
                dataBase.openConnection();

                try
                {
                    commandOrder.ExecuteNonQuery();
                    MessageBox.Show("Вас записано до туру.\nВам відправлено листа на пошту", "Замовлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sender.Email("Реєстрація в турі.", $"Вітаємо, вас записано до туру \"{textBox_Name.Text}\". \nСподіваємося він вам сподобається, приємної подорожі!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Сталася помилка\nПомилка: {ex.Message}", "Замовлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataBase.closeConnection();
                    return;
                }
                finally { dataBase.closeConnection(); }

                Close();
            }
        }

        // Event handler for the Clean button click.
        // This clears the description text box.
        private void btnClean_Click(object sender, EventArgs e)
        {
            textBox_Description.Clear();
        }
    }
}
