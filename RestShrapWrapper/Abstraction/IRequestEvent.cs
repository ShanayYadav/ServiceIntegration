using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestShrapWrapper.Abstraction
{
	public interface IRequestEvent
	{
		ValueTask OnBeforeRequest(HttpRequestMessage requestMessage);

		ValueTask OnAfterRequest(HttpResponseMessage requestMessage);
	}
}