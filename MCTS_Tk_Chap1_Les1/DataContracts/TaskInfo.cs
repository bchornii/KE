using System.Runtime.Serialization;

namespace MCTS_Tk_Chap1_Les1.Models
{
    //[DataContract(Namespace = "http://schemas.fabricam.com/2008/04/tasks/")]
    [DataContract]
    [KnownType(typeof(TaskInfoV2))]
    public class TaskInfo
    {
        [DataMember]
        public int TaskNumber { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string AssignedTo { get; set; }
        [DataMember]
        public bool IsCompeled { get; set; }

        public override string ToString() =>
            $"Task: {TaskNumber} is assigned to: {AssignedTo}; Description: {Description};" +
            $"Completed: {IsCompeled}";
    }

    [DataContract]
    public class TaskInfoV2 : TaskInfo
    {
    }
}