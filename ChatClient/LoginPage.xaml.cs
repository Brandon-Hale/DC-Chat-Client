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

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private ChatBusinessInterface foob;
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
            foob.GetUsers();

            if (username.Equals(foob.GetUsers()))
            {
                userNameStatus.Text = "Invalid Username: Already Taken";
            }
            else
            {
                NavigationService.Navigate(new ChatRoomSelection());
            }

           
        }
    }
}
