using System;
using eComplianceAPIDemo.APIClient;
using EC.Builder.API.DTOs.Site;

namespace eComplianceAPIDemo
{
    class Program
    {
        static void Main()
        {
            new Program().Run();
        }

        private readonly APIConfiguration configuration;
        private EComplianceClient client;

        public Program()
        {
            configuration = new APIConfiguration();
        }

        private void Run()
        {
            Configure();
            LogIn();
            ChooseSite();
            DisplaySites();
            DisplayForms(FormTypes.Inspections);
            DisplayForms(FormTypes.Meetings);
            DisplayForms(FormTypes.Incidents);
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
            WriteTitle("Sites in organization: " + organization.Name);
            foreach (var site in organization.Sites)
                Console.WriteLine(site.Name);
        }

        private void DisplayForms(string formType)
        {
            var forms = client.GetForms(formType);
            WriteTitle(string.Format("{0} {1}", forms.PagingInfo.TotalNumberOfItems, formType));
            foreach (var inspectionSummary in forms.Values)
            {
                Console.WriteLine("{0} {1}", inspectionSummary.CreatedDate, inspectionSummary.Title);
            }

            if (forms.PagingInfo.TotalNumberOfItems > forms.PagingInfo.PageSize)
                Console.WriteLine("plus {0} more", forms.PagingInfo.TotalNumberOfItems - forms.PagingInfo.PageSize);
        }

        private static void WriteTitle(string text)
        {
            Console.WriteLine();
            Console.WriteLine(text);
            Console.WriteLine(new string('=', text.Length));
        }

        private bool IsEmailAddress(string identifier)
        {
            // Not a real email validation, but API keys don't contain
            // the @ symbol, so close enough
            return identifier.Contains("@");
        }
    }
}
