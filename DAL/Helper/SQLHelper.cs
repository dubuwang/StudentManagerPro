using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;//引用读取配置文件类所在的命名空间

namespace DAL
{
    /// <summary>
    /// 访问SQLServer数据库的通用类
    /// </summary>
    class SQLHelper
    {
        //private static readonly string connString = @"Server=LAPTOP-QJAA410S\SQLEXPRESS;DataBase=SMDB;Uid=sa;Pwd=520";
        /// <summary>
        /// 从app.config配置文件中读取加密的字符串，解密后赋值给数据库连接字符串
        /// </summary>
        private static readonly string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();



        /// <summary>
        /// 执行增insert、删delete、改update的sql语句, ExecuteNonQuery()
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>受影响行数</returns>
        public static int Update(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
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
        /// 执行单一结果查询（select的sql语句）,ExeCuteScalar()
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>返回查询到的结果集中的第一行第一列</returns>
        public static object GetSingleResult(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
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
        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
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
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);    //创建一个数据适配器对象

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


        public static bool UpdateByTran(List<string> listSql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.Transaction = conn.BeginTransaction();
                foreach (string sql in listSql)
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                //提交事务（真正保存到数据库）
                cmd.Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction.Rollback(); //回滚事务
                }

                throw ex;
            }
            finally
            {
                if (cmd.Transaction != null)
                {
                    cmd.Transaction = null;  //清除事务
                }
                conn.Close();
            }

        }


        /// <summary>
        /// 获取当前服务器的时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            return Convert.ToDateTime(GetSingleResult("select getdate()"));
        }
    }
}
