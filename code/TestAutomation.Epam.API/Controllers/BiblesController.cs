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
        public BiblesController(CustomRestClient client, string apiKey) : base(client, Service.Bibles, apiKey)
        { 
        }

        public BiblesController(CustomRestClient client) : base(client, Service.Bibles, client._appConfig.ApiKey)
        {

        }

        private const string AllBiblesResourse = "/v1/bibles";

        /// <summary>
        /// Gets list of Bibles from API
        /// </summary>
        /// <typeparam name="T"><see cref="AllBiblesModel"/></typeparam>
        /// <returns>reponse info <see cref="RestResponse"/> and <see cref="AllBiblesModel"/></returns>
        public (RestResponse responce, T? Bibles) GetBibles<T>()
        {
            return Get<T>(AllBiblesResourse);
        }
    }
}
