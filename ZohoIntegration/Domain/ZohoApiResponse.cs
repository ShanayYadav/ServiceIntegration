namespace ZohoIntegration.Domain
{
    public class ZohoApiResponse<T> where T : class
    {
        public List<T> data { get; set; }
    }
}