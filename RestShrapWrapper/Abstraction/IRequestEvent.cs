namespace RestShrapWrapper.Abstraction
{
	public interface IRequestEvent
	{
		ValueTask OnBeforeRequest(HttpRequestMessage requestMessage);

		ValueTask OnAfterRequest(HttpResponseMessage requestMessage);
	}
}