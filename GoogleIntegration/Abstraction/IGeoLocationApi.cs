using ServiceAccessLayer.MapApi.Domain;

namespace GoogleIntegration.Abstraction
{
    public interface IGeoLocationApi
    {
        public GoogleGeoLocationResponseModel GetGeoCode(GeoLocationRequestModel requestModel);
    }
}
