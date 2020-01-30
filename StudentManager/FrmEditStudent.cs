using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DAL;
using Models;

namespace StudentManager
{
    public partial class FrmEditStudent : Form
    {
        public FrmEditStudent()
        {
            InitializeComponent();
        }

        public FrmEditStudent(Student objStudent):this()
        {

            //初始化下拉框的内容
            this.cboClassName.DataSource = new StudentClassService().GetAllClass();
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";
            
            //显示学员详细信息

            this.cboClassName.Text = objStudent.ClassName;

            this.txtStudentName.Text = objStudent.StudentName;
            if (objStudent.Gender == "男")
            {
                this.rdoMale.Checked = true;
            }
            else
            {
                this.rdoFemale.Checked=true;
            }

            this.txtStudentId.Text = objStudent.StudentId.ToString();
            
            this.txtAddress.Text = objStudent.StudentAddress;
            this.txtCardNo.Text = objStudent.CardNo;
            this.dtpBirthday.Text = objStudent.Birthday.ToString("yyyy-MM-dd");
           
            this.txtPhoneNumber.Text = objStudent.PhoneNumber;
            this.txtStudentIdNo.Text = objStudent.StudentIdNo;

            if (objStudent.StuImage.Length > 0)
            {
                this.pbStu.Image = (Image)new SerializeObjectToString().DeserializeObject(objStudent.StuImage);
            }
            else
            {
                this.pbStu.Image = Image.FromFile("default.png");
            }
        }

        private StudentService objStudentService = new StudentService();


        //提交修改
        private void btnModify_Click(object sender, EventArgs e)
        {
           //数据验证


           //验证身份证号是否重复
            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim(),this.txtStudentId.Text.Trim()))
            {
                MessageBox.Show("身份证号与现有的学员相同", "提示信息");
                return;
            }

            Student objStudent = new Student()
            {
                StudentId = Convert.ToInt32(this.txtStudentId.Text.Trim()),
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
                StuImage = this.pbStu.Image != null ? new SerializeObjectToString().SerializeObject(this.pbStu.Image) : ""
            };

            try
            {
                if (objStudentService.ModifyStudent(objStudent) == 1)
                {
                    MessageBox.Show("学员信息修改成功", "提示信息");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "提示信息");
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //选择照片
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pbStu.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}