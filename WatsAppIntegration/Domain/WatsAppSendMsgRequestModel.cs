using WatsAppIntegration.Domain.Shared;

namespace WatsAppIntegration.Domain
{
	public class WatsAppSendMsgRequestModel
	{
		public string Messaging_Product { get; set; }
		public string To { get; set; }
		public string Type { get; set; }
		public Template Template { get; set; }
	}
}








