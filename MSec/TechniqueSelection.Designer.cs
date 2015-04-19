namespace MSec
{
    partial class TechniqueSelection
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
            this.components = new System.ComponentModel.Container();
            this.Group_Configuration = new System.Windows.Forms.GroupBox();
            this.Label_Technique_Wavelet_Level = new System.Windows.Forms.Label();
            this.Number_Technique_Wavelet_Level = new System.Windows.Forms.NumericUpDown();
            this.Label_Technique_Wavelet_Alpha = new System.Windows.Forms.Label();
            this.Number_Technique_Wavelet_Alpha = new System.Windows.Forms.NumericUpDown();
            this.Label_Technique_Radish_Angles = new System.Windows.Forms.Label();
            this.Label_Technique_Radish_Sigma = new System.Windows.Forms.Label();
            this.Label_Technique_Radish_Gamma = new System.Windows.Forms.Label();
            this.Number_Technique_Radish_Angles = new System.Windows.Forms.NumericUpDown();
            this.Number_Technique_Radish_Sigma = new System.Windows.Forms.NumericUpDown();
            this.Number_Technique_Radish_Gamma = new System.Windows.Forms.NumericUpDown();
            this.Radio_Technique_Wavelet = new System.Windows.Forms.RadioButton();
            this.Radio_Technique_DCT = new System.Windows.Forms.RadioButton();
            this.Radio_Technique_Radish = new System.Windows.Forms.RadioButton();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Group_Configuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Wavelet_Level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Wavelet_Alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Angles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Sigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Gamma)).BeginInit();
            this.SuspendLayout();
            // 
            // Group_Configuration
            // 
            this.Group_Configuration.Controls.Add(this.Label_Technique_Wavelet_Level);
            this.Group_Configuration.Controls.Add(this.Number_Technique_Wavelet_Level);
            this.Group_Configuration.Controls.Add(this.Label_Technique_Wavelet_Alpha);
            this.Group_Configuration.Controls.Add(this.Number_Technique_Wavelet_Alpha);
            this.Group_Configuration.Controls.Add(this.Label_Technique_Radish_Angles);
            this.Group_Configuration.Controls.Add(this.Label_Technique_Radish_Sigma);
            this.Group_Configuration.Controls.Add(this.Label_Technique_Radish_Gamma);
            this.Group_Configuration.Controls.Add(this.Number_Technique_Radish_Angles);
            this.Group_Configuration.Controls.Add(this.Number_Technique_Radish_Sigma);
            this.Group_Configuration.Controls.Add(this.Number_Technique_Radish_Gamma);
            this.Group_Configuration.Controls.Add(this.Radio_Technique_Wavelet);
            this.Group_Configuration.Controls.Add(this.Radio_Technique_DCT);
            this.Group_Configuration.Controls.Add(this.Radio_Technique_Radish);
            this.Group_Configuration.Location = new System.Drawing.Point(3, 3);
            this.Group_Configuration.Name = "Group_Configuration";
            this.Group_Configuration.Size = new System.Drawing.Size(603, 92);
            this.Group_Configuration.TabIndex = 0;
            this.Group_Configuration.TabStop = false;
            this.Group_Configuration.Text = "Configuration";
            // 
            // Label_Technique_Wavelet_Level
            // 
            this.Label_Technique_Wavelet_Level.AutoSize = true;
            this.Label_Technique_Wavelet_Level.Location = new System.Drawing.Point(307, 65);
            this.Label_Technique_Wavelet_Level.Name = "Label_Technique_Wavelet_Level";
            this.Label_Technique_Wavelet_Level.Size = new System.Drawing.Size(36, 13);
            this.Label_Technique_Wavelet_Level.TabIndex = 18;
            this.Label_Technique_Wavelet_Level.Text = "Level:";
            // 
            // Number_Technique_Wavelet_Level
            // 
            this.Number_Technique_Wavelet_Level.DecimalPlaces = 1;
            this.Number_Technique_Wavelet_Level.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Number_Technique_Wavelet_Level.Location = new System.Drawing.Point(352, 61);
            this.Number_Technique_Wavelet_Level.Name = "Number_Technique_Wavelet_Level";
            this.Number_Technique_Wavelet_Level.Size = new System.Drawing.Size(45, 20);
            this.Number_Technique_Wavelet_Level.TabIndex = 17;
            this.Number_Technique_Wavelet_Level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.Number_Technique_Wavelet_Level, "Level of the scale factor");
            this.Number_Technique_Wavelet_Level.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Number_Technique_Wavelet_Level.ValueChanged += new System.EventHandler(this.Number_Technique_Wavelet_Level_ValueChanged);
            // 
            // Label_Technique_Wavelet_Alpha
            // 
            this.Label_Technique_Wavelet_Alpha.AutoSize = true;
            this.Label_Technique_Wavelet_Alpha.Location = new System.Drawing.Point(172, 65);
            this.Label_Technique_Wavelet_Alpha.Name = "Label_Technique_Wavelet_Alpha";
            this.Label_Technique_Wavelet_Alpha.Size = new System.Drawing.Size(37, 13);
            this.Label_Technique_Wavelet_Alpha.TabIndex = 16;
            this.Label_Technique_Wavelet_Alpha.Text = "Alpha:";
            // 
            // Number_Technique_Wavelet_Alpha
            // 
            this.Number_Technique_Wavelet_Alpha.DecimalPlaces = 1;
            this.Number_Technique_Wavelet_Alpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Number_Technique_Wavelet_Alpha.Location = new System.Drawing.Point(224, 61);
            this.Number_Technique_Wavelet_Alpha.Name = "Number_Technique_Wavelet_Alpha";
            this.Number_Technique_Wavelet_Alpha.Size = new System.Drawing.Size(45, 20);
            this.Number_Technique_Wavelet_Alpha.TabIndex = 15;
            this.Number_Technique_Wavelet_Alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.Number_Technique_Wavelet_Alpha, "Scale factor for marr wavelet");
            this.Number_Technique_Wavelet_Alpha.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Number_Technique_Wavelet_Alpha.ValueChanged += new System.EventHandler(this.Number_Technique_Wavelet_Alpha_ValueChanged);
            // 
            // Label_Technique_Radish_Angles
            // 
            this.Label_Technique_Radish_Angles.AutoSize = true;
            this.Label_Technique_Radish_Angles.Location = new System.Drawing.Point(435, 21);
            this.Label_Technique_Radish_Angles.Name = "Label_Technique_Radish_Angles";
            this.Label_Technique_Radish_Angles.Size = new System.Drawing.Size(93, 13);
            this.Label_Technique_Radish_Angles.TabIndex = 14;
            this.Label_Technique_Radish_Angles.Text = "Number of angles:";
            // 
            // Label_Technique_Radish_Sigma
            // 
            this.Label_Technique_Radish_Sigma.AutoSize = true;
            this.Label_Technique_Radish_Sigma.Location = new System.Drawing.Point(307, 21);
            this.Label_Technique_Radish_Sigma.Name = "Label_Technique_Radish_Sigma";
            this.Label_Technique_Radish_Sigma.Size = new System.Drawing.Size(39, 13);
            this.Label_Technique_Radish_Sigma.TabIndex = 13;
            this.Label_Technique_Radish_Sigma.Text = "Sigma:";
            // 
            // Label_Technique_Radish_Gamma
            // 
            this.Label_Technique_Radish_Gamma.AutoSize = true;
            this.Label_Technique_Radish_Gamma.Location = new System.Drawing.Point(172, 21);
            this.Label_Technique_Radish_Gamma.Name = "Label_Technique_Radish_Gamma";
            this.Label_Technique_Radish_Gamma.Size = new System.Drawing.Size(46, 13);
            this.Label_Technique_Radish_Gamma.TabIndex = 12;
            this.Label_Technique_Radish_Gamma.Text = "Gamma:";
            // 
            // Number_Technique_Radish_Angles
            // 
            this.Number_Technique_Radish_Angles.Location = new System.Drawing.Point(534, 17);
            this.Number_Technique_Radish_Angles.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.Number_Technique_Radish_Angles.Name = "Number_Technique_Radish_Angles";
            this.Number_Technique_Radish_Angles.Size = new System.Drawing.Size(62, 20);
            this.Number_Technique_Radish_Angles.TabIndex = 11;
            this.Number_Technique_Radish_Angles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Number_Technique_Radish_Angles.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.Number_Technique_Radish_Angles.ValueChanged += new System.EventHandler(this.Number_Technique_Radish_Angles_ValueChanged);
            // 
            // Number_Technique_Radish_Sigma
            // 
            this.Number_Technique_Radish_Sigma.DecimalPlaces = 1;
            this.Number_Technique_Radish_Sigma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Number_Technique_Radish_Sigma.Location = new System.Drawing.Point(352, 17);
            this.Number_Technique_Radish_Sigma.Name = "Number_Technique_Radish_Sigma";
            this.Number_Technique_Radish_Sigma.Size = new System.Drawing.Size(45, 20);
            this.Number_Technique_Radish_Sigma.TabIndex = 10;
            this.Number_Technique_Radish_Sigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.Number_Technique_Radish_Sigma, "Value for the deviation for gaussian filter");
            this.Number_Technique_Radish_Sigma.Value = new decimal(new int[] {
            35,
            0,
            0,
            65536});
            this.Number_Technique_Radish_Sigma.ValueChanged += new System.EventHandler(this.Number_Technique_Radish_Sigma_ValueChanged);
            // 
            // Number_Technique_Radish_Gamma
            // 
            this.Number_Technique_Radish_Gamma.DecimalPlaces = 1;
            this.Number_Technique_Radish_Gamma.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Number_Technique_Radish_Gamma.Location = new System.Drawing.Point(224, 17);
            this.Number_Technique_Radish_Gamma.Name = "Number_Technique_Radish_Gamma";
            this.Number_Technique_Radish_Gamma.Size = new System.Drawing.Size(45, 20);
            this.Number_Technique_Radish_Gamma.TabIndex = 9;
            this.Number_Technique_Radish_Gamma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.Number_Technique_Radish_Gamma, "Value for gamma correction on the input image");
            this.Number_Technique_Radish_Gamma.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Number_Technique_Radish_Gamma.ValueChanged += new System.EventHandler(this.Number_Technique_Radish_Gamma_ValueChanged);
            // 
            // Radio_Technique_Wavelet
            // 
            this.Radio_Technique_Wavelet.AutoSize = true;
            this.Radio_Technique_Wavelet.Location = new System.Drawing.Point(17, 65);
            this.Radio_Technique_Wavelet.Name = "Radio_Technique_Wavelet";
            this.Radio_Technique_Wavelet.Size = new System.Drawing.Size(149, 17);
            this.Radio_Technique_Wavelet.TabIndex = 5;
            this.Radio_Technique_Wavelet.Text = "Marr/Mexican hat wavelet";
            this.ToolTip.SetToolTip(this.Radio_Technique_Wavelet, "Hashing technique: Wavelet");
            this.Radio_Technique_Wavelet.UseVisualStyleBackColor = true;
            this.Radio_Technique_Wavelet.CheckedChanged += new System.EventHandler(this.Radio_Technique_Wavelet_CheckedChanged);
            // 
            // Radio_Technique_DCT
            // 
            this.Radio_Technique_DCT.AutoSize = true;
            this.Radio_Technique_DCT.Location = new System.Drawing.Point(17, 42);
            this.Radio_Technique_DCT.Name = "Radio_Technique_DCT";
            this.Radio_Technique_DCT.Size = new System.Drawing.Size(73, 17);
            this.Radio_Technique_DCT.TabIndex = 4;
            this.Radio_Technique_DCT.Text = "DCT hash";
            this.ToolTip.SetToolTip(this.Radio_Technique_DCT, "Hashing technique: DCT (Discrete Cosine Tranform)");
            this.Radio_Technique_DCT.UseVisualStyleBackColor = true;
            this.Radio_Technique_DCT.CheckedChanged += new System.EventHandler(this.Radio_Technique_DCT_CheckedChanged);
            // 
            // Radio_Technique_Radish
            // 
            this.Radio_Technique_Radish.AutoSize = true;
            this.Radio_Technique_Radish.Checked = true;
            this.Radio_Technique_Radish.Location = new System.Drawing.Point(17, 19);
            this.Radio_Technique_Radish.Name = "Radio_Technique_Radish";
            this.Radio_Technique_Radish.Size = new System.Drawing.Size(131, 17);
            this.Radio_Technique_Radish.TabIndex = 3;
            this.Radio_Technique_Radish.TabStop = true;
            this.Radio_Technique_Radish.Text = "Radial hash (RADISH)";
            this.ToolTip.SetToolTip(this.Radio_Technique_Radish, "Hashing technique: RADISH");
            this.Radio_Technique_Radish.UseVisualStyleBackColor = true;
            this.Radio_Technique_Radish.CheckedChanged += new System.EventHandler(this.Radio_Technique_Radish_CheckedChanged);
            // 
            // ToolTip
            // 
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Information";
            // 
            // TechniqueSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Group_Configuration);
            this.Name = "TechniqueSelection";
            this.Size = new System.Drawing.Size(610, 100);
            this.Group_Configuration.ResumeLayout(false);
            this.Group_Configuration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Wavelet_Level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Wavelet_Alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Angles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Sigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Gamma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Group_Configuration;
        private System.Windows.Forms.RadioButton Radio_Technique_Wavelet;
        private System.Windows.Forms.RadioButton Radio_Technique_DCT;
        private System.Windows.Forms.RadioButton Radio_Technique_Radish;
        private System.Windows.Forms.Label Label_Technique_Radish_Angles;
        private System.Windows.Forms.Label Label_Technique_Radish_Sigma;
        private System.Windows.Forms.Label Label_Technique_Radish_Gamma;
        private System.Windows.Forms.NumericUpDown Number_Technique_Radish_Angles;
        private System.Windows.Forms.NumericUpDown Number_Technique_Radish_Sigma;
        private System.Windows.Forms.NumericUpDown Number_Technique_Radish_Gamma;
        private System.Windows.Forms.Label Label_Technique_Wavelet_Level;
        private System.Windows.Forms.NumericUpDown Number_Technique_Wavelet_Level;
        private System.Windows.Forms.Label Label_Technique_Wavelet_Alpha;
        private System.Windows.Forms.NumericUpDown Number_Technique_Wavelet_Alpha;
        private System.Windows.Forms.ToolTip ToolTip;
    }
}
