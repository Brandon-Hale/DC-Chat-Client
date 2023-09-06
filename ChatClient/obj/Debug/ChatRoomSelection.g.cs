﻿#pragma checksum "..\..\ChatRoomSelection.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CAC84D77170ADAC5F6723A2C00E4F887A836C0E539226AF1FA03587256B658C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ChatClient;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ChatClient {
    
    
    /// <summary>
    /// ChatRoomSelection
    /// </summary>
    public partial class ChatRoomSelection : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\ChatRoomSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock chatRoom1;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ChatRoomSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button joinChatRoom1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ChatRoomSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock chatRoom2;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ChatRoomSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button joinChatRoom2;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ChatRoomSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock chatRoom3;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ChatRoomSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button joinChatRoom3;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ChatRoomSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ChatRoomSelection.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addChatRoomButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ChatClient1;component/chatroomselection.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChatRoomSelection.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.chatRoom1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.joinChatRoom1 = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\ChatRoomSelection.xaml"
            this.joinChatRoom1.Click += new System.Windows.RoutedEventHandler(this.joinChatRoom1_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.chatRoom2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.joinChatRoom2 = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\ChatRoomSelection.xaml"
            this.joinChatRoom2.Click += new System.Windows.RoutedEventHandler(this.joinChatRoom2_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.chatRoom3 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.joinChatRoom3 = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\ChatRoomSelection.xaml"
            this.joinChatRoom3.Click += new System.Windows.RoutedEventHandler(this.joinChatRoom3_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\ChatRoomSelection.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.addChatRoomButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ChatRoomSelection.xaml"
            this.addChatRoomButton.Click += new System.Windows.RoutedEventHandler(this.addChatRoomButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

