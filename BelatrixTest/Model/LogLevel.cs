using System;

namespace BelatrixLogger.Model
{
    public class LogLevel
    {
        public Int16 Code { get; set; }
        public ConsoleColor Color { get; set; }
        public String Name { get; set; }

        public static LogObject Fatal()
        {
            LogLevel level= new LogLevel() { Code = 1, Color = ConsoleColor.Red, Name = "FATAL" };
            return new LogObject(level);
        }

        public static LogObject Error()
        {
            LogLevel level = new LogLevel() { Code = 2, Color = ConsoleColor.DarkRed, Name = "ERROR" };
            return new LogObject(level);
        }

        public static LogObject Warning()
        {
            LogLevel level = new LogLevel() { Code = 3, Color = ConsoleColor.Yellow, Name = "WARNING" };
            return new LogObject(level);
        }

        public static LogObject Info()
        {
            LogLevel level = new LogLevel() { Code = 4, Color = ConsoleColor.White, Name = "INFO" };
            return new LogObject(level);
        }

        public static LogObject Debug()
        {
            LogLevel level = new LogLevel() { Code = 5, Color = ConsoleColor.Gray, Name = "DEBUG" };
            return new LogObject(level);
        }
        public static LogObject Trace()
        {
            LogLevel level = new LogLevel() { Code = 6, Color = ConsoleColor.Cyan, Name = "TRACE" };
            return new LogObject(level);
        }
    }
    
}
