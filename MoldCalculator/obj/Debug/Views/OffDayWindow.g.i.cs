﻿#pragma checksum "..\..\..\Views\OffDayWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9224FED2C814A3B297D21CCD42586D843DEEA5E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MoldCalculator.Views;
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


namespace MoldCalculator.Views {
    
    
    /// <summary>
    /// OffDayWindow
    /// </summary>
    public partial class OffDayWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\Views\OffDayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnApplyForAll;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Views\OffDayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtID;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\OffDayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpSelectOffDay;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Views\OffDayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grSupplier;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Views\OffDayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\OffDayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\OffDayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgOffDay;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Views\OffDayWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem miRemove;
        
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
            System.Uri resourceLocater = new System.Uri("/MoldCalculator;component/views/offdaywindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\OffDayWindow.xaml"
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
            
            #line 9 "..\..\..\Views\OffDayWindow.xaml"
            ((MoldCalculator.Views.OffDayWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnApplyForAll = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Views\OffDayWindow.xaml"
            this.btnApplyForAll.Click += new System.Windows.RoutedEventHandler(this.btnApplyForAll_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dpSelectOffDay = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.grSupplier = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\Views\OffDayWindow.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dgOffDay = ((System.Windows.Controls.DataGrid)(target));
            
            #line 80 "..\..\..\Views\OffDayWindow.xaml"
            this.dgOffDay.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.dgOffDay_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.miRemove = ((System.Windows.Controls.MenuItem)(target));
            
            #line 83 "..\..\..\Views\OffDayWindow.xaml"
            this.miRemove.Click += new System.Windows.RoutedEventHandler(this.miRemove_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

