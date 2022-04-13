namespace XamtCli
{
    /// <summary>
    /// to keep command data
    /// </summary>
    public class CommandDefinition
    {
        /// <summary>
        /// command title
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// command options
        /// </summary>
        public string[] Options { get; set; }
    }
}
