using GoogleIntegration.Abstraction;
using GoogleIntegration.Domain.Config;
using Microsoft.Extensions.Options;
using RestSharp;
using ServiceAccessLayer.MapApi.Domain;

namespace GoogleIntegration.Imp
{
	public class GoogleGeoCodeApi : IGeoLocationApi
	{
		private const string GEO_CODE_BASE_URI = "/maps/api/geocode/json?address={0}&key={1}";
		GoogleApi _googleApi;
		public GoogleGeoCodeApi(IOptions<GoogleApi> googleApi)
		{
			_googleApi = googleApi.Value;
		}

		public GoogleGeoLocationResponseModel GetGeoCode(GeoLocationRequestModel requestModel)
		{
			var address = $"{requestModel.ZipCode} {requestModel.Address} {requestModel.City}";
			var baseUri = string.Format(GEO_CODE_BASE_URI, address, _googleApi.MapApi.ApiKey);
			var apiUrl = $"{_googleApi.MapApi.Url}{baseUri}";
			var client = new RestClient();
			var request = new RestRequest(apiUrl, Method.Get);
			var response = client.Execute<GoogleGeoLocationResponseModel>(request);
			return response.Data;
		}
	}
}
