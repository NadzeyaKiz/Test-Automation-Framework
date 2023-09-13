using NuGet.Frameworks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;
using System.Net;
using TestAutomation.Epam.API.Controllers;
using TestAutomation.Epam.API.Models.SharedModels.Bible;

namespace TestAutomation.Epam.API.Tests
{
    [TestFixture]
    public class BibleTests
    {
        [Test]
        public void CheckAllBiblesResponceWithValidParams()
        {
            var response = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
            Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET request to /v1/bibles!");
        }

        [Test]
        public void CheckAllBiblesResponseWithoutAuthorization()
        {
            var response = new BiblesController(new CustomRestClient(), string.Empty).GetBibles<BibleSummaryModel>();
            Assert.That(response.response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized), "Invalid status code was returned while sending GET request to /v1/bibles without authorization!");
        }

        [Test]
        public void CheckAllBiblesResponseReturnObject()
        {
            var response = new BiblesController(new CustomRestClient()).GetBibles<BibleSummaryModel>();
            CollectionAssert.IsNotEmpty(response.Bibles.data, "Any bible should be returned after sending GET request to /v1/bibles!");
        }
    }
}
