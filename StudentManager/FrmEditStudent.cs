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

            //��ʼ�������������
            this.cboClassName.DataSource = new StudentClassService().GetAllClass();
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";
            
            //��ʾѧԱ��ϸ��Ϣ

            this.cboClassName.Text = objStudent.ClassName;

            this.txtStudentName.Text = objStudent.StudentName;
            if (objStudent.Gender == "��")
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


        //�ύ�޸�
        private void btnModify_Click(object sender, EventArgs e)
        {
           //������֤


           //��֤���֤���Ƿ��ظ�
            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim(),this.txtStudentId.Text.Trim()))
            {
                MessageBox.Show("���֤�������е�ѧԱ��ͬ", "��ʾ��Ϣ");
                return;
            }

            Student objStudent = new Student()
            {
                StudentId = Convert.ToInt32(this.txtStudentId.Text.Trim()),
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoMale.Checked ? "��" : "Ů",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtAddress.Text.Trim(),
                ClassName = this.cboClassName.Text,
                CardNo = this.txtCardNo.Text.Trim(),
                ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),//��ȡѡ��༶��Ӧ��ClassId
                Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year,
                StuImage = this.pbStu.Image != null ? new SerializeObjectToString().SerializeObject(this.pbStu.Image) : ""
            };

            try
            {
                if (objStudentService.ModifyStudent(objStudent) == 1)
                {
                    MessageBox.Show("ѧԱ��Ϣ�޸ĳɹ�", "��ʾ��Ϣ");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "��ʾ��Ϣ");
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ѡ����Ƭ
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