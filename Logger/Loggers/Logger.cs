namespace LoggerLibrary.Loggers
{
    using System;
    using Appenders.Contracts;
    using Loggers.Contracts;

    /// <summary>
    /// hold methods for various kinds of logging 
    /// </summary>

    public class Logger : ILogger
    {
        private IAppender consoleAappender;
        private IAppender fileAappender;

        public Logger(IAppender consoleAppender)
        {
            this.consoleAappender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAappender)
                : this(consoleAppender)
        {
            this.fileAappender = fileAappender;
        }

        public void Error(string dateTime, string errorMessage)
        {
            Append(dateTime, "Error", errorMessage);
        }

        public void Info(string dateTime, string infoMessage)
        {
            Append(dateTime, "Info", infoMessage);
        }

        public void Fatal(string dateTime, string fatalMessage)
        {
            Append(dateTime, "Fatal", fatalMessage);
        }

            public void Critical(string dateTime, string criticalMessage)
        {
            Append(dateTime, "Critical", criticalMessage);
        }

        private void Append(string dateTime, string type, string criticalMessage)
        {
            consoleAappender?.Append(dateTime, type, criticalMessage);
            fileAappender?.Append(dateTime, type, criticalMessage);
        }
    }
}
