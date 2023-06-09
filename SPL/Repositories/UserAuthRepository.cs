using Nancy.Json;
using Newtonsoft.Json;
using SPL.Data;
using SPL.IRepositories;
using SPL.Models;
using System.Net;

namespace SPL.Repositories
{
    public class UserAuthRepository : GenericRepository<UserAuth>, IUserAuthRepository
    {

        public UserAuthRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public Task<bool> Add(UserAuth entity)
        {
            throw new NotImplementedException();
        }

        public async Task<string> ChangeUserAuth(UserAuth userAuth, string crmBaseURL)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(crmBaseURL + "/api/changeUserAuth");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PATCH";
                //httpWebRequest.Headers.Add("Authorization", "Bearer " + token.RestClientWithAuth(cbsURL, cbsUser, cbsPass, grant_type));

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        UserGuid = userAuth.UserGuid,
                        Disable = userAuth.Disable
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

        public Task<bool> Update(UserAuth entity)
        {
            throw new NotImplementedException();
        }

    }
}