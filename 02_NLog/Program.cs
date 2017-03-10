using System;
using NLog;

namespace _02_NLog
{
    public class TestLoggerClass
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void WriteLog()
        {
            const int k = 42;
            const int l = 100;

            Logger.Trace("Sample trace message, k={0}, l={1}", k, l);
            Logger.Debug("Sample debug message, k={0}, l={1}", k, l);
            Logger.Info("Sample informational message, k={0}, l={1}", k, l);
            Logger.Warn("Sample warning message, k={0}, l={1}", k, l);
            Logger.Error("Sample error message, k={0}, l={1}", k, l);
            Logger.Fatal("Sample fatal error message, k={0}, l={1}", k, l);
            Logger.Log(LogLevel.Info, "Sample informational message, k={0}, l={1}", k, l);
        }
    }

    internal class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static void Main()
        {
            var k = 42;
            var l = 100;
            var testLogger = new TestLoggerClass();

            testLogger.WriteLog();

            Console.WriteLine(new string('-', 80));
            Logger.Trace("Sample trace message, k={0}, l={1}", k, l);
            Logger.Debug("Sample debug message, k={0}, l={1}", k, l);
            Logger.Info("Sample informational message, k={0}, l={1}", k, l);
            Logger.Warn("Sample warning message, k={0}, l={1}", k, l);
            Logger.Error("Sample error message, k={0}, l={1}", k, l);
            Logger.Fatal("Sample fatal error message, k={0}, l={1}", k, l);
            Logger.Log(LogLevel.Info, "Sample informational message, k={0}, l={1}", k, l);

            Console.WriteLine("Press any <Enter>...");
            Console.ReadLine();
        }
    }
}
