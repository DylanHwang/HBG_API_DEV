﻿#pragma checksum "..\..\..\View\AvailabilityAPIView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10679760E35CE340464CE6779862B710DA1626FA"
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
    /// AvailabilityView
    /// </summary>
    public partial class AvailabilityView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statusBar;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker CheckIn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker CheckOut;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoomNum_CB;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox AdultNum_CB;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RateCheck_YN;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Start_btn;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HotelCodes_TB;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ApiUrl_TB;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid hbHotelRoom_Grid;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RQ_Json_TB;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\View\AvailabilityAPIView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RS_Json_TB;
        
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
            System.Uri resourceLocater = new System.Uri("/HGB_DI_MONI;component/view/availabilityapiview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\AvailabilityAPIView.xaml"
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
            
            #line 8 "..\..\..\View\AvailabilityAPIView.xaml"
            ((HGB_DI_MONI.View.AvailabilityView)(target)).Initialized += new System.EventHandler(this.UserControl_Initialized);
            
            #line default
            #line hidden
            return;
            case 2:
            this.statusBar = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.CheckIn = ((System.Windows.Controls.DatePicker)(target));
            
            #line 36 "..\..\..\View\AvailabilityAPIView.xaml"
            this.CheckIn.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.CheckIn_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CheckOut = ((System.Windows.Controls.DatePicker)(target));
            
            #line 37 "..\..\..\View\AvailabilityAPIView.xaml"
            this.CheckOut.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.CheckOut_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RoomNum_CB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.AdultNum_CB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.RateCheck_YN = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.Start_btn = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\View\AvailabilityAPIView.xaml"
            this.Start_btn.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.HotelCodes_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.ApiUrl_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.hbHotelRoom_Grid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.RQ_Json_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.RS_Json_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

