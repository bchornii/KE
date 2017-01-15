using System.Runtime.Serialization;

namespace MCTS_Tk_Chap1_Les1.DataContracts
{
    [DataContract(Namespace = "http://schemas.fabricam.com/2008/04/tasks/")]
    public enum TaskStates : int
    {
        [EnumMember]
        Active = 0,

        [EnumMember]
        CompleteByDueDate = 1,

        [EnumMember]
        CompletePastDueDate = 2,

        [EnumMember]
        Overdue = 3
    }
}
