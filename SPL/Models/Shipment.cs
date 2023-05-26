namespace SPL.Models
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Account { get; set; }
        public string? AddressType { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverPhoneNumber { get; set; }
        public string? ReceiverType { get; set; }
        public string? ShortAddress { get; set; }
        public string? PostalCode { get; set; }
        public string? BuildingNumber { get; set; }
        public string? AdditionalNumber { get; set; }
        public string? UnitNumber { get; set; }
        public string? City { get; set; }
        public string? ParcelStation { get; set; }
        public string? Office { get; set; }
        public string? POBox { get; set; }
        public string? District { get; set; }
        public string? StreetName { get; set; }
        public string? NearestLandmark { get; set; }
        public string? InternationalPhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? IDType { get; set; }
        public string? InternationalIDNumber { get; set; }
        public string? ItemOrigin { get; set; }
        public decimal? ItemPrice { get; set; }
        public string? PaymentType { get; set; }
        public decimal? ShipmentWeight { get; set; }
        public string? ShipmentContentType { get; set; }
        public string? TransportationType { get; set; }
        public string? DeliveryType { get; set; }
        public string? CODCollected { get; set; }
    }
}
