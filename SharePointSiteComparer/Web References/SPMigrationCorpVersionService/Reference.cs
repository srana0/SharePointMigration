﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace SharePointSiteComparer.SPMigrationCorpVersionService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="VersionsSoap", Namespace="http://schemas.microsoft.com/sharepoint/soap/")]
    public partial class Versions : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetVersionsOperationCompleted;
        
        private System.Threading.SendOrPostCallback RestoreVersionOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteVersionOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteAllVersionsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Versions() {
            this.Url = global::SharePointSiteComparer.Properties.Settings.Default.SharePointSiteComparer_SPMigrationCorpVersionService_Versions;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetVersionsCompletedEventHandler GetVersionsCompleted;
        
        /// <remarks/>
        public event RestoreVersionCompletedEventHandler RestoreVersionCompleted;
        
        /// <remarks/>
        public event DeleteVersionCompletedEventHandler DeleteVersionCompleted;
        
        /// <remarks/>
        public event DeleteAllVersionsCompletedEventHandler DeleteAllVersionsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/GetVersions", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetVersions(string fileName) {
            object[] results = this.Invoke("GetVersions", new object[] {
                        fileName});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void GetVersionsAsync(string fileName) {
            this.GetVersionsAsync(fileName, null);
        }
        
        /// <remarks/>
        public void GetVersionsAsync(string fileName, object userState) {
            if ((this.GetVersionsOperationCompleted == null)) {
                this.GetVersionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetVersionsOperationCompleted);
            }
            this.InvokeAsync("GetVersions", new object[] {
                        fileName}, this.GetVersionsOperationCompleted, userState);
        }
        
        private void OnGetVersionsOperationCompleted(object arg) {
            if ((this.GetVersionsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetVersionsCompleted(this, new GetVersionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/RestoreVersion", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode RestoreVersion(string fileName, string fileVersion) {
            object[] results = this.Invoke("RestoreVersion", new object[] {
                        fileName,
                        fileVersion});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void RestoreVersionAsync(string fileName, string fileVersion) {
            this.RestoreVersionAsync(fileName, fileVersion, null);
        }
        
        /// <remarks/>
        public void RestoreVersionAsync(string fileName, string fileVersion, object userState) {
            if ((this.RestoreVersionOperationCompleted == null)) {
                this.RestoreVersionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRestoreVersionOperationCompleted);
            }
            this.InvokeAsync("RestoreVersion", new object[] {
                        fileName,
                        fileVersion}, this.RestoreVersionOperationCompleted, userState);
        }
        
        private void OnRestoreVersionOperationCompleted(object arg) {
            if ((this.RestoreVersionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RestoreVersionCompleted(this, new RestoreVersionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/DeleteVersion", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode DeleteVersion(string fileName, string fileVersion) {
            object[] results = this.Invoke("DeleteVersion", new object[] {
                        fileName,
                        fileVersion});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteVersionAsync(string fileName, string fileVersion) {
            this.DeleteVersionAsync(fileName, fileVersion, null);
        }
        
        /// <remarks/>
        public void DeleteVersionAsync(string fileName, string fileVersion, object userState) {
            if ((this.DeleteVersionOperationCompleted == null)) {
                this.DeleteVersionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteVersionOperationCompleted);
            }
            this.InvokeAsync("DeleteVersion", new object[] {
                        fileName,
                        fileVersion}, this.DeleteVersionOperationCompleted, userState);
        }
        
        private void OnDeleteVersionOperationCompleted(object arg) {
            if ((this.DeleteVersionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteVersionCompleted(this, new DeleteVersionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://schemas.microsoft.com/sharepoint/soap/DeleteAllVersions", RequestNamespace="http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace="http://schemas.microsoft.com/sharepoint/soap/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode DeleteAllVersions(string fileName) {
            object[] results = this.Invoke("DeleteAllVersions", new object[] {
                        fileName});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteAllVersionsAsync(string fileName) {
            this.DeleteAllVersionsAsync(fileName, null);
        }
        
        /// <remarks/>
        public void DeleteAllVersionsAsync(string fileName, object userState) {
            if ((this.DeleteAllVersionsOperationCompleted == null)) {
                this.DeleteAllVersionsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteAllVersionsOperationCompleted);
            }
            this.InvokeAsync("DeleteAllVersions", new object[] {
                        fileName}, this.DeleteAllVersionsOperationCompleted, userState);
        }
        
        private void OnDeleteAllVersionsOperationCompleted(object arg) {
            if ((this.DeleteAllVersionsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteAllVersionsCompleted(this, new DeleteAllVersionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetVersionsCompletedEventHandler(object sender, GetVersionsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetVersionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetVersionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void RestoreVersionCompletedEventHandler(object sender, RestoreVersionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RestoreVersionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RestoreVersionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void DeleteVersionCompletedEventHandler(object sender, DeleteVersionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteVersionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteVersionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void DeleteAllVersionsCompletedEventHandler(object sender, DeleteAllVersionsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteAllVersionsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteAllVersionsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591