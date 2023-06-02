using Nancy.Json;
using Newtonsoft.Json;
using SPL.Data;
using SPL.IRepositories;
using SPL.Models;
using System.Net;

namespace SPL.Repositories
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {

        public BranchRepository(
            SPLDatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }
        public async Task<string> CreateBranch(Branch branch, string crmBaseURL)
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
                        ParentCompany = branch.ParentCompany,
                        Name = branch.Name,
                        ShortAddress = branch.ShortAddress,
                        BuildingNumber = branch.BuildingNumber,
                        AdditionalNumber = branch.AdditionalNumber,
                        ZipCode = branch.ZipCode,
                        FirstName = branch.FirstName,
                        LastName = branch.LastName,
                        Email = branch.Email,
                        NationalId = branch.NationalId,
                        MobileNumber = branch.MobileNumber
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
