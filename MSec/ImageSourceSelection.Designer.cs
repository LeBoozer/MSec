
partial class ImageSourceSelection
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
            this.Group_ImageSource = new System.Windows.Forms.GroupBox();
            this.Text_Path = new System.Windows.Forms.TextBox();
            this.Text_Instructions = new System.Windows.Forms.TextBox();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.Button_Load = new System.Windows.Forms.Button();
            this.Picture_Preview = new System.Windows.Forms.PictureBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Group_ImageSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // Group_ImageSource
            // 
            this.Group_ImageSource.Controls.Add(this.Text_Path);
            this.Group_ImageSource.Controls.Add(this.Text_Instructions);
            this.Group_ImageSource.Controls.Add(this.Button_Delete);
            this.Group_ImageSource.Controls.Add(this.Button_Load);
            this.Group_ImageSource.Controls.Add(this.Picture_Preview);
            this.Group_ImageSource.Location = new System.Drawing.Point(3, 3);
            this.Group_ImageSource.Name = "Group_ImageSource";
            this.Group_ImageSource.Size = new System.Drawing.Size(312, 326);
            this.Group_ImageSource.TabIndex = 0;
            this.Group_ImageSource.TabStop = false;
            this.Group_ImageSource.Text = "Image source";
            // 
            // Text_Path
            // 
            this.Text_Path.Location = new System.Drawing.Point(6, 238);
            this.Text_Path.Name = "Text_Path";
            this.Text_Path.ReadOnly = true;
            this.Text_Path.Size = new System.Drawing.Size(298, 20);
            this.Text_Path.TabIndex = 4;
            this.ToolTip.SetToolTip(this.Text_Path, "Contains the path of the\r\nselected image source");
            // 
            // Text_Instructions
            // 
            this.Text_Instructions.Location = new System.Drawing.Point(6, 266);
            this.Text_Instructions.Multiline = true;
            this.Text_Instructions.Name = "Text_Instructions";
            this.Text_Instructions.ReadOnly = true;
            this.Text_Instructions.Size = new System.Drawing.Size(269, 52);
            this.Text_Instructions.TabIndex = 3;
            this.ToolTip.SetToolTip(this.Text_Instructions, "Displays informations about the current\r\noperation or the computed image hash");
            // 
            // Button_Delete
            // 
            this.Button_Delete.BackgroundImage = global::MSec.Properties.Resources.delete;
            this.Button_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_Delete.Location = new System.Drawing.Point(281, 295);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(23, 23);
            this.Button_Delete.TabIndex = 2;
            this.ToolTip.SetToolTip(this.Button_Delete, "Deletes the currently selected image");
            this.Button_Delete.UseVisualStyleBackColor = true;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Button_Load
            // 
            this.Button_Load.BackgroundImage = global::MSec.Properties.Resources.add;
            this.Button_Load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_Load.Location = new System.Drawing.Point(281, 266);
            this.Button_Load.Name = "Button_Load";
            this.Button_Load.Size = new System.Drawing.Size(23, 23);
            this.Button_Load.TabIndex = 1;
            this.ToolTip.SetToolTip(this.Button_Load, "Selects a new image");
            this.Button_Load.UseVisualStyleBackColor = true;
            this.Button_Load.Click += new System.EventHandler(this.Button_Load_Click);
            // 
            // Picture_Preview
            // 
            this.Picture_Preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Picture_Preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Picture_Preview.Location = new System.Drawing.Point(6, 19);
            this.Picture_Preview.Name = "Picture_Preview";
            this.Picture_Preview.Size = new System.Drawing.Size(298, 212);
            this.Picture_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Picture_Preview.TabIndex = 0;
            this.Picture_Preview.TabStop = false;
            this.ToolTip.SetToolTip(this.Picture_Preview, "Preview of the selected image");
            // 
            // ToolTip
            // 
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Information";
            // 
            // ImageSourceSelection
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Group_ImageSource);
            this.Name = "ImageSourceSelection";
            this.Size = new System.Drawing.Size(317, 331);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImageSourceSelection_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImageSourceSelection_DragEnter);
            this.Group_ImageSource.ResumeLayout(false);
            this.Group_ImageSource.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_Preview)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox Group_ImageSource;
    private System.Windows.Forms.PictureBox Picture_Preview;
    private System.Windows.Forms.TextBox Text_Instructions;
    private System.Windows.Forms.Button Button_Delete;
    private System.Windows.Forms.Button Button_Load;
    private System.Windows.Forms.ToolTip ToolTip;
    private System.Windows.Forms.TextBox Text_Path;
}
