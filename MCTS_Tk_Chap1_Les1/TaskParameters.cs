using System.Runtime.Serialization;

namespace MCTS_Tk_Chap1_Les1.Models
{
    [DataContract(Namespace = "http://schemas.fabricam.com/2008/04/tasks/")]
    public class TaskParameters
    {
        [DataMember]
        public string TaskDescription { get; set; }

        [DataMember(IsRequired = true)]
        public string AssignedTo { get; set; }

        //[DataMember(IsRequired = true)]
        //public int SomeId { get; set; }
    }
}