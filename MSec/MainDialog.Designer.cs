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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            this.MainDialog_MainTab = new System.Windows.Forms.TabControl();
            this.pageImageVsImage = new System.Windows.Forms.TabPage();
            this.Selection_Technique = new TechniqueSelection();
            this.Progress_ImageVsImage = new System.Windows.Forms.ProgressBar();
            this.Label_ImageVsImage_Result = new System.Windows.Forms.Label();
            this.Button_ImageVsImage_Compute = new System.Windows.Forms.Button();
            this.Selection_ImageSource1 = new ImageSourceSelection();
            this.Selection_ImageSource0 = new ImageSourceSelection();
            this.pageCrossComparison = new System.Windows.Forms.TabPage();
            this.CC_ToolStrip = new System.Windows.Forms.StatusStrip();
            this.CC_ToolStrip_Label_Action = new System.Windows.Forms.ToolStripStatusLabel();
            this.CC_ToolStrip_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.CC_List_Results = new ListViewFlickerFree();
            this.columnAccepted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnImageSource0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnImageSource1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHash0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHash1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnMatch = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageList_CC_List_Results = new System.Windows.Forms.ImageList(this.components);
            this.CC_Group_SourceLocation = new System.Windows.Forms.GroupBox();
            this.CC_Label_ReferenceFolder_NumSources = new System.Windows.Forms.Label();
            this.CC_Button_ReferenceFolder_Start = new System.Windows.Forms.Button();
            this.CC_Button_ReferenceFolder_Delete = new System.Windows.Forms.Button();
            this.CC_Button_ReferenceFolder_Select = new System.Windows.Forms.Button();
            this.CC_Label_ReferenceFolder = new System.Windows.Forms.Label();
            this.CC_Text_ReferenceFolder_Path = new System.Windows.Forms.TextBox();
            this.CC_Selection_Technique = new TechniqueSelection();
            this.ImageList_MainTab = new System.Windows.Forms.ImageList(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Menu_Main = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.MainDialog_MainTab.SuspendLayout();
            this.pageImageVsImage.SuspendLayout();
            this.pageCrossComparison.SuspendLayout();
            this.CC_ToolStrip.SuspendLayout();
            this.CC_Group_SourceLocation.SuspendLayout();
            this.Menu_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainDialog_MainTab
            // 
            this.MainDialog_MainTab.Controls.Add(this.pageImageVsImage);
            this.MainDialog_MainTab.Controls.Add(this.pageCrossComparison);
            this.MainDialog_MainTab.ImageList = this.ImageList_MainTab;
            this.MainDialog_MainTab.Location = new System.Drawing.Point(12, 27);
            this.MainDialog_MainTab.Name = "MainDialog_MainTab";
            this.MainDialog_MainTab.SelectedIndex = 0;
            this.MainDialog_MainTab.Size = new System.Drawing.Size(705, 523);
            this.MainDialog_MainTab.TabIndex = 0;
            // 
            // pageImageVsImage
            // 
            this.pageImageVsImage.Controls.Add(this.Selection_Technique);
            this.pageImageVsImage.Controls.Add(this.Progress_ImageVsImage);
            this.pageImageVsImage.Controls.Add(this.Label_ImageVsImage_Result);
            this.pageImageVsImage.Controls.Add(this.Button_ImageVsImage_Compute);
            this.pageImageVsImage.Controls.Add(this.Selection_ImageSource1);
            this.pageImageVsImage.Controls.Add(this.Selection_ImageSource0);
            this.pageImageVsImage.ImageIndex = 0;
            this.pageImageVsImage.Location = new System.Drawing.Point(4, 23);
            this.pageImageVsImage.Name = "pageImageVsImage";
            this.pageImageVsImage.Size = new System.Drawing.Size(697, 496);
            this.pageImageVsImage.TabIndex = 1;
            this.pageImageVsImage.Text = "Image vs. Image";
            this.pageImageVsImage.UseVisualStyleBackColor = true;
            // 
            // Selection_Technique
            // 
            this.Selection_Technique.Location = new System.Drawing.Point(3, 0);
            this.Selection_Technique.Name = "Selection_Technique";
            this.Selection_Technique.Size = new System.Drawing.Size(690, 100);
            this.Selection_Technique.TabIndex = 8;
            // 
            // Progress_ImageVsImage
            // 
            this.Progress_ImageVsImage.Enabled = false;
            this.Progress_ImageVsImage.Location = new System.Drawing.Point(3, 480);
            this.Progress_ImageVsImage.MarqueeAnimationSpeed = 20;
            this.Progress_ImageVsImage.Name = "Progress_ImageVsImage";
            this.Progress_ImageVsImage.Size = new System.Drawing.Size(690, 10);
            this.Progress_ImageVsImage.Step = 20;
            this.Progress_ImageVsImage.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.Progress_ImageVsImage.TabIndex = 7;
            this.Progress_ImageVsImage.Visible = false;
            // 
            // Label_ImageVsImage_Result
            // 
            this.Label_ImageVsImage_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ImageVsImage_Result.Location = new System.Drawing.Point(4, 445);
            this.Label_ImageVsImage_Result.Name = "Label_ImageVsImage_Result";
            this.Label_ImageVsImage_Result.Size = new System.Drawing.Size(690, 32);
            this.Label_ImageVsImage_Result.TabIndex = 6;
            this.Label_ImageVsImage_Result.Text = "-";
            this.Label_ImageVsImage_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTip.SetToolTip(this.Label_ImageVsImage_Result, "Statements about the equality of both images\r\n(green = above threshold, red = bel" +
        "ow threshold)\r\n");
            // 
            // Button_ImageVsImage_Compute
            // 
            this.Button_ImageVsImage_Compute.BackgroundImage = global::MSec.Properties.Resources.compare;
            this.Button_ImageVsImage_Compute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_ImageVsImage_Compute.Enabled = false;
            this.Button_ImageVsImage_Compute.Location = new System.Drawing.Point(326, 236);
            this.Button_ImageVsImage_Compute.Name = "Button_ImageVsImage_Compute";
            this.Button_ImageVsImage_Compute.Size = new System.Drawing.Size(45, 40);
            this.Button_ImageVsImage_Compute.TabIndex = 5;
            this.ToolTip.SetToolTip(this.Button_ImageVsImage_Compute, "Starts the hashing of both selected images and the subsequent comparison");
            this.Button_ImageVsImage_Compute.UseVisualStyleBackColor = true;
            // 
            // Selection_ImageSource1
            // 
            this.Selection_ImageSource1.AllowDrop = true;
            this.Selection_ImageSource1.Location = new System.Drawing.Point(376, 106);
            this.Selection_ImageSource1.Name = "Selection_ImageSource1";
            this.Selection_ImageSource1.Size = new System.Drawing.Size(317, 336);
            this.Selection_ImageSource1.TabIndex = 4;
            // 
            // Selection_ImageSource0
            // 
            this.Selection_ImageSource0.AllowDrop = true;
            this.Selection_ImageSource0.Location = new System.Drawing.Point(3, 106);
            this.Selection_ImageSource0.Name = "Selection_ImageSource0";
            this.Selection_ImageSource0.Size = new System.Drawing.Size(317, 336);
            this.Selection_ImageSource0.TabIndex = 3;
            // 
            // pageCrossComparison
            // 
            this.pageCrossComparison.Controls.Add(this.CC_ToolStrip);
            this.pageCrossComparison.Controls.Add(this.CC_List_Results);
            this.pageCrossComparison.Controls.Add(this.CC_Group_SourceLocation);
            this.pageCrossComparison.Controls.Add(this.CC_Selection_Technique);
            this.pageCrossComparison.ImageIndex = 1;
            this.pageCrossComparison.Location = new System.Drawing.Point(4, 23);
            this.pageCrossComparison.Name = "pageCrossComparison";
            this.pageCrossComparison.Size = new System.Drawing.Size(697, 496);
            this.pageCrossComparison.TabIndex = 2;
            this.pageCrossComparison.Text = "Cross Comparison";
            this.pageCrossComparison.UseVisualStyleBackColor = true;
            // 
            // CC_ToolStrip
            // 
            this.CC_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CC_ToolStrip_Label_Action,
            this.CC_ToolStrip_Progress});
            this.CC_ToolStrip.Location = new System.Drawing.Point(0, 474);
            this.CC_ToolStrip.Name = "CC_ToolStrip";
            this.CC_ToolStrip.Size = new System.Drawing.Size(697, 22);
            this.CC_ToolStrip.TabIndex = 3;
            this.CC_ToolStrip.Text = "statusStrip1";
            // 
            // CC_ToolStrip_Label_Action
            // 
            this.CC_ToolStrip_Label_Action.Name = "CC_ToolStrip_Label_Action";
            this.CC_ToolStrip_Label_Action.Size = new System.Drawing.Size(55, 17);
            this.CC_ToolStrip_Label_Action.Text = "Text here";
            // 
            // CC_ToolStrip_Progress
            // 
            this.CC_ToolStrip_Progress.MarqueeAnimationSpeed = 20;
            this.CC_ToolStrip_Progress.Name = "CC_ToolStrip_Progress";
            this.CC_ToolStrip_Progress.Size = new System.Drawing.Size(400, 16);
            this.CC_ToolStrip_Progress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.CC_ToolStrip_Progress.Visible = false;
            // 
            // CC_List_Results
            // 
            this.CC_List_Results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnAccepted,
            this.columnImageSource0,
            this.columnImageSource1,
            this.columnHash0,
            this.columnHash1,
            this.columnMatch});
            this.CC_List_Results.FullRowSelect = true;
            this.CC_List_Results.GridLines = true;
            this.CC_List_Results.HideSelection = false;
            this.CC_List_Results.Location = new System.Drawing.Point(3, 147);
            this.CC_List_Results.MultiSelect = false;
            this.CC_List_Results.Name = "CC_List_Results";
            this.CC_List_Results.Size = new System.Drawing.Size(690, 311);
            this.CC_List_Results.SmallImageList = this.ImageList_CC_List_Results;
            this.CC_List_Results.TabIndex = 2;
            this.ToolTip.SetToolTip(this.CC_List_Results, "Contains an brief overview of the hashed/compared\r\nimage sources.");
            this.CC_List_Results.UseCompatibleStateImageBehavior = false;
            this.CC_List_Results.View = System.Windows.Forms.View.Details;
            // 
            // columnAccepted
            // 
            this.columnAccepted.Text = "";
            this.columnAccepted.Width = 26;
            // 
            // columnImageSource0
            // 
            this.columnImageSource0.Text = "Image source 0";
            this.columnImageSource0.Width = 150;
            // 
            // columnImageSource1
            // 
            this.columnImageSource1.Text = "Image source 1";
            this.columnImageSource1.Width = 150;
            // 
            // columnHash0
            // 
            this.columnHash0.Text = "Hash 0";
            this.columnHash0.Width = 120;
            // 
            // columnHash1
            // 
            this.columnHash1.Text = "Hash 1";
            this.columnHash1.Width = 120;
            // 
            // columnMatch
            // 
            this.columnMatch.Text = "Match (%)";
            this.columnMatch.Width = 70;
            // 
            // ImageList_CC_List_Results
            // 
            this.ImageList_CC_List_Results.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_CC_List_Results.ImageStream")));
            this.ImageList_CC_List_Results.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_CC_List_Results.Images.SetKeyName(0, "checkmark.png");
            this.ImageList_CC_List_Results.Images.SetKeyName(1, "cross.png");
            // 
            // CC_Group_SourceLocation
            // 
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Label_ReferenceFolder_NumSources);
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Button_ReferenceFolder_Start);
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Button_ReferenceFolder_Delete);
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Button_ReferenceFolder_Select);
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Label_ReferenceFolder);
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Text_ReferenceFolder_Path);
            this.CC_Group_SourceLocation.Location = new System.Drawing.Point(3, 97);
            this.CC_Group_SourceLocation.Name = "CC_Group_SourceLocation";
            this.CC_Group_SourceLocation.Size = new System.Drawing.Size(690, 44);
            this.CC_Group_SourceLocation.TabIndex = 1;
            this.CC_Group_SourceLocation.TabStop = false;
            this.CC_Group_SourceLocation.Text = "Reference folder";
            // 
            // CC_Label_ReferenceFolder_NumSources
            // 
            this.CC_Label_ReferenceFolder_NumSources.Location = new System.Drawing.Point(547, 21);
            this.CC_Label_ReferenceFolder_NumSources.Name = "CC_Label_ReferenceFolder_NumSources";
            this.CC_Label_ReferenceFolder_NumSources.Size = new System.Drawing.Size(137, 13);
            this.CC_Label_ReferenceFolder_NumSources.TabIndex = 10;
            this.CC_Label_ReferenceFolder_NumSources.Text = "Image source count: 0";
            this.CC_Label_ReferenceFolder_NumSources.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CC_Button_ReferenceFolder_Start
            // 
            this.CC_Button_ReferenceFolder_Start.BackgroundImage = global::MSec.Properties.Resources.play;
            this.CC_Button_ReferenceFolder_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CC_Button_ReferenceFolder_Start.Enabled = false;
            this.CC_Button_ReferenceFolder_Start.Location = new System.Drawing.Point(337, 16);
            this.CC_Button_ReferenceFolder_Start.Name = "CC_Button_ReferenceFolder_Start";
            this.CC_Button_ReferenceFolder_Start.Size = new System.Drawing.Size(23, 23);
            this.CC_Button_ReferenceFolder_Start.TabIndex = 9;
            this.ToolTip.SetToolTip(this.CC_Button_ReferenceFolder_Start, "Executes the hashing and the subsequent\r\ncomparison of those hashes.");
            this.CC_Button_ReferenceFolder_Start.UseVisualStyleBackColor = true;
            // 
            // CC_Button_ReferenceFolder_Delete
            // 
            this.CC_Button_ReferenceFolder_Delete.BackgroundImage = global::MSec.Properties.Resources.delete;
            this.CC_Button_ReferenceFolder_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CC_Button_ReferenceFolder_Delete.Location = new System.Drawing.Point(308, 16);
            this.CC_Button_ReferenceFolder_Delete.Name = "CC_Button_ReferenceFolder_Delete";
            this.CC_Button_ReferenceFolder_Delete.Size = new System.Drawing.Size(23, 23);
            this.CC_Button_ReferenceFolder_Delete.TabIndex = 8;
            this.ToolTip.SetToolTip(this.CC_Button_ReferenceFolder_Delete, "Deletes the currently selected image sources.\r\nDoes not delete the comparison dat" +
        "a!");
            this.CC_Button_ReferenceFolder_Delete.UseVisualStyleBackColor = true;
            // 
            // CC_Button_ReferenceFolder_Select
            // 
            this.CC_Button_ReferenceFolder_Select.BackgroundImage = global::MSec.Properties.Resources.add;
            this.CC_Button_ReferenceFolder_Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CC_Button_ReferenceFolder_Select.Location = new System.Drawing.Point(279, 16);
            this.CC_Button_ReferenceFolder_Select.Name = "CC_Button_ReferenceFolder_Select";
            this.CC_Button_ReferenceFolder_Select.Size = new System.Drawing.Size(23, 23);
            this.CC_Button_ReferenceFolder_Select.TabIndex = 7;
            this.ToolTip.SetToolTip(this.CC_Button_ReferenceFolder_Select, "Selects a folder with image sources.\r\nSubfolders will be searched recursively.");
            this.CC_Button_ReferenceFolder_Select.UseVisualStyleBackColor = true;
            // 
            // CC_Label_ReferenceFolder
            // 
            this.CC_Label_ReferenceFolder.AutoSize = true;
            this.CC_Label_ReferenceFolder.Location = new System.Drawing.Point(6, 21);
            this.CC_Label_ReferenceFolder.Name = "CC_Label_ReferenceFolder";
            this.CC_Label_ReferenceFolder.Size = new System.Drawing.Size(32, 13);
            this.CC_Label_ReferenceFolder.TabIndex = 6;
            this.CC_Label_ReferenceFolder.Text = "Path:";
            // 
            // CC_Text_ReferenceFolder_Path
            // 
            this.CC_Text_ReferenceFolder_Path.Location = new System.Drawing.Point(40, 17);
            this.CC_Text_ReferenceFolder_Path.Name = "CC_Text_ReferenceFolder_Path";
            this.CC_Text_ReferenceFolder_Path.ReadOnly = true;
            this.CC_Text_ReferenceFolder_Path.Size = new System.Drawing.Size(233, 20);
            this.CC_Text_ReferenceFolder_Path.TabIndex = 5;
            this.ToolTip.SetToolTip(this.CC_Text_ReferenceFolder_Path, "Contains the path of the source folder\r\nfor the image sources.");
            // 
            // CC_Selection_Technique
            // 
            this.CC_Selection_Technique.Location = new System.Drawing.Point(3, 0);
            this.CC_Selection_Technique.Name = "CC_Selection_Technique";
            this.CC_Selection_Technique.Size = new System.Drawing.Size(690, 100);
            this.CC_Selection_Technique.TabIndex = 0;
            // 
            // ImageList_MainTab
            // 
            this.ImageList_MainTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList_MainTab.ImageStream")));
            this.ImageList_MainTab.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList_MainTab.Images.SetKeyName(0, "compare.png");
            this.ImageList_MainTab.Images.SetKeyName(1, "arrows.png");
            // 
            // ToolTip
            // 
            this.ToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip.ToolTipTitle = "Information";
            // 
            // Menu_Main
            // 
            this.Menu_Main.BackColor = System.Drawing.Color.LightGray;
            this.Menu_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.Menu_Main.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.Menu_Main.Location = new System.Drawing.Point(0, 0);
            this.Menu_Main.Name = "Menu_Main";
            this.Menu_Main.Size = new System.Drawing.Size(726, 24);
            this.Menu_Main.TabIndex = 1;
            this.Menu_Main.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Image = global::MSec.Properties.Resources.information;
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(560, 553);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(42, 13);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Freepik";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 553);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Icons made by";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 553);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "from";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(622, 553);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(94, 13);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "www.flaticon.com ";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 553);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Powered by";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(72, 553);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(68, 13);
            this.linkLabel3.TabIndex = 13;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "pHash library";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(726, 572);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.MainDialog_MainTab);
            this.Controls.Add(this.Menu_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menu_Main;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(742, 611);
            this.MinimizeBox = false;
            this.Name = "MainDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Percuptual Image Hashing";
            this.MainDialog_MainTab.ResumeLayout(false);
            this.pageImageVsImage.ResumeLayout(false);
            this.pageCrossComparison.ResumeLayout(false);
            this.pageCrossComparison.PerformLayout();
            this.CC_ToolStrip.ResumeLayout(false);
            this.CC_ToolStrip.PerformLayout();
            this.CC_Group_SourceLocation.ResumeLayout(false);
            this.CC_Group_SourceLocation.PerformLayout();
            this.Menu_Main.ResumeLayout(false);
            this.Menu_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl MainDialog_MainTab;
        private System.Windows.Forms.TabPage pageImageVsImage;
        private ImageSourceSelection Selection_ImageSource1;
        private ImageSourceSelection Selection_ImageSource0;
        private System.Windows.Forms.Button Button_ImageVsImage_Compute;
        private System.Windows.Forms.Label Label_ImageVsImage_Result;
        private System.Windows.Forms.ProgressBar Progress_ImageVsImage;
        private System.Windows.Forms.ToolTip ToolTip;
        private TechniqueSelection Selection_Technique;
        private System.Windows.Forms.MenuStrip Menu_Main;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.ImageList ImageList_MainTab;
        private System.Windows.Forms.TabPage pageCrossComparison;
        private TechniqueSelection CC_Selection_Technique;
        private System.Windows.Forms.GroupBox CC_Group_SourceLocation;
        private ListViewFlickerFree CC_List_Results;
        private System.Windows.Forms.ColumnHeader columnAccepted;
        private System.Windows.Forms.ColumnHeader columnImageSource0;
        private System.Windows.Forms.ColumnHeader columnImageSource1;
        private System.Windows.Forms.ColumnHeader columnHash0;
        private System.Windows.Forms.ColumnHeader columnHash1;
        private System.Windows.Forms.ColumnHeader columnMatch;
        private System.Windows.Forms.Label CC_Label_ReferenceFolder;
        private System.Windows.Forms.TextBox CC_Text_ReferenceFolder_Path;
        private System.Windows.Forms.Button CC_Button_ReferenceFolder_Select;
        private System.Windows.Forms.Button CC_Button_ReferenceFolder_Delete;
        private System.Windows.Forms.StatusStrip CC_ToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel CC_ToolStrip_Label_Action;
        private System.Windows.Forms.ToolStripProgressBar CC_ToolStrip_Progress;
        private System.Windows.Forms.Button CC_Button_ReferenceFolder_Start;
        private System.Windows.Forms.ImageList ImageList_CC_List_Results;
        private System.Windows.Forms.Label CC_Label_ReferenceFolder_NumSources;
    }
}

