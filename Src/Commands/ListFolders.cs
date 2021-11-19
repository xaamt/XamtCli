using System;
using System.IO;
using XamtCli.Helpers;

namespace XamtCli.Commands
{
    /// <summary>
    /// List files in folder
    /// </summary>
    public class ListFolders : IExecuter
    {
        public string GetTitle() => "List folders";

        public string GetDescription() => "List files in folder";

        public bool Execute(params string[] param)
        {
            var startFolder = Directory.GetCurrentDirectory();
            var dir = new DirectoryInfo(startFolder);

            var files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);

            var dirs = dir.GetDirectories("*", SearchOption.TopDirectoryOnly);

            var fileCount = files.Length;
            var folderCount = dirs.Length;

            ConsoleHelper.WriteInfo2($"Directories - Total Count: {folderCount}", true);
            foreach (var dr in dirs)
            {
                ConsoleHelper.Write($"{FileHelper.FileSizeSuffix(FileHelper.DirSize(dr)),10}");
                ConsoleHelper.Write($"\t{"dir",-4}", ConsoleColor.DarkGray);
                ConsoleHelper.Write($"\t{dr.Name}", ConsoleColor.DarkYellow);
                Console.WriteLine();
            }

            Console.WriteLine();
            ConsoleHelper.WriteInfo2($"Files - Total Count: {fileCount}", true);
            foreach (var file in files)
            {
                ConsoleHelper.Write($"{FileHelper.FileSizeSuffix(file.Length),10}");
                ConsoleHelper.Write($"\t{file.Extension.Replace(".", null),-4}", ExtensionColor(file.Extension));
                ConsoleHelper.Write($"\t{file.Name,-50}", ConsoleColor.DarkYellow);
                Console.WriteLine();
            }

            return true;
        }

        public static ConsoleColor ExtensionColor(string extension) => extension.ToLower().Replace(".", null) switch
        {
            "dll" => ConsoleColor.DarkCyan,
            "xml" => ConsoleColor.DarkGreen,
            "json" => ConsoleColor.DarkMagenta,
            "mrt" => ConsoleColor.DarkBlue,
            "exe" => ConsoleColor.DarkRed,
            "pdb" => ConsoleColor.DarkGray,
            _ => ConsoleColor.DarkYellow
        };
    }
}