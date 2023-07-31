namespace TravelAgency_temp
{
    partial class AddTourForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTourForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.monthCalendar_StartDate = new System.Windows.Forms.MonthCalendar();
            this.monthCalendar_EndDate = new System.Windows.Forms.MonthCalendar();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.panelName = new System.Windows.Forms.Panel();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.panelStartDate = new System.Windows.Forms.Panel();
            this.panelEndDate = new System.Windows.Forms.Panel();
            this.panelPrice = new System.Windows.Forms.Panel();
            this.btnClean = new System.Windows.Forms.Button();
            this.panelCount = new System.Windows.Forms.Panel();
            this.textBox_Count = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
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
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(0, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 36);
            this.panel4.TabIndex = 66;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(317, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 28);
            this.label8.TabIndex = 29;
            this.label8.Text = "Створення Туру";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(12, 85);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 17);
            this.labelName.TabIndex = 68;
            this.labelName.Text = "Назва Туру:";
            // 
            // textBox_Name
            // 
            this.textBox_Name.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Name.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_Name.ForeColor = System.Drawing.Color.Black;
            this.textBox_Name.Location = new System.Drawing.Point(93, 82);
            this.textBox_Name.Multiline = true;
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(376, 26);
            this.textBox_Name.TabIndex = 73;
            // 
            // textBox_Description
            // 
            this.textBox_Description.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Description.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Description.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_Description.ForeColor = System.Drawing.Color.Black;
            this.textBox_Description.Location = new System.Drawing.Point(93, 137);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Description.Size = new System.Drawing.Size(678, 149);
            this.textBox_Description.TabIndex = 75;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDescription.ForeColor = System.Drawing.Color.Black;
            this.labelDescription.Location = new System.Drawing.Point(12, 140);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(75, 17);
            this.labelDescription.TabIndex = 74;
            this.labelDescription.Text = "Опис Туру:";
            // 
            // monthCalendar_StartDate
            // 
            this.monthCalendar_StartDate.Location = new System.Drawing.Point(154, 312);
            this.monthCalendar_StartDate.Name = "monthCalendar_StartDate";
            this.monthCalendar_StartDate.TabIndex = 76;
            // 
            // monthCalendar_EndDate
            // 
            this.monthCalendar_EndDate.Location = new System.Drawing.Point(437, 312);
            this.monthCalendar_EndDate.Name = "monthCalendar_EndDate";
            this.monthCalendar_EndDate.TabIndex = 77;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStartDate.ForeColor = System.Drawing.Color.Black;
            this.labelStartDate.Location = new System.Drawing.Point(12, 381);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(127, 17);
            this.labelStartDate.TabIndex = 78;
            this.labelStartDate.Text = "Дата початку Туру:";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEndDate.ForeColor = System.Drawing.Color.Black;
            this.labelEndDate.Location = new System.Drawing.Point(353, 381);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(61, 17);
            this.labelEndDate.TabIndex = 79;
            this.labelEndDate.Text = "Та кінця:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.ForeColor = System.Drawing.Color.Black;
            this.labelPrice.Location = new System.Drawing.Point(12, 500);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(118, 17);
            this.labelPrice.TabIndex = 80;
            this.labelPrice.Text = "Ціна Туру (в грн.):";
            // 
            // textBox_Price
            // 
            this.textBox_Price.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Price.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Price.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBox_Price.ForeColor = System.Drawing.Color.Black;
            this.textBox_Price.Location = new System.Drawing.Point(133, 497);
            this.textBox_Price.Multiline = true;
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.Size = new System.Drawing.Size(241, 26);
            this.textBox_Price.TabIndex = 81;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.YellowGreen;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(591, 524);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(180, 50);
            this.SaveButton.TabIndex = 92;
            this.SaveButton.Text = "Зберегти";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // panelName
            // 
            this.panelName.BackColor = System.Drawing.Color.YellowGreen;
            this.panelName.Location = new System.Drawing.Point(93, 114);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(377, 3);
            this.panelName.TabIndex = 93;
            // 
            // panelDescription
            // 
            this.panelDescription.BackColor = System.Drawing.Color.YellowGreen;
            this.panelDescription.Location = new System.Drawing.Point(93, 292);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(678, 3);
            this.panelDescription.TabIndex = 94;
            // 
            // panelStartDate
            // 
            this.panelStartDate.BackColor = System.Drawing.Color.YellowGreen;
            this.panelStartDate.Location = new System.Drawing.Point(154, 478);
            this.panelStartDate.Name = "panelStartDate";
            this.panelStartDate.Size = new System.Drawing.Size(164, 3);
            this.panelStartDate.TabIndex = 94;
            // 
            // panelEndDate
            // 
            this.panelEndDate.BackColor = System.Drawing.Color.YellowGreen;
            this.panelEndDate.Location = new System.Drawing.Point(437, 478);
            this.panelEndDate.Name = "panelEndDate";
            this.panelEndDate.Size = new System.Drawing.Size(164, 3);
            this.panelEndDate.TabIndex = 95;
            // 
            // panelPrice
            // 
            this.panelPrice.BackColor = System.Drawing.Color.YellowGreen;
            this.panelPrice.Location = new System.Drawing.Point(133, 529);
            this.panelPrice.Name = "panelPrice";
            this.panelPrice.Size = new System.Drawing.Size(241, 3);
            this.panelPrice.TabIndex = 96;
            // 
            // btnClean
            // 
            this.btnClean.AutoSize = true;
            this.btnClean.BackColor = System.Drawing.Color.Transparent;
            this.btnClean.FlatAppearance.BorderSize = 0;
            this.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClean.Image = ((System.Drawing.Image)(resources.GetObject("btnClean.Image")));
            this.btnClean.Location = new System.Drawing.Point(733, 75);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(38, 39);
            this.btnClean.TabIndex = 97;
            this.btnClean.UseVisualStyleBackColor = false;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // panelCount
            // 
            this.panelCount.BackColor = System.Drawing.Color.YellowGreen;
            this.panelCount.Location = new System.Drawing.Point(237, 577);
            this.panelCount.Name = "panelCount";
            this.panelCount.Size = new System.Drawing.Size(50, 3);
            this.panelCount.TabIndex = 110;
            // 
            // textBox_Count
            // 
            this.textBox_Count.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Count.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Count.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Count.ForeColor = System.Drawing.Color.Black;
            this.textBox_Count.Location = new System.Drawing.Point(237, 549);
            this.textBox_Count.MaxLength = 2;
            this.textBox_Count.Name = "textBox_Count";
            this.textBox_Count.Size = new System.Drawing.Size(50, 18);
            this.textBox_Count.TabIndex = 109;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCount.ForeColor = System.Drawing.Color.Black;
            this.labelCount.Location = new System.Drawing.Point(12, 552);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(219, 17);
            this.labelCount.TabIndex = 108;
            this.labelCount.Text = "Максимальна кількість учасників:";
            // 
            // AddTourForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 596);
            this.Controls.Add(this.panelCount);
            this.Controls.Add(this.textBox_Count);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.panelPrice);
            this.Controls.Add(this.panelEndDate);
            this.Controls.Add(this.panelStartDate);
            this.Controls.Add(this.panelDescription);
            this.Controls.Add(this.panelName);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.textBox_Price);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.monthCalendar_EndDate);
            this.Controls.Add(this.monthCalendar_StartDate);
            this.Controls.Add(this.textBox_Description);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTourForm";
            this.Text = "Створити тур";
            this.Load += new System.EventHandler(this.AddTourForm_Load);
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.MonthCalendar monthCalendar_EndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBox_Price;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.MonthCalendar monthCalendar_StartDate;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Panel panelStartDate;
        private System.Windows.Forms.Panel panelEndDate;
        private System.Windows.Forms.Panel panelPrice;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Panel panelCount;
        private System.Windows.Forms.TextBox textBox_Count;
        private System.Windows.Forms.Label labelCount;
    }
}