using System;
using System.Diagnostics;
using System.IO;

namespace XamtCli.Helpers
{
    /// <summary>
    /// File Helpers
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Detect folder has work application and get info
        /// </summary>
        /// <returns></returns>
        public static PublishApplicationFileDescriptor DetectWorkApplication()
        {
            var startFolder = Directory.GetCurrentDirectory();
            var dir = new DirectoryInfo(startFolder);

            var fileList = dir.GetFiles("*.exe", SearchOption.AllDirectories);

            foreach (var file in fileList)
            {
                var fileName = file.Name.Replace(file.Extension, null);
                if (fileName.ToLower().StartsWith("armanit") && fileName.ToLower().EndsWith("webapi"))
                {

                    var appName = fileName
                        .Replace("armanIt", null, StringComparison.InvariantCultureIgnoreCase)
                        .Replace("webApi", null, StringComparison.InvariantCultureIgnoreCase)
                        .TrimStart('.').TrimEnd('.');

                    var versionInfo = FileVersionInfo.GetVersionInfo(file.FullName);
                    var fileVersion = !string.IsNullOrWhiteSpace(versionInfo.FileVersion) ? versionInfo.FileVersion : "0.0.0";

                    return new PublishApplicationFileDescriptor()
                    {
                        ApplicationName = appName,
                        ApplicationVersion = fileVersion
                    };
                }

                if (fileName.ToLower().StartsWith("gamecore") && fileName.ToLower().Contains("webapi"))
                {

                    var appName = fileName
                        .Replace(".webApi", null, StringComparison.InvariantCultureIgnoreCase)
                        .TrimStart('.').TrimEnd('.');

                    var versionInfo = FileVersionInfo.GetVersionInfo(file.FullName);
                    var fileVersion = !string.IsNullOrWhiteSpace(versionInfo.FileVersion) ? versionInfo.FileVersion : "0.0.0";

                    return new PublishApplicationFileDescriptor()
                    {
                        ApplicationName = appName,
                        ApplicationVersion = fileVersion
                    };
                }
            }

            return default;
        }

        public static string FileSizeSuffix(long value)
        {
            string[] SizeSuffixes = { "B ", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            if (value < 0) { return "-" + FileSizeSuffix(-value); }
            var i = 0;
            var dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }
            return $"{dValue:n1} {SizeSuffixes[i]}";
        }

        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            var fis = d.GetFiles();
            foreach (var fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            var dis = d.GetDirectories();
            foreach (var di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }
    }
}
