﻿#pragma checksum "..\..\..\Views\CreateANewSetWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1D53BC1ADE598DE070CCEEF91763CC32DA494041"
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
    /// CreateANewSetWindow
    /// </summary>
    public partial class CreateANewSetWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbOutsoleCode;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSupplier;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbComponent;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQuota;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpStartDate;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpRequestDate;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOptionRequestDate;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popOptionRequestDate;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClosePopUp;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOptioRequestDatePlus21;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOptioRequestDatePlus25;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOptioRequestDatePlus30;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddMold;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgCurrentMold;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn colRequestedDate;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\Views\CreateANewSetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCalculate;
        
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
            System.Uri resourceLocater = new System.Uri("/MoldCalculator;component/views/createanewsetwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\CreateANewSetWindow.xaml"
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
            
            #line 8 "..\..\..\Views\CreateANewSetWindow.xaml"
            ((MoldCalculator.Views.CreateANewSetWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbOutsoleCode = ((System.Windows.Controls.ComboBox)(target));
            
            #line 37 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.cbOutsoleCode.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbOutsoleCode_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbSupplier = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.cbSupplier.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbSupplier_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbComponent = ((System.Windows.Controls.ComboBox)(target));
            
            #line 39 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.cbComponent.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbComponent_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtQuota = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.dpStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.dpRequestDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.btnOptionRequestDate = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.btnOptionRequestDate.Click += new System.Windows.RoutedEventHandler(this.btnOptionRequestDate_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.popOptionRequestDate = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 10:
            this.btnClosePopUp = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.btnClosePopUp.Click += new System.Windows.RoutedEventHandler(this.btnClosePopUp_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnOptioRequestDatePlus21 = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.btnOptioRequestDatePlus21.Click += new System.Windows.RoutedEventHandler(this.btnOptioRequestDatePlus21_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnOptioRequestDatePlus25 = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.btnOptioRequestDatePlus25.Click += new System.Windows.RoutedEventHandler(this.btnOptioRequestDatePlus25_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.btnOptioRequestDatePlus30 = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.btnOptioRequestDatePlus30.Click += new System.Windows.RoutedEventHandler(this.btnOptioRequestDatePlus30_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnAddMold = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.btnAddMold.Click += new System.Windows.RoutedEventHandler(this.btnAddMold_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.dgCurrentMold = ((System.Windows.Controls.DataGrid)(target));
            
            #line 108 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.dgCurrentMold.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.dgCurrentMold_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 16:
            this.colRequestedDate = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 17:
            this.btnCalculate = ((System.Windows.Controls.Button)(target));
            
            #line 128 "..\..\..\Views\CreateANewSetWindow.xaml"
            this.btnCalculate.Click += new System.Windows.RoutedEventHandler(this.btnCalculate_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

