using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class SysAdminService
    {
        /// <summary>
        /// 管理员登陆方法
        /// </summary>
        /// <param name="objSysAdmin">封装了登陆id和pwd的管理员对象</param>
        /// <returns>查询到的管理员对象，如果为null，则未查询到</returns>
        public SysAdmin AdminLogin(SysAdmin objSysAdmin)
        {
            //1.编写sql语句
            string sql = "select AdminName from Admins where LoginId = {0} and LoginPwd = '{1}'";
            sql = string.Format(sql, objSysAdmin.LoginId, objSysAdmin.LoginPwd);


            try
            {
                //2.调用数据访问类，执行sql语句
                SqlDataReader objReader = SQLHelper.GetReader(sql);

                //3.封装对象，返回结果
                if (objReader.Read())
                {
                    objSysAdmin.AdminName = objReader["AdminName"].ToString();
                    objReader.Close();
                }
                else
                {
                    objSysAdmin = null;
                }

            }
            catch (SqlException ex)
            {
                objSysAdmin = null;
                throw new Exception("数据库访问出现问题：" + ex.Message);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return objSysAdmin;
        }


        public int ModifyPwd(SysAdmin objSysAdmin)
        {
            string sql = "update Admins set LoginPwd = '{0}' where LoginId = {1}";
            sql = string.Format(sql, objSysAdmin.LoginPwd, objSysAdmin.LoginId);

            try
            {
                return SQLHelper.Update(sql);
            }
            catch (Exception ex)
            {

                throw new Exception("修改密码时访问数据库出线错误，原因：" + ex.Message);
            }
        }

    }
}
