﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_Client.WcfServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TaskParameters", Namespace="http://schemas.fabricam.com/2008/04/tasks/")]
    [System.SerializableAttribute()]
    public partial class TaskParameters : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string AssignedToField;
        
        private int SomeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TaskDescriptionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string AssignedTo {
            get {
                return this.AssignedToField;
            }
            set {
                if ((object.ReferenceEquals(this.AssignedToField, value) != true)) {
                    this.AssignedToField = value;
                    this.RaisePropertyChanged("AssignedTo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int SomeId {
            get {
                return this.SomeIdField;
            }
            set {
                if ((this.SomeIdField.Equals(value) != true)) {
                    this.SomeIdField = value;
                    this.RaisePropertyChanged("SomeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TaskDescription {
            get {
                return this.TaskDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.TaskDescriptionField, value) != true)) {
                    this.TaskDescriptionField = value;
                    this.RaisePropertyChanged("TaskDescription");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TaskInfo", Namespace="http://schemas.datacontract.org/2004/07/MCTS_Tk_Chap1_Les1.Models")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(WCF_Client.WcfServices.TaskInfoV2))]
    public partial class TaskInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AssignedToField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsCompeledField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TaskNumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AssignedTo {
            get {
                return this.AssignedToField;
            }
            set {
                if ((object.ReferenceEquals(this.AssignedToField, value) != true)) {
                    this.AssignedToField = value;
                    this.RaisePropertyChanged("AssignedTo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsCompeled {
            get {
                return this.IsCompeledField;
            }
            set {
                if ((this.IsCompeledField.Equals(value) != true)) {
                    this.IsCompeledField = value;
                    this.RaisePropertyChanged("IsCompeled");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TaskNumber {
            get {
                return this.TaskNumberField;
            }
            set {
                if ((this.TaskNumberField.Equals(value) != true)) {
                    this.TaskNumberField = value;
                    this.RaisePropertyChanged("TaskNumber");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TaskInfoV2", Namespace="http://schemas.datacontract.org/2004/07/MCTS_Tk_Chap1_Les1.Models")]
    [System.SerializableAttribute()]
    public partial class TaskInfoV2 : WCF_Client.WcfServices.TaskInfo {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FaultInfo", Namespace="http://schemas.fabricam.com/2008/04/tasks/")]
    [System.SerializableAttribute()]
    public partial class FaultInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReasonField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Reason {
            get {
                return this.ReasonField;
            }
            set {
                if ((object.ReferenceEquals(this.ReasonField, value) != true)) {
                    this.ReasonField = value;
                    this.RaisePropertyChanged("Reason");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.fabricam.com/2008/04/tasks/", ConfigurationName="WcfServices.TaskManagerService")]
    public interface TaskManagerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/AddTask", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/AddTaskResponse")]
        WCF_Client.WcfServices.TaskInfo AddTask(WCF_Client.WcfServices.TaskParameters taskParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/AddTask", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/AddTaskResponse")]
        System.Threading.Tasks.Task<WCF_Client.WcfServices.TaskInfo> AddTaskAsync(WCF_Client.WcfServices.TaskParameters taskParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/GetTasksByAssignedNa" +
            "me", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/GetTasksByAssignedNa" +
            "meResponse")]
        int[] GetTasksByAssignedName(string assignedTo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/GetTasksByAssignedNa" +
            "me", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/GetTasksByAssignedNa" +
            "meResponse")]
        System.Threading.Tasks.Task<int[]> GetTasksByAssignedNameAsync(string assignedTo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/GetTaskDescription", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/GetTaskDescriptionRe" +
            "sponse")]
        string GetTaskDescription(int taskNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/GetTaskDescription", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/GetTaskDescriptionRe" +
            "sponse")]
        System.Threading.Tasks.Task<string> GetTaskDescriptionAsync(int taskNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/IsTaskCompeleted", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/IsTaskCompeletedResp" +
            "onse")]
        bool IsTaskCompeleted(int taskNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/IsTaskCompeleted", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/IsTaskCompeletedResp" +
            "onse")]
        System.Threading.Tasks.Task<bool> IsTaskCompeletedAsync(int taskNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/MarkTaskCompleted", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/MarkTaskCompletedRes" +
            "ponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WCF_Client.WcfServices.FaultInfo), Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/MarkTaskCompletedFau" +
            "ltInfoFault", Name="FaultInfo")]
        void MarkTaskCompleted(int taskNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/MarkTaskCompleted", ReplyAction="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/MarkTaskCompletedRes" +
            "ponse")]
        System.Threading.Tasks.Task MarkTaskCompletedAsync(int taskNumber);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/DeleteTask")]
        void DeleteTask(int taskNumber);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://schemas.fabricam.com/2008/04/tasks/TaskManagerService/DeleteTask")]
        System.Threading.Tasks.Task DeleteTaskAsync(int taskNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TaskManagerServiceChannel : WCF_Client.WcfServices.TaskManagerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskManagerServiceClient : System.ServiceModel.ClientBase<WCF_Client.WcfServices.TaskManagerService>, WCF_Client.WcfServices.TaskManagerService {
        
        public TaskManagerServiceClient() {
        }
        
        public TaskManagerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TaskManagerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskManagerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskManagerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WCF_Client.WcfServices.TaskInfo AddTask(WCF_Client.WcfServices.TaskParameters taskParameters) {
            return base.Channel.AddTask(taskParameters);
        }
        
        public System.Threading.Tasks.Task<WCF_Client.WcfServices.TaskInfo> AddTaskAsync(WCF_Client.WcfServices.TaskParameters taskParameters) {
            return base.Channel.AddTaskAsync(taskParameters);
        }
        
        public int[] GetTasksByAssignedName(string assignedTo) {
            return base.Channel.GetTasksByAssignedName(assignedTo);
        }
        
        public System.Threading.Tasks.Task<int[]> GetTasksByAssignedNameAsync(string assignedTo) {
            return base.Channel.GetTasksByAssignedNameAsync(assignedTo);
        }
        
        public string GetTaskDescription(int taskNumber) {
            return base.Channel.GetTaskDescription(taskNumber);
        }
        
        public System.Threading.Tasks.Task<string> GetTaskDescriptionAsync(int taskNumber) {
            return base.Channel.GetTaskDescriptionAsync(taskNumber);
        }
        
        public bool IsTaskCompeleted(int taskNumber) {
            return base.Channel.IsTaskCompeleted(taskNumber);
        }
        
        public System.Threading.Tasks.Task<bool> IsTaskCompeletedAsync(int taskNumber) {
            return base.Channel.IsTaskCompeletedAsync(taskNumber);
        }
        
        public void MarkTaskCompleted(int taskNumber) {
            base.Channel.MarkTaskCompleted(taskNumber);
        }
        
        public System.Threading.Tasks.Task MarkTaskCompletedAsync(int taskNumber) {
            return base.Channel.MarkTaskCompletedAsync(taskNumber);
        }
        
        public void DeleteTask(int taskNumber) {
            base.Channel.DeleteTask(taskNumber);
        }
        
        public System.Threading.Tasks.Task DeleteTaskAsync(int taskNumber) {
            return base.Channel.DeleteTaskAsync(taskNumber);
        }
    }
}
