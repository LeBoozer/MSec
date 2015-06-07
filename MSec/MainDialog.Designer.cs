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
            this.CC_Group_Controls = new System.Windows.Forms.GroupBox();
            this.CC_Button_Controls_SelectAll = new System.Windows.Forms.Button();
            this.CC_Button_Controls_CollapseGroups = new System.Windows.Forms.Button();
            this.CC_Button_ReferenceFolder_Start = new System.Windows.Forms.Button();
            this.CC_List_Results = new BrightIdeasSoftware.FastObjectListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label5 = new System.Windows.Forms.Label();
            this.CC_Label_ResultCount = new System.Windows.Forms.Label();
            this.CC_Text_Filter = new System.Windows.Forms.ComboBox();
            this.CC_ToolStrip = new System.Windows.Forms.StatusStrip();
            this.CC_ToolStrip_Label_Action = new System.Windows.Forms.ToolStripStatusLabel();
            this.CC_ToolStrip_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.CC_Group_SourceLocation = new System.Windows.Forms.GroupBox();
            this.CC_Label_ReferenceFolder_NumSources = new System.Windows.Forms.Label();
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
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.Test = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.MainDialog_MainTab.SuspendLayout();
            this.pageImageVsImage.SuspendLayout();
            this.pageCrossComparison.SuspendLayout();
            this.CC_Group_Controls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CC_List_Results)).BeginInit();
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
            this.MainDialog_MainTab.Size = new System.Drawing.Size(705, 568);
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
            this.pageImageVsImage.Size = new System.Drawing.Size(697, 541);
            this.pageImageVsImage.TabIndex = 1;
            this.pageImageVsImage.Text = "Image vs. Image";
            this.pageImageVsImage.UseVisualStyleBackColor = true;
            // 
            // Selection_Technique
            // 
            this.Selection_Technique.Location = new System.Drawing.Point(3, 0);
            this.Selection_Technique.Name = "Selection_Technique";
            this.Selection_Technique.OperationMode = TechniqueSelection.eMode.SINGLE;
            this.Selection_Technique.Size = new System.Drawing.Size(690, 117);
            this.Selection_Technique.TabIndex = 8;
            // 
            // Progress_ImageVsImage
            // 
            this.Progress_ImageVsImage.Enabled = false;
            this.Progress_ImageVsImage.Location = new System.Drawing.Point(3, 528);
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
            this.Label_ImageVsImage_Result.Location = new System.Drawing.Point(4, 474);
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
            this.Button_ImageVsImage_Compute.Location = new System.Drawing.Point(326, 246);
            this.Button_ImageVsImage_Compute.Name = "Button_ImageVsImage_Compute";
            this.Button_ImageVsImage_Compute.Size = new System.Drawing.Size(45, 40);
            this.Button_ImageVsImage_Compute.TabIndex = 5;
            this.ToolTip.SetToolTip(this.Button_ImageVsImage_Compute, "Starts the hashing of both selected images and the subsequent comparison");
            this.Button_ImageVsImage_Compute.UseVisualStyleBackColor = true;
            // 
            // Selection_ImageSource1
            // 
            this.Selection_ImageSource1.AllowDrop = true;
            this.Selection_ImageSource1.Location = new System.Drawing.Point(376, 116);
            this.Selection_ImageSource1.Name = "Selection_ImageSource1";
            this.Selection_ImageSource1.Size = new System.Drawing.Size(317, 336);
            this.Selection_ImageSource1.TabIndex = 4;
            // 
            // Selection_ImageSource0
            // 
            this.Selection_ImageSource0.AllowDrop = true;
            this.Selection_ImageSource0.Location = new System.Drawing.Point(3, 116);
            this.Selection_ImageSource0.Name = "Selection_ImageSource0";
            this.Selection_ImageSource0.Size = new System.Drawing.Size(317, 336);
            this.Selection_ImageSource0.TabIndex = 3;
            // 
            // pageCrossComparison
            // 
            this.pageCrossComparison.Controls.Add(this.CC_Group_Controls);
            this.pageCrossComparison.Controls.Add(this.CC_List_Results);
            this.pageCrossComparison.Controls.Add(this.label5);
            this.pageCrossComparison.Controls.Add(this.CC_Label_ResultCount);
            this.pageCrossComparison.Controls.Add(this.CC_Text_Filter);
            this.pageCrossComparison.Controls.Add(this.CC_ToolStrip);
            this.pageCrossComparison.Controls.Add(this.CC_Group_SourceLocation);
            this.pageCrossComparison.Controls.Add(this.CC_Selection_Technique);
            this.pageCrossComparison.ImageIndex = 1;
            this.pageCrossComparison.Location = new System.Drawing.Point(4, 23);
            this.pageCrossComparison.Name = "pageCrossComparison";
            this.pageCrossComparison.Size = new System.Drawing.Size(697, 541);
            this.pageCrossComparison.TabIndex = 2;
            this.pageCrossComparison.Text = "Cross Comparison";
            this.pageCrossComparison.UseVisualStyleBackColor = true;
            // 
            // CC_Group_Controls
            // 
            this.CC_Group_Controls.Controls.Add(this.CC_Button_Controls_SelectAll);
            this.CC_Group_Controls.Controls.Add(this.CC_Button_Controls_CollapseGroups);
            this.CC_Group_Controls.Controls.Add(this.CC_Button_ReferenceFolder_Start);
            this.CC_Group_Controls.Location = new System.Drawing.Point(490, 117);
            this.CC_Group_Controls.Name = "CC_Group_Controls";
            this.CC_Group_Controls.Size = new System.Drawing.Size(203, 44);
            this.CC_Group_Controls.TabIndex = 14;
            this.CC_Group_Controls.TabStop = false;
            this.CC_Group_Controls.Text = "Controls";
            // 
            // CC_Button_Controls_SelectAll
            // 
            this.CC_Button_Controls_SelectAll.BackgroundImage = global::MSec.Properties.Resources.selectall;
            this.CC_Button_Controls_SelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CC_Button_Controls_SelectAll.Enabled = false;
            this.CC_Button_Controls_SelectAll.Location = new System.Drawing.Point(78, 16);
            this.CC_Button_Controls_SelectAll.Name = "CC_Button_Controls_SelectAll";
            this.CC_Button_Controls_SelectAll.Size = new System.Drawing.Size(23, 23);
            this.CC_Button_Controls_SelectAll.TabIndex = 11;
            this.ToolTip.SetToolTip(this.CC_Button_Controls_SelectAll, "Select all items in the list");
            this.CC_Button_Controls_SelectAll.UseVisualStyleBackColor = true;
            // 
            // CC_Button_Controls_CollapseGroups
            // 
            this.CC_Button_Controls_CollapseGroups.BackgroundImage = global::MSec.Properties.Resources.collapse1;
            this.CC_Button_Controls_CollapseGroups.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CC_Button_Controls_CollapseGroups.Enabled = false;
            this.CC_Button_Controls_CollapseGroups.Location = new System.Drawing.Point(49, 16);
            this.CC_Button_Controls_CollapseGroups.Name = "CC_Button_Controls_CollapseGroups";
            this.CC_Button_Controls_CollapseGroups.Size = new System.Drawing.Size(23, 23);
            this.CC_Button_Controls_CollapseGroups.TabIndex = 10;
            this.ToolTip.SetToolTip(this.CC_Button_Controls_CollapseGroups, "Collapses all visible groups.");
            this.CC_Button_Controls_CollapseGroups.UseVisualStyleBackColor = true;
            // 
            // CC_Button_ReferenceFolder_Start
            // 
            this.CC_Button_ReferenceFolder_Start.BackgroundImage = global::MSec.Properties.Resources.play;
            this.CC_Button_ReferenceFolder_Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CC_Button_ReferenceFolder_Start.Enabled = false;
            this.CC_Button_ReferenceFolder_Start.Location = new System.Drawing.Point(20, 16);
            this.CC_Button_ReferenceFolder_Start.Name = "CC_Button_ReferenceFolder_Start";
            this.CC_Button_ReferenceFolder_Start.Size = new System.Drawing.Size(23, 23);
            this.CC_Button_ReferenceFolder_Start.TabIndex = 9;
            this.ToolTip.SetToolTip(this.CC_Button_ReferenceFolder_Start, "Executes the hashing and the subsequent\r\ncomparison of those hashes.");
            this.CC_Button_ReferenceFolder_Start.UseVisualStyleBackColor = true;
            // 
            // CC_List_Results
            // 
            this.CC_List_Results.AllColumns.Add(this.olvColumn2);
            this.CC_List_Results.AllColumns.Add(this.olvColumn3);
            this.CC_List_Results.AllColumns.Add(this.olvColumn6);
            this.CC_List_Results.AllColumns.Add(this.olvColumn4);
            this.CC_List_Results.AllColumns.Add(this.olvColumn7);
            this.CC_List_Results.AllColumns.Add(this.olvColumn8);
            this.CC_List_Results.AllColumns.Add(this.olvColumn1);
            this.CC_List_Results.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn6,
            this.olvColumn4,
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn1});
            this.CC_List_Results.FullRowSelect = true;
            this.CC_List_Results.GridLines = true;
            this.CC_List_Results.HeaderUsesThemes = true;
            this.CC_List_Results.HideSelection = false;
            this.CC_List_Results.Location = new System.Drawing.Point(3, 167);
            this.CC_List_Results.Name = "CC_List_Results";
            this.CC_List_Results.ShowGroups = false;
            this.CC_List_Results.ShowItemCountOnGroups = true;
            this.CC_List_Results.Size = new System.Drawing.Size(690, 319);
            this.CC_List_Results.TabIndex = 13;
            this.CC_List_Results.UseCellFormatEvents = true;
            this.CC_List_Results.UseCompatibleStateImageBehavior = false;
            this.CC_List_Results.View = System.Windows.Forms.View.Details;
            this.CC_List_Results.VirtualMode = true;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Source0.FileName";
            this.olvColumn2.Hideable = false;
            this.olvColumn2.Sortable = false;
            this.olvColumn2.Text = "Image source 0";
            this.olvColumn2.Width = 140;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Source1.FileName";
            this.olvColumn3.Hideable = false;
            this.olvColumn3.Sortable = false;
            this.olvColumn3.Text = "Image source 1";
            this.olvColumn3.Width = 140;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "MatchRateRADISH";
            this.olvColumn6.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Sortable = false;
            this.olvColumn6.Tag = "MatchRateRADISH";
            this.olvColumn6.Text = "RADISH (%)";
            this.olvColumn6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn6.Width = 75;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "MatchRateDCT";
            this.olvColumn4.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Sortable = false;
            this.olvColumn4.Tag = "MatchRateDCT";
            this.olvColumn4.Text = "DCT (%)";
            this.olvColumn4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn4.Width = 70;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "MatchRateWavelet";
            this.olvColumn7.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Sortable = false;
            this.olvColumn7.Tag = "MatchRateWavelet";
            this.olvColumn7.Text = "Wavelet (%)";
            this.olvColumn7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn7.Width = 80;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "MatchRateBMB";
            this.olvColumn8.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Sortable = false;
            this.olvColumn8.Tag = "MatchRateBMB";
            this.olvColumn8.Text = "BMB (%)";
            this.olvColumn8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn8.Width = 70;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "MatchRateAVG";
            this.olvColumn1.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Hideable = false;
            this.olvColumn1.Sortable = false;
            this.olvColumn1.Tag = "MatchRateAverage";
            this.olvColumn1.Text = "Average (%)";
            this.olvColumn1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.olvColumn1.Width = 80;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 496);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Filter (DLinq):";
            // 
            // CC_Label_ResultCount
            // 
            this.CC_Label_ResultCount.Location = new System.Drawing.Point(583, 496);
            this.CC_Label_ResultCount.Name = "CC_Label_ResultCount";
            this.CC_Label_ResultCount.Size = new System.Drawing.Size(110, 13);
            this.CC_Label_ResultCount.TabIndex = 11;
            this.CC_Label_ResultCount.Text = "Result count: 0";
            this.CC_Label_ResultCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CC_Text_Filter
            // 
            this.CC_Text_Filter.Location = new System.Drawing.Point(78, 492);
            this.CC_Text_Filter.Name = "CC_Text_Filter";
            this.CC_Text_Filter.Size = new System.Drawing.Size(499, 21);
            this.CC_Text_Filter.TabIndex = 4;
            this.ToolTip.SetToolTip(this.CC_Text_Filter, "Filters can be used to select just a subset\r\nof results from the cross comparison" +
        ".\r\nFor further informations about the syntax\r\nof the expression language see the" +
        " attached\r\nfile: Filter.txt");
            // 
            // CC_ToolStrip
            // 
            this.CC_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CC_ToolStrip_Label_Action,
            this.CC_ToolStrip_Progress});
            this.CC_ToolStrip.Location = new System.Drawing.Point(0, 519);
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
            // CC_Group_SourceLocation
            // 
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Label_ReferenceFolder_NumSources);
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Button_ReferenceFolder_Delete);
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Button_ReferenceFolder_Select);
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Label_ReferenceFolder);
            this.CC_Group_SourceLocation.Controls.Add(this.CC_Text_ReferenceFolder_Path);
            this.CC_Group_SourceLocation.Location = new System.Drawing.Point(3, 117);
            this.CC_Group_SourceLocation.Name = "CC_Group_SourceLocation";
            this.CC_Group_SourceLocation.Size = new System.Drawing.Size(481, 44);
            this.CC_Group_SourceLocation.TabIndex = 1;
            this.CC_Group_SourceLocation.TabStop = false;
            this.CC_Group_SourceLocation.Text = "Reference folder";
            // 
            // CC_Label_ReferenceFolder_NumSources
            // 
            this.CC_Label_ReferenceFolder_NumSources.Location = new System.Drawing.Point(337, 21);
            this.CC_Label_ReferenceFolder_NumSources.Name = "CC_Label_ReferenceFolder_NumSources";
            this.CC_Label_ReferenceFolder_NumSources.Size = new System.Drawing.Size(137, 13);
            this.CC_Label_ReferenceFolder_NumSources.TabIndex = 10;
            this.CC_Label_ReferenceFolder_NumSources.Text = "Image source count: 0";
            this.CC_Label_ReferenceFolder_NumSources.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.CC_Selection_Technique.OperationMode = TechniqueSelection.eMode.MULTIPLE;
            this.CC_Selection_Technique.Size = new System.Drawing.Size(690, 116);
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
            this.linkLabel1.Location = new System.Drawing.Point(560, 599);
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
            this.label1.Location = new System.Drawing.Point(487, 599);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Icons made by";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(599, 599);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "from";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(622, 599);
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
            this.label3.Location = new System.Drawing.Point(12, 599);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Powered by";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(72, 599);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(68, 13);
            this.linkLabel3.TabIndex = 13;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "pHash library";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 599);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = ",";
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Location = new System.Drawing.Point(141, 599);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(82, 13);
            this.linkLabel4.TabIndex = 15;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "Luminous library";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(219, 599);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = ",";
            // 
            // Test
            // 
            this.Test.AutoSize = true;
            this.Test.Location = new System.Drawing.Point(224, 599);
            this.Test.Name = "Test";
            this.Test.Size = new System.Drawing.Size(35, 13);
            this.Test.TabIndex = 17;
            this.Test.TabStop = true;
            this.Test.Text = "DLinq";
            this.Test.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 599);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = ",";
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Location = new System.Drawing.Point(259, 599);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(77, 13);
            this.linkLabel5.TabIndex = 19;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "ObjectListView";
            this.linkLabel5.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked_1);
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(726, 617);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Test);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.label4);
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
            this.MaximumSize = new System.Drawing.Size(742, 656);
            this.Name = "MainDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Percuptual Image Hashing";
            this.MainDialog_MainTab.ResumeLayout(false);
            this.pageImageVsImage.ResumeLayout(false);
            this.pageCrossComparison.ResumeLayout(false);
            this.pageCrossComparison.PerformLayout();
            this.CC_Group_Controls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CC_List_Results)).EndInit();
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
        private System.Windows.Forms.Label CC_Label_ReferenceFolder;
        private System.Windows.Forms.TextBox CC_Text_ReferenceFolder_Path;
        private System.Windows.Forms.Button CC_Button_ReferenceFolder_Select;
        private System.Windows.Forms.Button CC_Button_ReferenceFolder_Delete;
        private System.Windows.Forms.StatusStrip CC_ToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel CC_ToolStrip_Label_Action;
        private System.Windows.Forms.ToolStripProgressBar CC_ToolStrip_Progress;
        private System.Windows.Forms.Button CC_Button_ReferenceFolder_Start;
        private System.Windows.Forms.Label CC_Label_ReferenceFolder_NumSources;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.ComboBox CC_Text_Filter;
        private System.Windows.Forms.Label CC_Label_ResultCount;
        private System.Windows.Forms.Label label5;
        private BrightIdeasSoftware.FastObjectListView CC_List_Results;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn6;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private BrightIdeasSoftware.OLVColumn olvColumn8;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.GroupBox CC_Group_Controls;
        private System.Windows.Forms.Button CC_Button_Controls_CollapseGroups;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel Test;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.Button CC_Button_Controls_SelectAll;
    }
}

