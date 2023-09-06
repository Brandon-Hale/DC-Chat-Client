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
using ChatBusinessServer;
using DLL;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for ChatRoomSelection.xaml
    /// </summary>
    public partial class ChatRoomSelection : Page
    {
        private ChatBusinessInterface foob;
        public ChatRoomSelection()
        {
            InitializeComponent();
            ChannelFactory<ChatBusinessServer.ChatBusinessInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8200/BusinessService";
            foobFactory = new ChannelFactory<ChatBusinessInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void addChatRoomButton_Click(object sender, RoutedEventArgs e)
        {
            string newChatRoomName = "";


            foob.AddChatRoom(newChatRoomName);
        }

        private void joinChatRoom1_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom1";
            foob.AddChatRoom(chatRoom);

            NavigationService.Navigate(new ChatRoomMessage(chatRoom));
        }

        private void joinChatRoom2_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom2";
            foob.AddChatRoom(chatRoom);

            NavigationService.Navigate(new ChatRoomMessage(chatRoom));

        }

        private void joinChatRoom3_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom3";
            foob.AddChatRoom(chatRoom);

            NavigationService.Navigate(new ChatRoomMessage(chatRoom));
        }
    }
}
