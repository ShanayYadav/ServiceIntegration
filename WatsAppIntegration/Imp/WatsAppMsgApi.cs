using Microsoft.Extensions.Options;
using RestSharp;
using WatsAppIntegration.Abstraction;
using WatsAppIntegration.Domain;
using WatsAppIntegration.Domain.Config;

namespace WatsAppIntegration.Imp
{
	public class WatsAppMsgApi : IWatsAppMsgApi
	{
		const string GRAPH_MSG_API_URI = "/v17.0/{0}/messages";

		FaceBookGraphApiConfig _faceBookGraphApiConfig;
		public WatsAppMsgApi(IOptions<FaceBookGraphApiConfig> faceBookGraphApiConfig)
		{
			_faceBookGraphApiConfig = faceBookGraphApiConfig.Value;
		}

		public WatsAppSendMsgResponseModel Send(WatsAppSendMsgRequestModel watsSendMsgRequestModel)
		{
			var options = new RestClientOptions("")
			{
				MaxTimeout = -1,
			};
			var client = new RestClient(options);
			var url = string.Format($"{_faceBookGraphApiConfig.GraphApiUrl}{GRAPH_MSG_API_URI}", _faceBookGraphApiConfig.WatsAppApi.PhoneNumberId);
			watsSendMsgRequestModel.Messaging_Product = _faceBookGraphApiConfig.WatsAppApi.Messaging_Product;
			var request = new RestRequest(url, Method.Post);
			request.AddHeader("Authorization", _faceBookGraphApiConfig.WatsAppApi.AuthToken);
			request.AddHeader("Content-Type", "application/json");
			var body = "";
			request.AddJsonBody(watsSendMsgRequestModel);
			var response = client.Execute<WatsAppSendMsgResponseModel>(request);
			return response.Data;
		}
	}
}
