using System;
using eComplianceAPIDemo.APIClient;
using EC.Builder.API.DTOs.Site;

namespace eComplianceAPIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        private readonly APIConfiguration configuration;
        private EComplianceClient client;

        public Program()
        {
            configuration = new APIConfiguration();
            configuration.Server = "https://rcapi.ecompliance.com";
        }

        private void Run()
        {
            Configure();
            LogIn();
            ChooseSite();
            DisplaySites();
        }

        private void Configure()
        {
            Console.WriteLine("Enter API key (recommended) or eCompliance username");
            var identifier = Console.ReadLine();
            if (IsEmailAddress(identifier))
            {
                configuration.Username = identifier;
                Console.WriteLine("Enter password");
                configuration.Password = Console.ReadLine();
            }
            else
            {
                configuration.ApiKey = identifier;
            }

            client = new EComplianceClient(configuration);
        }

        private void LogIn()
        {
            client.Authenticate();
            Console.WriteLine("Authentication successful");
        }

        private void ChooseSite()
        {
            Console.WriteLine("Enter site ID");
            var siteIdString = Console.ReadLine();
            configuration.CurrentSiteId = long.Parse(siteIdString);
        }

        private void DisplaySites()
        {
            var sites = client.GetSites();
            foreach (var site in sites.Values)
                DisplayOrg(site);
        }

        private void DisplayOrg(OrganizationDto organization)
        {
            Console.WriteLine("Organization: " + organization.Name);
            foreach (var site in organization.Sites)
                Console.WriteLine(" - " + site.Name);
        }

        private bool IsEmailAddress(string identifier)
        {
            // Not a real email validation, but API keys don't contain
            // the @ symbol, so close enough
            return identifier.Contains("@");
        }
    }
}
