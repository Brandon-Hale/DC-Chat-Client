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
        private List<String> userCreatedRooms;
        public ChatRoomSelection(string username)
        {
            InitializeComponent();
            ChannelFactory<ChatBusinessServer.ChatBusinessInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8200/BusinessService";
            foobFactory = new ChannelFactory<ChatBusinessInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            this.username = username;

            //Adding Default Chatrooms (if required)
            foob.AddChatRoom("ChatRoom1", username);
            foob.AddChatRoom("ChatRoom2", username);
            foob.AddChatRoom("ChatRoom3", username);
            foob.AddChatRoom("ChatRoom4", username);
            foob.AddChatRoom("ChatRoom5", username);
            foob.AddChatRoom("ChatRoom6", username);


            //Populating User Created Rooms Combo Box
            PopulateComboBox();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            foob.RemoveUser(username);
            NavigationService.Navigate(new LoginPage());

        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            PopulateComboBox();
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
                foob.AddChatRoom(newChatRoomName, username);
                PopulateComboBox();

                NavigationService.Navigate(new ChatRoomMessage(newChatRoomName, username));

            }
        }

        private void joinChatRoom1_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom1";
            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));
        }

        private void joinChatRoom2_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom2";
            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));

        }

        private void joinChatRoom3_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom3";
            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));
        }

        private void joinChatRoom4_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom4";
            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));
        }

        private void joinChatRoom5_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom5";
            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));
        }

        private void joinChatRoom6_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = "ChatRoom6";
            NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));

        }

        private void joinUserCreatedRoom_Click(object sender, RoutedEventArgs e)
        {
            string chatRoom = userCreatedComboBox.SelectedItem.ToString();
            if(chatRoom != "" || chatRoom != null)
            {
                NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));
            }
        }

        private void PopulateComboBox()
        {
            userCreatedComboBox.Items.Clear();
            userCreatedRooms = foob.GetUserCreatedRooms(username);
            foreach (String room in userCreatedRooms)
            {
                userCreatedComboBox.Items.Add(room);
            }
        }
    }
}
