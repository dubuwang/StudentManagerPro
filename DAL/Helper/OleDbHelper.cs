using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace DAL
{
    /// <summary>
    /// 访问Access数据库的通用类
    /// </summary>
    class OleDbHelper
    {
        //创建连接字符串
        //适合Excel2003版本：connString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source={0},Extended Properties=Excel 8.0"

        //适合Excel2007以后的版本
        private static string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0";

       

        /// <summary>
        /// 执行增insert、删delete、改update的语句，ExecuteNonQuery()方法
        /// </summary>
        /// <returns></returns>
        public static int Update(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 执行单一结果查询（select的sql语句）,ExeCuteScalar()
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回查询到的结果集中的第一行第一列</returns>
        public static object GetSingleResult(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //将错误信息写入日志...

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 执行结果集查询（select的sql语句）,ExecuteReader()
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>返回一个SqlDataReader对象</returns>
        public static OleDbDataReader GetReader(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }

                //将错误信息写入日志...
                throw ex;
            }
        }

        /// <summary>
        /// 执行返回DataSet的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);    //创建一个数据适配器对象

            DataSet ds = new DataSet();     //创建一个内存数据集对象

            try
            {
                conn.Open();
                da.Fill(ds);        //使用数据适配器填充数据集
                return ds;
            }
            catch (Exception ex)
            {
                //将错误信息写入日志

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public static DataSet GetDataSet(string sql,string path)
        {
            OleDbConnection conn = new OleDbConnection(string.Format(connString,path));
            OleDbCommand cmd = new OleDbCommand(sql, conn);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);    //创建一个数据适配器对象

            DataSet ds = new DataSet();     //创建一个内存数据集对象

            try
            {
                conn.Open();
                da.Fill(ds);        //使用数据适配器填充数据集
                return ds;
            }
            catch (Exception ex)
            {
                //将错误信息写入日志

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

       
    }
}
