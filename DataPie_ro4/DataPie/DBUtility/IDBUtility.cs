using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace DataPie.DBUtility
{
    public interface IDBUtility
    {
        #region 执行SQL操作      返回 -1为失败 >0为成功   string SQL
        ///// <summary>
        ///// 设置字符串
        ///// </summary>
        ///// <param name="strConnectionString"></param>
        //void SetConnectionString(string strConnectionString);
        /// <summary>
        /// 运行SQL语句
        /// </summary>
        /// <param name="SQL"></param>
        int ExecuteSql(string SQL);
        #endregion

        #region 返回DataTable对象

        /// <summary>
        /// 运行SQL语句,返回DataTable对象
        /// </summary>
        DataTable ReturnDataTable(string SQL, int StartIndex, int PageSize);
        /// <summary>
        /// 运行SQL语句,返回DataTable对象
        /// </summary>
        DataTable ReturnDataTable(string SQL);
        #endregion

        #region 存储过程操作
        int RunProcedure(string storedProcName);
        #endregion

        #region 获取数据库Schema信息
        /// <summary>
        /// 获取数据库中的所有表
        /// </summary>
        IList<string> GetDataBaseInfo();
        IList<string> GetTableInfo();
        IList<string> GetColumnInfo(string TableName);
        IList<string> GetProcInfo();
        //IList<string> GetFunctionInfo();
        IList<string> GetViewInfo();
        int ReturnTbCount(string tb_name);
        #endregion

        #region 批量导入数据库
        /// <summary>
        /// 批量导入数据库
        /// </summary>
        bool SqlBulkCopyImport(IList<string> maplist, string TableName, DataTable dt);
        #endregion
    }
}
