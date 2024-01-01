using System.Text.Json;

namespace RestShrapWrapper.JsonPolicy
{
	public class LowerCaseJsonNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name?.ToLower();
        }
    }
}
