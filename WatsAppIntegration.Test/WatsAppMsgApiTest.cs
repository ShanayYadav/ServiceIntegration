using Microsoft.Extensions.Options;
using WatsAppIntegration.Abstraction;
using WatsAppIntegration.Imp;
using WatsAppIntegration.Domain.Config;
using WatsAppIntegration.Domain;
using WatsAppIntegration.Domain.Shared;
using RestShrapWrapper.Abstraction;
using RestShrapWrapper.Imp;
using Microsoft.EntityFrameworkCore;
using RestShrapWrapper.Domian;

namespace WatsAppIntegration.Test
{
    [TestClass]
	public class WatsAppMsgApiTest
	{
		IWatsAppMsgApi _watsAppMsgApi;
		WatsAppSendMsgResponseModel _result;
		WatsAppSendMsgRequestModel _watsAppSendMsgRequestModel;
		IRestApiInvoker _restApiInvoker;

		[TestInitialize]
		public void Init()
		{
			var contextOption = new DbContextOptionsBuilder<IntegrationAuditingContext>().UseSqlServer("").Options;
			_restApiInvoker = new RestApiInvoker(contextOption);
			_watsAppMsgApi = new WatsAppMsgApi(Options.Create(new FaceBookGraphApiConfig
			{
				GraphApiUrl = "https://graph.facebook.com",
				WatsAppApi = new FaceBookMsgGraphApiConfig
				{
					AuthToken = "Bearer EAAQz2SEZAtZBwBO3SWWL9AxOSa1SsuUlLSTKh9rowqZCMzVqLmiMt2TiNcvxQYh4ViQ00xRUosKUZB9DWixZC8kfiNWFZAq16JyiLyZAZBC1sWjHUApKKACgQ44FfsbZBTVeshckagjJOELikSlsgin4kfXGlAuVawewODW6sH2nlcUTZB9uQZBnEZAdSIz3L3wAqTzZBsxyh0WZCxxPpmCBW4Ls5st92f8ewZD",
					PhoneNumberId = "184597484744010",
					Messaging_Product = "whatsapp"
				}
			}), _restApiInvoker);

			_watsAppSendMsgRequestModel = new WatsAppSendMsgRequestModel
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
			};
		}

		[TestMethod]
		public void Test()
		{
			_result = _watsAppMsgApi.Send(_watsAppSendMsgRequestModel);
		}
	}
}
