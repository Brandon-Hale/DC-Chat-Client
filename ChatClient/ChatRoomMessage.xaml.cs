﻿using ChatBusinessServer;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for ChatRoomMessage.xaml
    /// </summary>
    public partial class ChatRoomMessage : Page
    {

        private ChatBusinessInterface foob;
        string chatRoomName;
        public ChatRoomMessage(string chatRoomName)
        {
            InitializeComponent();

            ChannelFactory<ChatBusinessServer.ChatBusinessInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8200/BusinessService";
            foobFactory = new ChannelFactory<ChatBusinessInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            this.chatRoomName = chatRoomName;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            //working for 1 chatROom currently can talk throughout
            string sentMessage = MessageBox.Text.ToString();

            await Task.Run(() => foob.AddMessage(sentMessage, chatRoomName));
            string chatMessages = await Task.Run(() => foob.PrintMessages(chatRoomName));

            ChatBox.Text = chatMessages;
            ChatBox.Visibility = Visibility.Visible;
        }
    }
}
