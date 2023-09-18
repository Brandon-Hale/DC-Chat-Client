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
        private List<User> usersOnlineRooms;
        private List<ChatRoom> privateChatRooms;
        private Timer updateRoomsTimer;
        public ChatRoomSelection(string username)
        {
            InitializeComponent();
            ChannelFactory<ChatBusinessServer.ChatBusinessInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8200/BusinessService";
            foobFactory = new ChannelFactory<ChatBusinessInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            updateRoomsTimer = new Timer(RoomListUpdateCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(7));

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
            PopulateUsersBox(username);
        }

        private async void RoomListUpdateCallback(object state)
        {
            try
            {
                List<ChatRoom> updatedRooms = await Task.Run(() => foob.GetChatRooms());
                List<User> onlineUsers = await Task.Run(() => foob.GetUsers());
                await Task.Run(() => foob.AddPrivateRooms(username));
                updatedRooms = updatedRooms.Where(room => !IsExcludedRoom(room.RoomName.ToString())).ToList();

                Dispatcher.Invoke(() =>
                {
                    userCreatedComboBox.Items.Clear();
                    foreach (ChatRoom room in updatedRooms)
                    {
                        foreach(User user in onlineUsers)
                        {
                            if (!room.RoomName.Contains(user.Username))
                            {
                                userCreatedComboBox.Items.Add(room.RoomName.ToString());
                            }
                        }
                    }
                    usersOnlineComboBox.Items.Clear();
                    foreach(User user in onlineUsers)
                    {
                        if (!user.Username.Equals(username))
                        {
                            usersOnlineComboBox.Items.Add(user.Username.ToString());
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
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
                Task.Run(() => foob.AddChatRoom(newChatRoomName, username));

                NavigationService.Navigate(new ChatRoomMessage(newChatRoomName, username));

            }
        }

        private Boolean IsExcludedRoom(string roomName)
        {
            string[] exludedRoomNames = { "ChatRoom1", "ChatRoom2", "ChatRoom3", "ChatRoom4", "ChatRoom5", "ChatRoom6" };

            return exludedRoomNames.Contains(roomName);
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
            try
            {
                string chatRoom = userCreatedComboBox.SelectedItem as string;
                if (!string.IsNullOrEmpty(chatRoom))
                {
                    NavigationService.Navigate(new ChatRoomMessage(chatRoom, username));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }    
        }

        private void joinUserOnlineRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string otherusername = usersOnlineComboBox.SelectedItem as string;
                List<ChatRoom> rooms = foob.GetChatRooms();
                string chatRoom1 = username + otherusername;
                string chatRoom2 = otherusername + username;

                if (!string.IsNullOrEmpty(otherusername))
                {
                    foreach (ChatRoom room in rooms)
                    {
                        if (room.RoomName.Equals(chatRoom1))
                        {
                            NavigationService.Navigate(new ChatRoomMessage(chatRoom1, username));
                        }
                        else if (room.RoomName.Equals(chatRoom2))
                        {
                            NavigationService.Navigate(new ChatRoomMessage(chatRoom2, username));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void PopulateUsersBox(string username)
        {
            usersOnlineRooms = foob.GetUsers();
            foreach (User user in usersOnlineRooms)
            {
                if (!user.Username.Equals(username))
                {
                    usersOnlineComboBox.Items.Add(user);
                }
            }
        }

        private void PopulateComboBox()
        {
            userCreatedRooms = foob.GetUserCreatedRooms(username);
            foreach (String room in userCreatedRooms)
            {
                userCreatedComboBox.Items.Add(room);
            }
        }
    }
}
