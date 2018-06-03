using BelatrixLogger.Model;
using BelatrixLogger.Utils;
using System;

namespace BelatrixLogger.Engine
{
    public class LoggerConsole : ILogger
    {
        /// <summary>
        /// Show Log in console
        /// </summary>
        /// <param name="logLevel">Depends on the severity of the log</param>
        /// <param name="message">Any text the user would like to add</param>
        /// <param name="exception">Can be null, when logging in trace or debug mode</param>
        /// <returns>Boolean for unit test purpose</returns>
        private Boolean Console(LogObject logLevel,String message, Exception exception = null)
        {
            Boolean response = false;
            try
            {
                if (message == null || message.Length == 0 || logLevel == null)
                    return response;
                
                LoggerUtilities.GetLogObject(logLevel, message, exception);

                String logMessage = LoggerUtilities.FormatLogMessage(logLevel);
                System.Console.ForegroundColor = logLevel.Level.Color;
                System.Console.WriteLine(logMessage);
                response = true;
            }
            catch (Exception ex)
            {
                LoggerUtilities.ShowUnexpectedError("console", ex);
            }
            return response;
        }
        
        public bool Fatal(String message, Exception exception = null)
        {
            return Console(LogLevel.Fatal(),message,exception);
        }

        public bool Error(String message, Exception exception = null)
        {
            return Console(LogLevel.Error(), message, exception);
        }

        public bool Warning(String message, Exception exception = null)
        {
            return Console(LogLevel.Warning(), message, exception);
        }

        public bool Info(String message, Exception exception = null)
        {
            return Console(LogLevel.Info(), message, exception);
        }

        public bool Debug(String message, Exception exception = null)
        {
            return Console(LogLevel.Debug(), message, exception);
        }

        public bool Trace(String message, Exception exception = null)
        {
            return Console(LogLevel.Trace(), message, exception);
        }
        
    }
}