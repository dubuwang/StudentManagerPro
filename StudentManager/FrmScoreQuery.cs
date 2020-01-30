using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using Models;


namespace StudentManager
{
    public partial class FrmScoreQuery : Form
    {      
        public FrmScoreQuery()
        {
            InitializeComponent();

            //基于datatable绑定下拉框
            DataTable dt = new StudentClassService().GetClasses().Tables[0];
            this.cboClass.DataSource = dt;
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.DisplayMember = "ClassName";

            //查询并显示全部考试成绩
            this.ds = objScoreService.GetAllScoreList();
            this.dgvScoreList.DataSource = ds.Tables[0];
            

        }

        private ScoreListService objScoreService = new ScoreListService();

        private DataSet ds = null;
   
        //根据班级名称动态筛选
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ds == null) return;

            this.ds.Tables[0].DefaultView.RowFilter = string.Format("ClassName = '{0}'", this.cboClass.Text.Trim());
        }

        //显示全部成绩
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            this.ds.Tables[0].DefaultView.RowFilter = "ClassName like '%%'";
        }

        //根据C#成绩动态筛选
        private void txtScore_TextChanged(object sender, EventArgs e)
        {
            if (this.txtScore.Text.Trim().Length == 0) return;
            if (!DataValidate.IsInteger(this.txtScore.Text.Trim())) return ;

            this.ds.Tables[0].DefaultView.RowFilter = "Csharp>" + this.txtScore.Text.Trim();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 给dgv添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvScoreList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewStyle.DgvRowPostPaint(this.dgvScoreList, e);
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            new ExportToExcel().Export(this.dgvScoreList);
        }
    }
}

