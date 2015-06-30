using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using eComplianceAPIDemo.APIClient;

namespace eComplianceAPIDemo
{
    public class HttpHelper
    {
        private readonly APIConfiguration configuration;

        public HttpHelper(APIConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public byte[] DownloadData(string uri, NameValueCollection query = null)
        {
            try
            {
                using (var client = GenerateClient())
                {
                    client.QueryString = query;
                    return client.DownloadData(new Uri(new Uri(configuration.Server), uri));
                }
            }
            catch (WebException e)
            {
                HandleWebException(e, uri);
                throw;
            }
        }

        public byte[] UploadValues(string uri, NameValueCollection values)
        {
            try
            {
                using (var client = GenerateClient())
                    return client.UploadValues(
                        new Uri(new Uri(configuration.Server), uri),
                        WebRequestMethods.Http.Post,
                        values);
            }
            catch (WebException e)
            {
                HandleWebException(e, uri);
                throw;
            }
        }

        private WebClient GenerateClient()
        {
            var client = new WebClient();
            client.Headers["x-version"] = "1";
            client.Headers["x-site"] = Convert.ToString(configuration.CurrentSiteId);
            client.Headers["Authorization"] = "Bearer " + configuration.AuthToken;
            return client;
        }

        private static void HandleWebException(WebException e, string uri)
        {
            Console.WriteLine("Error while requesting " + uri);
            if (e.Response != null)
                using (var reader = new StreamReader(e.Response.GetResponseStream()))
                    Console.WriteLine(reader.ReadToEnd());
        }
    }
}