using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BelatrixLogger.Engine.Tests
{
    [TestClass()]
    public class LoggerConsoleTests
    {
        [TestMethod()]
        public void FatalConsoleTest()
        {
            ILogger console = new LoggerConsole();
            Exception exception = new Exception();
            String message = "Something happened";
            Boolean expectedResult = true;
            Boolean actualResult = false;

            actualResult = console.Fatal(message, exception);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void WarningConsoleTestEmptyMessage()
        {
            ILogger console = new LoggerConsole();
            Exception exception = new Exception();
            String message = String.Empty;
            Boolean expectedResult = false;
            Boolean actualResult = false;

            actualResult = console.Warning(message, exception);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void InfoConsoleTestNoException()
        {
            ILogger console = new LoggerConsole();
            String message = "Error found.";
            Boolean expectedResult = true;
            Boolean actualResult = false;

            actualResult = console.Info(message);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
