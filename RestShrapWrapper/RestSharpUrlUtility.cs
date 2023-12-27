namespace RestShrapWrapper
{
	public class RestSharpUrlUtility
	{
		public static string GetParam<TSource>(TSource source)
		{
			var param = string.Empty;
			if (source == null)
			{
				return param;
			}
			var properties = source.GetType().GetProperties()?.ToList();
			properties?.ForEach(x =>
			{
				param += $"{x.Name}={x.GetValue(source)}&";
			});
			return param?.Substring(0, param.Length - 1);
		}
	}
}
