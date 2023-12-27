using GoogleIntegration.Abstraction;
using GoogleIntegration.Domain.Auth;
using GoogleIntegration.Domain.Config;
using GoogleIntegration.Imp;
using Microsoft.Extensions.Options;

namespace GoogleIntegration.Test
{
	[TestClass]
	public class When_Call_GoogleAuthApiTest_OprnConnect_With_Fields_And_Deafult
	{
		string _result = string.Empty;
		IGoogleAuthApi _googleAuthApi;
		OpenConnectRequestModel _openConnectRequestModel;
		IOptions<GoogleApi> _ggogleApi;

		[TestInitialize]
		public void Init()
		{
			_ggogleApi = Options.Create(new GoogleApi
			{
				AuthApi = new AuthApi
				{
					Scope = "https://www.googleapis.com/auth/drive.metadata.readonly",
					AccessType = "offline",
					IncludeGrantedScopes = true,
					ResponseType = "code",
					State = "gaurav",
					RedirectUri = "http://localhost:4200",
					Prompt = "consent",
					ClientId = "clientid12324567890.apps.googleusercontent.com"
				}
			});

			_googleAuthApi = new GoogleAuthApi(_ggogleApi);
			_openConnectRequestModel = new OpenConnectRequestModel
			{
				Scope = "https://www.googleapis.com/auth/drive.metadata.readonly",
				Access_Type = "offline",
				Include_Granted_Scopes = true,
				Response_Type = "code",
				State = "gaurav",
				Redirect_Uri = "http://localhost:4200",
				Prompt = "consent",
				Client_Id = "clientid12324567890.apps.googleusercontent.com"
			};
		}

		[TestMethod]
		public void OpenConnectUrl_With_All_Field_Should_Return_Expected_Result()
		{
			_result = _googleAuthApi.OpenConnectUrl(_openConnectRequestModel);
			Assert.IsNotNull(_result);
			Assert.IsTrue(_result.Trim().Length > 0);
			Assert.IsTrue(_result.Contains("Scope=https://www.googleapis.com/auth/drive.metadata.readonly", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Access_type=offline", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Include_Granted_Scopes=true", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Response_Type=code", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("State=gaurav", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Redirect_Uri=http://localhost:4200", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Prompt=consent", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Client_Id=clientid12324567890.apps.googleusercontent.com", StringComparison.InvariantCultureIgnoreCase));
		}

		[TestMethod]
		public void OpenConnectUrl_Default_Should_Return_Expected_Result()
		{
			_result = _googleAuthApi.OpenConnectUrl();
			Assert.IsNotNull(_result);
			Assert.IsTrue(_result.Trim().Length > 0);
			Assert.IsTrue(_result.Contains("Scope=https://www.googleapis.com/auth/drive.metadata.readonly", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Access_type=offline", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Include_Granted_Scopes=true", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Response_Type=code", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("State=gaurav", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Redirect_Uri=http://localhost:4200", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Prompt=consent", StringComparison.InvariantCultureIgnoreCase));
			Assert.IsTrue(_result.Contains("Client_Id=clientid12324567890.apps.googleusercontent.com", StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
