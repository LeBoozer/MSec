﻿namespace MSec
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
            this.components = new System.ComponentModel.Container();
            this.MainDialog_MainTab = new System.Windows.Forms.TabControl();
            this.pageImageVsImage = new System.Windows.Forms.TabPage();
            this.Progress_ImageVsImage = new System.Windows.Forms.ProgressBar();
            this.Label_ImageVsImage_Result = new System.Windows.Forms.Label();
            this.Button_ImageVsImage_Compute = new System.Windows.Forms.Button();
            this.Selection_ImageSource1 = new ImageSourceSelection();
            this.Selection_ImageSource0 = new ImageSourceSelection();
            this.Selection_Technique = new TechniqueSelection();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.pageImageVsImage.Controls.Add(this.Progress_ImageVsImage);
            this.pageImageVsImage.Controls.Add(this.Label_ImageVsImage_Result);
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
            // Progress_ImageVsImage
            // 
            this.Progress_ImageVsImage.Enabled = false;
            this.Progress_ImageVsImage.Location = new System.Drawing.Point(3, 448);
            this.Progress_ImageVsImage.MarqueeAnimationSpeed = 20;
            this.Progress_ImageVsImage.Name = "Progress_ImageVsImage";
            this.Progress_ImageVsImage.Size = new System.Drawing.Size(656, 10);
            this.Progress_ImageVsImage.Step = 20;
            this.Progress_ImageVsImage.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Progress_ImageVsImage.TabIndex = 7;
            this.Progress_ImageVsImage.Visible = false;
            // 
            // Label_ImageVsImage_Result
            // 
            this.Label_ImageVsImage_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ImageVsImage_Result.Location = new System.Drawing.Point(3, 413);
            this.Label_ImageVsImage_Result.Name = "Label_ImageVsImage_Result";
            this.Label_ImageVsImage_Result.Size = new System.Drawing.Size(656, 32);
            this.Label_ImageVsImage_Result.TabIndex = 6;
            this.Label_ImageVsImage_Result.Text = "-";
            this.Label_ImageVsImage_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button_ImageVsImage_Compute
            // 
            this.Button_ImageVsImage_Compute.Enabled = false;
            this.Button_ImageVsImage_Compute.Location = new System.Drawing.Point(322, 383);
            this.Button_ImageVsImage_Compute.Name = "Button_ImageVsImage_Compute";
            this.Button_ImageVsImage_Compute.Size = new System.Drawing.Size(19, 23);
            this.Button_ImageVsImage_Compute.TabIndex = 5;
            this.Button_ImageVsImage_Compute.Text = "C";
            this.ToolTip.SetToolTip(this.Button_ImageVsImage_Compute, "Starts the hashing of both selected images and the subsequent comparison");
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
            // ToolTip
            // 
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Information";
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
        private System.Windows.Forms.Label Label_ImageVsImage_Result;
        private System.Windows.Forms.ProgressBar Progress_ImageVsImage;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}

