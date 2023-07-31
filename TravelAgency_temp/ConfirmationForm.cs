using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelAgency_temp.Classes;

namespace TravelAgency_temp
{
    // The ConfirmationForm class represents a form for confirming actions by entering a verification code.
    public partial class ConfirmationForm : Form
    {
        Random random = new Random();

        // Private fields to store email, message, code, and remaining tries.
        private string Email = string.Empty;
        private string Message = string.Empty;
        private int code;
        private int tries;

        // Public property to indicate if the action is confirmed or not.
        public bool Confirmed {get; private set;}

        // Constants and DLL imports for moving the form by clicking and dragging the title bar.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        // Constructor of ConfirmationForm.
        public ConfirmationForm(string email, string Message)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.Email = email;
            this.Message = Message;
            this.Confirmed = false;
            this.tries = 3;
        }


        private void ConfirmationForm_Load(object sender, EventArgs e)
        {
            label_Message.Text = Message;

            // Generate a random verification code.
            code = random.Next(100000, 999999);
            Message += $" Код для перевірки: {code}";  // Append the verification code to the message.
            Sender.Email(Email, "Підтвердження дій", Message);  // Send the confirmation message to the specified email using the Sender class.
        }


        private void ConfirmationForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        // Event handler for the OK button click.
        // This checks if the entered verification code is correct and closes the form if confirmed.
        private void button_OK_Click(object sender, EventArgs e)
        {
            if(tries <= 3)
            {
                if(numeric_Code.Value == code)
                {
                    Confirmed = true;
                    Close();
                }
                else tries--;
            }
            else Close();
        }


        // Event handler for the Cancel button click.
        // This sets the Confirmed property to false and closes the form without confirmation.
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Confirmed = false;
            Close();
        }
    }
}
