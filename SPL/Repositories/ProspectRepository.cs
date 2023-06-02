using Nancy.Json;
using Newtonsoft.Json;
using SPL.Data;
using SPL.IRepositories;
using SPL.Models;
using System.Net;

namespace SPL.Repositories
{
    public class ProspectRepository : GenericRepository<Prospect>, IProspectRepository
    {

        public ProspectRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(Prospect entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Prospect entity)
        {
            throw new NotImplementedException();
        }
        public async Task<string> CreateProspect(Prospect prospect, string crmBaseURL)
        {
            //String crmBaseURL =  configuration.GetValue<string>("MySettings:DbConnection");
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(crmBaseURL + "/api/createProspect");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                //httpWebRequest.Headers.Add("Authorization", "Bearer " + token.RestClientWithAuth(cbsURL, cbsUser, cbsPass, grant_type));

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        CompanyNameEnglish = prospect.CompanyNameEnglish,
                        FullName = prospect.FullName,
                        Email = prospect.Email,
                        PhoneNumber = prospect.PhoneNumber,
                        CRNumber = prospect.CRNumber,
                        TaxNumber = prospect.TaxNumber,
                        BusinessPhoneNumber = prospect.BusinessPhoneNumber,
                        ShortAddress = prospect.ShortAddress,
                        BuildingNumber = prospect.BuildingNumber,
                        UnitNumber = prospect.UnitNumber,
                        AdditionalNumber = prospect.AdditionalNumber,
                        ZipCode = prospect.ZipCode
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
