using System;
using System.Runtime.Serialization;
using System.ServiceModel.Syndication;

namespace MCTS_Tk_Chap1_Les1.DataContracts
{
    [DataContract(Namespace = "http://schemas.fabricam.com/2008/04/tasks/")]
    public class Task : IExtensibleDataObject
    {
        [DataMember(IsRequired = false, Order = 0)]
        public int TaskNumber { get; set; }

        [DataMember(IsRequired = true, Order = 1)]
        public string Description { get; set; }

        [DataMember(IsRequired = false, Order = 2)]
        public TaskStates TaskState { get; set; }

        [DataMember(IsRequired = false, Order = 3)]
        public string AssignedTo { get; set; }

        [DataMember(IsRequired = false, Order = 4)]
        public string CreatedBy { get; set; }

        [DataMember(IsRequired = false, Order = 5)]
        public DateTime DateCreated { get; set; }

        [DataMember(IsRequired = false, Order = 6)]
        public DateTime DateLastModified { get; set; }

        [DataMember(IsRequired = false, Order = 7)]
        public DateTime DueDate { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}
