using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestShrapWrapper.Domian
{
	[Table("T_IntegrationAudit")]
	public class TIntegrationAudit
	{
		[Key]
		public int Id { get; set; }
		public int ApiType { get; set; }
		public string TraceId { get; set; }
		public int RecordType { get; set; }
		public string Content { get; set; }
		public int HttpStatus { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
