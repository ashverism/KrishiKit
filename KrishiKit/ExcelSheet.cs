using System;
using System.Data;
using GemBox.Spreadsheet;

namespace KrishiKit
{
    public static class ExcelSheet
    {
        public static DataTable viewExcelFertiliser(String s)
        {
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            String temp;
            temp = "Fertilisers\\" + s + ".xls";
            ExcelFile ef = ExcelFile.Load(temp);

            // Select the first worksheet from the file.
            ExcelWorksheet ws = ef.Worksheets[0];

            // Create DataTable from an Excel worksheet.
            DataTable dataTable = ws.CreateDataTable(new CreateDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 1,
                NumberOfColumns = 5,
                NumberOfRows = ws.Rows.Count - 1,
                Resolution = ColumnTypeResolution.AutoPreferStringCurrentCulture
            });

            // Write DataTable content
            /*StringBuilder sb = new StringBuilder();
            sb.AppendLine("DataTable content:");
            foreach (DataRow row in dataTable.Rows)
            {
                sb.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}", row[0], row[1], row[2], row[3], row[4]);
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());*/
            return dataTable;
        }

        public static DataTable viewExcelPesticides(String s)
        {
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            String temp;
            temp = "Pesticides\\" + s + ".xls";
            ExcelFile ef = ExcelFile.Load(temp);

            // Select the first worksheet from the file.
            ExcelWorksheet ws = ef.Worksheets[0];

            // Create DataTable from an Excel worksheet.
            DataTable dataTable = ws.CreateDataTable(new CreateDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 1,
                NumberOfColumns = 5,
                NumberOfRows = ws.Rows.Count - 1,
                Resolution = ColumnTypeResolution.AutoPreferStringCurrentCulture
            });

            // Write DataTable content
            /* StringBuilder sb = new StringBuilder();
             sb.AppendLine("DataTable content:");
             foreach (DataRow row in dataTable.Rows)
             {
                 sb.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}", row[0], row[1], row[2], row[3], row[4]);
                 sb.AppendLine();
             }

             Console.WriteLine(sb.ToString());*/
            return dataTable;
        }
    }
}
