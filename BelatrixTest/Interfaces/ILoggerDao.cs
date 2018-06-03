using BelatrixLogger.Model;
using System;

namespace BelatrixLogger.Interfaces
{
    public interface ILoggerDao
    {
        Boolean LogSave(LogObject loglevel);
    }
}
