namespace RestShrapWrapper.Utility
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
				var value = x.GetValue(source)?.ToString();

				if (!string.IsNullOrEmpty(value) && value.Trim().Length > 0)
				{
					if (x.PropertyType.IsPrimitive &&
					x.PropertyType.FullName.Equals("System.Boolean", StringComparison.InvariantCultureIgnoreCase))
					{
						value = value.ToLower();
					}

					param += $"{x.Name.ToLower()}={value}&";
				}
			});
			return param?.Substring(0, param.Length - 1);
		}

	}
}