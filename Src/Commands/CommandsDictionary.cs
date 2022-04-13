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

            ["cls"] = new Reset(),
            ["reset"] = new Reset(),

            ["l"] = new ListFolders(),
            ["ls"] = new ListFolders(),
            ["dir"] = new ListFolders(),
            ["info"] = new ListFolders(),

            ["d"] = new DetectAppFolder(),
            ["detect"] = new DetectAppFolder(),

            ["c"] = new ClearPublishFolder(),
            ["clear"] = new ClearPublishFolder(),

            ["z"] = new ZipPublishFolder(),
            ["zip"] = new ZipPublishFolder(),

            ["pure"] = new PurePublishFolder(),

            ["generatereport"] = new GenerateMonthlyReport(),
            ["gmr"] = new GenerateMonthlyReport(),
        };
    }
}
