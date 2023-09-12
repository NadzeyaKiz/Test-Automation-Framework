using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Epam.API.Controllers
{
    public class AudioBiblesController : BaseController
    {
        public AudioBiblesController(CustomRestClient client, string apiKey = "") : base(client, Service.Bibles, apiKey)
        {
        }

        public AudioBiblesController(CustomRestClient client) : base(client, Service.Bibles, client._appConfig.ApiKey)
        {

        }

        private const string AudioBiblesResourse = "/v1/audio-bibles";

        /// <summary>
        /// Gets list of Bibles from API
        /// </summary>
        /// <typeparam name="T"><see cref="AudioBiblesModel"/></typeparam>
        /// <returns>reponse info <see cref="RestResponse"/> and <see cref="AudioBiblesModel"/></returns>
        public (RestResponse responce, T? Bibles) GetBibles<T>()
        {
            return Get<T>(AudioBiblesResourse);
        }
    }
}
