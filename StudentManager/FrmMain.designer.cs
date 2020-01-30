namespace StudentManager
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiModifyPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.学员管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiManageStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.成绩管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQueryAndAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_AttendanceQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Card = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_AQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_linkxkt = new System.Windows.Forms.ToolStripMenuItem();
            this.txmi_update = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_about = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClose = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnSwitchAccount = new System.Windows.Forms.Button();
            this.btnModifyPwd = new System.Windows.Forms.Button();
            this.btnQueryAndAnalysis = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnAQuery = new System.Windows.Forms.Button();
            this.btnCard = new System.Windows.Forms.Button();
            this.btnManageStudent = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.学员管理ToolStripMenuItem,
            this.成绩管理ToolStripMenuItem,
            this.tsmi_AttendanceQuery,
            this.帮助HToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1902, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiModifyPwd,
            this.toolStripSeparator3,
            this.tmiClose});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.系统ToolStripMenuItem.Text = "系统(&S)";
            // 
            // tmiModifyPwd
            // 
            this.tmiModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("tmiModifyPwd.Image")));
            this.tmiModifyPwd.Name = "tmiModifyPwd";
            this.tmiModifyPwd.Size = new System.Drawing.Size(164, 26);
            this.tmiModifyPwd.Text = "密码修改(&C)";
            this.tmiModifyPwd.Click += new System.EventHandler(this.tmiModifyPwd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(161, 6);
            // 
            // tmiClose
            // 
            this.tmiClose.Image = ((System.Drawing.Image)(resources.GetObject("tmiClose.Image")));
            this.tmiClose.Name = "tmiClose";
            this.tmiClose.Size = new System.Drawing.Size(164, 26);
            this.tmiClose.Text = "退出(&E)";
            this.tmiClose.Click += new System.EventHandler(this.tmiClose_Click);
            // 
            // 学员管理ToolStripMenuItem
            // 
            this.学员管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddStudent,
            this.toolStripSeparator2,
            this.tsmiManageStudent});
            this.学员管理ToolStripMenuItem.Name = "学员管理ToolStripMenuItem";
            this.学员管理ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.学员管理ToolStripMenuItem.Text = "学员管理(&M)";
            // 
            // tsmiAddStudent
            // 
            this.tsmiAddStudent.Image = ((System.Drawing.Image)(resources.GetObject("tsmiAddStudent.Image")));
            this.tsmiAddStudent.Name = "tsmiAddStudent";
            this.tsmiAddStudent.Size = new System.Drawing.Size(196, 26);
            this.tsmiAddStudent.Text = "添加学员(&A)";
            this.tsmiAddStudent.Click += new System.EventHandler(this.tsmiAddStudent_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // tsmiManageStudent
            // 
            this.tsmiManageStudent.Image = ((System.Drawing.Image)(resources.GetObject("tsmiManageStudent.Image")));
            this.tsmiManageStudent.Name = "tsmiManageStudent";
            this.tsmiManageStudent.Size = new System.Drawing.Size(196, 26);
            this.tsmiManageStudent.Text = "学员信息管理(&Q)";
            this.tsmiManageStudent.Click += new System.EventHandler(this.tsmiManageStudent_Click);
            // 
            // 成绩管理ToolStripMenuItem
            // 
            this.成绩管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQueryAndAnalysis,
            this.toolStripSeparator1,
            this.tsmiQuery});
            this.成绩管理ToolStripMenuItem.Name = "成绩管理ToolStripMenuItem";
            this.成绩管理ToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.成绩管理ToolStripMenuItem.Text = "成绩管理(&J)";
            // 
            // tsmiQueryAndAnalysis
            // 
            this.tsmiQueryAndAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("tsmiQueryAndAnalysis.Image")));
            this.tsmiQueryAndAnalysis.Name = "tsmiQueryAndAnalysis";
            this.tsmiQueryAndAnalysis.Size = new System.Drawing.Size(211, 26);
            this.tsmiQueryAndAnalysis.Text = "成绩查询与分析(&Q)";
            this.tsmiQueryAndAnalysis.Click += new System.EventHandler(this.tsmiQueryAndAnalysis_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(208, 6);
            // 
            // tsmiQuery
            // 
            this.tsmiQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsmiQuery.Image")));
            this.tsmiQuery.Name = "tsmiQuery";
            this.tsmiQuery.Size = new System.Drawing.Size(211, 26);
            this.tsmiQuery.Text = "成绩快速查询(&S)";
            this.tsmiQuery.Click += new System.EventHandler(this.tsmiQuery_Click);
            // 
            // tsmi_AttendanceQuery
            // 
            this.tsmi_AttendanceQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Card,
            this.toolStripSeparator7,
            this.tsmi_AQuery});
            this.tsmi_AttendanceQuery.Name = "tsmi_AttendanceQuery";
            this.tsmi_AttendanceQuery.Size = new System.Drawing.Size(102, 24);
            this.tsmi_AttendanceQuery.Text = "考勤管理(&A)";
            // 
            // tsmi_Card
            // 
            this.tsmi_Card.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Card.Image")));
            this.tsmi_Card.Name = "tsmi_Card";
            this.tsmi_Card.Size = new System.Drawing.Size(164, 26);
            this.tsmi_Card.Text = "考勤打卡(&R)";
            this.tsmi_Card.Click += new System.EventHandler(this.tsmi_Card_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(161, 6);
            // 
            // tsmi_AQuery
            // 
            this.tsmi_AQuery.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_AQuery.Image")));
            this.tsmi_AQuery.Name = "tsmi_AQuery";
            this.tsmi_AQuery.Size = new System.Drawing.Size(164, 26);
            this.tsmi_AQuery.Text = "考勤查询";
            this.tsmi_AQuery.Click += new System.EventHandler(this.tsmi_AQuery_Click);
            // 
            // 帮助HToolStripMenuItem
            // 
            this.帮助HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_linkxkt,
            this.txmi_update,
            this.toolStripSeparator8,
            this.tsmi_about});
            this.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem";
            this.帮助HToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.帮助HToolStripMenuItem.Text = "帮助(&H)";
            // 
            // tsmi_linkxkt
            // 
            this.tsmi_linkxkt.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_linkxkt.Image")));
            this.tsmi_linkxkt.Name = "tsmi_linkxkt";
            this.tsmi_linkxkt.Size = new System.Drawing.Size(165, 26);
            this.tsmi_linkxkt.Text = "访问官网(&X)";
            this.tsmi_linkxkt.Click += new System.EventHandler(this.tsmi_linkxkt_Click);
            // 
            // txmi_update
            // 
            this.txmi_update.Image = ((System.Drawing.Image)(resources.GetObject("txmi_update.Image")));
            this.txmi_update.Name = "txmi_update";
            this.txmi_update.Size = new System.Drawing.Size(165, 26);
            this.txmi_update.Text = "系统升级(&U)";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(162, 6);
            // 
            // tsmi_about
            // 
            this.tsmi_about.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_about.Image")));
            this.tsmi_about.Name = "tsmi_about";
            this.tsmi_about.Size = new System.Drawing.Size(165, 26);
            this.tsmi_about.Text = "关于我们(&A)";
            this.tsmi_about.Click += new System.EventHandler(this.tsmi_about_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersion,
            this.toolStripStatusLabel1,
            this.lblCurrentUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1008);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1902, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblVersion
            // 
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(105, 20);
            this.lblVersion.Text = " 版本号：V2.0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(123, 20);
            this.toolStripStatusLabel1.Text = " [当前用登录户：";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(59, 20);
            this.lblCurrentUser.Text = "王晓军]";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.button12);
            this.splitContainer1.Panel1.Controls.Add(this.btnImport);
            this.splitContainer1.Panel1.Controls.Add(this.button10);
            this.splitContainer1.Panel1.Controls.Add(this.btnSwitchAccount);
            this.splitContainer1.Panel1.Controls.Add(this.btnModifyPwd);
            this.splitContainer1.Panel1.Controls.Add(this.btnQueryAndAnalysis);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.btnAQuery);
            this.splitContainer1.Panel1.Controls.Add(this.btnCard);
            this.splitContainer1.Panel1.Controls.Add(this.btnManageStudent);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddStudent);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar1);
            this.splitContainer1.Size = new System.Drawing.Size(1902, 980);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(203, 846);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 40);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = " 退出系统";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
            this.button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.Location = new System.Drawing.Point(56, 846);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(119, 40);
            this.button12.TabIndex = 11;
            this.button12.Text = " 访问官网";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(203, 695);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(119, 40);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = " 批量导入";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(56, 695);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(119, 40);
            this.button10.TabIndex = 9;
            this.button10.Text = " 系统升级";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btnSwitchAccount
            // 
            this.btnSwitchAccount.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwitchAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnSwitchAccount.Image")));
            this.btnSwitchAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSwitchAccount.Location = new System.Drawing.Point(203, 608);
            this.btnSwitchAccount.Name = "btnSwitchAccount";
            this.btnSwitchAccount.Size = new System.Drawing.Size(119, 40);
            this.btnSwitchAccount.TabIndex = 8;
            this.btnSwitchAccount.Text = " 账号切换";
            this.btnSwitchAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSwitchAccount.UseVisualStyleBackColor = true;
            this.btnSwitchAccount.Click += new System.EventHandler(this.btnSwitchAccount_Click);
            // 
            // btnModifyPwd
            // 
            this.btnModifyPwd.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnModifyPwd.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyPwd.Image")));
            this.btnModifyPwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModifyPwd.Location = new System.Drawing.Point(60, 608);
            this.btnModifyPwd.Name = "btnModifyPwd";
            this.btnModifyPwd.Size = new System.Drawing.Size(119, 40);
            this.btnModifyPwd.TabIndex = 7;
            this.btnModifyPwd.Text = " 密码修改";
            this.btnModifyPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifyPwd.UseVisualStyleBackColor = true;
            this.btnModifyPwd.Click += new System.EventHandler(this.btnModifyPwd_Click);
            // 
            // btnQueryAndAnalysis
            // 
            this.btnQueryAndAnalysis.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryAndAnalysis.Image = ((System.Drawing.Image)(resources.GetObject("btnQueryAndAnalysis.Image")));
            this.btnQueryAndAnalysis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQueryAndAnalysis.Location = new System.Drawing.Point(203, 465);
            this.btnQueryAndAnalysis.Name = "btnQueryAndAnalysis";
            this.btnQueryAndAnalysis.Size = new System.Drawing.Size(119, 40);
            this.btnQueryAndAnalysis.TabIndex = 6;
            this.btnQueryAndAnalysis.Text = " 成绩分析";
            this.btnQueryAndAnalysis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQueryAndAnalysis.UseVisualStyleBackColor = true;
            this.btnQueryAndAnalysis.Click += new System.EventHandler(this.btnQueryAndAnalysis_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(56, 465);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(119, 40);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = " 成绩浏览";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnAQuery
            // 
            this.btnAQuery.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnAQuery.Image")));
            this.btnAQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAQuery.Location = new System.Drawing.Point(203, 374);
            this.btnAQuery.Name = "btnAQuery";
            this.btnAQuery.Size = new System.Drawing.Size(119, 40);
            this.btnAQuery.TabIndex = 4;
            this.btnAQuery.Text = " 考勤查询";
            this.btnAQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAQuery.UseVisualStyleBackColor = true;
            this.btnAQuery.Click += new System.EventHandler(this.btnAQuery_Click);
            // 
            // btnCard
            // 
            this.btnCard.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCard.Image = ((System.Drawing.Image)(resources.GetObject("btnCard.Image")));
            this.btnCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCard.Location = new System.Drawing.Point(56, 374);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(119, 40);
            this.btnCard.TabIndex = 3;
            this.btnCard.Text = " 考勤打卡";
            this.btnCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCard.UseVisualStyleBackColor = true;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnManageStudent
            // 
            this.btnManageStudent.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManageStudent.Image = ((System.Drawing.Image)(resources.GetObject("btnManageStudent.Image")));
            this.btnManageStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageStudent.Location = new System.Drawing.Point(203, 286);
            this.btnManageStudent.Name = "btnManageStudent";
            this.btnManageStudent.Size = new System.Drawing.Size(119, 40);
            this.btnManageStudent.TabIndex = 2;
            this.btnManageStudent.Text = " 学员管理";
            this.btnManageStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnManageStudent.UseVisualStyleBackColor = true;
            this.btnManageStudent.Click += new System.EventHandler(this.btnManageStudent_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddStudent.Image = ((System.Drawing.Image)(resources.GetObject("btnAddStudent.Image")));
            this.btnAddStudent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddStudent.Location = new System.Drawing.Point(56, 286);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(119, 40);
            this.btnAddStudent.TabIndex = 1;
            this.btnAddStudent.Text = " 添加学员";
            this.btnAddStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(60, 31);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[学员信息管理系统]";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmiModifyPwd;
        private System.Windows.Forms.ToolStripMenuItem tmiClose;
        private System.Windows.Forms.ToolStripMenuItem 学员管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddStudent;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageStudent;
        private System.Windows.Forms.ToolStripMenuItem 成绩管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiQueryAndAnalysis;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AttendanceQuery;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Card;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AQuery;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_linkxkt;
        private System.Windows.Forms.ToolStripMenuItem txmi_update;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem tsmi_about;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnManageStudent;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnSwitchAccount;
        private System.Windows.Forms.Button btnModifyPwd;
        private System.Windows.Forms.Button btnQueryAndAnalysis;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnAQuery;
        private System.Windows.Forms.Button btnCard;


    }
}

