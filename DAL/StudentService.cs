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

    public class StudentService
    {
        /// <summary>
        /// 判断学员表中该身份证号是否已存在，返回true表示已存在
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <returns>返回true表示已存在</returns>
        public bool IsIdNoExisted(string studentIdNo)
        {
            string sql = "select count(*) from Students where StudentIdNo={0}";
            sql = string.Format(sql, studentIdNo);
            int result = int.Parse(SQLHelper.GetSingleResult(sql).ToString());

            if (result == 1) return true;
            else return false;
        }

        /// <summary>
        /// 判断学员表中该考勤卡号是否已经存在
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public bool IsCardNoExisted(string CardNo)
        {
            string sql = "select count(*) from Students where CardNo={0}";
            sql = string.Format(sql, CardNo);
            int result = int.Parse(SQLHelper.GetSingleResult(sql).ToString());

            if (result == 1) return true;
            else return false;
        }

        /// <summary>
        /// 添加学员对象，返回添加成功的学员的学号
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns>学号</returns>
        public int AddStudent(Student objStudent)
        {
            //编写sql语句
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students(StudentName,Gender,Birthday,StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId,StuImage)");
            sqlBuilder.Append("  values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},'{9}');select @@identity");

            //解析对象
            string sql = string.Format(sqlBuilder.ToString(),
                objStudent.StudentName, objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
                objStudent.StudentIdNo, objStudent.Age, objStudent.PhoneNumber,
                objStudent.StudentAddress, objStudent.CardNo, objStudent.ClassId, objStudent.StuImage);

            //提交到数据库
            try
            {
                return Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            }
            catch (SqlException ex)
            {

                throw new Exception("添加学员时，数据库操作出现异常，原因：" + ex.Message);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 通过班级名称查询所有学生
        /// </summary>
        /// <param name="className">班级名</param>
        /// <returns></returns>
        public List<Student> GetStudentByClass(string className)
        {
            string sql = "select StudentName,StudentId,Gender,Birthday,ClassName from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where ClassName='{0}'";
            sql = string.Format(sql, className);

            SqlDataReader objReader = SQLHelper.GetReader(sql);

            List<Student> list = new List<Student>();

            while (objReader.Read())
            {
                list.Add(new Student()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString()
                });
            }
            objReader.Close();

            return list;

        }


        /// <summary>
        /// 根据学号查询一个学员对象
        /// </summary>
        /// <param name="studentId">学号</param>
        /// <returns></returns>
        public Student GetStudentById(string studentId)
        {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,StudentIdNo,PhoneNumber,StudentAddress,CardNo,StuImage from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where StudentId=" + studentId;
            SqlDataReader objReader = SQLHelper.GetReader(sql);

            Student objStudent = null;

            if (objReader.Read())
            {
                objStudent = new Student()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    CardNo = objReader["CardNo"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    StuImage = objReader["StuImage"] == null ? "" : objReader["StuImage"].ToString()
                };
            }
            objReader.Close();

            return objStudent;
        }

        /// <summary>
        /// 修改学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int ModifyStudent(Student objStudent)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("Update Students set StudentName='{0}',Gender='{1}',Birthday='{2}',");
            sqlBuilder.Append("StudentIdNo={3},Age={4},PhoneNumber='{5}',StudentAddress='{6}',CardNo='{7}',ClassId={8},StuImage='{9}'");
            sqlBuilder.Append(" where StudentId={10}");
            //解析对象
            string sql = string.Format(sqlBuilder.ToString(),
            objStudent.StudentName, objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
            objStudent.StudentIdNo, objStudent.Age, objStudent.PhoneNumber,
            objStudent.StudentAddress, objStudent.CardNo, objStudent.ClassId, objStudent.StuImage,objStudent.StudentId);
            
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                throw new Exception("修改学员时，数据库操作出现异常！具体信息：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 修改学员时判断身份证号是否和其他学员重复
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string studentIdNo, string studentId)
        {
            string sql = "select count(*) from Students where StudentIdNo={0} and StudentId<>{1}";
            sql = string.Format(sql, studentIdNo, studentId);
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }

        /// <summary>
        /// 根据学员id删除该学员对象
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public int DeleteStudentById(Student objStudent)
        {
            string sql = "delete from Students where StudentId=" + objStudent.StudentId;
            try
            {
                return SQLHelper.Update(sql);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("该学号被其他数据表引用，不能直接删除该学员对象！");
                else
                    throw new Exception("数据库操作出现异常！具体信息：" + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
