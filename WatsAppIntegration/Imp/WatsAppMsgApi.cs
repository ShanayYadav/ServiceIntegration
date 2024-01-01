using Microsoft.Extensions.Options;
using RestShrapWrapper.Abstraction;
using WatsAppIntegration.Abstraction;
using WatsAppIntegration.Domain;
using WatsAppIntegration.Domain.Config;

namespace WatsAppIntegration.Imp
{
	public class WatsAppMsgApi : IWatsAppMsgApi
	{
		const string GRAPH_MSG_API_URI = "/v17.0/{0}/messages";

		FaceBookGraphApiConfig _faceBookGraphApiConfig;
		IRestApiInvoker _restApiInvoker;

		public WatsAppMsgApi(IOptions<FaceBookGraphApiConfig> faceBookGraphApiConfig, IRestApiInvoker restApiInvoker)
		{
			_faceBookGraphApiConfig = faceBookGraphApiConfig.Value;
			_restApiInvoker = restApiInvoker;
		}

		public WatsAppSendMsgResponseModel Send(WatsAppSendMsgRequestModel watsSendMsgRequestModel)
		{
			var url = string.Format($"{_faceBookGraphApiConfig.GraphApiUrl}{GRAPH_MSG_API_URI}", _faceBookGraphApiConfig.WatsAppApi.PhoneNumberId);
			watsSendMsgRequestModel.Messaging_Product = _faceBookGraphApiConfig.WatsAppApi.Messaging_Product;
			var headers = new Dictionary<string, string>
			{
				{ "Authorization", _faceBookGraphApiConfig.WatsAppApi.AuthToken}
			};
			var result = _restApiInvoker.Post<WatsAppSendMsgRequestModel, WatsAppSendMsgResponseModel>(url, watsSendMsgRequestModel, headers);
			return result;
		}
	}
}
