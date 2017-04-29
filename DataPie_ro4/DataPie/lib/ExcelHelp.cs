
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace DataPie
{
    class ExcelHelp
    {
        /// <summary>
        /// 根据excel路径和sheet名称，返回excel的DataTable
        /// </summary>
        public static DataTable GetExcelDataTable(string path, string tname)
        {
            /*Office 2007*/
            string ace = "Microsoft.ACE.OLEDB.12.0";
            /*Office 97 - 2003*/
            string jet = "Microsoft.Jet.OLEDB.4.0";
            string xl2007 = "Excel 12.0 Xml";
            string xl2003 = "Excel 8.0";
            string imex = "IMEX=1";
            /* csv */
            string text = "text";
            string fmt = "FMT=Delimited";
            string hdr = "Yes";
            string conn = "Provider={0};Data Source={1};Extended Properties=\"{2};HDR={3};{4}\";";
            string select = string.Format("SELECT * FROM [{0}$]", tname);
            //string select = sql;
            string ext = Path.GetExtension(path);
            OleDbDataAdapter oda;
            DataTable dt = new DataTable("data");
            switch (ext.ToLower())
            {
                case ".xlsx":
                    conn = String.Format(conn, ace, Path.GetFullPath(path), xl2007, hdr, imex);
                    break;
                case ".xls":
                    conn = String.Format(conn, jet, Path.GetFullPath(path), xl2003, hdr, imex);
                    break;
                case ".csv":
                    conn = String.Format(conn, jet, Path.GetDirectoryName(path), text, hdr, fmt);
                    //sheet = Path.GetFileName(path);
                    break;
                default:
                    throw new Exception("File Not Supported!");
            }
            OleDbConnection con = new OleDbConnection(conn);
            con.Open();
            //select = string.Format(select, sql);
            oda = new OleDbDataAdapter(select, con);
            oda.Fill(dt);
            con.Close();
            return dt;
        }
        /// <summary>
        /// 保存excel文件，覆盖相同文件名的文件
        /// </summary>
        public static bool SaveExcel(string SheetName, DataTable dt, ExcelPackage package)
        {

            try
            {               
                ExcelWorksheet ws = package.Workbook.Worksheets.Add(SheetName);
                ws.Cells["A1"].LoadFromDataTable(dt, true);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 多个表格导出到一个excel工作簿
        /// </summary>
        public static void export(IList<string> SheetNames, string filename, DBConfig db, IList<string> sqls)
        {
            DataTable dt = new DataTable();
            FileInfo newFile = new FileInfo(filename);
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(filename);
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                for (int i = 0; i < sqls.Count; i++)
                {
                    dt = db.DB.ReturnDataTable(sqls[i]);
                    SaveExcel(SheetNames[i], dt, package);
                }
                package.Save();
            }
        }

        /// <summary>
        /// 单个表格导出到一个excel工作簿
        /// </summary>
        public static void export(string SheetName, string filename, DBConfig db, string sql)
        {
            DataTable dt = new DataTable();
            FileInfo newFile = new FileInfo(filename);
            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(filename);
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                dt = db.DB.ReturnDataTable(sql);
                SaveExcel(SheetName, dt, package);
                package.Save();
            }
        }

        /// <summary>
        /// 单个表导出到多个excel工作簿（分页）
        /// </summary>
        public static void export(string SheetName, string filename, DBConfig db, string sql, int num, int pagesize)
        {
            DataTable dt = new DataTable();
            FileInfo newFile = new FileInfo(filename);
            int numtb = num / pagesize + 1;
            for (int i = 1; i <= numtb; i++)
            {
                string s = filename.Substring(0, filename.LastIndexOf("."));
                StringBuilder newfileName = new StringBuilder(s);
                newfileName.Append(i + ".xlsx");
                newFile = new FileInfo(newfileName.ToString());
                if (newFile.Exists)
                {
                    newFile.Delete();
                    newFile = new FileInfo(newfileName.ToString());
                }
                using (ExcelPackage package = new ExcelPackage(newFile))
                {
                    dt = db.DB.ReturnDataTable(sql, pagesize * (i - 1), pagesize);
                    SaveExcel(SheetName, dt, package);
                    package.Save();
                }
            }
        }
    
    
    }
}