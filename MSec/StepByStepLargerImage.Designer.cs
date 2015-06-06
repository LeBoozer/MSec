namespace MSec
{
    partial class StepByStepLargerImage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SS_Picture_LargeView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SS_Picture_LargeView)).BeginInit();
            this.SuspendLayout();
            // 
            // SS_Picture_LargeView
            // 
            this.SS_Picture_LargeView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SS_Picture_LargeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SS_Picture_LargeView.Location = new System.Drawing.Point(1, 1);
            this.SS_Picture_LargeView.Name = "SS_Picture_LargeView";
            this.SS_Picture_LargeView.Size = new System.Drawing.Size(398, 398);
            this.SS_Picture_LargeView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SS_Picture_LargeView.TabIndex = 1;
            this.SS_Picture_LargeView.TabStop = false;
            // 
            // StepByStepLargerImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SS_Picture_LargeView);
            this.Name = "StepByStepLargerImage";
            this.Size = new System.Drawing.Size(400, 400);
            ((System.ComponentModel.ISupportInitialize)(this.SS_Picture_LargeView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SS_Picture_LargeView;
    }
}
