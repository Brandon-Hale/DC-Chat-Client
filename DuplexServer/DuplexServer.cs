using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DuplexServer
{
    internal class DuplexServer
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Duplex Server. I send progress update");
            NetTcpBinding netTcpBinding = new NetTcpBinding();
            ServiceHost serviceHost = new ServiceHost(typeof(ProcessServiceImplement));
            serviceHost.AddServiceEndpoint(typeof(ProcessServiceInterface), netTcpBinding, "net.tcp://0.0.0.0:8300/ProcessService");
            serviceHost.Open();
            Console.WriteLine("System Online");
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}
