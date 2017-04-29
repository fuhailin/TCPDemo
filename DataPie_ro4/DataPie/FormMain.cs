using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DataPie
{
    public partial class FormMain : Form
    {
        public static DBConfig _DBConfig;
        public static string conString;

        public FormMain()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DataLoad();
        }
        /// <summary>
        /// 初始化需要导出的表、视图以及运算的存储过程
        /// </summary>
        public void DataLoad()
        {
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            TreeNode Node = new TreeNode();

            Node.Name = "所有表：";
            Node.Text = "所有表：";
            treeView1.Nodes.Add(Node);

            Node = new TreeNode();
            Node.Name = "所有视图：";
            Node.Text = "所有视图：";
            treeView1.Nodes.Add(Node);

            IList<string> list = _DBConfig.DB.GetTableInfo();
            foreach (string s in list)
            {
                TreeNode tn = new TreeNode();
                tn.Name = s;
                tn.Text = s;
                treeView1.Nodes["所有表："].Nodes.Add(tn);
            }

            list = _DBConfig.DB.GetViewInfo();
            foreach (string s in list)
            {
                TreeNode tn = new TreeNode();
                tn.Name = s;
                tn.Text = s;
                treeView1.Nodes["所有视图："].Nodes.Add(tn);
            }

            Node = new TreeNode();
            Node.Name = "存储过程";
            Node.Text = "存储过程";
            treeView2.Nodes.Add(Node);
            list = _DBConfig.DB.GetProcInfo();
            foreach (string s in list)
            {
                TreeNode tn = new TreeNode();
                tn.Name = s;
                tn.Text = s;
                treeView2.Nodes["存储过程"].Nodes.Add(tn);
            }

            treeView1.ExpandAll();
            treeView2.ExpandAll();

            IList<string> _DataBaseList = new List<string>();
            _DataBaseList = _DBConfig.DB.GetTableInfo();
            comboBox1.DataSource = _DataBaseList;

            comboBox4.DataSource = _DBConfig.DB.GetTableInfo();

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Text = "";

        }

        /// <summary>
        /// 文件浏览
        /// </summary>
        private void btnBrwse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXCEL2007文件|*.xlsx|EXCEL2003文件|*.xls";

            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
            }
        }
        /// <summary>
        /// 导入EXCEL文件
        /// </summary>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.ToString() == "" || comboBox1.Text.ToString() == "")
            {
                MessageBox.Show("请选择需要导入的文件和导入的表名！");
            }

            else
            {
                string tname = comboBox1.Text.ToString();
                IList<string> List = _DBConfig.DB.GetColumnInfo(tname);

                string fName = textBox1.Text.ToString();
                Stopwatch watch = Stopwatch.StartNew();
                watch.Start();

                DataTable dt = ExcelHelp.GetExcelDataTable(fName, comboBox1.Text.ToString());
                try
                {
                    _DBConfig.DB.SqlBulkCopyImport(List, comboBox1.Text.ToString(), dt);
                    MessageBox.Show("导入成功");
                }
                catch (Exception ee) { throw ee; }


                watch.Stop();
                GC.Collect();
                label1.Text = string.Format("导入的时间为:{0}秒", watch.ElapsedMilliseconds / 1000);
                label1.ForeColor = Color.Red;
            }
        }

        //导出EXCEL模板文件
        private void btnTP_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToString() == "")
            {
                MessageBox.Show("请选择需要导出模板的表名！");
            }
            else
            {
                Stopwatch watch = Stopwatch.StartNew();
                watch.Start();
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "excel2007|*.xlsx";
                saveFileDialog1.FileName = comboBox1.Text.ToString();
                saveFileDialog1.DefaultExt = ".xlsx";
                string fileName = "";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                    string tname = comboBox1.Text.ToString();
                    string sql = "select * from  " + tname.ToString() + " where 1=2";
                    ExcelHelp.export(tname, fileName, _DBConfig, sql);
                    MessageBox.Show("导出成功");
                }
                watch.Stop();
                GC.Collect();
                label1.Text = string.Format("导出的时间为:{0}秒", watch.ElapsedMilliseconds / 1000);
                label1.ForeColor = Color.Red;
            }

        }

        //删除数据库中的数据
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.ToString() == "")
            {
                MessageBox.Show("请选择需要删除的表名！");
            }
            else
            {
                Stopwatch watch = Stopwatch.StartNew();
                watch.Start();
                string tname = comboBox1.Text.ToString();
                int num = _DBConfig.DB.ExecuteSql("delete  from  " + tname);
                watch.Stop();
                if (num > 0)
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
                label1.Text = string.Format("导出的时间为:{0}秒", watch.ElapsedMilliseconds / 1000);
                label1.ForeColor = Color.Red;

            }
        }

        //导出数据
        private void btnDtout_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count < 1)
            {
                MessageBox.Show("请选择需要导入的表名！");
            }
            else
            {
                Stopwatch watch = Stopwatch.StartNew();
                watch.Start();
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "excel2007|*.xlsx";
                saveFileDialog1.FileName = listBox1.Items[0].ToString();
                saveFileDialog1.DefaultExt = ".xlsx";
                string fileName = "";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                    IList<string> sqls = new List<string>();
                    IList<string> SheetName = new List<string>();
                    foreach (var item in listBox1.Items)
                    {
                        SheetName.Add(item.ToString());
                        sqls.Add("select * from  [" + item.ToString() + "]");
                    }
                    ExcelHelp.export(SheetName, fileName, _DBConfig, sqls);
                    GC.Collect();
                    watch.Stop();
                    label1.Text = string.Format("导出的时间为:{0}秒", watch.ElapsedMilliseconds / 1000);
                    label1.ForeColor = Color.Red;
                    MessageBox.Show("导出成功");
                }
            }
        }



        //增加导出表名
        private void btnAddOne_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Contains(treeView1.SelectedNode.Text.ToString()))
            {
                return;
            }
            else if (listBox1.Items.Count > 9)
            {
                MessageBox.Show("最多可以选择10个表格");
            }
            else
            {
                listBox1.Items.Add(treeView1.SelectedNode.Text.ToString());

            }
        }

        //减少导出表名
        private void btnDeleteOne_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            { MessageBox.Show("请选择删除的表"); }
            else
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }

        }

        private void 登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
        }

        private void btnProcExe_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count < 1)
            {
                MessageBox.Show("请选择需要运算的存储过程！");
            }
            else
            {
                Stopwatch watch = Stopwatch.StartNew();
                watch.Start();
                DataTable dt = new DataTable();
                label1.Text = "";
                foreach (var item in listBox2.Items)
                {

                    int i = _DBConfig.DB.RunProcedure(item.ToString());
                    if (i > 0)
                    {
                        label1.Text = label1.Text + "存储过程:[" + item.ToString() + "]运算成功！" + "\r\n";
                    }
                    else
                    {
                        label1.Text = label1.Text + "存储过程:[" + item.ToString() + "]运算失败！" + "\r\n";
                    }

                }
                watch.Stop();
                label1.Text = label1.Text + string.Format("请求运算时间为:{0}秒", watch.ElapsedMilliseconds / 1000);
                label1.ForeColor = Color.Red;
                GC.Collect();
                MessageBox.Show("请求运算结束");

            }
        }

        private void btnProcAdd_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Contains(treeView2.SelectedNode.Text.ToString()))
            {
                MessageBox.Show("已选择，请选择其他表格");
            }
            else if (listBox2.Items.Count > 9)
            {
                MessageBox.Show("最多可以选择10个表格");
            }
            else
            {
                listBox2.Items.Add(treeView2.SelectedNode.Text.ToString());
            }
        }

        private void btnProcDel_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex < 0)
            { MessageBox.Show("请选择删除的存储过程"); }
            else
            { listBox2.Items.RemoveAt(listBox2.SelectedIndex); }
        }



        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        private Point pi;

        private void treeView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pi = new Point(e.X, e.Y);
        }

        private void treeView1_DoubleClick(object sender, System.EventArgs e)
        {
            TreeNode node = this.treeView1.GetNodeAt(pi);
            if (pi.X < node.Bounds.Left || pi.X > node.Bounds.Right)
            {
                //不触发事件   
                return;
            }
            else
            {
                int i = treeView1.SelectedNode.GetNodeCount(false);
                if (!listBox1.Items.Contains(treeView1.SelectedNode.Text.ToString()) && i == 0)

                    listBox1.Items.Add(treeView1.SelectedNode.Text.ToString());
            }
        }
        private void treeView2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pi = new Point(e.X, e.Y);
        }

        private void treeView2_DoubleClick(object sender, System.EventArgs e)
        {
            TreeNode node = this.treeView2.GetNodeAt(pi);
            if (pi.X < node.Bounds.Left || pi.X > node.Bounds.Right)
            {
                return;
            }
            else
            {
                int i = treeView2.SelectedNode.GetNodeCount(false);
                if (!listBox2.Items.Contains(treeView2.SelectedNode.Text.ToString()) && i == 0)
                    listBox2.Items.Add(treeView2.SelectedNode.Text.ToString());
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(0);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            System.Environment.Exit(0);
        }


        /// <summary>
        /// 分页导出excel
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "excel2007|*.xlsx";
            saveFileDialog1.FileName = comboBox4.Text.ToString();
            saveFileDialog1.DefaultExt = ".xlsx";
            string fileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog1.FileName;
                int pagesize = int.Parse(comboBox3.Text.ToString());
                int num = _DBConfig.DB.ReturnTbCount(comboBox4.Text.ToString());
                string sql = "select * from  [" + comboBox4.Text.ToString().Trim() + "]";
                ExcelHelp.export(comboBox4.Text.ToString(), fileName, _DBConfig, sql, num, pagesize);
                GC.Collect();
                watch.Stop();
                label1.Text = string.Format("导出的时间为:{0}秒", watch.ElapsedMilliseconds / 1000);
                label1.ForeColor = Color.Red;
                MessageBox.Show("导出成功");
            }
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {

            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
        List<String> FileList = new List<string>();
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FileList.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "文本文件|*.txt";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileList.AddRange(openFileDialog.FileNames);
                txtPath.Text = FileList.Count.ToString();
                txtError.Text = "";
                pbFileCount.Maximum = FileList.Count;


            }
        }

        private void btnTxtInput_Click(object sender, EventArgs e)
        {
            string name = txtNtname.Text;
            ThreadPool.QueueUserWorkItem(o =>
            {
                for (int i = 0; i < FileList.Count; i++)
                {
                    pbFileCount.Value = i + 1;
                    string temp = FileList[i];
                    string tname = Path.GetFileName(temp);

                    InputData(temp, tname, name);
                }
                MessageBox.Show("导入完成");

            });

            //InputData();

        }
        private void InputData(string tn, string fn, string Name)
        {

            string tname = tn;//txtTabName.Text.ToString();
            string fName = fn;// txtPath.Text.ToString(); 
            string tabName = string.Empty;
            if (radother.Checked)
            {
                tabName = Name + fName.Substring(2, 4);
            }
            else if (radAll.Checked)
            {
                tabName = Name;
            }
            else if (radError.Checked)
            {
                tabName = Name;
            }
            else if (radDrop.Checked)
            {
                tabName = Name;
            }
            else if (rdoLocate.Checked)
            {
                tabName = Name;
            }
            else if (userInfo.Checked)
            {
                tabName = Name;
            }

            Stopwatch watch = Stopwatch.StartNew();
            watch.Start();
            //获取列名
            List<string> TabList = new List<string>();
            DataTable dt = null;
            if (radother.Checked)
            {
                TabList.Add("Click_DataTime"); //
                TabList.Add("Click_CITYCODE");
                TabList.Add("Click_POIID");
                TabList.Add("Click_POINAME");
                TabList.Add("Click_POICODE");  //
                TabList.Add("Click_POITYPE_H");
                TabList.Add("Click_POITYPE_M");
                TabList.Add("Click_POITYPE_L");
                TabList.Add("Click_X");
                TabList.Add("Click_Y");
                TabList.Add("Click_NUMCOUNT");
                dt = ReaderTxt2DataTable(tname);  //单个城市
                IList<string> List = TabList;//= _DBConfig.DB.GetColumnInfo(tname.Split('.')[0]); 
                if (!_DBConfig.DB.SqlBulkCopyImport(List, tabName, dt))
                {
                    txtError.Text += "Err" + "|" + tname;
                }
            }
            else if (radAll.Checked)
            {
                TabList.Add("Click_NID");      //
                TabList.Add("Click_CITYCODE");
                TabList.Add("Click_CITYNAME"); //
                TabList.Add("Click_POIID");
                TabList.Add("Click_POINAME");
                TabList.Add("Click_POITYPE_H");
                TabList.Add("Click_POITYPE_M");
                TabList.Add("Click_POITYPE_L");
                TabList.Add("Click_X");
                TabList.Add("Click_Y");
                TabList.Add("Click_NUMCOUNT");
                ReaderTxt2DataTables(tname, TabList, tabName); //全国 

            }
            else if (radError.Checked)
            {
                TabList.Add("Error_Name");      //
                TabList.Add("Error_Addr");
                TabList.Add("Error_Type"); //
                TabList.Add("Error_X");
                TabList.Add("Error_Y");
                TabList.Add("Error_Note");
                ErrorTxt2Datatable(tname, TabList, tabName);
            }
            else if (radDrop.Checked)
            {
                TabList.Add("Drop_POIID");
                TabList.Add("Drop_POINAME");
                TabList.Add("Drop_POITYPE");
                TabList.Add("Drop_DELREA");
                TabList.Add("Drop_DELTIME");
                TabList.Add("Drop_X");
                TabList.Add("Drop_Y");
                TabList.Add("Drop_CITYNAME");
                DropTxt2Datatable(tname, TabList, tabName);
            }
            else if (rdoLocate.Checked)
            {
                TabList.Add("Locate_TIME");
                TabList.Add("Locate_IMEI");
                TabList.Add("Locate_NO");
                TabList.Add("Locate_SRC");
                TabList.Add("Locate_X");
                TabList.Add("Locate_Y");
                TabList.Add("Locate_PRECISION");
                TabList.Add("Locate_ADDR");
                LocateTxt2Datatable(tname, TabList, tabName);
            }
            else if (userInfo.Checked)
            {
                TabList.Add("LBI_UserName");
                TabList.Add("LBI_Pass");
                TabList.Add("LBI_Rank");

                UserInfoTxt2Datatable(tname, TabList, tabName);
            }

            watch.Stop();
            GC.Collect();
            label1.Text = string.Format("导入的时间为:{0}秒", watch.ElapsedMilliseconds / 1000);
            label1.ForeColor = Color.Red;

        }
        /// <summary>
        /// 读取文本为datatable. 单一城市
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private DataTable ReaderTxt2DataTable(string path)
        {
            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                #region 添加列
                dt.Columns.Add("Click_DataTime");
                dt.Columns.Add("Click_CITYCODE");
                dt.Columns.Add("Click_POIID");
                dt.Columns.Add("Click_POINAME");
                dt.Columns.Add("Click_POICODE");
                dt.Columns.Add("Click_POITYPE_H");
                dt.Columns.Add("Click_POITYPE_M");
                dt.Columns.Add("Click_POITYPE_L");
                dt.Columns.Add("Click_X");
                dt.Columns.Add("Click_Y");
                dt.Columns.Add("Click_NUMCOUNT");
                #endregion

                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    string[] Fields = row.Split('\t');

                    DataRow dr;
                    #region 添加行
                    dr = dt.NewRow();
                    if (!string.IsNullOrEmpty(Fields[0]))
                    {   //非空时
                        DateTime dtime = new DateTime(int.Parse(Fields[0].Substring(0, 4)), int.Parse(Fields[0].Substring(4, 2)), int.Parse(Fields[0].Substring(6, 2)));
                        dr["Click_DataTime"] = dtime.ToString("yyyy-MM-dd hh:mm:ss");
                    }
                    else
                    {
                        //空时至00
                        DateTime dtime = new DateTime();
                        dr["Click_DataTime"] = dtime.ToString("yyyy-MM-dd hh:mm:ss");
                    }
                    dr["Click_CITYCODE"] = Fields[1];

                    dr["Click_POIID"] = Fields[2];

                    dr["Click_POINAME"] = Fields[3];

                    dr["Click_POICODE"] = Fields[4];
                    string str = Fields[5];
                    if (str.Split(';').Length > 2)
                    {

                        dr["Click_POITYPE_H"] = str.Split(';')[0];

                        dr["Click_POITYPE_M"] = str.Split(';')[1];

                        dr["Click_POITYPE_L"] = str.Split(';')[2];

                    }
                    else
                    {

                        dr["Click_POITYPE_H"] = "UnKnow";

                        dr["Click_POITYPE_M"] = "UnKnow";

                        dr["Click_POITYPE_L"] = "UnKnow";
                    }

                    dr["Click_X"] = Fields[6];

                    dr["Click_Y"] = Fields[7];

                    dr["Click_NUMCOUNT"] = Fields[8];
                    dt.Rows.Add(dr);
                    #endregion
                }
            }
            return dt;


        }

        /// <summary>
        /// 读取文本为datatable. 全国
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private void ReaderTxt2DataTables(string path, List<string> list, string tabName)
        {
            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                #region 添加列
                dt.Columns.Add("Click_NID");
                dt.Columns.Add("Click_CITYCODE");
                dt.Columns.Add("Click_CITYNAME");
                dt.Columns.Add("Click_POINAME");
                dt.Columns.Add("Click_POIID");
                dt.Columns.Add("Click_POITYPE_H");
                dt.Columns.Add("Click_POITYPE_M");
                dt.Columns.Add("Click_POITYPE_L");
                dt.Columns.Add("Click_X");
                dt.Columns.Add("Click_Y");
                dt.Columns.Add("Click_NUMCOUNT");
                #endregion
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    string[] Fields = row.Split('\t');
                    DataRow dr;
                    #region 添加行
                    dr = dt.NewRow();
                    dr["Click_NID"] = Fields[0];
                    dr["Click_CITYCODE"] = Fields[1];
                    dr["Click_CITYNAME"] = Fields[2];
                    dr["Click_POINAME"] = Fields[3];
                    dr["Click_POIID"] = Fields[4];
                    string str = Fields[5];
                    if (str.Split(';').Length > 2)
                    {
                        dr["Click_POITYPE_H"] = str.Split(';')[0];

                        dr["Click_POITYPE_M"] = str.Split(';')[1];

                        dr["Click_POITYPE_L"] = str.Split(';')[2];

                    }
                    else
                    {

                        dr["Click_POITYPE_H"] = "UnKnow";

                        dr["Click_POITYPE_M"] = "UnKnow";

                        dr["Click_POITYPE_L"] = "UnKnow";
                    }

                    dr["Click_X"] = Fields[6];

                    dr["Click_Y"] = Fields[7];

                    dr["Click_NUMCOUNT"] = Fields[8];
                    dt.Rows.Add(dr);
                    #endregion

                    if (dt.Rows.Count == 1000000)
                    {
                        IList<string> List = list;
                        _DBConfig.DB.SqlBulkCopyImport(List, tabName, dt);
                        dt.Rows.Clear();
                    }
                }
                IList<string> Lists = list;
                if (dt.Rows.Count > 0)
                {
                    _DBConfig.DB.SqlBulkCopyImport(Lists, tabName, dt);
                }
            }

        }

        /// <summary>
        /// 报错数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="list"></param>
        /// <param name="tabName"></param>
        private void ErrorTxt2Datatable(string path, List<string> list, string tabName)
        {
            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                #region 添加列
                dt.Columns.Add("Error_Name");
                dt.Columns.Add("Error_Addr");
                dt.Columns.Add("Error_Type");
                dt.Columns.Add("Error_X");
                dt.Columns.Add("Error_Y");
                dt.Columns.Add("Error_Note");
                #endregion
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    if (row != ",,,,," && row != "")
                    {
                        string[] Fields = row.Split(',');
                        DataRow dr;
                        #region 添加行
                        dr = dt.NewRow();
                        dr["Error_Name"] = Fields[0];
                        dr["Error_Addr"] = Fields[1];
                        dr["Error_Type"] = Fields[2];
                        dr["Error_X"] = Fields[3];
                        dr["Error_Y"] = Fields[4];
                        dr["Error_Note"] = Fields[5];
                        dt.Rows.Add(dr);
                        #endregion
                    }

                    if (dt.Rows.Count == 1000000)
                    {
                        IList<string> List = list;
                        _DBConfig.DB.SqlBulkCopyImport(List, tabName, dt);
                        dt.Rows.Clear();
                    }
                }
                IList<string> Lists = list;
                if (dt.Rows.Count > 0)
                {
                    _DBConfig.DB.SqlBulkCopyImport(Lists, tabName, dt);
                }
            }
        }

        /// <summary>
        /// 下线数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="list"></param>
        /// <param name="tabName"></param>
        private void DropTxt2Datatable(string path, List<string> list, string tabName)
        {
            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                #region 添加列
                dt.Columns.Add("Drop_POIID");
                dt.Columns.Add("Drop_POINAME");
                dt.Columns.Add("Drop_POITYPE");
                dt.Columns.Add("Drop_DELREA");
                dt.Columns.Add("Drop_DELTIME");
                dt.Columns.Add("Drop_X");
                dt.Columns.Add("Drop_Y");
                dt.Columns.Add("Drop_CITYNAME");
                #endregion
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();

                    string[] Fields = row.Split(',');
                    DataRow dr;
                    #region 添加行
                    dr = dt.NewRow();
                    dr["Drop_POIID"] = Fields[0].Trim('\"');
                    dr["Drop_POINAME"] = Fields[1].Trim('\"');
                    dr["Drop_POITYPE"] = Fields[2].Trim('\"');
                    dr["Drop_DELREA"] = Fields[3].Trim('\"');
                    dr["Drop_DELTIME"] = Fields[4].Trim('\"');
                    dr["Drop_X"] = Fields[5].Trim('\"');
                    dr["Drop_Y"] = Fields[6].Trim('\"');
                    dr["Drop_CITYNAME"] = Fields[7].Trim('\"');
                    dt.Rows.Add(dr);
                    #endregion

                    if (dt.Rows.Count == 1000000)
                    {
                        IList<string> List = list;
                        _DBConfig.DB.SqlBulkCopyImport(List, tabName, dt);
                        dt.Rows.Clear();
                    }
                }
                IList<string> Lists = list;
                if (dt.Rows.Count > 0)
                {
                    _DBConfig.DB.SqlBulkCopyImport(Lists, tabName, dt);
                }
            }
        }

        /// <summary>
        /// 定位数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="list"></param>
        /// <param name="tabName"></param>
        private void LocateTxt2Datatable(string path, List<string> list, string tabName)
        {
            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                #region 添加列
                dt.Columns.Add("Locate_TIME");
                dt.Columns.Add("Locate_IMEI");
                dt.Columns.Add("Locate_NO");
                dt.Columns.Add("Locate_SRC");
                dt.Columns.Add("Locate_X");
                dt.Columns.Add("Locate_Y");
                dt.Columns.Add("Locate_PRECISION");
                dt.Columns.Add("Locate_ADDR");
                #endregion
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();

                    string[] Fields = row.Split(',');
                    DataRow dr;
                    #region 添加行
                    dr = dt.NewRow();
                    dr["Locate_TIME"] = Fields[0].Trim('\"');
                    dr["Locate_IMEI"] = Fields[1].Trim('\"');
                    dr["Locate_NO"] = Fields[2].Trim('\"');
                    dr["Locate_SRC"] = Fields[3].Trim('\"');
                    dr["Locate_X"] = Fields[4].Trim('\"');
                    dr["Locate_Y"] = Fields[5].Trim('\"');
                    dr["Locate_PRECISION"] = Fields[6].Trim('\"');
                    dr["Locate_ADDR"] = Fields[7].Trim('\"');
                    dt.Rows.Add(dr);
                    #endregion

                    if (dt.Rows.Count == 1000000)
                    {
                        IList<string> List = list;
                        _DBConfig.DB.SqlBulkCopyImport(List, tabName, dt);
                        dt.Rows.Clear();
                    }
                }
                IList<string> Lists = list;
                if (dt.Rows.Count > 0)
                {
                    _DBConfig.DB.SqlBulkCopyImport(Lists, tabName, dt);
                }
            }
        }
        /// <summary>
        /// 用户
        /// </summary>
        /// <param name="path"></param>
        /// <param name="list"></param>
        /// <param name="tabName"></param>
        private void UserInfoTxt2Datatable(string path, List<string> list, string tabName)
        {
            DataTable dt = new DataTable();

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                #region 添加列
                dt.Columns.Add("LBI_UserName");
                dt.Columns.Add("LBI_Pass");
                dt.Columns.Add("LBI_Rank");

                #endregion
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();

                    string[] Fields = row.Split(',');
                    DataRow dr;
                    #region 添加行
                    dr = dt.NewRow();
                    dr["LBI_UserName"] = Fields[0];
                    dr["LBI_Pass"] = Fields[1];
                    dr["LBI_Rank"] = 0;

                    dt.Rows.Add(dr);
                    #endregion

                    if (dt.Rows.Count == 1000000)
                    {
                        IList<string> List = list;
                        _DBConfig.DB.SqlBulkCopyImport(List, tabName, dt);
                        dt.Rows.Clear();
                    }
                }
                IList<string> Lists = list;
                if (dt.Rows.Count > 0)
                {
                    _DBConfig.DB.SqlBulkCopyImport(Lists, tabName, dt);
                }
            }
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked)
            {
                txtNtname.Text = "LBI_Click_Data_2013_All";
            }
        }

        private void radother_CheckedChanged(object sender, EventArgs e)
        {
            if (radother.Checked)
            {
                txtNtname.Text = "LBI_Click_Data_BeiJing_";

            }
        }

        private void radError_CheckedChanged(object sender, EventArgs e)
        {
            if (radError.Checked)
            {
                txtNtname.Text = "LBI_Error_Data";
            }
        }

        private void radDrop_CheckedChanged(object sender, EventArgs e)
        {
            if (radDrop.Checked)
            {
                txtNtname.Text = "LBI_Drop_Data";
            }
        }

        private void rdoDingWei_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoLocate.Checked)
            {
                txtNtname.Text = "LBI_Locate_Data";
            }

        }

        private void userInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (userInfo.Checked)
            {
                txtNtname.Text = "LBI_UserConfig";
            }
        }











    }
}
