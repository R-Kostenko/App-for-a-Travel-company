namespace TravelAgency_temp
{
    partial class SignedOnTour
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
            this.label2 = new System.Windows.Forms.Label();
            this.container_Tours = new System.Windows.Forms.FlowLayoutPanel();
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
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(0, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(800, 36);
            this.panel4.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(317, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Замовлені тури";
            // 
            // container_Tours
            // 
            this.container_Tours.AutoScroll = true;
            this.container_Tours.Location = new System.Drawing.Point(52, 89);
            this.container_Tours.Name = "container_Tours";
            this.container_Tours.Size = new System.Drawing.Size(696, 272);
            this.container_Tours.TabIndex = 69;
            // 
            // SignedOnTour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 392);
            this.Controls.Add(this.container_Tours);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignedOnTour";
            this.Text = "Замовлені тури";
            this.Load += new System.EventHandler(this.SignedOnTour_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel container_Tours;
    }
}