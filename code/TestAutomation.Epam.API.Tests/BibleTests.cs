using NUnit.Framework;
using RestSharp;
using System.Net;
using TestAutomation.Epam.API.Controllers;

namespace TestAutomation.Epam.API.Tests
{
    [TestFixture]
    public class BibleTests
    {
        [Test]
        public void CheckAllBiblesResponceWithValidParams()
        {
            var responce = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
            Assert.That(responce.responce.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET ");

        }
    }
}
