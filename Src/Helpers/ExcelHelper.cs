using OfficeOpenXml;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace XamtCli.Helpers
{
    /// <summary>
    /// Microsoft Excel Helper
    /// </summary>
    public static class ExcelHelper
    {
        /// <summary>
        /// Extract Daily report Data
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static IList<DailyReportRecord> ExtractListOfDailyReportRecords(FileInfo file)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(file);

            // Worksheet
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null)
            {
                return default;
            }

            // Report Date
            var reportDate = worksheet.Cells[3, 2]?.Value?.ToString()?.Trim();
            if (string.IsNullOrWhiteSpace(reportDate))
            {
                return default;
            }

            // Report Table
            var reportTable = worksheet.Tables.FirstOrDefault();
            if (reportTable == null)
            {
                return default;
            }

            var reportData = reportTable
                .ToDataTable()
                .Select()
                .Select(x => new DailyReportRecord(x, reportDate))
                .Where(x => !string.IsNullOrWhiteSpace(x.Title))
                .ToList();

            return reportData;
        }

        /// <summary>
        /// Convert a List of Records to excel file
        /// </summary>
        /// <param name="records">Record List</param>
        /// <returns>Excel File In Byte Array</returns>
        public static byte[] ConvertListToExcel(IEnumerable<DailyReportRecord> records)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var excelPackage = new ExcelPackage();

            var ws = excelPackage.Workbook.Worksheets.Add("Sheet 1");

            //put the data in the sheet, starting from column A, row 1
            ws.Cells["A1"].LoadFromCollection(records, false);

            return excelPackage.GetAsByteArray();
        }
    }

    /// <summary>
    /// Daily Report Data Model
    /// </summary>
    public class DailyReportRecord
    {
        public DailyReportRecord(DataRow row, string reportDate)
        {
            Date = reportDate;
            Project = row[1].ToString();
            Task = "کریم پیمانی";
            Title = row[3].ToString();
            Description = row[4].ToString();
            Duration = row[5].ToString();
        }

        public string Date { get; set; }
        public string Project { get; set; }
        public string Task { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
    }
}
