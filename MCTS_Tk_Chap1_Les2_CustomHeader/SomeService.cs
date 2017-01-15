using System.ServiceModel;

namespace MCTS_Tk_Chap1_Les2_CustomHeader
{
   public class SomeService : ISomeService
   {
       public ContractInfoResponseMessage GetProviderContractInformation(ContractInfoRequestMessage reqMsg)
       {
            if (reqMsg.LicenceKey != "abc-1234")
            {
                throw new FaultException<string>($"Invalid key: {reqMsg.LicenceKey}");
            }
            return new ContractInfoResponseMessage
            {
                ProviderContractInfo = new ContractInfo
                {
                    EmailAddress = "hello@gmail.com",
                    PhoneNumber = "0987734939"
                }
            };
        }
    }
}
