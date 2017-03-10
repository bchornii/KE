
//#define TEST
//#define VERIFY

using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace _01_CodeContracts
{
    [Conditional("TEST")]
    [Conditional("VERIFY")]
    public sealed class CondAttribute : Attribute
    {
    }

    [Cond]
    internal class Program
    {
        static Program()
        {
            AppDomain.CurrentDomain.FirstChanceException +=
                (sender, args) => { Console.WriteLine(args.Exception.Message); };
        }

        private static void Main()
        {
            var logName = "ProCSharpLog";
            var sourceName = "EventLogDemoApp";

            //if (!EventLog.SourceExists(sourceName))
            //{
            //    var eventSourceData = new EventSourceCreationData(sourceName, logName);
            //    EventLog.CreateEventSource(eventSourceData);
            //}

            //using (var log = new EventLog(logName,".", sourceName))
            //{
            //    log.WriteEntry("Message 1");
            //    log.WriteEntry("Message 2", EventLogEntryType.Warning);
            //    log.WriteEntry("Message 2", EventLogEntryType.Information, 33);
            //}

            //foreach (var performanceCounterCategory in PerformanceCounterCategory.GetCategories("."))
            //{
            //    Console.WriteLine(performanceCounterCategory.CategoryName);
            //}

            Console.WriteLine("CondAttribute is {0}applied to Program type.",
                Attribute.IsDefined(typeof(Program), typeof(CondAttribute))
                    ? ""
                    : "not ");

            Console.ReadLine();
        }

        private static void Except()
        {
            throw new ArgumentException("sgsgsg");
        }

        private static void MinMax(int min, int max)
        {
            Contract.Requires<ArgumentException>(min < max);
        }
    }
}
