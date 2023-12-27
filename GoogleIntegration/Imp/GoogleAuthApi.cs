using GoogleIntegration.Abstraction;
using GoogleIntegration.Domain.Auth;
using GoogleIntegration.Domain.Config;
using Microsoft.Extensions.Options;
using RestSharp;
using RestShrapWrapper;
using System.Web;

namespace GoogleIntegration.Imp
{
	public class GoogleAuthApi : IGoogleAuthApi
	{
		const string GOOGLE_OPEN_Connect_AUTH_URL = "https://accounts.google.com/o/oauth2/v2/auth";
		const string GOOGLE_AUTH_URL = "https://oauth2.googleapis.com/token";

		GoogleApi _googleApi;

		public GoogleAuthApi(IOptions<GoogleApi> googleApi)
		{
			_googleApi = googleApi.Value;
		}

		public string OpenConnectUrl()
		{
			var openConnectUrl = new OpenConnectRequestModel
			{
				Client_Id = _googleApi.AuthApi.ClientId,
				Redirect_Uri = _googleApi.AuthApi.RedirectUri,
				Response_Type = _googleApi.AuthApi.ResponseType,
				Include_Granted_Scopes = _googleApi.AuthApi.IncludeGrantedScopes,
				Scope = _googleApi.AuthApi.Scope,
				State = _googleApi.AuthApi.State,
				Prompt = _googleApi.AuthApi.Prompt,
				Access_Type = _googleApi.AuthApi.AccessType,
				Enable_Granular_Consent = _googleApi.AuthApi.EnableGranularConsent,
				Login_Hint = _googleApi.AuthApi.LoginHint
			};
			return OpenConnectUrl(openConnectUrl);
		}

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

		public AuthResponseModel GenerateAuthToken(string authCode)
		{
			var authRequestModel = new AuthRequestModel
			{
				client_id = _googleApi.AuthApi.ClientId,
				client_secret = _googleApi.AuthApi.ClientSecret,
				code = authCode,
				redirect_uri = _googleApi.AuthApi.RedirectUri,
				grant_type = _googleApi.AuthApi.GrantType//authorization_code
			};
			return GenerateAuthToken(authRequestModel);
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
