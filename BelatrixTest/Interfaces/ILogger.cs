
using System;

namespace BelatrixLogger
{
    public interface ILogger
    {
        Boolean Fatal(String message, Exception exception = null);
        Boolean Error(String message, Exception exception = null);
        Boolean Warning(String message, Exception exception = null);
        Boolean Info(String message, Exception exception = null);
        Boolean Debug(String message, Exception exception = null);
        Boolean Trace(String message, Exception exception = null);
    }
}
