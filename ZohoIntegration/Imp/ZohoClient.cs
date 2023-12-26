using RestSharp;
using ZohoAbstraction;
using ZohoIntegration.Domain;
using System.Text.Json;

namespace ZohoIntegration.Imp
{
	public class ZohoClient : IZohoClient
	{
		const string ZOHO_AUTH_GENERATE_URI = "/oauth/v2/token";
		public string ZohoOpenConnectUrl(ZohoConsentRequestModel model)
		{
			return $"{model.ConsentUri}/oauth/v2/auth?response_type=code&client_id={model.ClientId}&scope={model.Scope}&redirect_uri={model.RedirectUrl}&access_type=offline&prompt=consent";
		}

		public ZohoAuthTokenResponseModel GenerateZohoAuthToken(ZohoAuthTokenRequestModel zohoAuthTokenRequestModel)
		{
			var restClient = new RestClient(zohoAuthTokenRequestModel.ConsentUri);
			var restRequest = new RestRequest(ZOHO_AUTH_GENERATE_URI, Method.Post);
			restRequest.AlwaysMultipartFormData = true;
			restRequest.AddParameter("grant_type", zohoAuthTokenRequestModel.grant_type);
			restRequest.AddParameter("client_id", zohoAuthTokenRequestModel.client_id);
			restRequest.AddParameter("client_secret", zohoAuthTokenRequestModel.client_secret);
			restRequest.AddParameter("code", zohoAuthTokenRequestModel.code);
			restRequest.AddParameter("redirect_uri", zohoAuthTokenRequestModel.redirect_uri);
			var response = restClient.Execute(restRequest);
			if (response == null || string.IsNullOrEmpty(response.Content))
			{
				throw new Exception("Zoho Auth token(/oauth/v2/token) generation api fail");
			}
			//JsonConvert.DeserializeObject<ZohoAuthTokenResponseModel>(response.Content);
			return JsonSerializer.Deserialize<ZohoAuthTokenResponseModel>(response.Content);
		}
	}
}
