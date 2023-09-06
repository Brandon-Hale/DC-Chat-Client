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

        //user stuff
        public List<User> GetUsers()
        {
            Log("Get Users Called:");
            return foob.GetUsers();
        }

        public Boolean AddUser(string username)
        {
            Log($"AddUser Called with string: {username}");
            return foob.AddUser(username);
        }

        public Boolean DuplicateUser(string username)
        {
            Log($"DuplicateUser Called with string: {username}");
            return foob.DuplicateUser(username);
        }


        //chat stuff
        public void AddMessage(string sentMessage, string chatRoomName)
        {
            Log($"GetMessages Called with string: {sentMessage}");

            foob.AddMessage(sentMessage, chatRoomName);
        }

        public List<Message> GetMessages(string chatRoomName)
        {
            Log($"GetMessages Called:");

            return foob.GetMessages(chatRoomName);
        }
        public string PrintMessages(string chatRoomName)
        {
            Log("PrintMessages Called:");

            return foob.PrintMessages(chatRoomName);
        }

        public ChatRoom GetChatRoom(string chatRoomName) 
        {
            Log($"GetChatRoom Called with string: {chatRoomName}");
            return foob.GetChatRoom(chatRoomName);
        }

        public void AddChatRoom(string chatRoomName)
        {
            Log($"AddChatRoom Called with string: {chatRoomName}");
            foob.AddChatRoom(chatRoomName);
        }
    }
}
