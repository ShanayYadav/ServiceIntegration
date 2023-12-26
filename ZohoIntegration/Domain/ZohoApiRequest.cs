namespace ZohoIntegration.Domain
{
    public class ZohoApiRequest<T> where T : class
    {
        public List<T> data { get; set; }
    }
}