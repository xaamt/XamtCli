using XamtCli.Helpers;

namespace XamtCli.Commands
{
    /// <summary>
    /// Detect application name from Publish folder
    /// </summary>
    public class DetectAppFolder : IExecuter
    {
        public string GetTitle() => "Detect Application";

        public string GetDescription() => "Detect application name from publish folder";

        public bool Execute(params string[] param)
        {
            var app = FileHelper.DetectArmanApplication();

            if (app != null)
            {
                ConsoleHelper.WriteInfo($"Detecting application : {app.ApplicationName} version {app.ApplicationVersion} was successful");
                return true;
            }

            ConsoleHelper.WriteError($"Detecting applicaton name failed");
            return true;
        }
    }
}
