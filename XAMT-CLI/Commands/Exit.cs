using System;

namespace XamtCli.Commands
{
    /// <summary>
    /// Exit The CLI
    /// </summary>
    public class Exit : IExecuter
    {
        public string GetTitle() => "Exit The CLI";

        public string GetDescription() => null;

        public bool Execute(string[] options)
        {
            ConsoleHelper.WriteLine("Thanks for using XAMT Cli", ConsoleColor.DarkRed);

            return false;
        }
    }
}