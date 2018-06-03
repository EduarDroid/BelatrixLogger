using BelatrixLogger.Model;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BelatrixLogger.Utils
{
    public static class LoggerUtilities
    {
        #region Utilities
        public static SqlConnection GetConnection()
        {
            SqlConnection objConexion = null;
            try
            {
                String connString = "";
                if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null)
                    connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                objConexion = new SqlConnection(connString);
            }
            catch (Exception)
            {
                objConexion = null;
            }

            return objConexion;
        }

        public static void ShowUnexpectedError(String logType, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unexpected error in {0} logging: {1} // {2}", logType ,ex.Message,ex.StackTrace);
        }

        public static String FormatLogMessage(LogObject loglevel)
        {
            return String.Format("{0} [{1}]{2} :({3}/{4}) {5} // {6}", DateTime.Now.ToString(), loglevel.Level.Code, loglevel.Level.Name, Environment.MachineName, Environment.UserName, loglevel.Message, loglevel.ExceptionMessage);
        }

        public static LogObject GetLogObject(LogObject logLevel, String message, Exception exception)
        {
            LogObject logObject = logLevel;
            logObject.Message = message;
            logObject.Ex = exception;
            return logObject;
        }

        #endregion
    }
}
