using System;
using eComplianceAPIDemo.APIClient;
using EC.Builder.API.DTOs.Site;

namespace eComplianceAPIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = args.Length > 0 ? args[0] : null;
            new Program(server).Run();
        }

        private readonly APIConfiguration configuration;
        private EComplianceClient client;

        public Program(string server)
        {
            configuration = new APIConfiguration(server);
            Console.WriteLine("Connecting to {0} ...", configuration.Server);
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
            DisplayEmployees();
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

        private void DisplayEmployees()
        {
            var employees = client.GetEmployees();
            WriteTitle(string.Format("{0} employees", employees.PagingInfo.TotalNumberOfItems));
            foreach (var employee in employees.Values)
            {
                Console.WriteLine("{0} {1} <{2}>", employee.FirstName, employee.LastName, employee.EmailAddress);
            }

            if (employees.PagingInfo.TotalNumberOfItems > employees.PagingInfo.PageSize)
                Console.WriteLine("plus {0} more", employees.PagingInfo.TotalNumberOfItems - employees.PagingInfo.PageSize);
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
