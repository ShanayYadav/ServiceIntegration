using Microsoft.Extensions.Options;
using RestShrapWrapper;
using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Enums;
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
			var result = _restApiInvoker.Post<WatsAppSendMsgRequestModel, WatsAppSendMsgResponseModel>(url, watsSendMsgRequestModel,
				AddHeader(_faceBookGraphApiConfig.WatsAppApi.AuthToken));
			return result;
		}

		private Dictionary<string, string> AddHeader(string authToken)
		{
			return new Dictionary<string, string>
			{
				{ HeaderConstant.Authorization, authToken},
				{ HeaderConstant.API_TYPE, ApiType.WatsApi.ToString()}
			};
		}
	}
}
