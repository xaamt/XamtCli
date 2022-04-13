using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using XamtCli.Helpers;

namespace XamtCli.Commands
{
    /// <summary>
    /// Generate Monthly Report From Daily Reports
    /// </summary>
    public class GenerateMonthlyReport : IExecuter
    {
        public string GetTitle() => "Generate Monthly Report";

        public string GetDescription() => "Generate Monthly Report From Daily Reports in Arman Format";

        public bool Execute(params string[] param)
        {
            var startFolder = Directory.GetCurrentDirectory();
            var dir = new DirectoryInfo(startFolder);

            var allRecords = new List<DailyReportRecord>();

            var fileList = dir.GetFiles("Peymani Remote Report*.xlsx", SearchOption.TopDirectoryOnly);

            foreach (var file in fileList.OrderBy(x => x.Name))
            {
                try
                {
                    var records = ExcelHelper.ExtractListOfDailyReportRecords(file);
                    allRecords.AddRange(records);
                    ConsoleHelper.WriteInfo($"Extract {records.Count} records from file {file.Name} was successful");
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError($"Extract data from {file.Name} has error: {e.Message}");
                }
            }

            var resultFileDatePart = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss", new CultureInfo("Fa-Ir"));
            var resultFileName = $"ExtractData_{resultFileDatePart}.xlsx";
            var resultFullPath = Path.Combine(dir.FullName, resultFileName);

            try
            {
                var resultFile = ExcelHelper.ConvertListToExcel(allRecords);
                File.WriteAllBytes(resultFullPath, resultFile);
                ConsoleHelper.WriteInfo($"Generate file {resultFileName} was successful");
            }
            catch (Exception e)
            {
                ConsoleHelper.WriteError($"Save data to file {resultFullPath} has error: {e.Message}");
            }

            ConsoleHelper.WriteSuccess($"Generate Report with total {allRecords.Count} records from {fileList.Length} files was successful");

            return true;
        }
    }
}