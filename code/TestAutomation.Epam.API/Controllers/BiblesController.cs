using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Epam.API.Controllers
{
    /// <summary>
    /// Reponse model for 
    /// </summary>
    public class BiblesController : BaseController
    {
        public BiblesController(CustomRestClient client, string apiKey = "") : base(client, Service.Bibles, apiKey)
        { 
        }

        protected BiblesController(CustomRestClient client) : base(client, Service.Bibles, client._appConfig.ApiKey)
        {

        }

        private const string AllBiblesResourse = "/v1/bibles";

        /// <summary>
        /// Gets list of Bibles from API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>

        public (RestResponse responce, T? Bibles) GetBibles<T>()
        {
            return Get<T>(AllBiblesResourse);
        }
    }
}
