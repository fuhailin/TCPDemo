namespace DataPie
 {
     partial class FormMain
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
             this.btnTP = new System.Windows.Forms.Button();
             this.btnImport = new System.Windows.Forms.Button();
             this.btnDel = new System.Windows.Forms.Button();
             this.comboBox1 = new System.Windows.Forms.ComboBox();
             this.btnBrwse = new System.Windows.Forms.Button();
             this.textBox1 = new System.Windows.Forms.TextBox();
             this.groupBox1 = new System.Windows.Forms.GroupBox();
             this.label3 = new System.Windows.Forms.Label();
             this.tabControl1 = new System.Windows.Forms.TabControl();
             this.tabPage1 = new System.Windows.Forms.TabPage();
             this.tabPage5 = new System.Windows.Forms.TabPage();
             this.rdoLocate = new System.Windows.Forms.RadioButton();
             this.radDrop = new System.Windows.Forms.RadioButton();
             this.radError = new System.Windows.Forms.RadioButton();
             this.radAll = new System.Windows.Forms.RadioButton();
             this.radother = new System.Windows.Forms.RadioButton();
             this.label7 = new System.Windows.Forms.Label();
             this.pbFileCount = new System.Windows.Forms.ProgressBar();
             this.txtNtname = new System.Windows.Forms.TextBox();
             this.label6 = new System.Windows.Forms.Label();
             this.txtError = new System.Windows.Forms.TextBox();
             this.label5 = new System.Windows.Forms.Label();
             this.btnTxtOutPut = new System.Windows.Forms.Button();
             this.btnTxtInput = new System.Windows.Forms.Button();
             this.txtPath = new System.Windows.Forms.TextBox();
             this.btnBrowser = new System.Windows.Forms.Button();
             this.tabPage2 = new System.Windows.Forms.TabPage();
             this.groupBox2 = new System.Windows.Forms.GroupBox();
             this.btnDeleteOne = new System.Windows.Forms.Button();
             this.btnAddOne = new System.Windows.Forms.Button();
             this.listBox1 = new System.Windows.Forms.ListBox();
             this.treeView1 = new System.Windows.Forms.TreeView();
             this.btnDtout = new System.Windows.Forms.Button();
             this.tabPage4 = new System.Windows.Forms.TabPage();
             this.groupBox4 = new System.Windows.Forms.GroupBox();
             this.label2 = new System.Windows.Forms.Label();
             this.button3 = new System.Windows.Forms.Button();
             this.label4 = new System.Windows.Forms.Label();
             this.comboBox3 = new System.Windows.Forms.ComboBox();
             this.comboBox4 = new System.Windows.Forms.ComboBox();
             this.tabPage3 = new System.Windows.Forms.TabPage();
             this.btnProcExe = new System.Windows.Forms.Button();
             this.groupBox3 = new System.Windows.Forms.GroupBox();
             this.btnProcDel = new System.Windows.Forms.Button();
             this.btnProcAdd = new System.Windows.Forms.Button();
             this.listBox2 = new System.Windows.Forms.ListBox();
             this.treeView2 = new System.Windows.Forms.TreeView();
             this.label1 = new System.Windows.Forms.Label();
             this.menuStrip1 = new System.Windows.Forms.MenuStrip();
             this.登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
             this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
             this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
             this.userInfo = new System.Windows.Forms.RadioButton();
             this.groupBox1.SuspendLayout();
             this.tabControl1.SuspendLayout();
             this.tabPage1.SuspendLayout();
             this.tabPage5.SuspendLayout();
             this.tabPage2.SuspendLayout();
             this.groupBox2.SuspendLayout();
             this.tabPage4.SuspendLayout();
             this.groupBox4.SuspendLayout();
             this.tabPage3.SuspendLayout();
             this.groupBox3.SuspendLayout();
             this.menuStrip1.SuspendLayout();
             this.SuspendLayout();
             // 
             // btnTP
             // 
             this.btnTP.Location = new System.Drawing.Point(50, 278);
             this.btnTP.Name = "btnTP";
             this.btnTP.Size = new System.Drawing.Size(110, 39);
             this.btnTP.TabIndex = 40;
             this.btnTP.Text = "导出模板";
             this.btnTP.UseVisualStyleBackColor = true;
             this.btnTP.Click += new System.EventHandler(this.btnTP_Click);
             // 
             // btnImport
             // 
             this.btnImport.Location = new System.Drawing.Point(209, 278);
             this.btnImport.Name = "btnImport";
             this.btnImport.Size = new System.Drawing.Size(105, 39);
             this.btnImport.TabIndex = 37;
             this.btnImport.Text = "导入";
             this.btnImport.UseVisualStyleBackColor = true;
             this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
             // 
             // btnDel
             // 
             this.btnDel.Location = new System.Drawing.Point(401, 278);
             this.btnDel.Name = "btnDel";
             this.btnDel.Size = new System.Drawing.Size(88, 39);
             this.btnDel.TabIndex = 41;
             this.btnDel.Text = "删除数据";
             this.btnDel.UseVisualStyleBackColor = true;
             this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
             // 
             // comboBox1
             // 
             this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.comboBox1.FormattingEnabled = true;
             this.comboBox1.ItemHeight = 12;
             this.comboBox1.Location = new System.Drawing.Point(178, 122);
             this.comboBox1.Name = "comboBox1";
             this.comboBox1.Size = new System.Drawing.Size(280, 20);
             this.comboBox1.TabIndex = 36;
             // 
             // btnBrwse
             // 
             this.btnBrwse.Location = new System.Drawing.Point(19, 43);
             this.btnBrwse.Name = "btnBrwse";
             this.btnBrwse.Size = new System.Drawing.Size(124, 37);
             this.btnBrwse.TabIndex = 38;
             this.btnBrwse.Text = "浏览EXCEL文件";
             this.btnBrwse.UseVisualStyleBackColor = true;
             this.btnBrwse.Click += new System.EventHandler(this.btnBrwse_Click);
             // 
             // textBox1
             // 
             this.textBox1.Location = new System.Drawing.Point(178, 43);
             this.textBox1.Multiline = true;
             this.textBox1.Name = "textBox1";
             this.textBox1.Size = new System.Drawing.Size(326, 37);
             this.textBox1.TabIndex = 39;
             // 
             // groupBox1
             // 
             this.groupBox1.Controls.Add(this.label3);
             this.groupBox1.Controls.Add(this.btnBrwse);
             this.groupBox1.Controls.Add(this.textBox1);
             this.groupBox1.Controls.Add(this.comboBox1);
             this.groupBox1.Location = new System.Drawing.Point(31, 29);
             this.groupBox1.Name = "groupBox1";
             this.groupBox1.Size = new System.Drawing.Size(539, 208);
             this.groupBox1.TabIndex = 45;
             this.groupBox1.TabStop = false;
             // 
             // label3
             // 
             this.label3.AutoSize = true;
             this.label3.Location = new System.Drawing.Point(43, 122);
             this.label3.Name = "label3";
             this.label3.Size = new System.Drawing.Size(77, 12);
             this.label3.TabIndex = 40;
             this.label3.Text = "请选择表名：";
             // 
             // tabControl1
             // 
             this.tabControl1.Controls.Add(this.tabPage1);
             this.tabControl1.Controls.Add(this.tabPage5);
             this.tabControl1.Controls.Add(this.tabPage2);
             this.tabControl1.Controls.Add(this.tabPage4);
             this.tabControl1.Controls.Add(this.tabPage3);
             this.tabControl1.Location = new System.Drawing.Point(26, 40);
             this.tabControl1.Name = "tabControl1";
             this.tabControl1.SelectedIndex = 0;
             this.tabControl1.Size = new System.Drawing.Size(622, 426);
             this.tabControl1.TabIndex = 46;
             // 
             // tabPage1
             // 
             this.tabPage1.Controls.Add(this.groupBox1);
             this.tabPage1.Controls.Add(this.btnTP);
             this.tabPage1.Controls.Add(this.btnImport);
             this.tabPage1.Controls.Add(this.btnDel);
             this.tabPage1.Location = new System.Drawing.Point(4, 22);
             this.tabPage1.Name = "tabPage1";
             this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
             this.tabPage1.Size = new System.Drawing.Size(614, 400);
             this.tabPage1.TabIndex = 0;
             this.tabPage1.Text = "数据导入";
             this.tabPage1.UseVisualStyleBackColor = true;
             // 
             // tabPage5
             // 
             this.tabPage5.Controls.Add(this.userInfo);
             this.tabPage5.Controls.Add(this.rdoLocate);
             this.tabPage5.Controls.Add(this.radDrop);
             this.tabPage5.Controls.Add(this.radError);
             this.tabPage5.Controls.Add(this.radAll);
             this.tabPage5.Controls.Add(this.radother);
             this.tabPage5.Controls.Add(this.label7);
             this.tabPage5.Controls.Add(this.pbFileCount);
             this.tabPage5.Controls.Add(this.txtNtname);
             this.tabPage5.Controls.Add(this.label6);
             this.tabPage5.Controls.Add(this.txtError);
             this.tabPage5.Controls.Add(this.label5);
             this.tabPage5.Controls.Add(this.btnTxtOutPut);
             this.tabPage5.Controls.Add(this.btnTxtInput);
             this.tabPage5.Controls.Add(this.txtPath);
             this.tabPage5.Controls.Add(this.btnBrowser);
             this.tabPage5.Location = new System.Drawing.Point(4, 22);
             this.tabPage5.Name = "tabPage5";
             this.tabPage5.Size = new System.Drawing.Size(614, 400);
             this.tabPage5.TabIndex = 4;
             this.tabPage5.Text = "自定义文本";
             this.tabPage5.UseVisualStyleBackColor = true;
             // 
             // rdoLocate
             // 
             this.rdoLocate.AutoSize = true;
             this.rdoLocate.Location = new System.Drawing.Point(393, 223);
             this.rdoLocate.Name = "rdoLocate";
             this.rdoLocate.Size = new System.Drawing.Size(71, 16);
             this.rdoLocate.TabIndex = 12;
             this.rdoLocate.TabStop = true;
             this.rdoLocate.Text = "定位数据";
             this.rdoLocate.UseVisualStyleBackColor = true;
             this.rdoLocate.CheckedChanged += new System.EventHandler(this.rdoDingWei_CheckedChanged);
             // 
             // radDrop
             // 
             this.radDrop.AutoSize = true;
             this.radDrop.Location = new System.Drawing.Point(269, 223);
             this.radDrop.Name = "radDrop";
             this.radDrop.Size = new System.Drawing.Size(71, 16);
             this.radDrop.TabIndex = 11;
             this.radDrop.TabStop = true;
             this.radDrop.Text = "下线数据";
             this.radDrop.UseVisualStyleBackColor = true;
             this.radDrop.CheckedChanged += new System.EventHandler(this.radDrop_CheckedChanged);
             // 
             // radError
             // 
             this.radError.AutoSize = true;
             this.radError.Location = new System.Drawing.Point(177, 223);
             this.radError.Name = "radError";
             this.radError.Size = new System.Drawing.Size(71, 16);
             this.radError.TabIndex = 10;
             this.radError.TabStop = true;
             this.radError.Text = "报错数据";
             this.radError.UseVisualStyleBackColor = true;
             this.radError.CheckedChanged += new System.EventHandler(this.radError_CheckedChanged);
             // 
             // radAll
             // 
             this.radAll.AutoSize = true;
             this.radAll.Location = new System.Drawing.Point(393, 200);
             this.radAll.Name = "radAll";
             this.radAll.Size = new System.Drawing.Size(47, 16);
             this.radAll.TabIndex = 9;
             this.radAll.Text = "全国";
             this.radAll.UseVisualStyleBackColor = true;
             this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
             // 
             // radother
             // 
             this.radother.AutoSize = true;
             this.radother.Checked = true;
             this.radother.Location = new System.Drawing.Point(177, 200);
             this.radother.Name = "radother";
             this.radother.Size = new System.Drawing.Size(71, 16);
             this.radother.TabIndex = 9;
             this.radother.TabStop = true;
             this.radother.Text = "其他城市";
             this.radother.UseVisualStyleBackColor = true;
             this.radother.CheckedChanged += new System.EventHandler(this.radother_CheckedChanged);
             // 
             // label7
             // 
             this.label7.AutoSize = true;
             this.label7.Location = new System.Drawing.Point(99, 182);
             this.label7.Name = "label7";
             this.label7.Size = new System.Drawing.Size(53, 12);
             this.label7.TabIndex = 8;
             this.label7.Text = "文件总数";
             // 
             // pbFileCount
             // 
             this.pbFileCount.Location = new System.Drawing.Point(177, 171);
             this.pbFileCount.Name = "pbFileCount";
             this.pbFileCount.Size = new System.Drawing.Size(313, 23);
             this.pbFileCount.TabIndex = 7;
             // 
             // txtNtname
             // 
             this.txtNtname.Location = new System.Drawing.Point(177, 93);
             this.txtNtname.Name = "txtNtname";
             this.txtNtname.Size = new System.Drawing.Size(311, 21);
             this.txtNtname.TabIndex = 6;
             this.txtNtname.Text = "LBI_Click_Data_BeiJing_";
             // 
             // label6
             // 
             this.label6.AutoSize = true;
             this.label6.Location = new System.Drawing.Point(99, 96);
             this.label6.Name = "label6";
             this.label6.Size = new System.Drawing.Size(53, 12);
             this.label6.TabIndex = 5;
             this.label6.Text = "假定表名";
             // 
             // txtError
             // 
             this.txtError.Location = new System.Drawing.Point(177, 132);
             this.txtError.Name = "txtError";
             this.txtError.Size = new System.Drawing.Size(313, 21);
             this.txtError.TabIndex = 4;
             // 
             // label5
             // 
             this.label5.AutoSize = true;
             this.label5.Location = new System.Drawing.Point(111, 135);
             this.label5.Name = "label5";
             this.label5.Size = new System.Drawing.Size(35, 12);
             this.label5.TabIndex = 3;
             this.label5.Text = "Error";
             // 
             // btnTxtOutPut
             // 
             this.btnTxtOutPut.Location = new System.Drawing.Point(177, 287);
             this.btnTxtOutPut.Name = "btnTxtOutPut";
             this.btnTxtOutPut.Size = new System.Drawing.Size(123, 37);
             this.btnTxtOutPut.TabIndex = 2;
             this.btnTxtOutPut.Text = "导出";
             this.btnTxtOutPut.UseVisualStyleBackColor = true;
             // 
             // btnTxtInput
             // 
             this.btnTxtInput.Location = new System.Drawing.Point(29, 287);
             this.btnTxtInput.Name = "btnTxtInput";
             this.btnTxtInput.Size = new System.Drawing.Size(123, 37);
             this.btnTxtInput.TabIndex = 2;
             this.btnTxtInput.Text = "导入";
             this.btnTxtInput.UseVisualStyleBackColor = true;
             this.btnTxtInput.Click += new System.EventHandler(this.btnTxtInput_Click);
             // 
             // txtPath
             // 
             this.txtPath.Location = new System.Drawing.Point(177, 36);
             this.txtPath.Multiline = true;
             this.txtPath.Name = "txtPath";
             this.txtPath.Size = new System.Drawing.Size(313, 39);
             this.txtPath.TabIndex = 1;
             // 
             // btnBrowser
             // 
             this.btnBrowser.Location = new System.Drawing.Point(29, 34);
             this.btnBrowser.Name = "btnBrowser";
             this.btnBrowser.Size = new System.Drawing.Size(123, 42);
             this.btnBrowser.TabIndex = 0;
             this.btnBrowser.Text = "浏览文件";
             this.btnBrowser.UseVisualStyleBackColor = true;
             this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
             // 
             // tabPage2
             // 
             this.tabPage2.Controls.Add(this.groupBox2);
             this.tabPage2.Controls.Add(this.btnDtout);
             this.tabPage2.Location = new System.Drawing.Point(4, 22);
             this.tabPage2.Name = "tabPage2";
             this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
             this.tabPage2.Size = new System.Drawing.Size(614, 400);
             this.tabPage2.TabIndex = 1;
             this.tabPage2.Text = "数据导出";
             this.tabPage2.UseVisualStyleBackColor = true;
             // 
             // groupBox2
             // 
             this.groupBox2.Controls.Add(this.btnDeleteOne);
             this.groupBox2.Controls.Add(this.btnAddOne);
             this.groupBox2.Controls.Add(this.listBox1);
             this.groupBox2.Controls.Add(this.treeView1);
             this.groupBox2.Location = new System.Drawing.Point(21, 18);
             this.groupBox2.Name = "groupBox2";
             this.groupBox2.Size = new System.Drawing.Size(569, 325);
             this.groupBox2.TabIndex = 41;
             this.groupBox2.TabStop = false;
             // 
             // btnDeleteOne
             // 
             this.btnDeleteOne.Location = new System.Drawing.Point(216, 137);
             this.btnDeleteOne.Name = "btnDeleteOne";
             this.btnDeleteOne.Size = new System.Drawing.Size(109, 45);
             this.btnDeleteOne.TabIndex = 45;
             this.btnDeleteOne.Text = "减少一个表<==";
             this.btnDeleteOne.UseVisualStyleBackColor = true;
             this.btnDeleteOne.Click += new System.EventHandler(this.btnDeleteOne_Click);
             // 
             // btnAddOne
             // 
             this.btnAddOne.Location = new System.Drawing.Point(216, 64);
             this.btnAddOne.Name = "btnAddOne";
             this.btnAddOne.Size = new System.Drawing.Size(109, 40);
             this.btnAddOne.TabIndex = 44;
             this.btnAddOne.Text = "增加一个表==>";
             this.btnAddOne.UseVisualStyleBackColor = true;
             this.btnAddOne.Click += new System.EventHandler(this.btnAddOne_Click);
             // 
             // listBox1
             // 
             this.listBox1.FormattingEnabled = true;
             this.listBox1.ItemHeight = 12;
             this.listBox1.Location = new System.Drawing.Point(362, 13);
             this.listBox1.Name = "listBox1";
             this.listBox1.Size = new System.Drawing.Size(174, 292);
             this.listBox1.TabIndex = 43;
             this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
             // 
             // treeView1
             // 
             this.treeView1.Location = new System.Drawing.Point(6, 13);
             this.treeView1.Name = "treeView1";
             this.treeView1.Size = new System.Drawing.Size(184, 300);
             this.treeView1.TabIndex = 42;
             this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
             this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
             this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
             // 
             // btnDtout
             // 
             this.btnDtout.Location = new System.Drawing.Point(407, 346);
             this.btnDtout.Name = "btnDtout";
             this.btnDtout.Size = new System.Drawing.Size(150, 48);
             this.btnDtout.TabIndex = 39;
             this.btnDtout.Text = "单个EXCEL导出";
             this.btnDtout.UseVisualStyleBackColor = true;
             this.btnDtout.Click += new System.EventHandler(this.btnDtout_Click);
             // 
             // tabPage4
             // 
             this.tabPage4.Controls.Add(this.groupBox4);
             this.tabPage4.Location = new System.Drawing.Point(4, 22);
             this.tabPage4.Name = "tabPage4";
             this.tabPage4.Size = new System.Drawing.Size(614, 400);
             this.tabPage4.TabIndex = 3;
             this.tabPage4.Text = "数据导出（多EXCEL）";
             this.tabPage4.UseVisualStyleBackColor = true;
             // 
             // groupBox4
             // 
             this.groupBox4.Controls.Add(this.label2);
             this.groupBox4.Controls.Add(this.button3);
             this.groupBox4.Controls.Add(this.label4);
             this.groupBox4.Controls.Add(this.comboBox3);
             this.groupBox4.Controls.Add(this.comboBox4);
             this.groupBox4.Location = new System.Drawing.Point(70, 30);
             this.groupBox4.Name = "groupBox4";
             this.groupBox4.Size = new System.Drawing.Size(477, 210);
             this.groupBox4.TabIndex = 55;
             this.groupBox4.TabStop = false;
             this.groupBox4.Text = "导出设置";
             // 
             // label2
             // 
             this.label2.AutoSize = true;
             this.label2.Location = new System.Drawing.Point(21, 87);
             this.label2.Name = "label2";
             this.label2.Size = new System.Drawing.Size(77, 12);
             this.label2.TabIndex = 56;
             this.label2.Text = "选择导出表：";
             // 
             // button3
             // 
             this.button3.Location = new System.Drawing.Point(299, 138);
             this.button3.Name = "button3";
             this.button3.Size = new System.Drawing.Size(146, 50);
             this.button3.TabIndex = 55;
             this.button3.Text = "分多个EXCEL表格导出";
             this.button3.UseVisualStyleBackColor = true;
             this.button3.Click += new System.EventHandler(this.button3_Click);
             // 
             // label4
             // 
             this.label4.AutoSize = true;
             this.label4.Location = new System.Drawing.Point(21, 38);
             this.label4.Name = "label4";
             this.label4.Size = new System.Drawing.Size(89, 12);
             this.label4.TabIndex = 48;
             this.label4.Text = "分页导出数量：";
             // 
             // comboBox3
             // 
             this.comboBox3.FormattingEnabled = true;
             this.comboBox3.Items.AddRange(new object[] {
            "100000",
            "150000",
            "200000",
            "250000",
            "300000",
            "400000"});
             this.comboBox3.Location = new System.Drawing.Point(115, 35);
             this.comboBox3.Name = "comboBox3";
             this.comboBox3.Size = new System.Drawing.Size(224, 20);
             this.comboBox3.TabIndex = 49;
             this.comboBox3.Text = "200000";
             // 
             // comboBox4
             // 
             this.comboBox4.FormattingEnabled = true;
             this.comboBox4.Location = new System.Drawing.Point(115, 84);
             this.comboBox4.Name = "comboBox4";
             this.comboBox4.Size = new System.Drawing.Size(224, 20);
             this.comboBox4.TabIndex = 53;
             // 
             // tabPage3
             // 
             this.tabPage3.Controls.Add(this.btnProcExe);
             this.tabPage3.Controls.Add(this.groupBox3);
             this.tabPage3.Location = new System.Drawing.Point(4, 22);
             this.tabPage3.Name = "tabPage3";
             this.tabPage3.Size = new System.Drawing.Size(614, 400);
             this.tabPage3.TabIndex = 2;
             this.tabPage3.Text = "请求运算";
             this.tabPage3.UseVisualStyleBackColor = true;
             // 
             // btnProcExe
             // 
             this.btnProcExe.Location = new System.Drawing.Point(418, 354);
             this.btnProcExe.Name = "btnProcExe";
             this.btnProcExe.Size = new System.Drawing.Size(140, 46);
             this.btnProcExe.TabIndex = 43;
             this.btnProcExe.Text = "请求运算";
             this.btnProcExe.UseVisualStyleBackColor = true;
             this.btnProcExe.Click += new System.EventHandler(this.btnProcExe_Click);
             // 
             // groupBox3
             // 
             this.groupBox3.Controls.Add(this.btnProcDel);
             this.groupBox3.Controls.Add(this.btnProcAdd);
             this.groupBox3.Controls.Add(this.listBox2);
             this.groupBox3.Controls.Add(this.treeView2);
             this.groupBox3.Location = new System.Drawing.Point(21, 12);
             this.groupBox3.Name = "groupBox3";
             this.groupBox3.Size = new System.Drawing.Size(576, 340);
             this.groupBox3.TabIndex = 42;
             this.groupBox3.TabStop = false;
             // 
             // btnProcDel
             // 
             this.btnProcDel.Location = new System.Drawing.Point(227, 198);
             this.btnProcDel.Name = "btnProcDel";
             this.btnProcDel.Size = new System.Drawing.Size(109, 47);
             this.btnProcDel.TabIndex = 45;
             this.btnProcDel.Text = "减少一个请求<==";
             this.btnProcDel.UseVisualStyleBackColor = true;
             this.btnProcDel.Click += new System.EventHandler(this.btnProcDel_Click);
             // 
             // btnProcAdd
             // 
             this.btnProcAdd.Location = new System.Drawing.Point(227, 78);
             this.btnProcAdd.Name = "btnProcAdd";
             this.btnProcAdd.Size = new System.Drawing.Size(109, 46);
             this.btnProcAdd.TabIndex = 44;
             this.btnProcAdd.Text = "增加一个请求==>";
             this.btnProcAdd.UseVisualStyleBackColor = true;
             this.btnProcAdd.Click += new System.EventHandler(this.btnProcAdd_Click);
             // 
             // listBox2
             // 
             this.listBox2.FormattingEnabled = true;
             this.listBox2.ItemHeight = 12;
             this.listBox2.Location = new System.Drawing.Point(363, 34);
             this.listBox2.Name = "listBox2";
             this.listBox2.Size = new System.Drawing.Size(174, 292);
             this.listBox2.TabIndex = 43;
             this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
             // 
             // treeView2
             // 
             this.treeView2.Location = new System.Drawing.Point(10, 34);
             this.treeView2.Name = "treeView2";
             this.treeView2.Size = new System.Drawing.Size(184, 292);
             this.treeView2.TabIndex = 42;
             this.treeView2.DoubleClick += new System.EventHandler(this.treeView2_DoubleClick);
             this.treeView2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView2_MouseDown);
             // 
             // label1
             // 
             this.label1.AutoSize = true;
             this.label1.Location = new System.Drawing.Point(374, 25);
             this.label1.Name = "label1";
             this.label1.Size = new System.Drawing.Size(65, 12);
             this.label1.TabIndex = 47;
             this.label1.Text = "提示信息：";
             // 
             // menuStrip1
             // 
             this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登陆ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.退出ToolStripMenuItem});
             this.menuStrip1.Location = new System.Drawing.Point(0, 0);
             this.menuStrip1.Name = "menuStrip1";
             this.menuStrip1.Size = new System.Drawing.Size(706, 25);
             this.menuStrip1.TabIndex = 48;
             this.menuStrip1.Text = "menuStrip1";
             // 
             // 登陆ToolStripMenuItem
             // 
             this.登陆ToolStripMenuItem.Name = "登陆ToolStripMenuItem";
             this.登陆ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
             this.登陆ToolStripMenuItem.Text = "登陆切换";
             this.登陆ToolStripMenuItem.Click += new System.EventHandler(this.登陆ToolStripMenuItem_Click);
             // 
             // 关于ToolStripMenuItem
             // 
             this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
             this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
             this.关于ToolStripMenuItem.Text = "关于";
             this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
             // 
             // 退出ToolStripMenuItem
             // 
             this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
             this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
             this.退出ToolStripMenuItem.Text = "退出";
             this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
             // 
             // userInfo
             // 
             this.userInfo.AutoSize = true;
             this.userInfo.Location = new System.Drawing.Point(177, 246);
             this.userInfo.Name = "userInfo";
             this.userInfo.Size = new System.Drawing.Size(47, 16);
             this.userInfo.TabIndex = 13;
             this.userInfo.TabStop = true;
             this.userInfo.Text = "用户";
             this.userInfo.UseVisualStyleBackColor = true;
             this.userInfo.CheckedChanged += new System.EventHandler(this.userInfo_CheckedChanged);
             // 
             // FormMain
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(706, 488);
             this.Controls.Add(this.label1);
             this.Controls.Add(this.tabControl1);
             this.Controls.Add(this.menuStrip1);
             this.MainMenuStrip = this.menuStrip1;
             this.Name = "FormMain";
             this.Text = "DataPie";
             this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
             this.Load += new System.EventHandler(this.FormMain_Load);
             this.groupBox1.ResumeLayout(false);
             this.groupBox1.PerformLayout();
             this.tabControl1.ResumeLayout(false);
             this.tabPage1.ResumeLayout(false);
             this.tabPage5.ResumeLayout(false);
             this.tabPage5.PerformLayout();
             this.tabPage2.ResumeLayout(false);
             this.groupBox2.ResumeLayout(false);
             this.tabPage4.ResumeLayout(false);
             this.groupBox4.ResumeLayout(false);
             this.groupBox4.PerformLayout();
             this.tabPage3.ResumeLayout(false);
             this.groupBox3.ResumeLayout(false);
             this.menuStrip1.ResumeLayout(false);
             this.menuStrip1.PerformLayout();
             this.ResumeLayout(false);
             this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTP;
         private System.Windows.Forms.Button btnImport;
         private System.Windows.Forms.Button btnDel;
         private System.Windows.Forms.ComboBox comboBox1;
         private System.Windows.Forms.Button btnBrwse;
         private System.Windows.Forms.TextBox textBox1;
         private System.Windows.Forms.GroupBox groupBox1;
         private System.Windows.Forms.TabControl tabControl1;
         private System.Windows.Forms.TabPage tabPage1;
         private System.Windows.Forms.TabPage tabPage2;
         private System.Windows.Forms.Button btnDtout;
         private System.Windows.Forms.Label label1;
         private System.Windows.Forms.GroupBox groupBox2;
         private System.Windows.Forms.TreeView treeView1;
         private System.Windows.Forms.ListBox listBox1;
         private System.Windows.Forms.Button btnDeleteOne;
         private System.Windows.Forms.Button btnAddOne;
         private System.Windows.Forms.MenuStrip menuStrip1;
         private System.Windows.Forms.ToolStripMenuItem 登陆ToolStripMenuItem;
         private System.Windows.Forms.TabPage tabPage3;
         private System.Windows.Forms.Button btnProcExe;
         private System.Windows.Forms.GroupBox groupBox3;
         private System.Windows.Forms.Button btnProcDel;
         private System.Windows.Forms.Button btnProcAdd;
         private System.Windows.Forms.ListBox listBox2;
         private System.Windows.Forms.TreeView treeView2;
         private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
         private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
         private System.Windows.Forms.TabPage tabPage4;
         private System.Windows.Forms.GroupBox groupBox4;
         private System.Windows.Forms.Label label4;
         private System.Windows.Forms.ComboBox comboBox3;
         private System.Windows.Forms.ComboBox comboBox4;
         private System.Windows.Forms.Button button3;
         private System.Windows.Forms.Label label2;
         private System.Windows.Forms.Label label3;
         private System.Windows.Forms.TabPage tabPage5;
         private System.Windows.Forms.TextBox txtPath;
         private System.Windows.Forms.Button btnBrowser;
         private System.Windows.Forms.Button btnTxtInput;
         private System.Windows.Forms.Button btnTxtOutPut;
         private System.Windows.Forms.TextBox txtError;
         private System.Windows.Forms.Label label5;
         private System.Windows.Forms.TextBox txtNtname;
         private System.Windows.Forms.Label label6;
         private System.Windows.Forms.Label label7;
         private System.Windows.Forms.ProgressBar pbFileCount;
         private System.Windows.Forms.RadioButton radAll;
         private System.Windows.Forms.RadioButton radother;
         private System.Windows.Forms.RadioButton radError;
         private System.Windows.Forms.RadioButton rdoLocate;
         private System.Windows.Forms.RadioButton radDrop;
         private System.Windows.Forms.RadioButton userInfo;
     }
 }
