using System.ComponentModel.DataAnnotations;

namespace GoogleIntegration.Domain.Auth
{
	public class AuthRequestModel
	{
		[Required]
		public string client_id { get; set; }
		[Required]
		public string client_secret { get; set; }
		[Required]
		public string code { get; set; }
		[Required]
		public string grant_type { get; set; }
		[Required]
		public string redirect_uri { get; set; }
	}
}
