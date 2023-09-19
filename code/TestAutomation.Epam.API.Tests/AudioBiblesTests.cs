using NUnit.Framework;
using RestSharp;
using System.Net;
using TestAutomation.Epam.API.Controllers;
using TestAutomation.Epam.API.Models.ResponceModels.Tech;
using TestAutomation.Epam.API.Models.SharedModels.Bible;
using System.Linq;

namespace TestAutomation.Epam.API.Tests
{
    [TestFixture]
    public class AudioBiblesTests
    {
        [Test]
        //Task2 API(2)
        public void CheckAudioBiblesResponceWithValidParams()
        {
            var response = new BiblesController(new CustomRestClient()).GetAudioBibles<RestResponse>();
            Assert.That(response.responce.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to /v1/audio-bibles");
        }

        [Test]
        //Task4 API(2)
        public void CheckAudioBiblesResponceWithoutAuthorization()
        {
            var response = new BiblesController(new CustomRestClient(), string.Empty).GetAudioBibles<RestResponse>();
            Assert.That(response.responce.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status codewas returned while sending GET");
        }
        
        [Test]
        //Task3 API(2)
        public void CheckAudioBiblesIdResponceWithValidParams()
        {
            var responseBooks = new BiblesController(new CustomRestClient()).GetAudioBibles<BibleSummaryModel>();
            var randomId = responseBooks.Bibles.data.FirstOrDefault().Id;
            var response = new BiblesController(new CustomRestClient()).GetBiblesByBibleId<RestResponse>(randomId);
            Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to '/v1/audio-bibles/{audioBibleId}/books'.");
        }

    }
}
