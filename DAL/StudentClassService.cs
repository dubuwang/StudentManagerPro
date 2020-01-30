using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    /// <summary>
    /// 班级数据访问类
    /// </summary>
    public class StudentClassService
    {
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <returns></returns>
        public List<StudentClass> GetAllClass()
        {
            string sql = "select ClassName,ClassId from StudentClass";
            List<StudentClass> list = new List<StudentClass>();
            SqlDataReader objReader = null;
            try
            {
                objReader = SQLHelper.GetReader(sql);
                while (objReader.Read())
                {
                    list.Add(new StudentClass()
                    {
                        ClassId = Convert.ToInt32(objReader["ClassId"]),
                        ClassName = objReader["ClassName"].ToString()
                    });
                }
            }
            catch (SqlException ex)
            {
                
                throw new Exception("访问数据库班级信息出现错误，原因："+ex.Message);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                objReader.Close();
            }
            
            return list;
            
        }

        /// <summary>
        /// 获取班级信息，存放到返回的数据集里面
        /// </summary>
        /// <returns></returns>
        public DataSet GetClasses()
        {
            string sql = "select ClassId,ClassName from StudentClass";
            try
            {
                return SQLHelper.GetDataSet(sql);
            }
            catch (SqlException ex)
            {

                throw new Exception("数据库访问异常，原因：" + ex.Message);

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
