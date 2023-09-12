using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Epam.API.Controllers;
using TestAutomation.Epam.API.ResponceModels;

namespace TestAutomation.Epam.API.Tests
{
    [TestFixture]
    public class AudioBiblesTests
    {
        [Test]
        public void CheckAudioBiblesResponceWithValidParams()
        {
            var responce = new AudioBiblesController(new CustomRestClient()).GetBibles<RestResponse>();
            Assert.That(responce.responce.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to /v1/audio-bibles");

        }

        [Test]
        public void CheckAudioBiblesResponceWithoutAuthorization()
        {
            var responce = new AudioBiblesController(new CustomRestClient(), string.Empty).GetBibles<RestResponse>();
            Assert.That(responce.responce.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status codewas returned while sending GET");
        }

        [Test]
        public void CheckAudioBiblesResponceReturnesID()
        {
            var responce = new AudioBiblesController(new CustomRestClient()).GetBibles<List<AudioBiblesModel>>();
            CollectionAssert.IsNotEmpty(responce.Bibles.data, "Any bible should be returned after sending GET request to v1/bibles!");
                        
        }
    }
}
