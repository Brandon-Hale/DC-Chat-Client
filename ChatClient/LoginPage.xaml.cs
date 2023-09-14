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
using ServiceInterface;
using ChatClient1;

namespace ChatClient
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public delegate void ProcessLongTask();
    public partial class LoginPage : Page
    {
        private ProcessServiceInterface processFoob;
        private ProcessServiceCallback processFoobCallback;
        private ProcessLongTask longTask;
        IAsyncResult asyncResult;
        private ChatBusinessInterface foob;

        public LoginPage()
        {
            InitializeComponent();

            ChannelFactory<ChatBusinessServer.ChatBusinessInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            string URL = "net.tcp://localhost:8200/BusinessService";
            foobFactory = new ChannelFactory<ChatBusinessInterface>(tcp, URL);
            foob = foobFactory.CreateChannel();

            DuplexChannelFactory<ProcessServiceInterface> processFoobFactory;
            NetTcpBinding processTcp = new NetTcpBinding();
            string processURL = "net.tcp://localhost:8300/ProcessService";
            processFoobCallback = new ProcessServiceCallbackImple(this);
            processFoobFactory = new DuplexChannelFactory<ProcessServiceInterface>(processFoobCallback, processTcp, processURL);
            processFoob = processFoobFactory.CreateChannel();

        }

        public void Progress(int percentageCompleted)
        {
           loginProgress.Dispatcher.Invoke(new Action(() => { loginProgress.Value = percentageCompleted; }));
            if (percentageCompleted == 100)
            {
                asyncResult.AsyncWaitHandle.Close();
            }
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = userName.Text.ToString();
            longTask = processFoob.ProcessLongTask;
            asyncResult = longTask.BeginInvoke(null, null);

            Boolean userSuccess = await Task.Run(() => foob.AddUser(username));

            if (userSuccess)
            {
                userNameStatus.Text = "Login Success: Welcome!";
                NavigationService.Navigate(new ChatRoomSelection(username));
            }
            else
            {
                userNameStatus.Text = "Invalid Name: Taken Already";
            }
        }
    }
}
