﻿#pragma checksum "..\..\..\..\Views\UCReceive.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48CD11DC402B2C2F57F434A040810E94CCB59150"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using EVO_PV.Utilities;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
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


namespace EVO_PV.Views {
    
    
    /// <summary>
    /// UCReceive
    /// </summary>
    public partial class UCReceive : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 64 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOpenEvidence;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Codigo;
        
        #line default
        #line hidden
        
        
        #line 142 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cBoxDeliveries;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem DeliveryNumber;
        
        #line default
        #line hidden
        
        
        #line 189 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander ArticlesExpanded;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgDeliveryArticles;
        
        #line default
        #line hidden
        
        
        #line 413 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackContainers;
        
        #line default
        #line hidden
        
        
        #line 417 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ContainersItemControl;
        
        #line default
        #line hidden
        
        
        #line 510 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgWeighingsAtEight;
        
        #line default
        #line hidden
        
        
        #line 650 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddWeighingAtEight;
        
        #line default
        #line hidden
        
        
        #line 701 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgWeighingsAtFive;
        
        #line default
        #line hidden
        
        
        #line 841 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddWeighingAtFive;
        
        #line default
        #line hidden
        
        
        #line 886 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgWeighingsBarCode;
        
        #line default
        #line hidden
        
        
        #line 1020 "..\..\..\..\Views\UCReceive.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EVO_PV;component/views/ucreceive.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\UCReceive.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnOpenEvidence = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.Codigo = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 3:
            this.cBoxDeliveries = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.DeliveryNumber = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 5:
            this.ArticlesExpanded = ((System.Windows.Controls.Expander)(target));
            return;
            case 6:
            this.dgDeliveryArticles = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.stackContainers = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.ContainersItemControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 11:
            this.dgWeighingsAtEight = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 12:
            this.btnAddWeighingAtEight = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.dgWeighingsAtFive = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 14:
            this.btnAddWeighingAtFive = ((System.Windows.Controls.Button)(target));
            return;
            case 15:
            this.dgWeighingsBarCode = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 16:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 372 "..\..\..\..\Views\UCReceive.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_KeyDown);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 443 "..\..\..\..\Views\UCReceive.xaml"
            ((System.Windows.Controls.TextBox)(target)).GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 444 "..\..\..\..\Views\UCReceive.xaml"
            ((System.Windows.Controls.TextBox)(target)).LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
