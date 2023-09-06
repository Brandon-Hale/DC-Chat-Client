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
using System.Runtime.CompilerServices;
using System.Reflection.Emit;

namespace ChatDatabaseServer
{

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class DatabaseImplementation : DatabaseInterface
    {
        ChatRoom room;
        private static List<ChatRoom> roomList = new List<ChatRoom>();
        private static List<User> users = new List<User>();

        //stuff for Users
        public Boolean DuplicateUser(string username)
        {
            foreach (User user in users)
            {
                if (user.Username.Equals(username))
                {
                    return true;
                }
            }
            return false;

        }

        public Boolean AddUser(string username)
        {
            Boolean userAdded = false;
            if (DuplicateUser(username))
            {
                userAdded = false;
            }
            else
            {
                User user = new User();
                user.Username = username;
                users.Add(user);
                userAdded = true;
            }
            return userAdded;
        }

        public List<User> GetUsers()
        {
            return users;
        }


        //stuff for chat Rooms
        public void AddChatRoom(string chatRoomName)
        {
            ChatRoom chatRoom = new ChatRoom();
            chatRoom.RoomName = chatRoomName;
            roomList.Add(chatRoom);
        }
        public void AddMessage(string sentMessage, string chatRoomName)
        {
            room = GetChatRoom(chatRoomName);
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("HH:mm:ss");
            Message newMessage = new Message { MessageText = (formattedDate + ": " + sentMessage) };
            room.Messages.Add(newMessage);
        }

        public string PrintMessages(string chatRoomName) //need to have time: user: message
        {
            string messageLog = "";
            ChatRoom chatRoom = GetChatRoom(chatRoomName);
            chatRoom.Messages = GetMessages(chatRoomName);

            foreach (var message in chatRoom.Messages)
            {
                messageLog += message.MessageText.ToString() + "\n";
            }

            return messageLog;
        }
        public ChatRoom GetChatRoom(string chatRoomName)
        {
            foreach (ChatRoom chatRoom in roomList)
            {
                if (chatRoomName.Equals(chatRoom.RoomName.ToString()))
                {
                    return chatRoom;
                }
            }
            return null;
        }

        public List<Message> GetMessages(string chatRoomName)
        {
            ChatRoom chatRoom = GetChatRoom(chatRoomName);
            List<Message> messages = chatRoom.Messages;

            return messages;
        }
    }
}
