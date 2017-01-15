using System;
using System.ServiceModel;
using WCF_Client.WcfServices;

namespace WCF_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TaskManagerServiceClient();
            try
            {
                client.AddTask(new TaskParameters
                {
                    AssignedTo = "sdsdg",
                    SomeId = 10
                });
            }
            catch (FaultException<FaultInfo> e)
            {
                Console.WriteLine(e.Detail);
                Console.WriteLine(e.Detail.Reason);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Press to exit...");
            Console.Read();
        }
    }
}
