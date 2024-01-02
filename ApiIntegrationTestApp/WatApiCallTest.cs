using WatsAppIntegration.Abstraction;
using WatsAppIntegration.Domain.Shared;
using WatsAppIntegration.Domain;

namespace ApiIntegrationTestApp
{
	public class WatApiCallTest
	{
		IWatsAppMsgApi _apiClient;
		public WatApiCallTest(IWatsAppMsgApi apiClient)
		{
			_apiClient = apiClient;
		}

		public void SendMsg()
		{
			_apiClient.Send(new WatsAppSendMsgRequestModel
			{
				Messaging_Product = "whatsapp",
				To = "919350436789",
				Type = "template",
				Template = new Template
				{
					Name = "trail_msg",
					Language = new Language { Code = "en_US" },
					Components = new List<Component>
					{
						new Component
						{
							Type= "HEADER",
							Parameters= new List<Parameter>
							{
								new Parameter
								{
									Type= "text",
									Text= "Yusuf"
								}
							}
						},
						new Component
						{
							Type= "BODY",
							Parameters=  new List<Parameter>
							{
								new Parameter
								{
									Type= "text",
									Text= "0147"

								},
								new Parameter
								{
									Type= "text",
									Text= "29-12-2023"
								}
							}
						}
					}
				}
			});
		}
	}
}
