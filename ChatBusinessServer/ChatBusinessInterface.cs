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
        //user stuff
        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        Boolean AddUser(string username);
        [OperationContract]
        Boolean DuplicateUser(string username);

        //chatRoom
        [OperationContract]
        void AddMessage(string sentMessage, string chatRoomName, string username);

        [OperationContract]
        List<Message> GetMessages(string chatRoomName);

        [OperationContract]
        string PrintMessages(string chatRoomName);

        [OperationContract]
        ChatRoom GetChatRoom(string chatRoomName);
        [OperationContract]
        void AddChatRoom(string chatRoomName);

    }
}
