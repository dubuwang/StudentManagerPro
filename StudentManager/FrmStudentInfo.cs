using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Models;


namespace StudentManager
{
    public partial class FrmStudentInfo : Form
    {
        public FrmStudentInfo()
        {
            InitializeComponent();
        }

        public FrmStudentInfo(Student objStudent)
            : this()
        {
            //显示学员详细信息

            this.lblStudentName.Text = objStudent.StudentName;
            this.lblGender.Text = objStudent.Gender;
            this.lblAddress.Text = objStudent.StudentAddress;
            this.lblCardNo.Text = objStudent.CardNo;
            this.lblBirthday.Text = objStudent.Birthday.ToString("yyyy-MM-dd");
            this.lblClass.Text = objStudent.ClassName;
            this.lblPhoneNumber.Text = objStudent.PhoneNumber;
            this.lblStudentIdNo.Text = objStudent.StudentIdNo;

            if (objStudent.StuImage.Length > 0)
            {
                this.pbStu.Image = (Image)new SerializeObjectToString().DeserializeObject(objStudent.StuImage);
            }
            else
            {
                this.pbStu.Image = Image.FromFile("default.png");
            }
            
        }
        
        

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}