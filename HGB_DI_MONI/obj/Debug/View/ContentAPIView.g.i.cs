﻿#pragma checksum "..\..\..\View\ContentAPIView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "85F448B15089A8ED41027D6E56169CFDEECBE709"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HGB_DI_MONI.View;
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


namespace HGB_DI_MONI.View {
    
    
    /// <summary>
    /// ContentAPIView
    /// </summary>
    public partial class ContentAPIView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statusBar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetHotel_btn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Extract_btn;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ApiUrl_TB;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid hbHotelRoom_Grid;
        
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
            System.Uri resourceLocater = new System.Uri("/HGB_DI_MONI;component/view/contentapiview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ContentAPIView.xaml"
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
            
            #line 8 "..\..\..\View\ContentAPIView.xaml"
            ((HGB_DI_MONI.View.ContentAPIView)(target)).Initialized += new System.EventHandler(this.UserControl_Initialized);
            
            #line default
            #line hidden
            return;
            case 2:
            this.statusBar = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.GetHotel_btn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\View\ContentAPIView.xaml"
            this.GetHotel_btn.Click += new System.Windows.RoutedEventHandler(this.GetHotel_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Extract_btn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\View\ContentAPIView.xaml"
            this.Extract_btn.Click += new System.Windows.RoutedEventHandler(this.Extract_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ApiUrl_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.hbHotelRoom_Grid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

