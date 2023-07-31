namespace TravelAgency_temp
{
    partial class ConfirmationForm
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
            this.label_Message = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_Code = new System.Windows.Forms.NumericUpDown();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Code)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Location = new System.Drawing.Point(32, 33);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(53, 13);
            this.label_Message.TabIndex = 0;
            this.label_Message.Text = "Message ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "На вашу пошту відправлено листа";
            // 
            // numeric_Code
            // 
            this.numeric_Code.Location = new System.Drawing.Point(55, 58);
            this.numeric_Code.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numeric_Code.Name = "numeric_Code";
            this.numeric_Code.Size = new System.Drawing.Size(120, 20);
            this.numeric_Code.TabIndex = 2;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(29, 84);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 3;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(130, 84);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 4;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 117);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.numeric_Code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_Message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmationForm";
            this.Text = "Confirmation";
            this.Load += new System.EventHandler(this.ConfirmationForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ConfirmationForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Code)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Message;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numeric_Code;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
    }
}