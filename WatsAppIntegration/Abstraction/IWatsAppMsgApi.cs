using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatsAppIntegration.Domain;

namespace WatsAppIntegration.Abstraction
{
	public interface IWatsAppMsgApi
	{
		WatsAppSendMsgResponseModel Send(WatsAppSendMsgRequestModel watsSendMsgRequestModel);
	}
}
