using WatsAppIntegration.Domain.Shared;

namespace WatsAppIntegration.Domain
{
	public class WatsAppSendMsgResponseModel
	{
		public string Messaging_Product { get; set; }
		public List<Contact> Contacts { get; set; }
		public List<Message> Messages { get; set; }
	}
}
