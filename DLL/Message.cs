using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Message
    {
        private string messageText;
        private string textFile;
        private Bitmap imageFile;

        public Message()
        {
            messageText = "";
            textFile = null;
            imageFile = null;
        }

        public string MessageText
        {
            get { return messageText; }
            set { messageText = value; }
        }

        public string TextFile { get { return textFile; } set {  textFile = value; } }
        public Bitmap ImageFile { get { return imageFile; } set {  imageFile = value; } }
    }
}
