﻿#pragma checksum "..\..\..\View\ContentAPIView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D6C5CBC3C7992AEDCC0609CBCED6CA268229A555"
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
        
        
        #line 23 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Option_Grid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox extract_Opt_Combo;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem HT;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem IMG;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem HDTL;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\ContentAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ApiUrl_TB;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\ContentAPIView.xaml"
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
            this.Option_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.extract_Opt_Combo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 28 "..\..\..\View\ContentAPIView.xaml"
            this.extract_Opt_Combo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.extract_Opt_Combo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.HT = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.IMG = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 9:
            this.HDTL = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 10:
            this.ApiUrl_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.hbHotelRoom_Grid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

