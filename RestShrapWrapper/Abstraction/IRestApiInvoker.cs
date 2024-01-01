namespace RestShrapWrapper.Abstraction
{
	public interface IRestApiInvoker
	{
		TReturn Post<TSource, TReturn>(string url, TSource source, Dictionary<string, string> headers) where TReturn : class, new();
	}
}
