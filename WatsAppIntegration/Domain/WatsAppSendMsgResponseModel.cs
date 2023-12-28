using WatsAppIntegration.Domain.Shared;

namespace WatsAppIntegration.Domain
{
	public class WatsAppSendMsgResponseModel
	{
		public string Messaging_Product { get; set; }
		public Contact[] Contacts { get; set; }
		public Message[] Messages { get; set; }
	}
}
