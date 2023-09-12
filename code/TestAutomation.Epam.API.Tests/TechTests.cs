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
    public class TechTests
    {
        [Test]
        public void CheckAllTechResponceWithValidParams()
        {
            var responce = new TechController(new CustomRestClient()).GetTech<RestResponse>();
            Assert.That(responce.responce.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code was returned while sending GET ");
        }

        [Test]
        public void CheckAllTechResponce()
        {
            var responce = new TechController(new CustomRestClient()).GetTech<List<AllObjectsModel>>();
            CollectionAssert.IsNotEmpty(responce.Tech, "Any object should be returned");
        }
    }
}
