namespace RestShrapWrapper.Domian
{
	public class TIntegrationAudit
	{
		public int Id { get; set; }
		public int ApiType { get; set; }
		public string Request { get; set; }
		public string Response { get; set; }
		public string HttpStatus { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
