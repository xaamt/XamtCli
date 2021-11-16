namespace XamtCli
{
    /// <summary>
    /// Command Execute Interface
    /// </summary>
    public interface IExecuter
    {
        string GetTitle();
        string GetDescription();
        bool Execute(string[] options);
    }
}