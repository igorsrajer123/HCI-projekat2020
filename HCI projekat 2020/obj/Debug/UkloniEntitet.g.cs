﻿#pragma checksum "..\..\UkloniEntitet.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7B8ACBD49D8BB4CFAD27CCB0660E1F06AD03B677"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCI_projekat_2020;
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


namespace HCI_projekat_2020 {
    
    
    /// <summary>
    /// UkloniEntitet
    /// </summary>
    public partial class UkloniEntitet : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\UkloniEntitet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tabControl;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\UkloniEntitet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tab1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\UkloniEntitet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView1;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\UkloniEntitet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tab2;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\UkloniEntitet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView2;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\UkloniEntitet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabItem tab3;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\UkloniEntitet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView3;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\UkloniEntitet.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
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
            System.Uri resourceLocater = new System.Uri("/HCI projekat 2020;component/uklonientitet.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UkloniEntitet.xaml"
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
            
            #line 10 "..\..\UkloniEntitet.xaml"
            ((HCI_projekat_2020.UkloniEntitet)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tabControl = ((System.Windows.Controls.TabControl)(target));
            
            #line 13 "..\..\UkloniEntitet.xaml"
            this.tabControl.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.tabControl_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tab1 = ((System.Windows.Controls.TabItem)(target));
            return;
            case 4:
            this.listView1 = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.tab2 = ((System.Windows.Controls.TabItem)(target));
            return;
            case 6:
            this.listView2 = ((System.Windows.Controls.ListView)(target));
            return;
            case 7:
            this.tab3 = ((System.Windows.Controls.TabItem)(target));
            return;
            case 8:
            this.listView3 = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\UkloniEntitet.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.ukloni_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

