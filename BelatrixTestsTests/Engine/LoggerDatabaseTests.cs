using BelatrixLogger.Model;
using BelatrixLoggerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BelatrixLogger.Engine.Tests
{
    [TestClass()]
    public class LoggerDatabaseTests
    {
        [TestMethod()]
        public void FatalTestNonDatabase()
        {
            ILogger db = new LoggerDatabase(new LoggerDaoMock());
            Exception exception = new Exception();
            String message = "Something happened";
            Boolean expectedResult = true;
            Boolean actualResult = false;

            actualResult = db.Fatal(message, exception);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void ErrorTestToDatabase()
        {
            ILogger db = new LoggerDatabase(new LoggerDao());
            Exception exception = new Exception();
            String message = "Something happened";
            Boolean expectedResult = true;
            Boolean actualResult = false;

            actualResult = db.Error(message, exception);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void WarningTestToDatabaseNoMessage()
        {
            ILogger db = new LoggerDatabase(new LoggerDao());
            Exception exception = new Exception();
            String message = String.Empty;
            Boolean expectedResult = false;
            Boolean actualResult = false;

            actualResult = db.Warning(message, exception);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void TraceTestDatabaseNoException()
        {
            ILogger db = new LoggerDatabase(new LoggerDao());
            String message = "Something happened";
            Boolean expectedResult = true;
            Boolean actualResult = false;

            actualResult = db.Trace(message);

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}