using WatsAppIntegration.Domain;

namespace WatsAppIntegration.Abstraction
{
	public interface IWatsAppMsgApi
	{
		WatsAppSendMsgResponseModel Send(WatsAppSendMsgRequestModel watsSendMsgRequestModel);
	}
}
