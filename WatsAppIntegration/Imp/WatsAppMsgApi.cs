using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatsAppIntegration.Abstraction;
using WatsAppIntegration.Domain;
using WatsAppIntegration.Domain.Config;

namespace WatsAppIntegration.Imp
{
	public class WatsAppMsgApi : IWatsAppMsgApi
	{
		FaceBookGraphApiConfig _faceBookGraphApiConfig;
		public WatsAppMsgApi(IOptions<FaceBookGraphApiConfig> faceBookGraphApiConfig)
		{
			_faceBookGraphApiConfig = faceBookGraphApiConfig.Value;
		}

		public WatsAppSendMsgResponseModel Send(WatsAppSendMsgRequestModel watsSendMsgRequestModel)
		{
			throw new NotImplementedException();
		}
	}
}
