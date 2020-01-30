using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;
using System.Data.SqlClient;


namespace StudentManager
{
    public partial class FrmImport : Form
    {
        public FrmImport()
        {
            InitializeComponent();

            this.dataGridView1.AutoGenerateColumns = false;
        }

        private ImportDataFromExcel objImportExcel = new ImportDataFromExcel();

        private List<Student> listStu = null;

        /// <summary>
        /// 从excel文件导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "xlsx files(*.xlsx)|*.xlsx";
            DialogResult result = ofd.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                string path = ofd.FileName;
                //从excel文件读取数据
                this.listStu = objImportExcel.GetStudentByExcel(path);

                //显示数据
                this.dataGridView1.DataSource = this.listStu;
                
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dataGridView1,e);
        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (listStu.Count==0||listStu==null)
            {
                return;
            }
            try
            {
                if (objImportExcel.ImportStudentList(this.listStu))
                {
                    MessageBox.Show("学生数据导入数据库成功","提示信息");
                    this.dataGridView1.DataSource = null;
                    this.listStu = null;
                }else
                {
                    MessageBox.Show("学生数据导入数据库失败", "提示信息");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("导入学生数据出错，原因"+ex.Message,"错误提示");
            }
            
        }
    }
}
