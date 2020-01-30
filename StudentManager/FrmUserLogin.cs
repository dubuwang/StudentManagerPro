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
    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 登陆系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //判断账号和密码是否为空
            if (this.txtLoginId.Text.Trim().Length == 0 || this.txtLoginPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入账号名和密码", "输入提示");
                return;
            }

            //验证账号是否为整数
            if (!DataValidate.IsInteger(this.txtLoginId.Text.Trim()))
            {
                MessageBox.Show("账号不符合规范，必须为数字", "登陆提示");
                return;
            }

            //登陆账号和密码不能包含危险字符

            //封装管理员对象
            SysAdmin objSysAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text.Trim()
            };

            //与后台交互，验证登陆用户是否正确
            try
            {
                objSysAdmin = new SysAdminService().AdminLogin(objSysAdmin);
                if (objSysAdmin != null)
                {
                    //保存登陆信息
                    Program.objCurrentAdmin = objSysAdmin;
                    //设置登陆窗体的返回值
                    this.DialogResult = DialogResult.OK;

                    this.Close();

                }
                else
                {
                    MessageBox.Show("登陆失败，用户名或密码错误", "登陆提示");
                    this.txtLoginId.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("登陆出现异常，原因：" + ex.Message);
                this.txtLoginId.Focus();
                return;
            }

        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLoginId_KeyDown(object sender, KeyEventArgs e)
        {
            //如果按下的是回车键
            if (e.KeyValue == 13)
            {
                this.txtLoginPwd.Focus();
            }
        }
    }
}
