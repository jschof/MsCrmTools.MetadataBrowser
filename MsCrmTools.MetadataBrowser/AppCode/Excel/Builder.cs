using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MsCrmTools.MetadataBrowser.AppCode.Excel
{
    internal class Builder
    {
        public void BuildFile(string path, ListView list, string sheetName, Control parent = null)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            ExcelPackage innerWorkBook = new ExcelPackage();
            ExcelWorksheet sheet = innerWorkBook.Workbook.Worksheets.Add(sheetName);

            int index = 1;
            foreach (ColumnHeader column in list.Columns)
            {
                sheet.Cells[1, index++].Value = column.Text;
            }

            ExcelRange r = sheet.Cells["1:1"];

            r.Style.Font.Bold = true;
            r.Style.Fill.PatternType = ExcelFillStyle.Solid;
            r.Style.Fill.BackgroundColor.SetColor(Color.Navy);
            r.Style.Font.Color.SetColor(Color.White);

            int row = 2;
            foreach (ListViewItem item in list.Items)
            {
                index = 1;

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    sheet.Cells[row, index++].Value = subItem.Text;
                }

                row++;
            }

            innerWorkBook.SaveAs(new FileInfo(path));

            if (parent != null)
            {
                if (DialogResult.Yes == MessageBox.Show(parent,
                        $"File saved to {path}!\n\nWould you like to open it now? (Requires Microsoft Excel)",
                        "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    Process.Start("Excel.exe", $"\"{path}\"");
                }
            }
        }

        public void BuildFile(ExcelPackage innerWorkBook, ListView list, string sheetName)
        {
            bool sheetExists = true;
            int index = 1;
            int row;

            ExcelWorksheet sheet = innerWorkBook.Workbook.Worksheets[sheetName];

            if (sheet == null)
            {
                sheet = innerWorkBook.Workbook.Worksheets.Add(sheetName);
                sheetExists = false;
            }

            if (sheetExists)
            {
                int colCount = sheet.Dimension.End.Column;  //get Column Count
                int rowCount = sheet.Dimension.End.Row;     //get row count

                row = rowCount + 1;
            }
            else // Write header
            {
                foreach (ColumnHeader column in list.Columns)
                {
                    sheet.Cells[1, index++].Value = column.Text;
                }
                ExcelRange r = sheet.Cells["1:1"];

                r.Style.Font.Bold = true;
                r.Style.Fill.PatternType = ExcelFillStyle.Solid;
                r.Style.Fill.BackgroundColor.SetColor(Color.Navy);
                r.Style.Font.Color.SetColor(Color.White);

                row = 2;
            }

            //int row = 2;
            foreach (ListViewItem item in list.Items)
            {
                index = 1;

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    sheet.Cells[row, index++].Value = subItem.Text;
                }

                row++;
            }

            //innerWorkBook.Save();
        }
    }
}