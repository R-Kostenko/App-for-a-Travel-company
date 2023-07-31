using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_temp.Classes;

namespace TravelAgency_temp
{
    // ContactForm is for contact with administration
    public partial class ContactForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        public ContactForm()
        {
            InitializeComponent();
        }

        private void ContactForm_Load(object sender, EventArgs e)
        {
            textBox_Subject.Text = string.Empty;
            textBox_Body.Text = string.Empty;
            textBox_Subject.Focus();
            resetPanelsColors();
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


        // Called when the "Send" button is clicked.
        // Validates the input fields, sends an email to the admin with the subject and body, and displays a success message.
        private void SendButton_Click(object sender, EventArgs e)
        {
            resetPanelsColors();    // Reset panel colors to their default state.

            // Create instances of CheckTourNameOrSubject and CheckDescriptionOrBody classes to validate subject and body inputs.
            var checkHeader = new CheckTourNameOrSubject(textBox_Subject.Text, ref panelSubj);
            var checkBody = new CheckDescriptionOrBody(textBox_Body.Text, ref panelBody);

            checkHeader.setNext(checkBody); // Set the next validation step for subject and body inputs.

            checkHeader.Check();    // Start the validation process.

            // If any input is invalid, return without sending the email.
            if (checkPanels())
            {
                return;
            }

            // Send an email to the admin with the subject and body inputs.
            Sender.EmailToAdmin(textBox_Subject.Text, textBox_Body.Text);

            // Display a success message to the user after sending the email.
            MessageBox.Show("Вашого листа надіслано адміністрації.", "Зв'язок", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        // Checks if any input panels are in the error state (red color).
        private bool checkPanels()
        {
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                if (panel.BackColor == Color.Red) return true;
            }
            return false;
        }

        // Resets the background colors of input panels to their default state (turquoise color).
        private void resetPanelsColors()
        {
            foreach (Panel panel in Controls.OfType<Panel>())
            {
                if (panel.Name != panel1.Name && panel.Name != panel4.Name) panel.BackColor = Color.Turquoise;
            }
        }


        // Called when the "Clean" button is clicked.
        // Clears the body textbox.
        private void btnClean_Click(object sender, EventArgs e)
        {
            textBox_Body.Clear();
        }


        // Called when the "Close" button is clicked.
        // Closes the form.
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }        
    }
}
