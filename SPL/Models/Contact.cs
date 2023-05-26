namespace SPL.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string? EnglishName { get; set; }
        public string? AccountID { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Salutation { get; set; }
        public string? InformalName { get; set; }
        public string? AddressType { get; set; }
        public string? NationalAddressId { get; set; }
        public string? DescriptiveAddress { get; set; }
    }
}
