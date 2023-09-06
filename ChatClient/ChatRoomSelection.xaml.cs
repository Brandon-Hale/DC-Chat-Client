using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
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
using ChatBusinessServer;
using ChatClient1;
using DLL;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for ChatRoomSelection.xaml
    /// </summary>
    public partial class ChatRoomSelection : Page
    {
        private ChatBusinessInterface foob;
        private string username;
        private string chatRoomNameNew;
        public ChatRoomSelection(string username)
        {
            InitializeComponent();
            newChatStack.Visibility = Visibility.Hidden;
            ChannelFactory<ChatBusinessServer.ChatBusinessInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8200/BusinessService";
            foobFactory = new ChannelFactory<ChatBusinessInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            this.username = username;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void addChatRoomButton_Click(object sender, RoutedEventArgs e)
        {
            ChatRoomCreationWindow chatRoomCreationWindow = new ChatRoomCreationWindow(username);
            chatRoomCreationWindow.ShowDialog();
             
            if (chatRoomCreationWindow.ChatRoomname == null)
            {
                return;
            }
            else
            {
                string newChatRoomName = chatRoomCreationWindow.ChatRoomname.ToString();
                foob.AddChatRoom(newChatRoomName);

                newChatRoom.Text = newChatRoomName;
                chatRoomNameNew = newChatRoomName;
                newChatStack.Visibility = Visibility.Visible;

                NavigationService.Navigate(new ChatRoomMessage(newChatRoomName, username));

            }
        }

        private void joinChatRoom1_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom1";
            foob.AddChatRoom(chatRoom);

            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));
        }

        private void joinChatRoom2_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom2";
            foob.AddChatRoom(chatRoom);

            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));

        }

        private void joinChatRoom3_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom3";
            foob.AddChatRoom(chatRoom);

            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));
        }

        private void joinNewChatRoom_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = chatRoomNameNew;
            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));
        }
    }
}
