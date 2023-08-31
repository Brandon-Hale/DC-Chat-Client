using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChatDatabaseServer;
using System.Runtime.CompilerServices;
using DLL;

namespace ChatBusinessServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ChatBusinessImplementation : ChatBusinessInterface
    {
        private DatabaseInterface foob;
        private uint LogNumber = 0;
        private ChatRoom room = new ChatRoom();

        public ChatBusinessImplementation()
        {
            //sajib said just to use 1 channel factory for the methods
            ChannelFactory<DatabaseInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8100/DataService";
            foobFactory = new ChannelFactory<DatabaseInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Log(string logString)
        {
            LogNumber++;
            string logMessage = $"Log {LogNumber}: {logString}";
            Console.WriteLine(logMessage);
        }

        public ChatRoom GetMessages(string sentMessage)
        {
            Log($"GetMessages Called with string: {sentMessage}");
            foob.GetMessages(sentMessage);

            return room;
        }
        public string PrintMessages()
        {
            Log("PrintMessages Called:");

            return foob.PrintMessages();
        }

        public List<User> GetUsers()
        {
            Log("Get Users Called:");
            return foob.GetUsers();
        }
    }
}
