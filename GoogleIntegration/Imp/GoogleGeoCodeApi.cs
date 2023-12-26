using GoogleIntegration.Abstraction;
using GoogleIntegration.Domain.Config.MapApi;
using Microsoft.Extensions.Options;
using RestSharp;
using ServiceAccessLayer.MapApi.Domain;

namespace GoogleIntegration.Imp
{
    public class GoogleGeoCodeApi : IGeoLocationApi
    {
        private const string GEO_CODE_BASE_URI = "/maps/api/geocode/json?address={0}&key={1}";
        ThiredPartyApi _thiredPartyApi;
        public GoogleGeoCodeApi(IOptions<ThiredPartyApi> thiredPartyApi)
        {
            _thiredPartyApi = thiredPartyApi.Value;
        }

        public GoogleGeoLocationResponseModel GetGeoCode(GeoLocationRequestModel requestModel)
        {
            var address = $"{requestModel.ZipCode} {requestModel.Address} {requestModel.City}";
            var baseUri = string.Format(GEO_CODE_BASE_URI, address, _thiredPartyApi.GoogleApi.MapApi.ApiKey);
            var apiUrl = $"{_thiredPartyApi.GoogleApi.MapApi.Url}{baseUri}";
            var client = new RestClient();
            var request = new RestRequest(apiUrl, Method.Get);
            var response = client.Execute<GoogleGeoLocationResponseModel>(request);
            return response.Data;
        }
    }
}
