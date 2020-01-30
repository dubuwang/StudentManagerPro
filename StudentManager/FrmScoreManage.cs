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
    public partial class FrmScoreManage : Form
    {
        public FrmScoreManage()
        {
            InitializeComponent();

            this.cboClass.SelectedIndexChanged -= this.cboClass_SelectedIndexChanged;

            this.cboClass.DataSource = new StudentClassService().GetClasses().Tables[0];
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.SelectedIndex = -1;

            this.cboClass.SelectedIndexChanged += this.cboClass_SelectedIndexChanged;
            
            this.dgvScoreList.AutoGenerateColumns = false;
        }

        private ScoreListService objScoreService = new ScoreListService();

        /// <summary>
        /// 根据班级查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1) return;

            //显示成绩查询结果
            this.dgvScoreList.DataSource = objScoreService.GetScoreList(this.cboClass.Text.Trim());
            
            //显示统计信息
            Dictionary<string, string> listInfo = objScoreService.GetScoreInfoByClassId(this.cboClass.SelectedValue.ToString());
            this.lblAttendCount.Text = listInfo["stuCount"];
            this.lblCount.Text = listInfo["absentCount"];
            this.lblCSharpAvg.Text = listInfo["avgCSharp"];
            this.lblDBAvg.Text = listInfo["avgDB"];
            
            //显示缺考人员列表
            List<string> list = objScoreService.GetAbsentListByClassId(this.cboClass.SelectedValue.ToString());
            this.lblList.Items.Clear();
            if (list.Count==0)
            {
                this.lblList.Items.Add("没有缺考");
            }
            else
            {
                this.lblList.Items.AddRange(list.ToArray());
            }
        }

        //统计全校考试成绩
        private void btnStat_Click(object sender, EventArgs e)
        {
            //显示成绩查询结果
            this.dgvScoreList.DataSource = objScoreService.GetAllScoreList().Tables[0];

            //显示统计信息
            Dictionary<string, string> listInfo = objScoreService.GetScoreInfo();
            this.lblAttendCount.Text = listInfo["stuCount"];
            this.lblCount.Text = listInfo["absentCount"];
            this.lblCSharpAvg.Text = listInfo["avgCSharp"];
            this.lblDBAvg.Text = listInfo["avgDB"];

            //显示缺考人员列表
            List<string> list = objScoreService.GetAbsentList();
            this.lblList.Items.Clear();
            if (list.Count == 0)
            {
                this.lblList.Items.Add("没有缺考");
            }
            else
            {
                this.lblList.Items.AddRange(list.ToArray());
            }
        }

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}