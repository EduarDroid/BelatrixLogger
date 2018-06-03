using BelatrixLogger.Interfaces;
using BelatrixLogger.Utils;
using System;
using System.Data.SqlClient;

namespace BelatrixLogger.Model
{
    public class LoggerDao : ILoggerDao
    {
        SqlConnection _connection = null;
        public LoggerDao()
        {
            _connection = LoggerUtilities.GetConnection();
        }

        public bool LogSave(LogObject loglevel)
        {
            Boolean response = false;
            try
            {
                using (var command = new SqlCommand("LogSave", _connection))
                {
                    _connection.Open();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@level", loglevel.Level.Code);
                    command.Parameters.AddWithValue("@message", loglevel.Message);
                    command.Parameters.AddWithValue("@stackTrace", loglevel.ExceptionMessage);
                    command.Parameters.AddWithValue("@machineName", loglevel.MachineName);
                    command.Parameters.AddWithValue("@userName", loglevel.UserName);
                    command.Parameters.AddWithValue("@createdDate", loglevel.CreatedDate);
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                    response = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Error while connecting database - {0}", ex.Message));
            }
            finally
            {
                _connection.Close();
            }

            return response;
        }
    }
}
