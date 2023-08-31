﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for ChatRoomSelection.xaml
    /// </summary>
    public partial class ChatRoomSelection : Page
    {
        public ChatRoomSelection()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void joinChatRoom1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChatRoomMessage());
        }
    }
}
