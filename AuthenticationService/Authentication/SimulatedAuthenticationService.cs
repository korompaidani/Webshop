using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

//TODO Json file handling and formatting must be separated
namespace CommonServices.Authentication
{
    public class SimulatedAuthenticationService : IAuthenticationService
    {
        private const string Uri = "https://api-test.com/api/Account/PostIsUserWithEmailExists";
        private KeyValuePair<string, string> _emailAndName;

        public bool IsEmailValid(string email)
        {
            var queryFromat = CreateValidQueryFormatFromEmail(email);
            var resultText = PostRequest(queryFromat).Result;
            return JsonResultProcessor(resultText);
        }

        // TODO thinking on a nice solution!
        // The problem is here that correct usage
        // is not forced by any pattern
        public void SetLoggedUser(KeyValuePair<string, string> emailAndName)
        {
            _emailAndName = emailAndName;
        }

        public KeyValuePair<string, string> GetLoggedUser()
        {
            return _emailAndName;
        }

        private static async Task<string> PostRequest(JObject json)
        {
            var jsonAsHttpContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsync(Uri, jsonAsHttpContent))
                {
                    using (HttpContent content = response.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }

        private JObject CreateValidQueryFormatFromEmail(string email)
        {
            return new JObject(
                new JProperty("UserDto",
                    new JObject(
                        new JProperty("EmailAddress", email)
                        )
                    )
                );
        }

        private bool JsonResultProcessor(string resultText)
        {
            try
            {
                JObject json = JObject.Parse(resultText);
                var answer = json.GetValue("UserWithEmailExists").ToString();
                return answer == "True" ? true : false;
            }
            catch
            {
                return false;
            }
        }       
    }
}
