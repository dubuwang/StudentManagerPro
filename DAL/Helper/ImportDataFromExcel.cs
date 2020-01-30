using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 从Excel中导入数据
    /// </summary>
    public class ImportDataFromExcel
    {
        /// <summary>
        /// 从指定路径的excle文件查询读取数据，封装成student
        /// </summary>
        /// <param name="path">excel文件路径</param>
        /// <returns></returns>
        public List<Student> GetStudentByExcel(string path)
        {
            List<Student> list = new List<Student>();

            string sql = "select *from[Student$]";

            DataSet ds = OleDbHelper.GetDataSet(sql, path);

            DataTable dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Student()
                { 
                    StudentName = row["姓名"].ToString(),
                    Gender = row["性别"].ToString(),
                    Birthday = Convert.ToDateTime(row["出生日期"].ToString()),
                    StudentIdNo = row["身份证号"].ToString(),
                    CardNo = row["考勤卡号"].ToString(),
                    PhoneNumber = row["电话号码"].ToString(),
                    StudentAddress = row["家庭住址"].ToString(),
                    ClassId = int.Parse(row["班级编号"].ToString()),
                    Age = DateTime.Now.Year - Convert.ToDateTime(row["出生日期"].ToString()).Year
                });
            }

            return list;
        }

        /// <summary>
        /// 批量添加学生
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool ImportStudentList(List<Student> list)
        {

            //1-编写sql语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students(StudentName,Gender,Birthday,StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId)");
            sqlBuilder.Append("  values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8})");

            List<string> listSql = new List<string>();

            //2-解析对象
            foreach (Student objStudent in list)
            {
                
                string sql = string.Format(sqlBuilder.ToString(),
                    objStudent.StudentName, objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
                    objStudent.StudentIdNo, objStudent.Age, objStudent.PhoneNumber,
                    objStudent.StudentAddress, objStudent.CardNo, objStudent.ClassId);

                listSql.Add(sql);
            }
            

            //3-将sql语句提交到数据库

            try
            {
                return SQLHelper.UpdateByTran(listSql);
            }
            catch (SqlException ex)
            {

                throw new Exception("批量添加学员时，数据库事务操作出现异常，原因：" + ex.Message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
