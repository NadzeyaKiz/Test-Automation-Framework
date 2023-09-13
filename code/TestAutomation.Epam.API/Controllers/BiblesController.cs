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

        public BiblesController(CustomRestClient client) : base(client, Service.Bibles, client.AppConfig.ApiKey)
        {

        }

        private const string AllBiblesResourse = "/v1/bibles";
        private const string AudioBiblesResourse = "/v1/audio-bibles";
        private const string AudioBiblesIdResource = "/v1/audio-bibles/{audioBibleId}/books";

        /// <summary>
        /// Gets list of Bibles from API
        /// </summary>
        /// <typeparam name="T"><see cref="BibleSummaryModel"/></typeparam>
        /// <returns>response info <see cref="RestResponse"/> and <see cref="BibleSummaryModel"/></returns>
        public (RestResponse response, T? Bibles) GetBibles<T>()
        {
            return Get<T>(AllBiblesResourse);
        }

        /// <summary>
        /// Gets list of Bibles from API
        /// </summary>
        /// <typeparam name="T"><see cref="BibleSummaryModel"/></typeparam>
        /// <returns>reponse info <see cref="RestResponse"/> and <see cref="BibleSummaryModel"/></returns>
        public (RestResponse responce, T? Bibles) GetAudioBibles<T>()
        {
            var resp = Get<T>(AudioBiblesResourse);
            return resp;
        }

        /// <summary>
        /// Gets an array of Book objects for a given bibleId
        /// </summary>
        /// <typeparam name="T"><see cref="BibleSummaryModel"/></typeparam>
        /// <returns>reponse info <see cref="RestResponse"/> and <see cref="BibleSummaryModel"/></returns>
        public (RestResponse response, T? Bibles) GetBiblesByBibleId<T>(string bibleId)
        {
            string formattedResource = AudioBiblesIdResource.Replace("{audioBibleId}", $"{bibleId}");
            return Get<T>(formattedResource);
        }
    }
}
