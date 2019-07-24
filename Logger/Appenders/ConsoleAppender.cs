namespace LoggerLibrary.Appenders
{
    using Appenders.Contracts;
    using Layouts.Contracts;

    using System;

    /// <summary>
    /// appends a log to the console, using the provided layout
    /// </summary>

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;
        
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout
        {
            get => this.layout;
            set => this.layout = value;
        }

        public void Append(string dateTime, string reportLevel, string message)
        {
            Console.WriteLine(string.Format(this.Layout.Format, dateTime, reportLevel, message));
        }
    }
}
