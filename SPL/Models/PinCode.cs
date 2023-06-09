namespace SPL.Models
{
    public class PinCodeModel
    {
        public Guid Id { get; set; } 
        public int StoreId { get; set; }    
        public string MobileNo { get; set; }
        public string? ErrorCode { get; set; }
        public string? PinCode { get; set; }
        public string? ErrorFriendlyMessage { get; set; }
        public bool Status { get; set; }
        public string? SystemErrorMessage { get; set; }
        public string SMSBody { get; set; }


    }
}
