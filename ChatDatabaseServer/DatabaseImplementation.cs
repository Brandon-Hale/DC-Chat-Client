using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Runtime.InteropServices;
using DLL;
using System.ServiceModel.Configuration;
using System.Configuration;
using Microsoft.SqlServer.Server;

namespace ChatDatabaseServer
{

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class DatabaseImplementation : DatabaseInterface
    {
        private ChatRoom room = new ChatRoom();
        private User user;
        private List<ChatRoom> roomList = new List<ChatRoom>();
        private List<User> users = new List<User>();

        public void AddUser(string username)
        {
            user = new User();

            user.Username = username;
            users.Add(user);
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public void AddMessage(string sentMessage)
        {

            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("HH:mm:ss");
            Message newMessage = new Message { MessageText = (formattedDate + ": " + sentMessage) };
            room.Messages.Add(newMessage);
        }

        public ChatRoom GetMessages()
        {
            return room;
        }

        public string PrintMessages() //need to have time: user: message
        {
            string messageLog = "";
            foreach(var message in room.Messages)
            {
                messageLog += message.MessageText.ToString() + "\n";
            }

            return messageLog;
        }
    }
}
