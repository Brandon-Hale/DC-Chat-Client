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
        ChatRoom GetMessages(string sentMessage);

        [OperationContract]
        string PrintMessages();

        [OperationContract]
        List<User> GetUsers();

    }
}
