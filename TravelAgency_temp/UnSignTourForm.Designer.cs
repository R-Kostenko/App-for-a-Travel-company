namespace TravelAgency_temp
{
    partial class UnSignTourForm
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_EndDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_StartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UnsignButton = new System.Windows.Forms.Button();
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
            this.panel1.Size = new System.Drawing.Size(800, 31);
            this.panel1.TabIndex = 25;
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
            this.button_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Close.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Close.ForeColor = System.Drawing.Color.White;
            this.button_Close.Location = new System.Drawing.Point(772, 3);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(25, 25);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "X";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.panel4.Controls.Add(this.textBox_Name);
            this.panel4.Location = new System.Drawing.Point(0, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 36);
            this.panel4.TabIndex = 68;
            // 
            // textBox_Name
            // 
            this.textBox_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.textBox_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Name.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.textBox_Name.ForeColor = System.Drawing.Color.White;
            this.textBox_Name.Location = new System.Drawing.Point(8, 0);
            this.textBox_Name.Multiline = true;
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.ReadOnly = true;
            this.textBox_Name.Size = new System.Drawing.Size(774, 36);
            this.textBox_Name.TabIndex = 95;
            this.textBox_Name.Text = "Назва Туру";
            this.textBox_Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Description
            // 
            this.textBox_Description.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Description.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_Description.ForeColor = System.Drawing.Color.Black;
            this.textBox_Description.Location = new System.Drawing.Point(12, 104);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.ReadOnly = true;
            this.textBox_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Description.Size = new System.Drawing.Size(771, 197);
            this.textBox_Description.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(9, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 77;
            this.label2.Text = "Опис туру:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(364, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 21);
            this.label7.TabIndex = 103;
            this.label7.Text = "По";
            // 
            // textBox_EndDate
            // 
            this.textBox_EndDate.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_EndDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_EndDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_EndDate.ForeColor = System.Drawing.Color.Black;
            this.textBox_EndDate.Location = new System.Drawing.Point(400, 342);
            this.textBox_EndDate.Name = "textBox_EndDate";
            this.textBox_EndDate.ReadOnly = true;
            this.textBox_EndDate.Size = new System.Drawing.Size(167, 22);
            this.textBox_EndDate.TabIndex = 102;
            this.textBox_EndDate.Text = "Кінець";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(166, 342);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 21);
            this.label5.TabIndex = 101;
            this.label5.Text = "З";
            // 
            // textBox_StartDate
            // 
            this.textBox_StartDate.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_StartDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_StartDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_StartDate.ForeColor = System.Drawing.Color.Black;
            this.textBox_StartDate.Location = new System.Drawing.Point(191, 342);
            this.textBox_StartDate.Name = "textBox_StartDate";
            this.textBox_StartDate.ReadOnly = true;
            this.textBox_StartDate.Size = new System.Drawing.Size(167, 22);
            this.textBox_StartDate.TabIndex = 100;
            this.textBox_StartDate.Text = "Початок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(13, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 21);
            this.label3.TabIndex = 99;
            this.label3.Text = "Тривалість туру:";
            // 
            // textBox_Price
            // 
            this.textBox_Price.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_Price.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Price.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_Price.ForeColor = System.Drawing.Color.Black;
            this.textBox_Price.Location = new System.Drawing.Point(171, 388);
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.ReadOnly = true;
            this.textBox_Price.Size = new System.Drawing.Size(167, 22);
            this.textBox_Price.TabIndex = 105;
            this.textBox_Price.Text = "Ціна";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(13, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 21);
            this.label4.TabIndex = 104;
            this.label4.Text = "Ціна туру (грн.):";
            // 
            // UnsignButton
            // 
            this.UnsignButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.UnsignButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.UnsignButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen;
            this.UnsignButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UnsignButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UnsignButton.ForeColor = System.Drawing.Color.White;
            this.UnsignButton.Location = new System.Drawing.Point(525, 389);
            this.UnsignButton.Name = "UnsignButton";
            this.UnsignButton.Size = new System.Drawing.Size(257, 37);
            this.UnsignButton.TabIndex = 106;
            this.UnsignButton.Text = "Відмовитись від туру";
            this.UnsignButton.UseVisualStyleBackColor = false;
            this.UnsignButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UnSignTourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.UnsignButton);
            this.Controls.Add(this.textBox_Price);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_EndDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_StartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Description);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UnSignTourForm";
            this.Text = "UnSignTourForm";
            this.Load += new System.EventHandler(this.UnSignTourForm_Load);
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
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_EndDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_StartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UnsignButton;
    }
}