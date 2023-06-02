using Nancy.Json;
using Newtonsoft.Json;
using SPL.Data;
using SPL.IRepositories;
using SPL.Models;
using System.Net;

namespace SPL.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {

        public ContactRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        
        public async Task<string> CreateContact(Contact contact, string crmBaseURL)
        {
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
                        EnglishName = contact.EnglishName,
                        AccountID = contact.AccountID,
                        Email = contact.Email,
                        PhoneNumber = contact.PhoneNumber,
                        Username = contact.Username,
                        Password = contact.Password,
                        Salutation = contact.Salutation,
                        InformalName = contact.InformalName,
                        AddressType = contact.AddressType,
                        NationalAddressId = contact.NationalAddressId,
                        DescriptiveAddress = contact.DescriptiveAddress
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
