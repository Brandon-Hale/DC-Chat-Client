using ChatBusinessServer;
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
using DLL;
using System.Threading;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private ChatBusinessInterface foob;
        private List<User> users = new List<User>();
        public LoginPage()
        {
            InitializeComponent();

            ChannelFactory<ChatBusinessServer.ChatBusinessInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8200/BusinessService";
            foobFactory = new ChannelFactory<ChatBusinessInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = userName.Text.ToString();
            users = foob.GetUsers();
            Boolean loginSuccess = true;

                foreach (User user in users)
                {

                    if (username.Equals(user.Username.ToString()))
                    {
                        userNameStatus.Text = "Invalid Username: Already Taken";
                        loginSuccess = false;
                        break;
                    }
                }

            if (loginSuccess)
            {
                foob.AddUser(username);
                userNameStatus.Text = "Login Success: Welcome!";
                NavigationService.Navigate(new ChatRoomSelection());
            }
        }
    }
}
