
using BelatrixLogger.Interfaces;
using BelatrixLogger.Model;

namespace BelatrixLoggerTests
{
    public class LoggerDaoMock : ILoggerDao
    {
        public bool LogSave(LogObject loglevel)
        {
            return true;
        }
    }
}
