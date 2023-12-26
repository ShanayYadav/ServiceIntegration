using GoogleIntegration.Abstraction;
using GoogleIntegration.Domain.Auth;
using System.Web;

namespace GoogleIntegration.Imp
{
	public class GoogleAuthApi : IGoogleAuthApi
	{
		const string GOOGLE_OPEN_Connect_AUTH_URL = "https://accounts.google.com/o/oauth2/v2/auth";
		const string GOOGLE_AUTH_URL = "https://oauth2.googleapis.com/token";
		public string OpenConnectUrl(OpenConnectRequestModel googleAuthRequest)
		{
			var url = $"{GOOGLE_OPEN_Connect_AUTH_URL}?{GetParam(googleAuthRequest)}";
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
			return new AuthResponseModel { };
		}

		private string GetParam<TSource>(TSource source)
		{
			var param = string.Empty;
			if (source == null)
			{
				return param;
			}
			var properties = source.GetType().GetProperties()?.ToList();
			properties?.ForEach(x =>
			{
				param += $"{x.Name}={x.GetValue(source)}&";
			});
			return param?.Substring(0, param.Length - 1);
		}

	}

}
