using ZohoIntegration.Domain.Lead;

namespace ZohoAbstraction
{
	public interface IZohoLeadApi
	{
		ZohoLeadApiResponseModel GenerateZohoLead(string authToken, ZohoLeadApiRequestModel zohoLeadRequest);
		List<ZohoLeadApiResponseModel> GenerateZohoLead(string authToken, List<ZohoLeadApiRequestModel> zohoLeadRequest);
	}
}
