using BelatrixLogger.Interfaces;
using BelatrixLogger.Model;
using BelatrixLogger.Utils;
using System;

namespace BelatrixLogger.Engine
{
    public class LoggerDatabase : ILogger
    {
        ILoggerDao logDao = null;
        public LoggerDatabase(ILoggerDao interfaceDao)
        {
            logDao = interfaceDao;
        }
        /// <summary>
        /// Save Log to a database. Settings needed in app.config for connectivity
        /// </summary>
        /// <param name="loglevel">Depends on the severity of the log</param>
        /// <param name="message">Any text the user would like to add</param>
        /// <param name="exception">Can be null, when logging in trace or debug mode</param>
        /// <returns>Boolean for unit test purpose</returns>
        private Boolean Database(LogObject loglevel, String message, Exception exception = null)
        {
            Boolean response = false;
            try
            {
                if (message == null || message.Length == 0 || loglevel == null)
                    return response;
                
                LoggerUtilities.GetLogObject(loglevel, message, exception);
                
                response=logDao.LogSave(loglevel);
            }
            catch (Exception ex)
            {
                LoggerUtilities.ShowUnexpectedError("database", ex);
            }

            return response;
        }
        
        public bool Fatal(String message, Exception exception = null)
        {
            return Database(LogLevel.Fatal(), message, exception);
        }

        public bool Error(String message, Exception exception = null)
        {
            return Database(LogLevel.Error(), message, exception);
        }

        public bool Warning(String message, Exception exception = null)
        {
            return Database(LogLevel.Warning(), message, exception);
        }

        public bool Info(String message, Exception exception = null)
        {
            return Database(LogLevel.Info(), message, exception);
        }

        public bool Debug(String message, Exception exception = null)
        {
            return Database(LogLevel.Debug(), message, exception);
        }

        public bool Trace(String message, Exception exception = null)
        {
            return Database(LogLevel.Trace(), message, exception);
        }
    }
}
