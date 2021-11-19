using System;

namespace XamtCli.Commands
{
    /// <summary>
    /// Clear The CLI
    /// </summary>
    public class Reset : IExecuter
    {
        public string GetTitle() => "Reset The CLI";

        public string GetDescription() => "Clear The CLI";

        public bool Execute(string[] options)
        {
            Console.Clear();

            ConsoleHelper.WriteLogo();
            ConsoleHelper.WriteVersion();

            return true;
        }
    }
}