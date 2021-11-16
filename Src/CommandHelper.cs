using System;
using System.Linq;
using XamtCli.Commands;

namespace XamtCli
{
    /// <summary>
    /// Command Helper
    /// </summary>
    public static class CommandHelper
    {
        /// <summary>
        /// Execute a command defenition
        /// </summary>
        /// <param name="defenition"></param>
        /// <returns></returns>
        public static bool Execute(this CommandDefenition defenition)
        {
            var command = ChooseCommand(defenition.Name);

            if (!string.IsNullOrWhiteSpace(command.GetTitle()))
            {
                ConsoleHelper.WriteTitle(command.GetTitle());
            }

            var result = command.Execute(defenition.Options);

            return result;
        }

        /// <summary>
        /// parse user input line
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static CommandDefenition ParseCommand(this string input)
        {
            var parts = input.Split(new char[] { ' ', '.', '-' }, StringSplitOptions.RemoveEmptyEntries);

            var result = new CommandDefenition()
            {
                Name = parts[0],
                Options = parts.Skip(1).ToArray()
            };

            return result;
        }

        /// <summary>
        /// choose a command by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static IExecuter ChooseCommand(string name)
        {
            if (CommandsDictionary.Commands.TryGetValue(name.ToLower(), out var result))
            {
                return result;
            }

            return new GetHelp();
        }
    }
}