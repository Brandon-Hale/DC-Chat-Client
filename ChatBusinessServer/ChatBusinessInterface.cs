﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DLL;
using System.Drawing;

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
        [OperationContract]
        void RemoveUser(string username);

        //chatRoom
        [OperationContract]
        void AddMessage(string sentMessage, string chatRoomName, string username);

        [OperationContract]
        void AddTextFile(string fileName, string chatRoomName, string username, string file);

        [OperationContract]
        void AddImageFile(string fileName, string chatRoomName, string username, byte[] image);

        [OperationContract]
        List<Message> GetMessages(string chatRoomName);

        [OperationContract]
        string PrintMessages(string chatRoomName);

        [OperationContract]
        ChatRoom GetChatRoom(string chatRoomName);
        [OperationContract]
        void AddChatRoom(string chatRoomName, string username);
        [OperationContract]
        List<ChatRoom> GetChatRooms();

        [OperationContract]
        List<String> GetUserCreatedRooms(string username);

        [OperationContract]
        void AddPrivateRooms(string username);
    }
}
