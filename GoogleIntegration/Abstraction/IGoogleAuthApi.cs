using GoogleIntegration.Domain.Auth;

namespace GoogleIntegration.Abstraction
{
	public interface IGoogleAuthApi
	{
		string OpenConnectUrl(OpenConnectRequestModel googleAuthRequest);
		string GetAuthCodeFromResponse(string redirectUri);
		AuthResponseModel GenerateAuthToken(AuthRequestModel authRequestModel);
	}
}