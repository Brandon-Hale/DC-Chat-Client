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
using Path = System.IO.Path;

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
                List<Message> chatMessages = foob.GetMessages(chatRoomName);

                Dispatcher.Invoke(() =>
                {
                    displayMessages(chatMessages);
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
            List<Message> chatMessages = await Task.Run(() => foob.GetMessages(chatRoomName));

            displayMessages(chatMessages);
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            foob.RemoveUser(username);
            NavigationService.Navigate(new LoginPage());
            
        }

        private async void uploadFile_Click(object sender, RoutedEventArgs e)
        {
            var fileOpen = new OpenFileDialog();
            fileOpen.Filter = "TXT Files(*.txt;)|*.txt|Image Files(*.jpg;*.jpeg)|*.jpg;*.jpeg;";
            string textFile;

            bool? res = fileOpen.ShowDialog();
            if(res.HasValue && res.Value)
            {
                string ext = Path.GetExtension(fileOpen.FileName);

                if (ext == ".txt")
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fileOpen.FileName);
                    textFile = sr.ReadToEnd();
                    await Task.Run(() => foob.AddTextFile(fileOpen.SafeFileName, chatRoomName, username, textFile));
                } else
                {
                    Bitmap img = new Bitmap(fileOpen.FileName);
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imgbytes = ms.ToArray();
                    await Task.Run(() => foob.AddImageFile(fileOpen.SafeFileName, chatRoomName, username, imgbytes));
                }
            }
        }

        private void displayMessages(List<Message> messages)
        {
            MessageList.Items.Clear();
            MessageList.DisplayMemberPath = "MessageText";

            foreach (Message message in messages) { 
                MessageList.Items.Add(message);
            }
        }

        private void MessageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Message m = (MessageList.SelectedItem as Message);

            if (m != null && m.TextFile != null)
            {
                var fileSave = new SaveFileDialog();
                fileSave.Filter = "TXT Files(*.txt;)|*.txt;";

                bool? res = fileSave.ShowDialog();
                if (res.HasValue && res.Value)
                {
                    using (StreamWriter wr = new StreamWriter(fileSave.FileName))
                    {
                        wr.Write(m.TextFile);
                    }
                }
            }
            else if (m != null && m.ImageFile != null)
            {
                var fileSave = new SaveFileDialog();
                fileSave.Filter = "Image Files(*.jpg;*.jpeg)|*.jpg;*.jpeg;";

                bool? res = fileSave.ShowDialog();
                if (res.HasValue && res.Value)
                {
                    using (var ms = new MemoryStream(m.ImageFile))
                    {
                        Bitmap bmp = new Bitmap(ms);
                        bmp.Save(fileSave.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
            }
        }
    }
}
