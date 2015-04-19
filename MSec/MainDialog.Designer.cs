namespace MSec
{
    partial class MainDialog
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
            this.MainDialog_MainTab = new System.Windows.Forms.TabControl();
            this.pageImageVsImage = new System.Windows.Forms.TabPage();
            this.Button_ImageVsImage_Compute = new System.Windows.Forms.Button();
            this.Selection_ImageSource1 = new ImageSourceSelection();
            this.Selection_ImageSource0 = new ImageSourceSelection();
            this.Selection_Technique = new TechniqueSelection();
            this.MainDialog_MainTab.SuspendLayout();
            this.pageImageVsImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainDialog_MainTab
            // 
            this.MainDialog_MainTab.Controls.Add(this.pageImageVsImage);
            this.MainDialog_MainTab.Location = new System.Drawing.Point(12, 12);
            this.MainDialog_MainTab.Name = "MainDialog_MainTab";
            this.MainDialog_MainTab.SelectedIndex = 0;
            this.MainDialog_MainTab.Size = new System.Drawing.Size(670, 487);
            this.MainDialog_MainTab.TabIndex = 0;
            // 
            // pageImageVsImage
            // 
            this.pageImageVsImage.Controls.Add(this.Button_ImageVsImage_Compute);
            this.pageImageVsImage.Controls.Add(this.Selection_ImageSource1);
            this.pageImageVsImage.Controls.Add(this.Selection_ImageSource0);
            this.pageImageVsImage.Controls.Add(this.Selection_Technique);
            this.pageImageVsImage.Location = new System.Drawing.Point(4, 22);
            this.pageImageVsImage.Name = "pageImageVsImage";
            this.pageImageVsImage.Size = new System.Drawing.Size(662, 461);
            this.pageImageVsImage.TabIndex = 1;
            this.pageImageVsImage.Text = "Image vs. Image";
            this.pageImageVsImage.UseVisualStyleBackColor = true;
            // 
            // Button_ImageVsImage_Compute
            // 
            this.Button_ImageVsImage_Compute.Enabled = false;
            this.Button_ImageVsImage_Compute.Location = new System.Drawing.Point(292, 416);
            this.Button_ImageVsImage_Compute.Name = "Button_ImageVsImage_Compute";
            this.Button_ImageVsImage_Compute.Size = new System.Drawing.Size(75, 23);
            this.Button_ImageVsImage_Compute.TabIndex = 5;
            this.Button_ImageVsImage_Compute.Text = "Compute";
            this.Button_ImageVsImage_Compute.UseVisualStyleBackColor = true;
            // 
            // Selection_ImageSource1
            // 
            this.Selection_ImageSource1.AllowDrop = true;
            this.Selection_ImageSource1.Location = new System.Drawing.Point(342, 109);
            this.Selection_ImageSource1.Name = "Selection_ImageSource1";
            this.Selection_ImageSource1.Size = new System.Drawing.Size(317, 301);
            this.Selection_ImageSource1.TabIndex = 4;
            // 
            // Selection_ImageSource0
            // 
            this.Selection_ImageSource0.AllowDrop = true;
            this.Selection_ImageSource0.Location = new System.Drawing.Point(3, 109);
            this.Selection_ImageSource0.Name = "Selection_ImageSource0";
            this.Selection_ImageSource0.Size = new System.Drawing.Size(317, 301);
            this.Selection_ImageSource0.TabIndex = 3;
            // 
            // Selection_Technique
            // 
            this.Selection_Technique.Location = new System.Drawing.Point(27, 3);
            this.Selection_Technique.Name = "Selection_Technique";
            this.Selection_Technique.Size = new System.Drawing.Size(610, 100);
            this.Selection_Technique.TabIndex = 0;
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(694, 511);
            this.Controls.Add(this.MainDialog_MainTab);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(710, 550);
            this.MinimizeBox = false;
            this.Name = "MainDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSec";
            this.MainDialog_MainTab.ResumeLayout(false);
            this.pageImageVsImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainDialog_MainTab;
        private System.Windows.Forms.TabPage pageImageVsImage;
        private TechniqueSelection Selection_Technique;
        private ImageSourceSelection Selection_ImageSource1;
        private ImageSourceSelection Selection_ImageSource0;
        private System.Windows.Forms.Button Button_ImageVsImage_Compute;
    }
}

