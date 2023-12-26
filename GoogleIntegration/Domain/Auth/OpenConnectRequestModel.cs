using System.ComponentModel.DataAnnotations;


namespace GoogleIntegration.Domain.Auth
{
	public class OpenConnectRequestModel
	{
		[Required]
		public string client_id { get; set; }
		[Required]
		public string redirect_uri { get; set; }
		[Required]
		public string response_type { get; set; }
		[Required]
		public string scope { get; set; }
		[Required]
		public string access_type { get; set; }
		[Required]
		public string state { get; set; }
		public string include_granted_scopes { get; set; }
		public string enable_granular_consent { get; set; }
		public string login_hint { get; set; }
		public string prompt { get; set; }
	}
}
