using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;

using XamtCli.Helpers;

namespace XamtCli.Commands
{
    /// <summary>
    /// Compress Publish
    /// </summary>
    public class ZipPublishFolder : IExecuter
    {
        public string GetTitle() => "Compress Publish";

        public string GetDescription() => "Compress Current folder to zip archive and make a file on desktop";

        public bool Execute(params string[] param)
        {
            param ??= new[] { "File" };
            var startFolder = Directory.GetCurrentDirectory();
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss", new CultureInfo("fa-IR"));

            var suggestedFileName = param.Length == 0 || string.IsNullOrWhiteSpace(param[0]) ? "File" : param[0];
            if (suggestedFileName == ".")
            {
                var workApp = FileHelper.DetectWorkApplication();
                suggestedFileName = $"{workApp.ApplicationName}(v{workApp.ApplicationVersion})";
            }

            var fileName = $"{suggestedFileName}_{dateTime}.zip";
            var zipPath = Path.Combine(desktop, fileName);

            try
            {
                ZipFile.CreateFromDirectory(startFolder, zipPath, CompressionLevel.Optimal, false);
                ConsoleHelper.WriteSuccess($"Zipping {fileName} was successful");
            }
            catch (Exception e)
            {
                ConsoleHelper.WriteError($"Zipping {fileName} has error: {e.Message}");
            }

            return true;
        }
    }
}