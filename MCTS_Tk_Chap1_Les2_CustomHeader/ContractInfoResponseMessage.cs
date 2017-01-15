using System.ServiceModel;

namespace MCTS_Tk_Chap1_Les2_CustomHeader
{
    [MessageContract(IsWrapped = true, WrapperName = "Response")]
    public class ContractInfoResponseMessage
    {
        [MessageBodyMember]
        public ContractInfo ProviderContractInfo { get; set; }
    }
}
