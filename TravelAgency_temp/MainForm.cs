using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_temp.Classes;
using static TravelAgency_temp.MainForm.TourPanel;

namespace TravelAgency_temp
{
    // The MainForm class represents the main window of the application.
    public partial class MainForm : Form
    {
        DataBaseConnection dataBase = DataBaseConnection.GetInstance();

        // Constants and DLL imports for moving the form by clicking and dragging the title bar.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        // Constructor of MainForm.
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        // Event handler for the MainForm_Load event.
        // This event is triggered when the main form is loaded.
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Update the user account information and refresh the list of tours.
            updateAccInfo();
            refreshTours();

            // Create columns for the data grid view and refresh the data.
            createColumns();
            refreshDataGrid(dataGridView_Accounts);
        }


        // Event handler for mouse down on the title bar (panel1).
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Move the form by clicking and dragging the title bar.
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        // Event handler for mouse down on the title bar (label1).
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        // Event handler for clicking the Login button
        private void button_Login_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog(); //Open Login form
            updateAccInfo();    //update account information after user`s login
        }


        // Event handler for clicking the Registration link label
        private void linkLabel_Registration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();  //Open Registration form
            updateAccInfo();
        }


        // Event handler for clicking the "Contact with administration" link label
        private void linkLabel_Contact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.ShowDialog();   //Open Contact form
        }
        
        
        private void button_Contact_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            contactForm.ShowDialog();
        }


        // Method to update user account information and UI elements based on the user's login status.
        private void updateAccInfo()
        {
            if (DataStorage.idUser != "0")  // If user loged in
            {
                if (DataStorage.isAdmin)    // If user is admin
                {
                    button_Add.Visible = true;  // Button for tour creation
                    if (!tabControl1.Contains(tabPage3)) tabControl1.TabPages.Add(tabPage3);    // Page for user administration
                                                                                                // tabPage3 was created during loading of MainForm
                }

                toolStrip_Profile.Visible = true;   
                linkLabel_Registration.Visible = false;
                button_Login.Visible = false;

                // Selecting a name of user to show it in Profile tool strip
                string queryGetName = $"select user_first_name from register where id_user = '{DataStorage.idUser}'";
                SqlCommand command = new SqlCommand(queryGetName, dataBase.getConnection());
                try
                {
                    dataBase.openConnection();      // We have to open connection to the DB before executing SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())      // If the reader has records
                    {
                        toolStripLabel_Profile.Text = GetShortenedText(reader[0].ToString(), 10);   // Pass the first column of the record of reader
                    }
                    reader.Close();         // Close reader after executing
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Виникла помилка при отриманні ім'я користувача.\nПомилка: {ex.Message}", "Оновлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally { dataBase.closeConnection(); }    // Always close connection with DB after operations
            }
            else
            {
                if (tabControl1.Contains(tabPage3)) tabControl1.TabPages.Remove(tabPage3);  // Remove page for user administration from tabControl
                toolStrip_Profile.Visible = false;
                linkLabel_Registration.Visible = true;
                button_Login.Visible = true;
                button_Add.Visible = false;
            }

        }
        private string GetShortenedText(string text, int maxLength)     // Method to made text shorter
        {
            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength-3) + "...";
            }
            return text;
        }


        // Method to refresh the list of tours displayed in TourPanels.
        private void refreshTours()
        {
            container_Tours.Controls.Clear();

            string querySelect = $"select id_tour, tour_name, tour_description, tour_start_date, tour_end_date, tour_price from tours";
            SqlDataAdapter adapter = new SqlDataAdapter(querySelect, dataBase.getConnection());
            DataTable table = new DataTable();

            try
            {                
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    // If the tour start date is before the current date and the tour end date is after the current date - do not show this tour
                    if ((row.Field<DateTime>("tour_start_date") <= DateTime.Now) && (row.Field<DateTime>("tour_end_date") >= DateTime.Now)) 
                    {
                        continue;
                    }

                    // If the tour end date is before the current date - delete this tour
                    if (row.Field<DateTime>("tour_end_date") <= DateTime.Now)
                    {
                        string queryDelete = $"delete from tours where id_tour = '{row.ItemArray[0]}'";
                        SqlCommand commandDelete = new SqlCommand(queryDelete, dataBase.getConnection());
                        dataBase.openConnection();

                        try
                        {                            
                            commandDelete.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Видалення не виконане.\nПомилка: {ex.Message}", "Зміна даних", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataBase.closeConnection();
                        }
                        finally { dataBase.closeConnection(); }

                        continue;
                    }

                    // Creating the TourPanel using recieved from DB data
                    TourPanel tourPanel = new TourPanel(row.ItemArray[0].ToString(), row.ItemArray[1].ToString(), row.ItemArray[2].ToString(),
                        row.Field<DateTime>("tour_start_date"), row.Field<DateTime>("tour_end_date"), row.ItemArray[5].ToString());

                    // Adding here a method TourPanel_TourClicked to the event handler TourClicked for panel                
                    tourPanel.TourClicked += TourPanel_TourClicked;
                    // In result of clicking on panel or label of panel function TourPanel_TourClicked will be called

                    container_Tours.Controls.Add(tourPanel);    // Adding our tourPanel to FlowLayoutPanel(container_Tours)
                }
            }
            catch (Exception ex)
            {
                // Show a message if an exception is thrown
                MessageBox.Show($"Виникла помилка при виведенні турів.\nПомилка: {ex.Message}", "Оновлення", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            finally
            {
                // I use it to be sure that connection will be closed in any case
                dataBase.closeConnection();
            }
        }

        // Method to create columns for the data grid view.
        private void createColumns()
        {
            dataGridView_Accounts.Columns.Add("id_user", "ID");
            dataGridView_Accounts.Columns.Add("user_last_name", "Фамілія");
            dataGridView_Accounts.Columns.Add("user_first_name", "Ім'я");
            dataGridView_Accounts.Columns.Add("user_middle_name", "По батькові");
            dataGridView_Accounts.Columns.Add("user_gender", "Стать");
            dataGridView_Accounts.Columns.Add("user_email", "Email");
            dataGridView_Accounts.Columns.Add("user_phone_number", "Номер телефону");
            var checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "IsAdmin";
            checkColumn.HeaderText = "Адмін";
            dataGridView_Accounts.Columns.Add(checkColumn);
        }


        // Method to refresh the data grid view with user information.
        private void refreshDataGrid(DataGridView dgw)
        {
            try
            {
                dgw.Rows.Clear();

                string querySelAcc = $"select id_user, user_last_name, user_first_name, user_middle_name, user_gender, user_email, " +
                    $"user_phone_number, is_admin from register";
                SqlCommand command = new SqlCommand(querySelAcc, dataBase.getConnection());

                dataBase.openConnection();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ReadSingleRows(dgw, reader);
                }
                reader.Close();
                dataBase.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при оновленні списку користувачів.\nПомилка: {ex.Message}", "Користувачі", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally { dataBase.closeConnection(); }
        }

        private void ReadSingleRows(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), 
                record.GetString(5), record.GetString(6), record.GetBoolean(7));
        }
        
        
        // Event handler for saving users` idmin status
        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.openConnection();

                for (int index = 0; index < dataGridView_Accounts.Rows.Count; index++)
                {
                    var id = dataGridView_Accounts.Rows[index].Cells[0].Value.ToString();
                    var isadmin = dataGridView_Accounts.Rows[index].Cells[7].Value.ToString();

                    string queryString = $"update register set is_admin = '{isadmin}' where id_user = '{id}'";

                    SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                dataBase.closeConnection();

                refreshDataGrid(dataGridView_Accounts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при зміні статусів користувачів.\nПомилка: {ex.Message}", "Користувачі",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally { dataBase.closeConnection(); }
        }


        // Event handler for saving admin status of users
        private void button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.openConnection();

                var currentRow = dataGridView_Accounts.CurrentCell.RowIndex;

                int id = Convert.ToInt32(dataGridView_Accounts.Rows[currentRow].Cells[0].Value);

                string queryString = $"delete from register where id_user = {id}";

                SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
                command.ExecuteNonQuery();

                dataBase.closeConnection();

                refreshDataGrid(dataGridView_Accounts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при видаленні користувачів.\nПомилка: {ex.Message}", "Користувачі",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally { dataBase.closeConnection(); }
        }


        // Event handler for clicking on "Log out" item of tool strip menu
        private void вийтиЗАккаунтуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataStorage.idUser = "0";
            DataStorage.isAdmin = false;
            updateAccInfo();
        }

        // Event handler for clicking on "Show ordered tours" item of tool strip menu
        private void вжеЗамовленіТуриToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignedOnTour signedOnTour = new SignedOnTour();
            signedOnTour.ShowDialog();      // Open SignedOnTour Form
        }

        // Event handler for clicking on "Profile" item of tool strip menu
        private void профільToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm();
            profileForm.ShowDialog();       // Open Profile form
            updateAccInfo();            // Update user status
        }


        // Class TourPanel represents a custom user control for displaying tour information.
        public class TourPanel : UserControl
        {
            // Event handler delegate and event for when a tour is clicked.
            public event EventHandler<IDSenderEventArgs> TourClicked;

            string ID_Tour;

            // Class IDSenderEventArgs represents custom event arguments containing the ID_Tour.
            public class IDSenderEventArgs : EventArgs
            {
                public string ID_Tour { get; set; }
                public IDSenderEventArgs(string iD_Tour)
                {
                    ID_Tour = iD_Tour;
                }
            }

            // Constructor for TourPanel.
            public TourPanel(string id_tour, string name,string description, DateTime startDate, DateTime endDate, string price)
            {
                this.ID_Tour = id_tour;

                // Style of Panel
                BackColor = SystemColors.Control;
                Size = new Size(670, 100);
                Padding = new Padding(10);
                BorderStyle = BorderStyle.None;
                BorderRadius = 10;
                BorderColor = Color.Gray;

                // Creating of Name label and it's style
                Label nameLabel = new Label
                {
                    Location = new Point(10, 20),
                    AutoSize = false,
                    Size = new Size(150, 50),
                    Text = name,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.TopLeft,
                    AutoEllipsis = true,      // Add "..." if lenth of text is too long
                    UseCompatibleTextRendering = true,
                    UseMnemonic = false
                };
                this.Controls.Add(nameLabel);       // Add this label to this panel

                // Creating of Description label and it's style
                Label descLabel = new Label
                {
                    Location = new Point(170, 25),
                    AutoSize = false,
                    Size = new Size(390, 50),
                    Text = description,
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Black,
                    TextAlign = ContentAlignment.TopLeft,
                    AutoEllipsis = true,
                    UseCompatibleTextRendering = true,
                    UseMnemonic = false
                };
                this.Controls.Add(descLabel);

                // Creating of Dates label and it's style
                Label datesLabel = new Label
                {
                    Location = new Point(200, 70),
                    Text = $"З {startDate.ToString("d MMMM yyyy")} по {endDate.ToString("d MMMM yyyy")}",    // Dates will look like "3 may 2022"
                    Font = new Font("Segoe UI", 12),
                    AutoSize = true
                };
                this.Controls.Add(datesLabel);

                // Creating of Price label and it's style
                Label priceLabel = new Label
                {
                    Location = new Point(560, 40),
                    AutoSize = false,
                    Size = new Size(100, 30),
                    Text = price + " грн.",
                    Font = new Font("Segoe UI", 13, FontStyle.Bold),
                    TextAlign = ContentAlignment.TopLeft,
                    AutoEllipsis = true,
                    UseCompatibleTextRendering = true,
                    UseMnemonic = false
                };
                this.Controls.Add(priceLabel);

                // When you click on this panel or on the title label, the TourPanel_Click method will be called
                this.Click += TourPanel_Click;
                nameLabel.Click += TourPanel_Click;
            }

            // Event handler for the TourPanel_Click event.
            // This event is triggered when the tour panel or its name label is clicked.
            private void TourPanel_Click(object sender, EventArgs e)
            {
                // Invoke the TourClicked event passing the ID_Tour as event arguments.
                var args = new IDSenderEventArgs(ID_Tour);
                TourClicked?.Invoke(this, args);
            }

            // Method for drawing panel borders
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                using (var borderPen = new Pen(BorderColor))
                {
                    var rect = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width - 1, ClientRectangle.Height - 1);
                    var path = GetRoundRectPath(rect, BorderRadius);
                    e.Graphics.DrawPath(borderPen, path);
                }
            }

            private GraphicsPath GetRoundRectPath(Rectangle rect, int borderRadius)
            {
                int diameter = borderRadius * 2;
                Size size = new Size(diameter, diameter);
                Rectangle arcRect = new Rectangle(rect.Location, size);
                GraphicsPath path = new GraphicsPath();

                // Top left corner
                path.AddArc(arcRect, 180, 90);

                // Top right corner
                arcRect.X = rect.Right - diameter;
                path.AddArc(arcRect, 270, 90);

                // Lower right corner
                arcRect.Y = rect.Bottom - diameter;
                path.AddArc(arcRect, 0, 90);

                // Lower left corner
                arcRect.X = rect.Left;
                path.AddArc(arcRect, 90, 90);

                path.CloseFigure();

                return path;
            }

            public int BorderRadius { get; set; }
            public Color BorderColor { get; set; }
        }

        // Method which will be called by TourClicked event handler
        private void TourPanel_TourClicked(object sender, IDSenderEventArgs e)
        {
            SelectedTour selectedTour = new SelectedTour(e.ID_Tour);
            selectedTour.ShowDialog();  // Open selected tour form
            updateAccInfo();
        }
        
        
        // Event handler for "Add Tour" button
        private void button1_Click_2(object sender, EventArgs e)
        {
            AddTourForm addTourForm = new AddTourForm();
            addTourForm.ShowDialog();

            updateAccInfo();
            refreshTours();
        }


        // Event handler for "Refresh" button
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            refreshTours();
        }


        // Event handler for tour searching
        private void textBox_Search_TextChanged_1(object sender, EventArgs e)
        {
            container_Tours.Controls.Clear();

            string querySelect = $"select id_tour, tour_name, tour_description, tour_start_date, tour_end_date, tour_price " +  // This query select every record where
                $"from tours where concat (tour_name, tour_description) like '%" + textBox_Search.Text + "%'";  //in tour_name or in tour_description you can find text
                                                                                                                //from textBox_Search

            SqlCommand commandSelect = new SqlCommand(querySelect, dataBase.getConnection());

            try
            {
                dataBase.openConnection();
                SqlDataReader reader = commandSelect.ExecuteReader();
                container_Tours.Controls.Clear();
                while (reader.Read())
                {
                    TourPanel tourPanel = new TourPanel(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),
                        reader.GetDateTime(reader.GetOrdinal("tour_start_date")), reader.GetDateTime(reader.GetOrdinal("tour_end_date")),
                        reader[5].ToString());
                    
                    tourPanel.TourClicked += TourPanel_TourClicked;

                    container_Tours.Controls.Add(tourPanel);
                }
                reader.Close();
                dataBase.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при пошуку турів.\nПомилка: {ex.Message}", "Оновлення", MessageBoxButtons.OK, MessageBoxIcon.Information);
                refreshTours();
            }
            finally { dataBase.closeConnection(); }
        }


        // Event handler for "Clean" button
        private void btnClean_Click(object sender, EventArgs e)
        {
            textBox_Search.Clear();
            refreshTours();
        }

        // Event handler for "X"(Close) button
        private void button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //private void btnSave_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnChange_Click(object sender, EventArgs e)
        //{

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        //private void label4_Click(object sender, EventArgs e)
        //{

        //}

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        //private void btnClear_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnRefresh_Click(object sender, EventArgs e)
        //{

        //}

        //private void textBox_Search_TextChanged(object sender, EventArgs e)
        //{

        //}
                
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{

        //}        
    }
}
