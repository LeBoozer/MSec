namespace MSec
{
    partial class CC_ComparisonDetails
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
            this.CC_Group_Sources = new System.Windows.Forms.GroupBox();
            this.CC_Picture_Source0 = new System.Windows.Forms.PictureBox();
            this.CC_Picture_Source_1 = new System.Windows.Forms.PictureBox();
            this.CC_Text_Source1 = new System.Windows.Forms.TextBox();
            this.CC_Text_Source0 = new System.Windows.Forms.TextBox();
            this.CC_Group_Sources.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CC_Picture_Source0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CC_Picture_Source_1)).BeginInit();
            this.SuspendLayout();
            // 
            // CC_Group_Sources
            // 
            this.CC_Group_Sources.Controls.Add(this.CC_Text_Source0);
            this.CC_Group_Sources.Controls.Add(this.CC_Text_Source1);
            this.CC_Group_Sources.Controls.Add(this.CC_Picture_Source_1);
            this.CC_Group_Sources.Controls.Add(this.CC_Picture_Source0);
            this.CC_Group_Sources.Location = new System.Drawing.Point(3, 3);
            this.CC_Group_Sources.Name = "CC_Group_Sources";
            this.CC_Group_Sources.Size = new System.Drawing.Size(490, 250);
            this.CC_Group_Sources.TabIndex = 0;
            this.CC_Group_Sources.TabStop = false;
            this.CC_Group_Sources.Text = "Previews";
            // 
            // CC_Picture_Source0
            // 
            this.CC_Picture_Source0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CC_Picture_Source0.Location = new System.Drawing.Point(6, 19);
            this.CC_Picture_Source0.Name = "CC_Picture_Source0";
            this.CC_Picture_Source0.Size = new System.Drawing.Size(234, 198);
            this.CC_Picture_Source0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CC_Picture_Source0.TabIndex = 0;
            this.CC_Picture_Source0.TabStop = false;
            // 
            // CC_Picture_Source_1
            // 
            this.CC_Picture_Source_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CC_Picture_Source_1.Location = new System.Drawing.Point(250, 19);
            this.CC_Picture_Source_1.Name = "CC_Picture_Source_1";
            this.CC_Picture_Source_1.Size = new System.Drawing.Size(234, 198);
            this.CC_Picture_Source_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CC_Picture_Source_1.TabIndex = 1;
            this.CC_Picture_Source_1.TabStop = false;
            // 
            // CC_Text_Source1
            // 
            this.CC_Text_Source1.Location = new System.Drawing.Point(250, 223);
            this.CC_Text_Source1.Name = "CC_Text_Source1";
            this.CC_Text_Source1.ReadOnly = true;
            this.CC_Text_Source1.Size = new System.Drawing.Size(234, 20);
            this.CC_Text_Source1.TabIndex = 2;
            // 
            // CC_Text_Source0
            // 
            this.CC_Text_Source0.Location = new System.Drawing.Point(6, 223);
            this.CC_Text_Source0.Name = "CC_Text_Source0";
            this.CC_Text_Source0.ReadOnly = true;
            this.CC_Text_Source0.Size = new System.Drawing.Size(234, 20);
            this.CC_Text_Source0.TabIndex = 3;
            // 
            // CC_ComparisonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.CC_Group_Sources);
            this.Name = "CC_ComparisonDetails";
            this.Size = new System.Drawing.Size(496, 257);
            this.CC_Group_Sources.ResumeLayout(false);
            this.CC_Group_Sources.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CC_Picture_Source0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CC_Picture_Source_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox CC_Group_Sources;
        private System.Windows.Forms.PictureBox CC_Picture_Source_1;
        private System.Windows.Forms.PictureBox CC_Picture_Source0;
        private System.Windows.Forms.TextBox CC_Text_Source0;
        private System.Windows.Forms.TextBox CC_Text_Source1;

    }
}
