using OfficeOpenXml;
using System;
using System.Data;
using System.IO;

namespace winform_app.Services
{
    public class ExcelExportService
    {
        public void ExportToExcel(DataTable dataTable, string filePath, string fileName)
        {
            // Set the license context for EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(fileName);

                // Load the DataTable into the sheet, starting from cell A1.
                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);

                // Format date columns
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.DataType == typeof(DateTime))
                    {
                        int colIndex = dataTable.Columns.IndexOf(column) + 1;
                        worksheet.Cells[2, colIndex, dataTable.Rows.Count + 1, colIndex].Style.Numberformat.Format = "yyyy-mm-dd";
                    }
                }
                // Save the Excel package to the specified file path
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }
    }
}