using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DLL;

namespace ChatBusinessServer
{
    [ServiceContract]
    public interface ChatBusinessInterface
    {
        [OperationContract]
        void AddMessage(string message);

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
