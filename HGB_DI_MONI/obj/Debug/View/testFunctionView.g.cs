﻿#pragma checksum "..\..\..\View\testFunctionView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "207D0E289D6995FF9C407B8B11BE186EB0F38472"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
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
    /// testFunctionView
    /// </summary>
    public partial class testFunctionView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\View\testFunctionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statusBar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\testFunctionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetRoomDescrip_btn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\testFunctionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetImage_btn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\View\testFunctionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Extract_btn;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\testFunctionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Option_Grid;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\testFunctionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetCountry_btn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\testFunctionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetdDestination_btn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\testFunctionView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ApiUrl_TB;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\View\testFunctionView.xaml"
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
            System.Uri resourceLocater = new System.Uri("/HGB_DI_MONI;component/view/testfunctionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\testFunctionView.xaml"
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
            
            #line 8 "..\..\..\View\testFunctionView.xaml"
            ((HGB_DI_MONI.View.testFunctionView)(target)).Initialized += new System.EventHandler(this.UserControl_Initialized);
            
            #line default
            #line hidden
            return;
            case 2:
            this.statusBar = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.GetRoomDescrip_btn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\View\testFunctionView.xaml"
            this.GetRoomDescrip_btn.Click += new System.Windows.RoutedEventHandler(this.GetRoomDescrip_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.GetImage_btn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\View\testFunctionView.xaml"
            this.GetImage_btn.Click += new System.Windows.RoutedEventHandler(this.GetImage_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Extract_btn = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.Option_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.GetCountry_btn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\View\testFunctionView.xaml"
            this.GetCountry_btn.Click += new System.Windows.RoutedEventHandler(this.GetCountry_btn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GetdDestination_btn = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\View\testFunctionView.xaml"
            this.GetdDestination_btn.Click += new System.Windows.RoutedEventHandler(this.GetdDestination_btn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ApiUrl_TB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.hbHotelRoom_Grid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

