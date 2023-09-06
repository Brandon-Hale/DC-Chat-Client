using ChatBusinessServer;
using ChatClient;
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

namespace ChatClient1
{
    /// <summary>
    /// Interaction logic for ChatRoomCreationWindow.xaml
    /// </summary>
    public partial class ChatRoomCreationWindow : Window
    {
        public string ChatRoomname { get; private set; }
        private string username;
        private ChatBusinessInterface foob;

        public ChatRoomCreationWindow(string username)
        {
            InitializeComponent();
            ChannelFactory<ChatBusinessServer.ChatBusinessInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8200/BusinessService";
            foobFactory = new ChannelFactory<ChatBusinessInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            this.username = username;
            
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            ChatRoomname = ChatRoomName.Text.ToString();
            this.Close();
        }
    }
}
