using System;
using System.IO;
using System.Linq;

namespace XamtCli.Commands
{
    /// <summary>
    /// Clear Publish
    /// </summary>
    public class ClearPublishFolder : IExecuter
    {
        public string GetTitle() => "Clear Publish";

        public string GetDescription() => "Clear Current folder from dump files";

        public bool Execute(params string[] param)
        {
            var dumpExtensions = new string[] { ".pdb", ".design", ".tmp", ".temp" };

            var startFolder = Directory.GetCurrentDirectory();
            var dir = new DirectoryInfo(startFolder);

            var fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);
            var dumpCount = 0;
            var dumpSize = 0M;

            foreach (var file in fileList)
            {
                if (dumpExtensions.Contains(file.Extension.ToLower()))
                {
                    try
                    {
                        file.Delete();
                        ConsoleHelper.WriteInfo($"Deleting {file.Name} was successful");
                        dumpCount++;
                        dumpSize += file.Length;
                    }
                    catch (Exception e)
                    {
                        ConsoleHelper.WriteError($"Deleting {file.Name} has error: {e.Message}");
                    }
                }
            }

            ConsoleHelper.WriteSuccess($"Total {dumpCount} file count in {dumpSize} bytes deleted");

            return true;
        }
    }
}
