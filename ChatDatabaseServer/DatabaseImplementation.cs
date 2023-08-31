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

namespace ChatDatabaseServer
{

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class DatabaseImplementation : DatabaseInterface
    {
        private ChatRoom room;
        private User user;
        private List<ChatRoom> roomList = new List<ChatRoom>();
        private List<User> users = new List<User>();

        public List<User> GetUsers()
        {
            user = new User();

            string username = user.Username;
            users.Add(user);

            return users;
        }

        public ChatRoom GetMessages(string sentMessage)
        {
            room = new ChatRoom();
            Message newMessage = new Message { MessageText = sentMessage };
            room.Messages.Add(newMessage);

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
