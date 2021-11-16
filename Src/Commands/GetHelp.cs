using System;
using System.Linq;

namespace XamtCli.Commands
{
    /// <summary>
    /// Get Help
    /// </summary>
    public class GetHelp : IExecuter
    {
        public string GetTitle() => "Get Help";

        public string GetDescription() => "Get CLI full guid";

        public bool Execute(string[] options)
        {
            Console.WriteLine("Available Commands:");
            foreach (var command in CommandsDictionary.Commands.OrderBy(x => x.Key))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {command.Key}:");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($" {command.Value.GetTitle()}");
                Console.ResetColor();
                Console.WriteLine($" [{command.Value.GetDescription()}]");
            }

            return true;
        }
    }
}