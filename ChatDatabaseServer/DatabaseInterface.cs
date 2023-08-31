using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DLL;
using System.Configuration;

namespace ChatDatabaseServer
{
    [ServiceContract]
    public interface DatabaseInterface
    {
        [OperationContract]
        void AddMessage(string sentMessage);

        [OperationContract]
        ChatRoom GetMessages();

        [OperationContract]
        string PrintMessages();

        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        void AddUser(string username);


    }
}
