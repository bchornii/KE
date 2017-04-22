using System.ServiceModel;

namespace MCTS_Tk_Chap1_Les2_CustomHeader
{
    [MessageContract(IsWrapped = true, WrapperName = "Request")]
    public class ContractInfoRequestMessage
    {
        [MessageHeader]
        public string LicenceKey { get; set; }

        [MessageBodyMember]
        public string CustomPayLoad { get; set; }
    }
}
