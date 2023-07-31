using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_temp.Classes;
using static TravelAgency_temp.MainForm;
using static TravelAgency_temp.MainForm.TourPanel;

namespace TravelAgency_temp
{
    public partial class SignedOnTour : Form
    {
        DataBaseConnection dataBase = DataBaseConnection.GetInstance();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        public SignedOnTour()
        {
            InitializeComponent();
        }


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


        private void SignedOnTour_Load(object sender, EventArgs e)
        {
            refreshTours();
        }


        // This class was already commented
        public class TourPanel : UserControl
        {
            //
            public event EventHandler<IDSenderEventArgs> TourClicked;

            string ID_Tour;

            public class IDSenderEventArgs : EventArgs
            {
                public string ID_Tour { get; set; }
                public IDSenderEventArgs(string iD_Tour)
                {
                    ID_Tour = iD_Tour;
                }
            }

            public TourPanel(string id_tour, string name, string description, DateTime startDate, DateTime endDate, string price)
            {
                this.ID_Tour = id_tour;

                BackColor = SystemColors.Control;
                Size = new Size(670, 100);
                Padding = new Padding(10);
                BorderStyle = BorderStyle.None;
                BorderRadius = 10;
                BorderColor = Color.Gray;

                Label nameLabel = new Label
                {
                    Location = new Point(10, 20),
                    AutoSize = false,
                    Size = new Size(150, 50),
                    Text = name,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.TopLeft,
                    AutoEllipsis = true,
                    UseCompatibleTextRendering = true,
                    UseMnemonic = false
                };
                this.Controls.Add(nameLabel);

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

                Label datesLabel = new Label();
                datesLabel.Location = new Point(200, 70);
                TimeSpan difference;
                if (startDate > DateTime.Now)
                {
                    difference = startDate.Subtract(DateTime.Now).Duration();
                    if (difference.Days != 0)
                    {
                        datesLabel.Text = $"Тур почнеться через {difference.Days} днів";                        
                    }
                    else
                    {
                        datesLabel.Text = $"Тур почнеться завтра";
                    }
                    
                }
                if (startDate <= DateTime.Now)
                {
                    difference = endDate.Subtract(DateTime.Now).Duration();
                    datesLabel.Text = $"Тур закінчиться через {difference.Days} днів";
                }
                datesLabel.Font = new Font("Segoe UI", 12);
                datesLabel.AutoSize = true;
                this.Controls.Add(datesLabel);

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

                //
                this.Click += TourPanel_Click;
                nameLabel.Click += TourPanel_Click;
            }

            private void TourPanel_Click(object sender, EventArgs e)
            {
                //
                var args = new IDSenderEventArgs(ID_Tour);
                TourClicked?.Invoke(this, args);
            }


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

                path.AddArc(arcRect, 180, 90);

                arcRect.X = rect.Right - diameter;
                path.AddArc(arcRect, 270, 90);

                arcRect.Y = rect.Bottom - diameter;
                path.AddArc(arcRect, 0, 90);

                arcRect.X = rect.Left;
                path.AddArc(arcRect, 90, 90);

                path.CloseFigure();

                return path;
            }

            public int BorderRadius { get; set; }
            public Color BorderColor { get; set; }
        }

        private void TourPanel_TourClicked(object sender, TourPanel.IDSenderEventArgs e)
        {
            //
            UnSignTourForm unSignTourForm = new UnSignTourForm(e.ID_Tour);
            unSignTourForm.ShowDialog();
            refreshTours();
        }


        // This method was already commented
        private void refreshTours()
        {
            string querySelectSigned = $"select id_tour from orders where id_user = '{DataStorage.idUser}'";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(querySelectSigned, dataBase.getConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show($"У вас немає замовлених турів.", "Замовлені", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }

                foreach(DataRow row in dt.Rows)
                {
                    string tourId = row["id_tour"].ToString();

                    string querySelect = $"select id_tour, tour_name, tour_description, tour_start_date, tour_end_date, tour_price " +
                        $"from tours where id_tour = '{tourId}'";
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
                    }
                    catch (Exception ex)
                    {
                        string exceptionMessage = "Помилка при запиті даних туру. " + ex.Message;
                        throw new Exception(exceptionMessage);
                    }
                    finally { dataBase.closeConnection(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка при оновленні списку.\nПомилка: {ex.Message}", "Відтворення списку", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            finally { dataBase.closeConnection(); }
        }
    }
}
