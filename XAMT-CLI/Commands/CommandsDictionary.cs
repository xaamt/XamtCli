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
            ["q"] = new Exit(),

            ["help"] = new GetHelp(),

            ["c"] = new ClearPublishFolder(),
            ["clear"] = new ClearPublishFolder(),

            ["z"] = new ZipPublishFolder(),
            ["zip"] = new ZipPublishFolder(),

            ["p"] = new PurePublishFolder(),
            ["pure"] = new PurePublishFolder(),
        };
    }
}
