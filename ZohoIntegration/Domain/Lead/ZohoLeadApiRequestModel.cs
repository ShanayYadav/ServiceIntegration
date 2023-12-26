namespace ZohoIntegration.Domain.Lead
{
    public class ZohoLeadApiRequestModel
    {
        public string Lead_Owner { get; set; }
        public string Company { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Lead_Source { get; set; }
        public string Lead_Status { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public string Created_Date { get; set; }
        public string Updated_Date { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
