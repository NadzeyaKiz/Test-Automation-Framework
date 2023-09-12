using NuGet.Frameworks;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TestAutomation.Epam.API.Controllers;
using TestAutomation.Epam.API.ResponceModels;

namespace TestAutomation.Epam.API.Tests
{
    [TestFixture]
    public class BibleTests
    {
        [Test]
        public void CheckAllBiblesResponceWithValidParams()
        {
            var responce = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
            Assert.That(responce.responce.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to /v1/bibles");
             
        }

        [Test]
        public void CheckAllBiblesResponceWithoutAuthorization()
        {
            var responce = new BiblesController(new CustomRestClient(), string.Empty).GetBibles<RestResponse>();
            Assert.That(responce.responce.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status codewas returned while sending GET");
        }


        [Test]
        public void CheckAllBiblesResponceReturnesObject()
        {
            var responce = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>();
            CollectionAssert.IsNotEmpty(responce.Bibles.data, "Any bible should be returned after sending GET request to v1/bibles!");
        }
    }
}
