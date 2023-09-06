using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class ChatRoom
    {
        private List<Message> messages = new List<Message>();
        private string roomName;

        public List<Message> Messages 
        { 
            get { return messages; } 
            set { messages = value; }
        } 

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }

    }
}
