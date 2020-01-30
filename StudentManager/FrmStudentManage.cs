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

            //初始化下拉框的内容
            this.cboClass.DataSource = objClassService.GetAllClass();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";

            this.dgvStudentList.AutoGenerateColumns = false;
        }



        private StudentClassService objClassService = new StudentClassService();

        private StudentService objStudentService = new StudentService();

        private List<Student> stuList;

        /// <summary>
        /// 按照班级查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级");
                return;
            }

            this.stuList = objStudentService.GetStudentByClass(this.cboClass.Text);
            this.dgvStudentList.DataSource = this.stuList;
            new DataGridViewStyle().DgvStyle2(this.dgvStudentList);
        }


        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            //数据验证


            //查询
            Student objStudent = objStudentService.GetStudentById(this.txtStudentId.Text.Trim());

            if (objStudent == null)
            {
                MessageBox.Show("学员信息不存在", "提示信息");
            }
            else
            {
                //显示学员信息
                new FrmStudentInfo(objStudent).Show();
            }
        }

        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        //双击选中的学员对象并显示详细信息
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //修改学员对象
        private void btnEidt_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0 || this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("未选中学员", "提示信息");
                return;
            }

            //获取学号
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
           
            //查询学员
            Student objStudent = objStudentService.GetStudentById(studentId);

            //显示修改学员信息窗口
            FrmEditStudent objFrmEditStudent = new FrmEditStudent(objStudent);
            if (objFrmEditStudent.ShowDialog() == DialogResult.OK)
            {
                //同步刷新
                btnQuery_Click(null, null);
            }


        }

        //删除学员对象
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0 || this.dgvStudentList.CurrentRow == null)
            {
                MessageBox.Show("未选中学员", "提示信息");
                return;
            }

            //删除前确认
            DialogResult result = MessageBox.Show("确定要删除该学员吗", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel) return;

            //获取学号
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();

            //查询学员，然后删除
            try
            {
                Student objStudent = objStudentService.GetStudentById(studentId);
                if (objStudentService.DeleteStudentById(objStudent) == 1)
                {
                    //如果删除成功，同步刷新数据的显示
                    btnQuery_Click(null, null);
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("删除学员对象，访问数据库时出错，原因：" + ex.Message);
            }
            
        }

        //姓名降序
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0) return;

            this.stuList.Sort(new NameDesc());

            this.dgvStudentList.Refresh();

        }

        //学号降序
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {

            if (this.dgvStudentList.RowCount == 0) return;

            this.stuList.Sort(new StuIdDesc());

            this.dgvStudentList.Refresh();
        }

        //添加行号
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }


        //打印当前学员信息
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dgvStudentList.RowCount == 0 || this.dgvStudentList.CurrentRow == null) return;

            string studendId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();

            Student objStudent = objStudentService.GetStudentById(studendId);

            PrintStudent.ExcPrint(objStudent);
        }

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    #region 排序类


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