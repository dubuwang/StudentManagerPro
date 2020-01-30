using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Drawing;
using System.IO;
using Microsoft.Office.Core;


namespace StudentManager
{
    /// <summary>
    /// 打印学生，基于excel模板
    /// </summary>
    class PrintStudent
    {
        public static void ExcPrint(Student objStudent)
        {
            //1.定义一个Excel工作簿对象
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            //2.获取工作簿模板的路径
            string excelBookPath = Environment.CurrentDirectory + "\\StudentInfo.xls";

            //3.将现有工作簿加入已经定义的工作簿集合
            excelApp.Workbooks.Add(excelBookPath);

            //4.获取第一个工作表
            Microsoft.Office.Interop.Excel.Worksheet sheet = excelApp.Worksheets[1];

            //5.在当前excel工作表中写入数据
            if (objStudent.StuImage.Length !=0)
            {
                //将学生对象中的图片解析出来
                Image objImage = (Image)new SerializeObjectToString().DeserializeObject(objStudent.StuImage);
                //保存图片
                if (File.Exists(Environment.CurrentDirectory + "\\Student.image"))
                {
                    File.Delete(Environment.CurrentDirectory + "\\Student.image");
                }
                else
                {
                    //保存图片到路径中
                    objImage.Save(Environment.CurrentDirectory + "\\Student.image");

                    //将图片插入到excel中
                    sheet.Shapes.AddPicture(Environment.CurrentDirectory + "\\Student.image", MsoTriState.msoFalse, MsoTriState.msoTrue, 10, 50, 70, 80);

                    //插入完毕后，删除图片
                    File.Delete(Environment.CurrentDirectory + "\\Student.image");
                }

            }

            //写入其他数据
            sheet.Cells[4, 4] = objStudent.StudentId;
            sheet.Cells[4, 6] = objStudent.StudentName;
            sheet.Cells[4, 8] = objStudent.Gender;
            sheet.Cells[6, 4] = objStudent.ClassName;
            sheet.Cells[6, 6] = objStudent.PhoneNumber;
            sheet.Cells[8, 4] = objStudent.StudentAddress;

            //6.打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview(true);
            
            //7.释放对象
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;

        }
    }
}
