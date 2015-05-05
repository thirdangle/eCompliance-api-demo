using System;
using System.Collections.Specialized;
using System.Text;
using eComplianceAPIDemo.Models;
using Newtonsoft.Json;

namespace eComplianceAPIDemo.APIClient
{
    public class EComplianceClient
    {
        private readonly APIConfiguration configuration;
        private readonly HttpHelper httpHelper;

        public EComplianceClient(APIConfiguration configuration)
        {
            this.configuration = configuration;
            httpHelper = new HttpHelper(configuration);
        }

        public void GetSites()
        {
        }

        public void Authenticate()
        {
            var response = string.IsNullOrEmpty(configuration.ApiKey) ? LoginWithUsername() : LoginWithApiKey();
            var responseString = Encoding.UTF8.GetString(response);
            var tokenResponse = JsonConvert.DeserializeObject<AuthTokenResponse>(responseString);
            configuration.AuthToken = tokenResponse.Access_Token;
        }

        private byte[] LoginWithUsername()
        {
            Console.WriteLine("Authenticating with username/password");
            return httpHelper.UploadValues("/Token", new NameValueCollection
            {
                { "username", configuration.Username },
                { "password", configuration.Password },
                { "grant_type", "password" }
            });
        }

        private byte[] LoginWithApiKey()
        {
            Console.WriteLine("Authenticating with API key");
            return httpHelper.UploadValues("/Token", new NameValueCollection
            {
                { "ApiKey", configuration.ApiKey },
                { "grant_type", "password" }
            });
        }
    }
}