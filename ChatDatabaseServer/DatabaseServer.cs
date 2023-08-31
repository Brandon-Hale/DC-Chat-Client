using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatDatabaseServer
{
    internal class DatabaseServer //basic server bootin up
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Database Server Loading Up....");
            ServiceHost host;
            NetTcpBinding tcp = new NetTcpBinding();
            host = new ServiceHost(typeof(DatabaseImplementation));
            host.AddServiceEndpoint(typeof(DatabaseInterface), tcp, "net.tcp://0.0.0.0:8100/DataService");

            host.Open();
            Console.WriteLine("System Online");
            Console.ReadLine();


            host.Close();
        }
    }
}
