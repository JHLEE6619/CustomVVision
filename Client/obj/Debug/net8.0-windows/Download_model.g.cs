﻿#pragma checksum "..\..\..\Download_model.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D5EFE49C6C9DD4FD4DE8A47139D8189497ED5205"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using Client;
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


namespace Client {
    
    
    /// <summary>
    /// Download_model
    /// </summary>
    public partial class Download_model : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Download_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LV_modelList;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Download_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_dir_sel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Download_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TBlock_dir;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Download_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_download;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Client;component/download_model.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Download_model.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LV_modelList = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.btn_dir_sel = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Download_model.xaml"
            this.btn_dir_sel.Click += new System.Windows.RoutedEventHandler(this.btn_dir_sel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TBlock_dir = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btn_download = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Download_model.xaml"
            this.btn_download.Click += new System.Windows.RoutedEventHandler(this.btn_download_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

