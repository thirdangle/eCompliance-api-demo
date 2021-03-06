﻿namespace eComplianceAPIDemo.APIClient
{
    public class APIConfiguration
    {
        public APIConfiguration(string server)
        {
            Server = server ?? "https://robotapi.ecompliance.com";
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public string Server { get; set; }

        public long CurrentSiteId { get; set; }
        public string AuthToken { get; set; }
    }
}
