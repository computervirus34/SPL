using Microsoft.EntityFrameworkCore;
using Nancy.Json;
using Newtonsoft.Json;
using SPL.Data;
using SPL.IRepositories;
using SPL.Models;
using System.Net;

namespace SPL.Repositories
{
    public class PinCodeRepository : GenericRepository<PinCodeModel>, IPinCodeRepository
    {

        public PinCodeRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }
        public async Task<PinCodeModel> GetPinCode(PinCodeModel pinCode, string externalBaseURL)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(externalBaseURL + "/api/OTP/GetPinCode");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                //httpWebRequest.Headers.Add("Authorization", "Bearer " + token.RestClientWithAuth(cbsURL, cbsUser, cbsPass, grant_type));

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        StoreId = pinCode.StoreId,
                        MobileNo = pinCode.MobileNo
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
                    var resultText = JsonConvert.DeserializeObject<PinCodeModel>(result);
                    return resultText;
                }

            }
            catch (Exception ex)
            {
                return new PinCodeModel { ErrorCode="Error", SystemErrorMessage=ex.Message, StoreId=pinCode.StoreId, MobileNo=pinCode.MobileNo};
            }
        }

        public virtual async Task<bool> Update(PinCodeModel entity)
        {
            try
            {
                var infoExists = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (infoExists == null)
                    return false;
                infoExists.ErrorCode = entity.ErrorCode;
                infoExists.ErrorFriendlyMessage = entity.ErrorFriendlyMessage;
                infoExists.Status = entity.Status;
                infoExists.SystemErrorMessage = entity.SystemErrorMessage;
                infoExists.PinCode = entity.PinCode;
                infoExists.SMSBody = entity.SMSBody;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(PinCodeRepository));
                return false;
            }
        }
    }
}
