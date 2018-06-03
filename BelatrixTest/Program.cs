using BelatrixLogger.Engine;
using BelatrixLogger.Model;
using System;

namespace BelatrixLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to eLogger");
            Exception exception = new Exception();

            ILogger console = new LoggerConsole();
            ILogger file = new LoggerFile();
            ILogger db = new LoggerDatabase(new LoggerDao());

            console.Fatal("Fatal Error found.", exception);
            console.Error("Error found.", exception);
            console.Warning("Warning found.", exception);
            console.Info("Informative message.");
            console.Debug("Debug message.");
            console.Trace("Trace message.");


            file.Fatal("Fatal Error found.", exception);
            file.Error("Error found.", exception);
            file.Warning("Warning found.", exception);
            file.Info("Informative message.");
            file.Debug("Debug message.");
            file.Trace("Trace message.");

            db.Fatal("Fatal Error found.", exception);
            db.Error("Error found.", exception);
            db.Warning("Warning found.", exception);
            db.Info("Informative message.");
            db.Debug("Debug message.");
            db.Trace("Trace message.");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
        }
    }
}
