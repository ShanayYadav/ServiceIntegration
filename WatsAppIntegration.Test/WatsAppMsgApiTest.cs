using Microsoft.Extensions.Options;
using WatsAppIntegration.Abstraction;
using WatsAppIntegration.Imp;
using WatsAppIntegration.Domain;
using WatsAppIntegration.Domain.Shared;
using RestShrapWrapper.Abstraction;
using WatsAppIntegration.Config;
using Moq;
using RestShrapWrapper.Enums;
using RestShrapWrapper;

namespace WatsAppIntegration.Test
{
	[TestClass]
	public class WatsAppMsgApiTest
	{
		IWatsAppMsgApi _watsAppMsgApi;
		WatsAppSendMsgResponseModel _result;
		WatsAppSendMsgRequestModel _watsAppSendMsgRequestModel;
		WatsAppSendMsgResponseModel _watsAppApiResponse;
		Mock<IRestApiInvoker> _restApiInvoker;
		FaceBookGraphApiConfig _watsApiConfig;

		[TestInitialize]
		public void Init()
		{
			_restApiInvoker = new Mock<IRestApiInvoker>();
			_watsApiConfig = new FaceBookGraphApiConfig
			{
				GraphApiUrl = "https://graph.facebook.com",
				WatsAppApi = new FaceBookMsgGraphApiConfig
				{
					AuthToken = "Bearer EAAQz2SEZAtZBwBO3SWWL9AxOSa1SsuUlLSTKh9rowqZCMzVqLmiMt2TiNcvxQYh4ViQ00xRUosKUZB9DWixZC8kfiNWFZAq16JyiLyZAZBC1sWjHUApKKACgQ44FfsbZBTVeshckagjJOELikSlsgin4kfXGlAuVawewODW6sH2nlcUTZB9uQZBnEZAdSIz3L3wAqTzZBsxyh0WZCxxPpmCBW4Ls5st92f8ewZD",
					PhoneNumberId = "184597484744010",
					Messaging_Product = "whatsapp"
				}
			};
			_watsAppMsgApi = new WatsAppMsgApi(Options.Create(_watsApiConfig), _restApiInvoker.Object);

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
			_watsAppApiResponse = new WatsAppSendMsgResponseModel
			{
				Messaging_Product = "whatsapp",
				Contacts = new List<Contact>
					{
						new Contact
						{
							Input="919350436789", Wa_Id="919350436789"
						}
					},
				Messages = new List<Message>
					{
						new Message
						{
							Id="wamid.HBgMOTE5MzUwNDM2Nzg5FQIAERgSNEQ0RDZFM0Y0QTFEMjU3Rjk1AA==",
							Message_Status="accepted"
						}
					}
			};

			_restApiInvoker.Setup(x => x.Post<WatsAppSendMsgRequestModel, WatsAppSendMsgResponseModel>("https://graph.facebook.com/v17.0/184597484744010/messages",
				_watsAppSendMsgRequestModel,
				new Dictionary<string, string>
				{
					{ HeaderConstant.Authorization, _watsApiConfig.WatsAppApi.AuthToken},
				{ HeaderConstant.API_TYPE, ApiType.WatsApi.ToString()}
				})).Returns(_watsAppApiResponse);
		}

		[TestMethod]
		public void Test()
		{
			_result = _watsAppMsgApi.Send(_watsAppSendMsgRequestModel);
			Assert.IsNotNull(_watsAppApiResponse);
			Assert.AreEqual(_watsAppApiResponse.Messaging_Product, "whatsapp");
			Assert.AreEqual(_watsAppApiResponse.Messages[0].Message_Status, "accepted");
			Assert.AreEqual(_watsAppApiResponse.Messages[0].Id, "wamid.HBgMOTE5MzUwNDM2Nzg5FQIAERgSNEQ0RDZFM0Y0QTFEMjU3Rjk1AA==");
		}
	}
}
