using System.Runtime.Serialization;

namespace MCTS_Tk_Chap1_Les1.DataContracts
{
    [DataContract(Namespace = "http://schemas.fabricam.com/2008/04/tasks/")]
    public class FaultInfo
    {
        [DataMember(IsRequired = true)]
        public string Reason { get; set; }
    }
}
