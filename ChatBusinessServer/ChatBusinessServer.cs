using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatBusinessServer
{
    internal class ChatBusinessServer
    {
        static void Main(string[]args)
        {
            Console.WriteLine("Loading up Chat Business Server....");
            ServiceHost host;
            NetTcpBinding tcp = new NetTcpBinding();
            host = new ServiceHost(typeof(ChatBusinessImplementation));
            host.AddServiceEndpoint(typeof(ChatBusinessInterface), tcp, "net.tcp://0.0.0.0:8200/BusinessService");
            host.Open();
            Console.WriteLine("System Online");
            Console.ReadLine();
            host.Close();
        }
    }
}
