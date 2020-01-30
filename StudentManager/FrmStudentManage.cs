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
    public partial class FrmStudentManage : Form
    {

        public FrmStudentManage()
        {
            InitializeComponent();

            //��ʼ�������������
            this.cboClass.DataSource = objClassService.GetAllClass();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";

            this.dgvStudentList.AutoGenerateColumns = false;
        }



        private StudentClassService objClassService = new StudentClassService();

        private StudentService objStudentService = new StudentService();

        private List<Student> stuList;

        /// <summary>
        /// ���հ༶��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��༶");
                return;
            }

            this.stuList = objStudentService.GetStudentByClass(this.cboClass.Text);
            this.dgvStudentList.DataSource = this.stuList;
            new DataGridViewStyle().DgvStyle2(this.dgvStudentList);
        }


        //����ѧ�Ų�ѯ
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            //������֤


            //��ѯ
            Student objStudent = objStudentService.GetStudentById(this.txtStudentId.Text.Trim());

            if (objStudent == null)
            {
                MessageBox.Show("ѧԱ��Ϣ������", "��ʾ��Ϣ");
            }
            else
            {
                //��ʾѧԱ��Ϣ
                new FrmStudentInfo(objStudent).Show();
            }
        }

        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //˫��ѡ�е�ѧԱ������ʾ��ϸ��Ϣ
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //�޸�ѧԱ����
        private void btnEidt_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0 || this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("δѡ��ѧԱ", "��ʾ��Ϣ");
                return;
            }

            //��ȡѧ��
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
           
            //��ѯѧԱ
            Student objStudent = objStudentService.GetStudentById(studentId);

            //��ʾ�޸�ѧԱ��Ϣ����
            FrmEditStudent objFrmEditStudent = new FrmEditStudent(objStudent);
            if (objFrmEditStudent.ShowDialog() == DialogResult.OK)
            {
                //ͬ��ˢ��
                btnQuery_Click(null, null);
            }


        }

        //ɾ��ѧԱ����
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0 || this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("δѡ��ѧԱ", "��ʾ��Ϣ");
                return;
            }

            //ɾ��ǰȷ��
            DialogResult result = MessageBox.Show("ȷ��Ҫɾ����ѧԱ��", "ɾ����ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel) return;

            //��ȡѧ��
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();

            //��ѯѧԱ��Ȼ��ɾ��
            try
            {
                Student objStudent = objStudentService.GetStudentById(studentId);
                if (objStudentService.DeleteStudentById(objStudent) == 1)
                {
                    //���ɾ���ɹ���ͬ��ˢ�����ݵ���ʾ
                    btnQuery_Click(null, null);
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("ɾ��ѧԱ���󣬷������ݿ�ʱ����ԭ��" + ex.Message);
            }
            
        }

        //��������
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0) return;

            this.stuList.Sort(new NameDesc());

            this.dgvStudentList.Refresh();

        }

        //ѧ�Ž���
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {

            if (this.dgvStudentList.RowCount == 0) return;

            this.stuList.Sort(new StuIdDesc());

            this.dgvStudentList.Refresh();
        }

        //����к�
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }


        //��ӡ��ǰѧԱ��Ϣ
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0 || this.dgvStudentList.CurrentRow == null) return;

            string studendId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();

            Student objStudent = objStudentService.GetStudentById(studendId);

            PrintStudent.ExcPrint(objStudent);
        }

        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    #region ������


    class NameDesc : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.StudentName.CompareTo(y.StudentName);
        }
    }

    class StuIdDesc : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.StudentId.CompareTo(y.StudentId);
        }
    }

    #endregion

}