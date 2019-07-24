namespace LoggerLibrary.Appenders
{
    using Appenders.Contracts;
    using Layouts.Contracts;
    using Loggers.Contracts;

    using System;
    using System.IO;

    /// <summary>
    /// appends a log to a file, using the provided layout
    /// </summary>

    public class FileAppender : IAppender
    {
        private const string LogFilePath = @"..\..\..\log.txt";

        private ILayout layout;
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.Layout = layout;
            this.LogFile = logFile;
        }

        public ILayout Layout
        {
            get => this.layout;
            set => this.layout = value;
        }
        public ILogFile LogFile
        {
            get => logFile;
            set => logFile = value;
        }

        public void Append(string dateTime, string reportLevel, string message)
        {
            string content = string.Format(this.Layout.Format, dateTime, reportLevel, message) +
               Environment.NewLine;

            File.AppendAllText(LogFilePath, content);
        }
    }
}
