namespace SPL.Models
{
    public class Branch
    {
        public Guid Id { get; set; }
        public string? ParentCompany { get; set; }
        public string? Name { get; set; }
        public string? ShortAddress { get; set; }
        public string? BuildingNumber { get; set; }
        public string? AdditionalNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? NationalId { get; set; }
        public string? MobileNumber { get; set; }
    }
}
