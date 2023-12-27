using ZohoIntegration.Domain.Enum;

namespace ZohoIntegration.Domain
{
	public class ZohoOpenConnectRequestModel
	{
		public string GrantType { get; set; }
		public string Client_Id { get; set; }
		public string Client_Secret { get; set; }
		public string Redirect_Uri { get; set; }
		public string Scope { get; set; }
		public ZohoClientTypeEnum ClientType { get; set; }
		public string Access_Type { get; set; }
		public string Prompt { get; set; }
		public string Response_Type { get; set; }
	}
}