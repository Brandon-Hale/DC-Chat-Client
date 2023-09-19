using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Message
    {
        private string messageText;


        public Message()
        {
            messageText = "";
        }

        public string MessageText
        {
            get { return messageText; }
            set { messageText = value; }
        }
    }
}
