namespace ZohoIntegration.Domain.Shared
{
    public class ResponseDetails
    {
        public DateTime Modified_Time { get; set; }
        public ModifiedBy Modified_By { get; set; }
        public DateTime Created_Time { get; set; }
        public string Id { get; set; }
        public CreatedBy Created_By { get; set; }
        public string? Api_Name { get; set; }
        public string? Json_Path { get; set; }
        public string? Approval_State { get; set; }
    }
}
