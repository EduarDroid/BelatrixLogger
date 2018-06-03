using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.IO;

namespace BelatrixLogger.Engine.Tests
{
    [TestClass()]
    public class LoggerFileTests
    {
        [TestMethod()]
        public void FatalFileTest()
        {
            ILogger file = new LoggerConsole();
            Exception exception = new Exception();
            String message = "Something happened";
            Boolean expectedResult = true;
            Boolean actualResult = false;
            Boolean fileExists = false;
            Boolean logResult = false;

            logResult = file.Fatal(message, exception);

            //verify if file exists
            if (File.Exists(ConfigurationManager.AppSettings["LogFileDirectory"]
                            + "LogFile"
                            + DateTime.Now.ToShortDateString().Replace("/", "_") + ".txt"))
                fileExists = true;

            if (logResult && fileExists)
                actualResult = true;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void DebugFileTestEmptyMessage()
        {
            ILogger file = new LoggerConsole();
            Exception exception = new Exception();
            String message = String.Empty;
            Boolean expectedResult = false;
            Boolean actualResult = false;
            Boolean fileExists = false;
            Boolean logResult = false;

            logResult = file.Debug(message, exception);

            //verify if file exists
            if (File.Exists(ConfigurationManager.AppSettings["LogFileDirectory"]
                            + "LogFile"
                            + DateTime.Now.ToShortDateString().Replace("/", "_") + ".txt"))
                fileExists = true;

            if (logResult && fileExists)
                actualResult = true;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void TraceFileTestNoException()
        {
            ILogger file = new LoggerConsole();
            String message = "Something happened";
            Boolean expectedResult = true;
            Boolean actualResult = false;
            Boolean fileExists = false;
            Boolean logResult = false;

            logResult = file.Trace(message);

            //verify if file exists
            if (File.Exists(ConfigurationManager.AppSettings["LogFileDirectory"]
                            + "LogFile"
                            + DateTime.Now.ToShortDateString().Replace("/", "_") + ".txt"))
                fileExists = true;

            if (logResult && fileExists)
                actualResult = true;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}