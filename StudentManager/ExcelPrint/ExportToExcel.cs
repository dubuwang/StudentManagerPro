using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace StudentManager
{
    class ExportToExcel
    {
        public bool Export(DataGridView dgv)
        {
            //1.定义一个Excel工作簿对象
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            //2.定义excel工作表，获取第一个工作表
            Microsoft.Office.Interop.Excel.Worksheet sheet = excelApp.Workbooks.Add().Worksheets[1];

            //3.设置工作表的标题样式，从第二行第二列开始
            sheet.Cells[2, 2] = "学生成绩表";
            sheet.Cells.RowHeight = 25;
            Microsoft.Office.Interop.Excel.Range range = sheet.get_Range("B2", "F2");
            range.Merge(0);//合并表头单元格
            range.Borders.Value = 1;//设置表头的边框
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//设置单元格内容居中显示
            range.Font.Size = 15;

            //4.获取总列数和总行数
            int columnCount = dgv.ColumnCount;
            int rowCount = dgv.RowCount;

            //5.设置列标题
            for (int i = 0; i < columnCount; i++)
            {
                sheet.Cells[3, i + 2] = dgv.Columns[i].HeaderText;
                sheet.Cells[3, i + 2].Borders.Value = 1;
                sheet.Cells[3, i + 2].RowHeight = 23;
            }

            //6.显示数据，从第四行第二列开始
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    sheet.Cells[4 + i, j + 2] = dgv.Rows[i].Cells[j].Value;
                    sheet.Cells[4 + i, j + 2].Borders.Value = 1;
                    sheet.Cells[4 + i, j + 2].RowHeight = 23;
                }
            }

            //7.设置列宽和数据一致
            sheet.Columns.AutoFit();

            //8.打印预览
            excelApp.Visible = true;
            excelApp.Sheets.PrintPreview();

            //释放对象
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            excelApp = null;

            return true;
        }
    }
}
