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
        
            //��ʼ�������������
            this.cboClassName.DataSource = objClassService.GetAllClass();
            this.cboClassName.DisplayMember = "ClassName";
            this.cboClassName.ValueMember = "ClassId";

            this.dgvStuList.AutoGenerateColumns = false;
        }

        private StudentClassService objClassService = new StudentClassService();

        private StudentService objStudentService = new StudentService();

        List<Student> listStu = new List<Student>();


        /// <summary>
        /// �����ѧԱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region ������֤
            //�ǿ���֤
            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("ѧ����������Ϊ��");
                this.txtStudentName.Focus();
                return;
            }
            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("�������Ա�");
                return;
            }
            if (this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("���ڿ��Ų���Ϊ��");
                this.txtCardNo.Focus();
                return;
            }
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��༶");
                return;
            }

            //������֤
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age>35 || age<18)
            {
                MessageBox.Show("���������18-35��֮��");
                return;
            }

            //���֤��ʽ��֤
            if (!DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤�������");
                return;
            }
            //��֤���֤����������Ƿ����
            string birthday = Convert.ToDateTime(this.dtpBirthday.Text).ToString("yyyyMMdd");
            if (!this.txtStudentIdNo.Text.Trim().Contains(birthday))
            {
                MessageBox.Show("���֤��������ڲ�ƥ��");
                return;
            }
            #endregion

            #region ���֤�źͿ��ڿ��ŵ��ظ���֤

            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("�����֤���ظ�", "������ʾ");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }

            if (objStudentService.IsCardNoExisted(this.txtCardNo.Text.Trim()))
            {
                MessageBox.Show("�ÿ��ڿ����Ѿ�����", "������ʾ");
                this.txtCardNo.Focus();
                this.txtCardNo.SelectAll();
                return;
            }
            #endregion

            #region ��װѧ������

            Student objStudent = new Student()
            {
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
                StuImage = this.pbStu.Image!=null? new SerializeObjectToString().SerializeObject(this.pbStu.Image):""
            };

            #endregion

            ///���ú�̨���ݷ��ʷ���
            try
            {
                int studentId = objStudentService.AddStudent(objStudent);
                if (studentId >1)
                {
                    //ͬ����ʾ��ӵ�ѧ��
                    objStudent.StudentId = studentId;
                    listStu.Add(objStudent);
                    dgvStuList.DataSource = null;
                    dgvStuList.DataSource = listStu;

                    //ѯ���Ƿ�������
                    DialogResult result = MessageBox.Show("��ѧԱ��ӳɹ����Ƿ�������", "��ʾ��Ϣ",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        //����û��������Ϣ


                    }
                    else
                    {
                        this.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                
                MessageBox.Show("���ѧԱʧ�ܣ�ԭ��"+ex.Message);
            }


            
        }
    
        //�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
    
        /// <summary>
        /// ѡ������Ƭ
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