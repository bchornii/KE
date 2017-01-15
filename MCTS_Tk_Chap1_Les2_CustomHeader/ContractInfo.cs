using System.Runtime.Serialization;

namespace MCTS_Tk_Chap1_Les2_CustomHeader
{
    [DataContract]
    public class ContractInfo
    {
        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}
