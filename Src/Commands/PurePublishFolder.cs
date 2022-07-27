using System;
using System.IO;
using System.Linq;
using XamtCli.Helpers;

namespace XamtCli.Commands
{
    /// <summary>
    /// Pure Publish folder for arman only files
    /// </summary>
    public class PurePublishFolder : IExecuter
    {
        public string GetTitle() => "Pure Publish";

        public string GetDescription() => "Pure Current folder from old files that does not contains new codes";

        public bool Execute(params string[] param)
        {
            var armanApp = FileHelper.DetectArmanApplication();

            if (armanApp == null)
            {
                ConsoleHelper.WriteError($"Pure command is only available on ArmanIT application folder for security reasons.");
                return true;
            }

            var primaryExtensions = new string[] { ".dll", ".exe", ".xml" };

            var startFolder = Directory.GetCurrentDirectory();
            var dir = new DirectoryInfo(startFolder);

            var fileList = dir.GetFiles("*.*", SearchOption.AllDirectories)
                .Where(x => !x.Name.ToLower().StartsWith("armanit.")
                            || !primaryExtensions.Contains(x.Extension.ToLower())
                            || x.Name.ToLower().StartsWith("armanit.framework")
                            ).ToList();



            var fileDumpCount = 0;
            var dumpSize = 0M;

            foreach (var file in fileList)
            {
                try
                {
                    if (File.Exists(file.FullName))
                    {
                        file.Delete();
                        ConsoleHelper.WriteInfo($"Deleting file {file.Name} was successful");
                        fileDumpCount++;
                        dumpSize += file.Length;
                    }
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError($"Deleting file {file.Name} has error: {e.Message}");
                }
            }

            var folderList = dir.GetDirectories("*", SearchOption.AllDirectories);
            var folderDumpCount = 0;

            foreach (var folder in folderList)
            {
                try
                {
                    if (Directory.Exists(folder.FullName))
                    {
                        Directory.Delete(folder.FullName, true);
                        ConsoleHelper.WriteInfo($"Deleting folder {folder.Name} was successful");
                        folderDumpCount++;
                    }
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError($"Deleting folder {folder.Name} has error: {e.Message}");
                }
            }

            ConsoleHelper.WriteSuccess($"Total file {fileDumpCount} file count in {dumpSize} bytes and {folderDumpCount} folder deleted");

            return true;
        }
    }
}