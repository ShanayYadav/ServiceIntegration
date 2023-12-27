using System.ComponentModel.DataAnnotations;

namespace GoogleIntegration.Domain.Config
{
	public class AuthApi
	{
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
		public string RedirectUri { get; set; }
		public string State { get; set; }
		public string Scope { get; set; }
		public string AccessType { get; set; }
		public string ResponseType { get; set; }
		public bool IncludeGrantedScopes { get; set; }
		public string EnableGranularConsent { get; set; }
		public string LoginHint { get; set; }
		public string GrantType { get; set; }
		public string Prompt { get; set; }
	}
}