using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Epam.API
{
    public class CustomRestClient
    {
        public readonly AppConfiguration _appConfig = new();

        public CustomRestClient() 
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            config.Bind(_appConfig);
        }

        public RestClient CreateRestClient(Service servise)
        {
            var baseUrl = servise switch
                {
                Service.Bibles => _appConfig.BiblesBaseUrl,
                    Service.Tech => _appConfig.TechBaseUrl,
                    _=> throw new ArgumentException("Invalid service option provided!")
            };
            var options = new RestClientOptions(baseUrl);
            return new RestClient(options);
        }
    }
}
