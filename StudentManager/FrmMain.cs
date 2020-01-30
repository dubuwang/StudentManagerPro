using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;

namespace StudentManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            //显示登陆用户名
            this.lblCurrentUser.Text = Program.objCurrentAdmin.AdminName+"]";

            //加载显示图片
            this.splitContainer1.Panel2.BackgroundImage = Image.FromFile("mainbg.png");
            this.splitContainer1.Panel2.BackgroundImageLayout = ImageLayout.Stretch;

            //显示版本号
            this.lblVersion.Text = "版本号：" + ConfigurationManager.AppSettings["pversion"].ToString();

            //权限设定
        }    

        #region 嵌入窗体显示

        private void CloseExistedForm()
        {
            foreach (Control item in this.splitContainer1.Panel2.Controls)
            {
                if (item is Form)
                {
                    //存在则关闭
                    Form objForm = (Form)item;
                    objForm.Close();
                }
            }
        }

        private void OpenForm(Form objFrm)
        {
            //关闭容器中已经嵌入的窗体
            CloseExistedForm();

            //往容器中嵌入新的子窗体
            objFrm.TopLevel = false;  //将子窗体设置成非顶级控件
            objFrm.FormBorderStyle = FormBorderStyle.None;    //去掉窗体的边框   
            objFrm.Parent = this.splitContainer1.Panel2;
            objFrm.Dock = DockStyle.Fill;

            objFrm.Show();
        }
     
        /// <summary>
        /// 显示添加新学员窗体 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {          
            FrmAddStudent objFrmAddStudent = new FrmAddStudent();

            OpenForm(objFrmAddStudent);
          
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            this.tsmiAddStudent_Click(null, null);
        }

        /// <summary>
        /// 显示学员信息管理窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiManageStudent_Click(object sender, EventArgs e)
        {
            FrmStudentManage objFrmStudentManage = new FrmStudentManage();
            OpenForm(objFrmStudentManage);
        }
        private void btnManageStudent_Click(object sender, EventArgs e)
        {
            tsmiManageStudent_Click(null, null);
        }

        /// <summary>
        /// 显示考勤打卡窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Card_Click(object sender, EventArgs e)
        {
            FrmAttendance objFrmAttendance = new FrmAttendance();
            OpenForm(objFrmAttendance);
        }
        private void btnCard_Click(object sender, EventArgs e)
        {
            tsmi_Card_Click(null, null);
        }

        /// <summary>
        /// 显示考勤查询窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_AQuery_Click(object sender, EventArgs e)
        {
            FrmAttendanceQuery objFrmAttendancequery = new FrmAttendanceQuery();
            OpenForm(objFrmAttendancequery);
        }
        private void btnAQuery_Click(object sender, EventArgs e)
        {
            tsmi_AQuery_Click(null, null);
        }

       
        /// <summary>
        /// 显示成绩快速查询窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiQuery_Click(object sender, EventArgs e)
        {
          FrmScoreQuery objFrmScoreQuery = new FrmScoreQuery();
          OpenForm(objFrmScoreQuery);
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            tsmiQuery_Click(null, null);
        }

        /// <summary>
        /// 显示成绩查询与分析窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiQueryAndAnalysis_Click(object sender, EventArgs e)
        {
            FrmScoreManage objFrmScoreManage = new FrmScoreManage();
            OpenForm(objFrmScoreManage);
            
        }
        private void btnQueryAndAnalysis_Click(object sender, EventArgs e)
        {
            tsmiQueryAndAnalysis_Click(null,null);
        }


        private void btnImport_Click(object sender, EventArgs e)
        {
            FrmImport objFrmImport = new FrmImport();
            OpenForm(objFrmImport);
        }
        
        #endregion

        #region 退出系统前的确认

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退出吗", "退出询问", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region 其他窗口的打开

        /// <summary>
        /// 显示密码修改窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmiModifyPwd_Click(object sender, EventArgs e)
        {
            FrmModifyPwd objPwd = new FrmModifyPwd();
            objPwd.ShowDialog();
        }
        private void btnModifyPwd_Click(object sender, EventArgs e)
        {
            tmiModifyPwd_Click(null, null);
        }
     
        /// <summary>
        /// 访问官网
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_linkxkt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "https://github.com/dubuwang");
        }

        /// <summary>
        /// 打开关于窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_about_Click(object sender, EventArgs e)
        {
            FrmAbout objAbout = new FrmAbout();
            objAbout.Show();
        }

        /// <summary>
        /// 切换账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwitchAccount_Click(object sender, EventArgs e)
        {
            FrmUserLogin objFrm = new FrmUserLogin();
            objFrm.Text = "【账号切换】";

            DialogResult result = objFrm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.lblCurrentUser.Text = Program.objCurrentAdmin.AdminName + "]";
            }
        }

        #endregion 


        

        

        

        

        

        

        

        

        

        


    
    }
}