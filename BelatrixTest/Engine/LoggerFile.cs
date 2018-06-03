using BelatrixLogger.Model;
using BelatrixLogger.Utils;
using System;
using System.Configuration;
using System.IO;

namespace BelatrixLogger.Engine
{
    public class LoggerFile : ILogger
    {
        private static String MainPath;

        public LoggerFile()
        {
            MainPath = String.Format("{0}{1}",ConfigurationManager.AppSettings["LogFileDirectory"], "LogFile");
        }

        /// <summary>
        /// Save Log to a txt file. File Path needed in app.config
        /// </summary>
        /// <param name="loglevel">Depends on the severity of the log</param>
        /// <param name="message">Any text the user would like to add</param>
        /// <param name="exception">Can be null, when logging in trace or debug mode</param>
        /// <returns>Boolean for unit test purpose</returns>
        private Boolean File(LogObject loglevel, String message, Exception exception = null)
        {
            Boolean response = false;
            try
            {
                if (message == null || message.Length == 0 || loglevel == null)
                    return response;

                LoggerUtilities.GetLogObject(loglevel, message, exception);
                String currentPath = String.Format("{0}{1}{2}", MainPath, DateTime.Now.ToShortDateString().Replace("/", "_"), ".txt");
                using (StreamWriter logFile = System.IO.File.AppendText(currentPath))
                {
                    String logMessage = LoggerUtilities.FormatLogMessage(loglevel);
                    logFile.WriteLine(logMessage);
                    response = true;
                }
            }
            catch (Exception ex)
            {
                LoggerUtilities.ShowUnexpectedError("file", ex);
            }
            return response;
        }
      
        public bool Fatal(String message, Exception exception = null)
        {
            return File(LogLevel.Fatal(), message, exception);
        }

        public bool Error(String message, Exception exception = null)
        {
            return File(LogLevel.Error(), message, exception);
        }

        public bool Warning(String message, Exception exception = null)
        {
            return File(LogLevel.Warning(), message, exception);
        }

        public bool Info(String message, Exception exception = null)
        {
            return File(LogLevel.Info(), message, exception);
        }

        public bool Debug(String message, Exception exception = null)
        {
            return File(LogLevel.Debug(), message, exception);
        }

        public bool Trace(String message, Exception exception = null)
        {
            return File(LogLevel.Trace(), message, exception);
        }
    }
}
