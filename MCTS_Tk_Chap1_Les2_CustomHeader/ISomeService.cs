using System.ServiceModel;

namespace MCTS_Tk_Chap1_Les2_CustomHeader
{
    [ServiceContract]
    public interface ISomeService
    {
        [OperationContract]
        [FaultContract(typeof(string))]
        ContractInfoResponseMessage GetProviderContractInformation(ContractInfoRequestMessage reqMsg);
    }
}
