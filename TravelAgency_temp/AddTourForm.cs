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
    // The AddTourForm class represents a form that allows users to create a new tour.
    public partial class AddTourForm : Form
    {
        DataBaseConnection dataBase = DataBaseConnection.GetInstance();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        public AddTourForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void AddTourForm_Load(object sender, EventArgs e)
        {
            textBox_Name.Select();
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


        // Event handler for the Save button click.
        // This saves the new tour information to the database.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Information;

            string caption = "Збереження даних";

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
            if (monthCalendar_StartDate.SelectionStart < DateTime.Now.AddDays(5))
            {
                panelStartDate.BackColor = Color.Red;
            }

            if(monthCalendar_EndDate.SelectionStart < monthCalendar_StartDate.SelectionStart)
            {
                panelEndDate.BackColor = Color.Red;
            }

            if (monthCalendar_EndDate.SelectionStart < DateTime.Now.AddDays(10))
            {
                panelEndDate.BackColor = Color.Red;
            }

            // If there are any validation errors, return without saving.
            if (checkPanels())
            {
                return;
            }

            // Check if the tour name is already used.
            string queryString = $"select * from tours where tour_name = '{textBox_Name.Text}'";
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, dataBase.getConnection());
            DataTable dt = new DataTable();

            try
            {
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Ця назва вже використовується. Оберіть іншу.", caption, btn, icon);
                    textBox_Name.SelectAll();
                    panelName.BackColor = Color.Red;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при перевірці назви.\nПомилка: {ex.Message}", "Відписка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Ask for confirmation before saving the new tour to the database.
            DialogResult result;
            result = MessageBox.Show("Чи ви хочете створити цей Тур?", caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Build the SQL query to insert the new tour into the database.
                string queryAdd = string.Empty;
                var StartDate = monthCalendar_StartDate.SelectionStart;
                var EndDate = monthCalendar_EndDate.SelectionStart;

                queryAdd = $"insert into tours (tour_name, tour_description, tour_start_date, tour_end_date, tour_price, tour_max_count_users) " +
                    $"values ('{textBox_Name.Text}', '{textBox_Description.Text}', '{StartDate}', '{EndDate}', '{Convert.ToInt32(textBox_Price.Text)}', '{Convert.ToInt32(textBox_Count.Text)}')";

                // Open the database connection and execute the insert query.
                dataBase.openConnection();
                SqlCommand command = new SqlCommand(queryAdd, dataBase.getConnection());
                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Тур був створений успішно", caption, btn, icon);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Тур не був створений.\nПомилка: {ex.Message}", caption, btn, icon);
                    dataBase.closeConnection();
                    return;
                }
                finally { dataBase.closeConnection(); }

                // Clear the input fields and close the form.
                clearControls();
                dataBase.closeConnection();
                Close();
            }
            else return;
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


        // Event handler for the Clean button click.
        // This clears the input fields and resets the calendar selection.
        private void btnClean_Click(object sender, EventArgs e)
        {
            clearControls();
            monthCalendar_StartDate.TodayDate = DateTime.Now;
            monthCalendar_EndDate.TodayDate = DateTime.Now;
        }
    }
}
