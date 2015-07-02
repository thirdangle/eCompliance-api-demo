using System;
using System.Collections.Specialized;
using System.Text;
using eComplianceAPIDemo.Models;
using EC.Builder.API.DTOs.Employee;
using EC.Builder.API.DTOs.Inspection;
using EC.Builder.API.DTOs.Site;
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

        public SiteListingResponseDto GetSites()
        {
            var url = configuration.Server + "/sites";
            var response = httpHelper.DownloadData(url);
            var responseString = Encoding.UTF8.GetString(response);
            return JsonConvert.DeserializeObject<SiteListingResponseDto>(responseString);
        }

        public InspectionListingResponseDto GetForms(string formType)
        {
            var url = configuration.Server + "/" + formType;
            var response = httpHelper.DownloadData(url);
            var responseString = Encoding.UTF8.GetString(response);
            return JsonConvert.DeserializeObject<InspectionListingResponseDto>(responseString);
        }

        public EmployeeListingResponseDto GetEmployees()
        {
            var url = configuration.Server + "/employees";
            var response = httpHelper.DownloadData(url);
            var responseString = Encoding.UTF8.GetString(response);
            return JsonConvert.DeserializeObject<EmployeeListingResponseDto>(responseString);
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