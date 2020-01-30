using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace StudentManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //创建登陆窗体
            FrmUserLogin objFrmUserLogin = new FrmUserLogin();
            DialogResult result = objFrmUserLogin.ShowDialog();

            //判断登陆是否成功
            if (result == DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
            else
            {
                Application.Exit();
            }

        }

        /// <summary>
        /// Program类的一个全局静态字段,保存登陆用户的对象
        /// </summary>
        public static Models.SysAdmin objCurrentAdmin = null;
    }
}
