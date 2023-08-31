using ChatBusinessServer;
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

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for ChatRoomMessage.xaml
    /// </summary>
    public partial class ChatRoomMessage : Page
    {
        private ChatBusinessInterface foob;
        private ChatRoom room = new ChatRoom();
        public ChatRoomMessage()
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

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string sentMessage = MessageBox.Text.ToString();
            foob.AddMessage(sentMessage);
            ChatBox.Text = foob.PrintMessages();
            ChatBox.Visibility = Visibility.Visible;
        }
    }
}
