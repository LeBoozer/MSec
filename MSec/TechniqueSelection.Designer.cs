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
            this.Combo_Technique_BMB_Method = new System.Windows.Forms.ComboBox();
            this.Label_Technique_BMB_Method = new System.Windows.Forms.Label();
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
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Number_General_Threshold = new System.Windows.Forms.NumericUpDown();
            this.Label_General_Threshold = new System.Windows.Forms.Label();
            this.Group_General = new System.Windows.Forms.GroupBox();
            this.Check_Technique_Radish = new System.Windows.Forms.CheckBox();
            this.Check_Technique_DCT = new System.Windows.Forms.CheckBox();
            this.Check_Technique_Wavelet = new System.Windows.Forms.CheckBox();
            this.Check_Technique_BMB = new System.Windows.Forms.CheckBox();
            this.Group_Configuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Wavelet_Level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Wavelet_Alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Angles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Sigma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Gamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_General_Threshold)).BeginInit();
            this.Group_General.SuspendLayout();
            this.SuspendLayout();
            // 
            // Group_Configuration
            // 
            this.Group_Configuration.Controls.Add(this.Check_Technique_BMB);
            this.Group_Configuration.Controls.Add(this.Check_Technique_Wavelet);
            this.Group_Configuration.Controls.Add(this.Check_Technique_DCT);
            this.Group_Configuration.Controls.Add(this.Check_Technique_Radish);
            this.Group_Configuration.Controls.Add(this.Combo_Technique_BMB_Method);
            this.Group_Configuration.Controls.Add(this.Label_Technique_BMB_Method);
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
            this.Group_Configuration.Location = new System.Drawing.Point(3, 3);
            this.Group_Configuration.Name = "Group_Configuration";
            this.Group_Configuration.Size = new System.Drawing.Size(604, 110);
            this.Group_Configuration.TabIndex = 0;
            this.Group_Configuration.TabStop = false;
            this.Group_Configuration.Text = "Configuration";
            // 
            // Combo_Technique_BMB_Method
            // 
            this.Combo_Technique_BMB_Method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Technique_BMB_Method.FormattingEnabled = true;
            this.Combo_Technique_BMB_Method.Items.AddRange(new object[] {
            "1",
            "2"});
            this.Combo_Technique_BMB_Method.Location = new System.Drawing.Point(224, 86);
            this.Combo_Technique_BMB_Method.Name = "Combo_Technique_BMB_Method";
            this.Combo_Technique_BMB_Method.Size = new System.Drawing.Size(45, 21);
            this.Combo_Technique_BMB_Method.TabIndex = 21;
            this.ToolTip.SetToolTip(this.Combo_Technique_BMB_Method, "1: No overlapping blocks\r\n2: Overlapping blocks (degree: half the block size)");
            this.Combo_Technique_BMB_Method.SelectionChangeCommitted += new System.EventHandler(this.Combo_Technique_BMB_Method_SelectionChangeCommitted);
            // 
            // Label_Technique_BMB_Method
            // 
            this.Label_Technique_BMB_Method.AutoSize = true;
            this.Label_Technique_BMB_Method.Location = new System.Drawing.Point(172, 90);
            this.Label_Technique_BMB_Method.Name = "Label_Technique_BMB_Method";
            this.Label_Technique_BMB_Method.Size = new System.Drawing.Size(46, 13);
            this.Label_Technique_BMB_Method.TabIndex = 20;
            this.Label_Technique_BMB_Method.Text = "Method:";
            // 
            // Label_Technique_Wavelet_Level
            // 
            this.Label_Technique_Wavelet_Level.AutoSize = true;
            this.Label_Technique_Wavelet_Level.Location = new System.Drawing.Point(307, 67);
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
            this.Number_Technique_Wavelet_Level.Location = new System.Drawing.Point(352, 63);
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
            this.Label_Technique_Wavelet_Alpha.Location = new System.Drawing.Point(172, 67);
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
            this.Number_Technique_Wavelet_Alpha.Location = new System.Drawing.Point(224, 63);
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
            // ToolTip
            // 
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Information";
            // 
            // Number_General_Threshold
            // 
            this.Number_General_Threshold.Location = new System.Drawing.Point(9, 40);
            this.Number_General_Threshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Number_General_Threshold.Name = "Number_General_Threshold";
            this.Number_General_Threshold.Size = new System.Drawing.Size(56, 20);
            this.Number_General_Threshold.TabIndex = 19;
            this.Number_General_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ToolTip.SetToolTip(this.Number_General_Threshold, "The lower limit for the degree of similarity\r\nduring the acceptance test");
            this.Number_General_Threshold.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.Number_General_Threshold.ValueChanged += new System.EventHandler(this.Number_General_Threshold_ValueChanged);
            // 
            // Label_General_Threshold
            // 
            this.Label_General_Threshold.AutoSize = true;
            this.Label_General_Threshold.Location = new System.Drawing.Point(9, 21);
            this.Label_General_Threshold.Name = "Label_General_Threshold";
            this.Label_General_Threshold.Size = new System.Drawing.Size(57, 13);
            this.Label_General_Threshold.TabIndex = 1;
            this.Label_General_Threshold.Text = "Threshold:";
            // 
            // Group_General
            // 
            this.Group_General.Controls.Add(this.Number_General_Threshold);
            this.Group_General.Controls.Add(this.Label_General_Threshold);
            this.Group_General.Location = new System.Drawing.Point(613, 3);
            this.Group_General.Name = "Group_General";
            this.Group_General.Size = new System.Drawing.Size(74, 110);
            this.Group_General.TabIndex = 2;
            this.Group_General.TabStop = false;
            this.Group_General.Text = "General";
            // 
            // Check_Technique_Radish
            // 
            this.Check_Technique_Radish.AutoCheck = false;
            this.Check_Technique_Radish.AutoSize = true;
            this.Check_Technique_Radish.Checked = true;
            this.Check_Technique_Radish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Check_Technique_Radish.Location = new System.Drawing.Point(17, 19);
            this.Check_Technique_Radish.Name = "Check_Technique_Radish";
            this.Check_Technique_Radish.Size = new System.Drawing.Size(132, 17);
            this.Check_Technique_Radish.TabIndex = 22;
            this.Check_Technique_Radish.Text = "Radial hash (RADISH)";
            this.Check_Technique_Radish.UseVisualStyleBackColor = true;
            this.Check_Technique_Radish.Click += new System.EventHandler(this.Check_Technique_Radish_Click);
            // 
            // Check_Technique_DCT
            // 
            this.Check_Technique_DCT.AutoCheck = false;
            this.Check_Technique_DCT.AutoSize = true;
            this.Check_Technique_DCT.Location = new System.Drawing.Point(17, 42);
            this.Check_Technique_DCT.Name = "Check_Technique_DCT";
            this.Check_Technique_DCT.Size = new System.Drawing.Size(76, 17);
            this.Check_Technique_DCT.TabIndex = 23;
            this.Check_Technique_DCT.Text = "DCT Hash";
            this.Check_Technique_DCT.UseVisualStyleBackColor = true;
            this.Check_Technique_DCT.Click += new System.EventHandler(this.Check_Technique_DCT_Click);
            // 
            // Check_Technique_Wavelet
            // 
            this.Check_Technique_Wavelet.AutoCheck = false;
            this.Check_Technique_Wavelet.AutoSize = true;
            this.Check_Technique_Wavelet.Location = new System.Drawing.Point(17, 65);
            this.Check_Technique_Wavelet.Name = "Check_Technique_Wavelet";
            this.Check_Technique_Wavelet.Size = new System.Drawing.Size(150, 17);
            this.Check_Technique_Wavelet.TabIndex = 24;
            this.Check_Technique_Wavelet.Text = "Marr/Mexican hat wavelet";
            this.Check_Technique_Wavelet.UseVisualStyleBackColor = true;
            this.Check_Technique_Wavelet.Click += new System.EventHandler(this.Check_Technique_Wavelet_Click);
            // 
            // Check_Technique_BMB
            // 
            this.Check_Technique_BMB.AutoCheck = false;
            this.Check_Technique_BMB.AutoSize = true;
            this.Check_Technique_BMB.Location = new System.Drawing.Point(17, 88);
            this.Check_Technique_BMB.Name = "Check_Technique_BMB";
            this.Check_Technique_BMB.Size = new System.Drawing.Size(77, 17);
            this.Check_Technique_BMB.TabIndex = 25;
            this.Check_Technique_BMB.Text = "BMB Hash";
            this.Check_Technique_BMB.UseVisualStyleBackColor = true;
            this.Check_Technique_BMB.Click += new System.EventHandler(this.Check_Technique_BMB_Click);
            // 
            // TechniqueSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Group_General);
            this.Controls.Add(this.Group_Configuration);
            this.Name = "TechniqueSelection";
            this.Size = new System.Drawing.Size(690, 116);
            this.Group_Configuration.ResumeLayout(false);
            this.Group_Configuration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Wavelet_Level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Wavelet_Alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Angles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Sigma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_Technique_Radish_Gamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Number_General_Threshold)).EndInit();
            this.Group_General.ResumeLayout(false);
            this.Group_General.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Group_Configuration;
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
        private System.Windows.Forms.Label Label_General_Threshold;
        private System.Windows.Forms.GroupBox Group_General;
        private System.Windows.Forms.NumericUpDown Number_General_Threshold;
        private System.Windows.Forms.Label Label_Technique_BMB_Method;
        private System.Windows.Forms.ComboBox Combo_Technique_BMB_Method;
        private System.Windows.Forms.CheckBox Check_Technique_Radish;
        private System.Windows.Forms.CheckBox Check_Technique_BMB;
        private System.Windows.Forms.CheckBox Check_Technique_Wavelet;
        private System.Windows.Forms.CheckBox Check_Technique_DCT;
    }
}
