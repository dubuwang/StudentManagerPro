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

            //��ʾ��½�û���
            this.lblCurrentUser.Text = Program.objCurrentAdmin.AdminName+"]";

            //������ʾͼƬ
            this.splitContainer1.Panel2.BackgroundImage = Image.FromFile("mainbg.png");
            this.splitContainer1.Panel2.BackgroundImageLayout = ImageLayout.Stretch;

            //��ʾ�汾��
            this.lblVersion.Text = "�汾�ţ�" + ConfigurationManager.AppSettings["pversion"].ToString();

            //Ȩ���趨
        }    

        #region Ƕ�봰����ʾ

        private void CloseExistedForm()
        {
            foreach (Control item in this.splitContainer1.Panel2.Controls)
            {
                if (item is Form)
                {
                    //������ر�
                    Form objForm = (Form)item;
                    objForm.Close();
                }
            }
        }

        private void OpenForm(Form objFrm)
        {
            //�ر��������Ѿ�Ƕ��Ĵ���
            CloseExistedForm();

            //��������Ƕ���µ��Ӵ���
            objFrm.TopLevel = false;  //���Ӵ������óɷǶ����ؼ�
            objFrm.FormBorderStyle = FormBorderStyle.None;    //ȥ������ı߿�   
            objFrm.Parent = this.splitContainer1.Panel2;
            objFrm.Dock = DockStyle.Fill;

            objFrm.Show();
        }
     
        /// <summary>
        /// ��ʾ�����ѧԱ���� 
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
        /// ��ʾѧԱ��Ϣ������
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
        /// ��ʾ���ڴ򿨴���
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
        /// ��ʾ���ڲ�ѯ����
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
        /// ��ʾ�ɼ����ٲ�ѯ����
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
        /// ��ʾ�ɼ���ѯ���������
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

        #region �˳�ϵͳǰ��ȷ��

        /// <summary>
        /// �˳�ϵͳ
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
            DialogResult result = MessageBox.Show("ȷ���˳���", "�˳�ѯ��", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region �������ڵĴ�

        /// <summary>
        /// ��ʾ�����޸Ĵ���
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
        /// ���ʹ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_linkxkt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "https://github.com/dubuwang");
        }

        /// <summary>
        /// �򿪹��ڴ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_about_Click(object sender, EventArgs e)
        {
            FrmAbout objAbout = new FrmAbout();
            objAbout.Show();
        }

        /// <summary>
        /// �л��˺�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwitchAccount_Click(object sender, EventArgs e)
        {
            FrmUserLogin objFrm = new FrmUserLogin();
            objFrm.Text = "���˺��л���";

            DialogResult result = objFrm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.lblCurrentUser.Text = Program.objCurrentAdmin.AdminName + "]";
            }
        }

        #endregion 


        

        

        

        

        

        

        

        

        

        


    
    }
}