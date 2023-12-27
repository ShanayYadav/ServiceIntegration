using System.ComponentModel.DataAnnotations;


namespace GoogleIntegration.Domain.Auth
{
	public class OpenConnectRequestModel
	{
		[Required]
		public string Client_Id { get; set; }
		[Required]
		public string Redirect_Uri { get; set; }
		[Required]
		public string Response_Type { get; set; }
		[Required]
		public string Scope { get; set; }
		[Required]
		public string Access_Type { get; set; }
		[Required]
		public string State { get; set; }
		public bool Include_Granted_Scopes { get; set; }
		public string Enable_Granular_Consent { get; set; }
		public string Login_Hint { get; set; }
		public string Prompt { get; set; }
	}
}
