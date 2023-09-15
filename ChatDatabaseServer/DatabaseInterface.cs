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
        List<User> GetUsers();

        [OperationContract]
        Boolean AddUser(string username);
        [OperationContract]
        Boolean DuplicateUser(string username);
        [OperationContract]
        void RemoveUser(string username);

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
        void AddChatRoom(string chatRoomName, string username);

        [OperationContract]
        List<String> GetUserCreatedRooms();

    }
}
