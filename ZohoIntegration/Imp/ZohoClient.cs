using RestSharp;
using ZohoAbstraction;
using ZohoIntegration.Domain;
using System.Text.Json;
using Microsoft.Extensions.Options;
using ZohoIntegration.Domain.Config;
using RestShrapWrapper;

namespace ZohoIntegration.Imp
{
	public class ZohoClient : IZohoClient
	{
		const string ZOHO_AUTH_OPENCONNECT_URI = "/oauth/v2/auth";
		const string ZOHO_AUTH_GENERATE_URI = "/oauth/v2/token";

		ZohoApi _zohoApi;

		public ZohoClient(IOptions<ZohoApi> zohoApi)
		{
			_zohoApi = zohoApi.Value;
		}

		public string ZohoOpenConnectUrl()
		{
			var openConnectRequestModel = new ZohoOpenConnectRequestModel
			{
				Access_Type = _zohoApi.AccessType,
				ClientType = _zohoApi.ClientType,
				Client_Id = _zohoApi.ClientId,
				GrantType = _zohoApi.GrantType,
				Prompt = _zohoApi.Prompt,
				Redirect_Uri = _zohoApi.RedirectUrl,
				Response_Type = _zohoApi.ResponseType,
				Scope = _zohoApi.Scope
			};
			return ZohoOpenConnectUrl(openConnectRequestModel);
			//return $"{_zohoApi.ConsentUri}/oauth/v2/auth?response_type=code&client_id={_zohoApi.ClientId}&scope={_zohoApi.Scope}&redirect_uri={_zohoApi.RedirectUrl}&access_type=offline&prompt=consent";
		}

		public string ZohoOpenConnectUrl(ZohoOpenConnectRequestModel model)
		{
			var openConnecturl = $"{_zohoApi.ConsentUri}{ZOHO_AUTH_OPENCONNECT_URI}?{RestSharpUrlUtility.GetParam(model)}";
			return openConnecturl; //$"{model.ConsentUri}/oauth/v2/auth?response_type=code&client_id={model.ClientId}&scope={model.Scope}&redirect_uri={model.RedirectUrl}&access_type=offline&prompt=consent";
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
