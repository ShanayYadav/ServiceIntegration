using GoogleIntegration.Abstraction;
using GoogleIntegration.Domain.Auth;
using RestSharp;
using RestShrapWrapper;
using System.Web;

namespace GoogleIntegration.Imp
{
	public class GoogleAuthApi : IGoogleAuthApi
	{
		const string GOOGLE_OPEN_Connect_AUTH_URL = "https://accounts.google.com/o/oauth2/v2/auth";
		const string GOOGLE_AUTH_URL = "https://oauth2.googleapis.com/token";
		public string OpenConnectUrl(OpenConnectRequestModel googleAuthRequest)
		{
			var url = $"{GOOGLE_OPEN_Connect_AUTH_URL}?{RestSharpUrlUtility.GetParam(googleAuthRequest)}";
			return url;
		}

		public string GetAuthCodeFromResponse(string redirectUri)
		{
			if (string.IsNullOrEmpty(redirectUri))
			{
				return string.Empty;
			}
			var uri = new Uri(redirectUri);
			return HttpUtility.ParseQueryString(uri.Query).Get("code");
		}

		public AuthResponseModel GenerateAuthToken(AuthRequestModel authRequestModel)
		{
			var apiUrl = $"{GOOGLE_AUTH_URL}";
			var client = new RestClient();
			var request = new RestRequest(apiUrl, Method.Post);
			request.AddHeader("host", "oauth2.googleapis.com");
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			var response = client.Execute<AuthResponseModel>(request);
			return response.Data;
		}

	}
}
