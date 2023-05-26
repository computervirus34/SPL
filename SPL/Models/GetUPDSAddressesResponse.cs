namespace SPL.Models
{
    public class GetUPDSAddressesResponse
    {
        public GetUPDSAddressesResponse()
        {
            genericReult = new UPDSGenericReult();
            waselAddressDetails = new List<WaselAddressDetails>();
        }
        public UPDSGenericReult genericReult { get; set; }
        public List<WaselAddressDetails> waselAddressDetails { get; set; }
    }
    public class WaselAddressDetails
    {
        public Guid Id { get; set; }
        public string? City { get; set; }
        public string? CityName { get; set; }
        public string? CityNameEN { get; set; }
        public string? District { get; set; }
        public string? DistrictArea { get; set; }
        public string? DistrictName { get; set; }
        public string? DistrictNameEN { get; set; }
        public string? LocationX { get; set; }
        public string? LocationY { get; set; }
        public string? LocationZ { get; set; }
        public string? MobileNo { get; set; }
        public string? Street { get; set; }
        public string? Street_NameEN { get; set; }
        public string? StreetName { get; set; }
        public string? Unit { get; set; }
        public string? Latitude { get; set; } 
        public string? Longitude { get; set; }
        public string? UnitTypeID { get; set; }

    }

    public class UPDSGenericReult
    {
        public Guid Id { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorFriendlyMessage { get; set; }
        public bool Status { get; set; }
        public string? SystemErrorMessage { get; set; }
        public int RequestId { get; set; }
    }
}
