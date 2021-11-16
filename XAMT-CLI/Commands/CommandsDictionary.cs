using System.Collections.Generic;

namespace XamtCli.Commands
{
    /// <summary>
    /// List of commands
    /// </summary>
    public static class CommandsDictionary
    {
        public static readonly Dictionary<string, IExecuter> Commands = new Dictionary<string, IExecuter>()
        {
            ["exit"] = new Exit(),
            ["help"] = new GetHelp(),
            ["clear"] = new ClearPublishFolder(),
            ["zip"] = new ZipPublishFolder(),
        };
    }
}
