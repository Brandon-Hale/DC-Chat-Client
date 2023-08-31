using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class ChatRoom
    {
        private List<Message> messages;

        public ChatRoom()
        {
            messages = new List<Message>();
        }

        public List<Message> Messages 
        { 
            get { return messages; } 
            set { messages = value; }
        } 

    }
}
