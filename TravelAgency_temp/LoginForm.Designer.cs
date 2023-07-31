namespace TravelAgency_temp
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Login = new System.Windows.Forms.Button();
            this.checkBox_ShowPassword = new System.Windows.Forms.CheckBox();
            this.panelEmail = new System.Windows.Forms.Panel();
            this.panelPassword = new System.Windows.Forms.Panel();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PhoneNumberLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel_Registration = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 31);
            this.panel1.TabIndex = 24;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Wanderlust Explorers";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.button_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Close.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Close.ForeColor = System.Drawing.Color.White;
            this.button_Close.Location = new System.Drawing.Point(372, 3);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(25, 25);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "X";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Login
            // 
            this.button_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.button_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.button_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen;
            this.button_Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Login.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Login.ForeColor = System.Drawing.Color.White;
            this.button_Login.Location = new System.Drawing.Point(12, 244);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(376, 50);
            this.button_Login.TabIndex = 32;
            this.button_Login.Text = "Ввійти";
            this.button_Login.UseVisualStyleBackColor = false;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // checkBox_ShowPassword
            // 
            this.checkBox_ShowPassword.AutoSize = true;
            this.checkBox_ShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox_ShowPassword.ForeColor = System.Drawing.Color.Black;
            this.checkBox_ShowPassword.Location = new System.Drawing.Point(272, 217);
            this.checkBox_ShowPassword.Name = "checkBox_ShowPassword";
            this.checkBox_ShowPassword.Size = new System.Drawing.Size(120, 19);
            this.checkBox_ShowPassword.TabIndex = 31;
            this.checkBox_ShowPassword.Text = "Показати пароль";
            this.checkBox_ShowPassword.UseVisualStyleBackColor = true;
            this.checkBox_ShowPassword.CheckedChanged += new System.EventHandler(this.checkBox_ShowPassword_CheckedChanged);
            // 
            // panelEmail
            // 
            this.panelEmail.BackColor = System.Drawing.Color.YellowGreen;
            this.panelEmail.Location = new System.Drawing.Point(12, 134);
            this.panelEmail.Name = "panelEmail";
            this.panelEmail.Size = new System.Drawing.Size(377, 3);
            this.panelEmail.TabIndex = 30;
            // 
            // panelPassword
            // 
            this.panelPassword.BackColor = System.Drawing.Color.YellowGreen;
            this.panelPassword.Location = new System.Drawing.Point(12, 203);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(377, 3);
            this.panelPassword.TabIndex = 29;
            // 
            // textBox_Password
            // 
            this.textBox_Password.BackColor = System.Drawing.Color.MidnightBlue;
            this.textBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Password.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_Password.ForeColor = System.Drawing.Color.White;
            this.textBox_Password.Location = new System.Drawing.Point(12, 171);
            this.textBox_Password.Multiline = true;
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(376, 26);
            this.textBox_Password.TabIndex = 28;
            // 
            // textBox_Email
            // 
            this.textBox_Email.BackColor = System.Drawing.Color.MidnightBlue;
            this.textBox_Email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Email.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Email.ForeColor = System.Drawing.Color.White;
            this.textBox_Email.Location = new System.Drawing.Point(12, 102);
            this.textBox_Email.Multiline = true;
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(376, 26);
            this.textBox_Email.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Введіть пароль";
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.AutoSize = true;
            this.PhoneNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneNumberLabel.ForeColor = System.Drawing.Color.Black;
            this.PhoneNumberLabel.Location = new System.Drawing.Point(5, 79);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(113, 17);
            this.PhoneNumberLabel.TabIndex = 25;
            this.PhoneNumberLabel.Text = "Ведіть ваш e-mail";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(0, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 36);
            this.panel4.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(173, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 28);
            this.label8.TabIndex = 29;
            this.label8.Text = "Вхід";
            // 
            // linkLabel_Registration
            // 
            this.linkLabel_Registration.AutoSize = true;
            this.linkLabel_Registration.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabel_Registration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(255)))));
            this.linkLabel_Registration.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel_Registration.Location = new System.Drawing.Point(163, 304);
            this.linkLabel_Registration.Name = "linkLabel_Registration";
            this.linkLabel_Registration.Size = new System.Drawing.Size(75, 17);
            this.linkLabel_Registration.TabIndex = 30;
            this.linkLabel_Registration.TabStop = true;
            this.linkLabel_Registration.Text = "Реєстрація";
            this.linkLabel_Registration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Registration_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.Add(this.linkLabel_Registration);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.checkBox_ShowPassword);
            this.Controls.Add(this.panelEmail);
            this.Controls.Add(this.panelPassword);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PhoneNumberLabel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "Вхід";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.CheckBox checkBox_ShowPassword;
        private System.Windows.Forms.Panel panelEmail;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel_Registration;
    }
}