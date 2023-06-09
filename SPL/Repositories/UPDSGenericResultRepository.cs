using Nancy.Json;
using Newtonsoft.Json;
using SPL.Data;
using SPL.IRepositories;
using SPL.Models;
using System.Net;

namespace SPL.Repositories
{
    public class UPDSGenericResultRepository : GenericRepository<UPDSGenericReult>, IUPDSGenericResultRepository
    {

        public UPDSGenericResultRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }
        public async Task<UPDSGenericReult> GetAddresses(PinCodeModel pinCode, string externalBaseURL)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(externalBaseURL + "/api/OTP/GetAddresses");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                //httpWebRequest.Headers.Add("Authorization", "Bearer " + token.RestClientWithAuth(cbsURL, cbsUser, cbsPass, grant_type));

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        StoreId = pinCode.StoreId,
                        MobileNo = pinCode.MobileNo,
                        PinCode = pinCode.PinCode
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
                    var resultText = JsonConvert.DeserializeObject<UPDSGenericReult>(result);
                    return resultText;
                }

            }
            catch (Exception ex)
            {
                return new UPDSGenericReult { ErrorCode = "Error", SystemErrorMessage = ex.Message };
            }
        }
        public Task<bool> Add(UPDSGenericReult entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UPDSGenericReult entity)
        {
            throw new NotImplementedException();
        }
    }
}
