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
using System.ComponentModel;
using System.Threading;
using Microsoft.Win32;
using System.Drawing;
using System.IO;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for ChatRoomMessage.xaml
    /// </summary>
    public partial class ChatRoomMessage : Page
    {

        private ChatBusinessInterface foob;
        private string chatRoomName;
        private string username;
        private Timer updateTimer;

        public ChatRoomMessage(string chatRoomName, string username)
        {
            InitializeComponent();

            ChannelFactory<ChatBusinessServer.ChatBusinessInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();

            string URL = "net.tcp://localhost:8200/BusinessService";
            foobFactory = new ChannelFactory<ChatBusinessInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            this.chatRoomName = chatRoomName;
            this.username = username;
            updateTimer = new Timer(UpdateCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private void UpdateCallback(object state) //update GUI texts quickly
        {
            try
            {
                string chatMessages = foob.PrintMessages(chatRoomName);

                Dispatcher.Invoke(() =>
                {
                    ChatBox.Text = chatMessages;
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            //working for all created chatrooms
            string sentMessage = MessageBox.Text.ToString();

            await Task.Run(() => foob.AddMessage(sentMessage, chatRoomName, username));
            string chatMessages = await Task.Run(() => foob.PrintMessages(chatRoomName));

            ChatBox.Text = chatMessages;
            ChatBox.Visibility = Visibility.Visible;
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            foob.RemoveUser(username);
            NavigationService.Navigate(new LoginPage());
            
        }

        private void uploadFile_Click(object sender, RoutedEventArgs e)
        {
            var fileOpen = new OpenFileDialog();
            fileOpen.Filter = "TXT Files(*.txt;)|*.txt;|Image Files(*.jpg;*.jpeg;*.bmp)|*.jpg;*.jpeg;.bmp;";
            string textFile;
            Bitmap imageFile;

            bool? res = fileOpen.ShowDialog();
            if(res.HasValue && res.Value)
            {
                string ext = System.IO.Path.GetExtension(fileOpen.FileName);
                
                //Reading text file as string
                if(ext.Equals(".txt"))
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileOpen.FileName);
                    textFile = sr.ReadToEnd();
                }
                //Reading image file as Bitmap
                else
                {
                    imageFile = new Bitmap(fileOpen.FileName);
                }
            }
        }
    }
}
