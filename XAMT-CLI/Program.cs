using static XamtCli.ConsoleHelper;

namespace XamtCli
{
    /// <summary>
    /// Application Start Point
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            WriteLogo();
            WriteVersion();

            var continueProgram = true;

            while (continueProgram)
            {
                var input = GetInput();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                continueProgram = input.ParseCommand().Execute();
            }
        }
    }
}
