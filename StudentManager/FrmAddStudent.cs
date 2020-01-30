using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {       
        public FrmAddStudent()
        {
            InitializeComponent();   
        
            //初始化下拉框的内容
            this.cboClassName.DataSource = objClassService.GetAllClass();
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";

            this.dgvStuList.AutoGenerateColumns = false;
        }

        private StudentClassService objClassService = new StudentClassService();

        private StudentService objStudentService = new StudentService();

        List<Student> listStu = new List<Student>();


        /// <summary>
        /// 添加新学员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region 数据验证
            //非空验证
            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("学生姓名不能为空");
                this.txtStudentName.Focus();
                return;
            }
            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("请输入性别");
                return;
            }
            if (this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("考勤卡号不能为空");
                this.txtCardNo.Focus();
                return;
            }
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级");
                return;
            }

            //年龄验证
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age>35 || age<18)
            {
                MessageBox.Show("年龄必须在18-35岁之间");
                return;
            }

            //身份证格式验证
            if (!DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证输入错误");
                return;
            }
            //验证身份证与出生日期是否符合
            string birthday = Convert.ToDateTime(this.dtpBirthday.Text).ToString("yyyyMMdd");
            if (!this.txtStudentIdNo.Text.Trim().Contains(birthday))
            {
                MessageBox.Show("身份证与出生日期不匹配");
                return;
            }
            #endregion

            #region 身份证号和考勤卡号的重复验证

            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("该身份证号重复", "错误提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }

            if (objStudentService.IsCardNoExisted(this.txtCardNo.Text.Trim()))
            {
                MessageBox.Show("该考勤卡号已经存在", "错误提示");
                this.txtCardNo.Focus();
                this.txtCardNo.SelectAll();
                return;
            }
            #endregion

            #region 封装学生对象

            Student objStudent = new Student()
            {
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoMale.Checked ? "男" : "女",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtAddress.Text.Trim(),
                ClassName = this.cboClassName.Text,
                CardNo = this.txtCardNo.Text.Trim(),
                ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),//获取选择班级对应的ClassId
                Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year,
                StuImage = this.pbStu.Image!=null? new SerializeObjectToString().SerializeObject(this.pbStu.Image):""
            };

            #endregion

            ///调用后台数据访问方法
            try
            {
                int studentId = objStudentService.AddStudent(objStudent);
                if (studentId >1)
                {
                    //同步显示添加的学生
                    objStudent.StudentId = studentId;
                    listStu.Add(objStudent);
                    dgvStuList.DataSource = null;
                    dgvStuList.DataSource = listStu;

                    //询问是否继续添加
                    DialogResult result = MessageBox.Show("新学员添加成功，是否继续添加", "提示信息",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        //清空用户输入的信息


                    }
                    else
                    {
                        this.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                
                MessageBox.Show("添加学员失败，原因："+ex.Message);
            }


            
        }
    
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
    
        /// <summary>
        /// 选择新照片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.pbStu.Image = Image.FromFile(fileDialog.FileName);
            }
        }
    }
}