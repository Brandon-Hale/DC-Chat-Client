using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DLL;

namespace ChatDatabaseServer
{
    [ServiceContract]
    public interface DatabaseInterface
    {
        [OperationContract]
        ChatRoom GetMessages(string sentMessage);

        [OperationContract]
        string PrintMessages();

        [OperationContract]
        List<User> GetUsers();
    }
}
