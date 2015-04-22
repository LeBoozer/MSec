namespace MSec
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.Label_ProductName = new System.Windows.Forms.Label();
            this.Label_Version = new System.Windows.Forms.Label();
            this.Label_Copyright = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::MSec.Properties.Resources.head;
            this.logoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(131, 144);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // Label_ProductName
            // 
            this.Label_ProductName.AutoSize = true;
            this.Label_ProductName.Location = new System.Drawing.Point(149, 50);
            this.Label_ProductName.Name = "Label_ProductName";
            this.Label_ProductName.Size = new System.Drawing.Size(75, 13);
            this.Label_ProductName.TabIndex = 13;
            this.Label_ProductName.Text = "Product Name";
            // 
            // Label_Version
            // 
            this.Label_Version.AutoSize = true;
            this.Label_Version.Location = new System.Drawing.Point(149, 78);
            this.Label_Version.Name = "Label_Version";
            this.Label_Version.Size = new System.Drawing.Size(42, 13);
            this.Label_Version.TabIndex = 14;
            this.Label_Version.Text = "Version";
            // 
            // Label_Copyright
            // 
            this.Label_Copyright.AutoSize = true;
            this.Label_Copyright.Location = new System.Drawing.Point(149, 106);
            this.Label_Copyright.Name = "Label_Copyright";
            this.Label_Copyright.Size = new System.Drawing.Size(51, 13);
            this.Label_Copyright.TabIndex = 15;
            this.Label_Copyright.Text = "Copyright";
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(311, 167);
            this.Controls.Add(this.Label_Copyright);
            this.Controls.Add(this.Label_Version);
            this.Controls.Add(this.Label_ProductName);
            this.Controls.Add(this.logoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox";
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label Label_ProductName;
        private System.Windows.Forms.Label Label_Version;
        private System.Windows.Forms.Label Label_Copyright;

    }
}
