using System.Runtime.Serialization;

namespace MCTS_Tk_Chap1_Les1.DataContracts
{
    [DataContract(Namespace = "http://schemas.fabricam.com/2008/04/tasks/")]
    public class TaskAcknowlegement : IExtensibleDataObject
    {
        [DataMember(IsRequired = false, Order = 0)]
        public int TaskNumber { get; set; }

        [DataMember(IsRequired = false, Order = 1)]
        public TaskStates TaskState { get; set; }

        [DataMember(IsRequired = false, Order = 2)]
        public string Comment { get; set; }

        public ExtensionDataObject ExtensionData { get; set; }
    }
}