﻿#pragma checksum "..\..\NewSchedule.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BAABA527D094997BFCBB53F0F0725A8C84A32A94"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FTPClient;
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


namespace FTPClient {
    
    
    /// <summary>
    /// NewSchedule
    /// </summary>
    public partial class NewSchedule : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\NewSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox dateStart;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NewSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox weekly;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\NewSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox startTime;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\NewSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox endTime;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\NewSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox device;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\NewSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox zone;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\NewSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox status;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\NewSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addScheduleBtn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\NewSchedule.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox voiceFile;
        
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
            System.Uri resourceLocater = new System.Uri("/FTPClient;component/newschedule.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewSchedule.xaml"
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
            this.dateStart = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.weekly = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.startTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.endTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.device = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.zone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.status = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.addScheduleBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\NewSchedule.xaml"
            this.addScheduleBtn.Click += new System.Windows.RoutedEventHandler(this.addScheduleClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.voiceFile = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

