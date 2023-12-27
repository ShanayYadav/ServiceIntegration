using ZohoIntegration.Domain.Enum;

namespace ZohoIntegration.Domain.Config
{
	public class ZohoApi
	{
		public string ConsentUri { get; set; }
		public string BaseUrl { get; set; }
		public string GrantType { get; set; }
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
		public string ResponseType { get; set; }
		public string RedirectUrl { get; set; }
		public string Scope { get; set; }
		public string AccessType { get; set; }
		public string Prompt { get; set; }
		public ZohoClientTypeEnum ClientType { get; set; }
	}
}