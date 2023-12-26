using System.Text.Json;
using RestSharp;
using ZohoAbstraction;
using ZohoIntegration.Domain;
using ZohoIntegration.Domain.Lead;
using ZohoIntegration.Domain.Enum;

namespace ZohoIntegration.Imp
{
	public class ZohoLeadApi : IZohoLeadApi
	{
		const string ZOHO_LEAD_API_URI = "/crm/v5/Leads";
		IZohoConfiguration _zohoConfiguration;

		public ZohoLeadApi(IZohoConfiguration zohoConfiguration)
		{
			_zohoConfiguration = zohoConfiguration;
		}


		public ZohoLeadApiResponseModel GenerateZohoLead(string authToken, ZohoLeadApiRequestModel zohoLeadRequest)
		{
			return GenerateZohoLead(authToken, new List<ZohoLeadApiRequestModel> { zohoLeadRequest }).First();
		}

		public List<ZohoLeadApiResponseModel> GenerateZohoLead(string authToken, List<ZohoLeadApiRequestModel> zohoLeadRequest)
		{
			try
			{
				var responseData = new ZohoApiResponse<ZohoLeadApiResponseModel>();
				var configuration = _zohoConfiguration.GetZohoConfiguration(ZohoClientTypeEnum.Crm);
				var leadRequest = new ZohoApiRequest<ZohoLeadApiRequestModel>();
				leadRequest.data = zohoLeadRequest;
				var restClient = new RestClient(configuration.BaseUrl);
				var restRequest = new RestRequest(ZOHO_LEAD_API_URI, Method.Post);
				restRequest.AddHeader("Authorization", $"Zoho-oauthtoken {authToken}");
				restRequest.AddHeader("Content-Type", "application/json");
				var jsonRequest = JsonSerializer.Serialize(leadRequest);
				restRequest.AddJsonBody(jsonRequest);
				var response = restClient.Execute(restRequest);
				if (response != null && response.Content != null)
				{
					var content = response.Content.Replace("$approval_state", "approval_state");
					responseData = JsonSerializer.Deserialize<ZohoApiResponse<ZohoLeadApiResponseModel>>(content);
				}
				return responseData?.data;
			}
			catch (Exception ex)
			{
				throw new Exception("Zoho lead api failing", ex);
			}
		}
	}
}
