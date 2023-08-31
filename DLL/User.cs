using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class User
    {
        private string username;

        public User()
        {
            username = "Guest";
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string toString()
        {
            string info = username;

            return info;
        }
    }
}
