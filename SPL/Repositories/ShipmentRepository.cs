using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Nancy.Json;
using Newtonsoft.Json;
using SPL.Data;
using SPL.IRepositories;
using SPL.Models;
using System.Net;
using System.Runtime.Intrinsics.X86;

namespace SPL.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public async Task<string> CreateShipment(Shipment shipment, string crmBaseURL)
        {
            //String crmBaseURL =  configuration.GetValue<string>("MySettings:DbConnection");
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(crmBaseURL + "/api/createShipment");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                //httpWebRequest.Headers.Add("Authorization", "Bearer " + token.RestClientWithAuth(cbsURL, cbsUser, cbsPass, grant_type));
                
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        Name = shipment.Name,
                        Account = shipment.Account,
                        AddressType = shipment.AddressType,
                        ReceiverName = shipment.ReceiverName,
                        ReceiverPhoneNumber = shipment.ReceiverPhoneNumber,
                        ReceiverType = shipment.ReceiverType,
                        ShortAddress = shipment.ShortAddress,
                        PostalCode = shipment.PostalCode,
                        BuildingNumber = shipment.BuildingNumber,
                        AdditionalNumber = shipment.AdditionalNumber,
                        UnitNumber = shipment.UnitNumber,
                        City = shipment.City,
                        ParcelStation = shipment.ParcelStation,
                        Office = shipment.Office,
                        POBox = shipment.POBox,
                        District = shipment.District,
                        StreetName = shipment.StreetName,
                        NearestLandmark = shipment.NearestLandmark,
                        InternationalPhoneNumber = shipment.InternationalPhoneNumber,
                        Country = shipment.Country,
                        IDType = shipment.IDType,
                        InternationalIDNumber = shipment.InternationalIDNumber,
                        ItemOrigin = shipment.ItemOrigin,   
                        ItemPrice = shipment.ItemPrice,
                        PaymentType = shipment.PaymentType,   
                        ShipmentWeight = shipment.ShipmentWeight,
                        ShipmentContentType = shipment.ShipmentContentType,
                        TransportationType = shipment.TransportationType,
                        DeliveryType = shipment.DeliveryType,
                        CODCollected = shipment.CODCollected
                    });
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                
                //get http status code 
                //if (httpResponse.StatusCode == HttpStatusCode.OK)

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var resultText = JsonConvert.DeserializeObject<string>(result);
                    return resultText;
                }
                
            }
            catch (Exception ex)
            {
                return "Error! " + ex.Message;
            }
        }

    }
}
