using NUnit.Framework;
using RestSharp;
using System.Net;
using TestAutomation.Epam.API.Controllers;
using TestAutomation.Epam.API.Models.RequestModels;
using TestAutomation.Epam.API.Models.ResponceModels.Tech;
using TestAutomation.Epam.API.Models.SharedModels.Tech;

namespace TestAutomation.Epam.API.Tests
{
    [TestFixture]
    public class TechTests
    {
        [Test]
        //Task5 API(2)
        public void VerifyTechResponse()
        {
            var response = new TechController(new CustomRestClient()).GetTechItems<List<TechItemSingleResponseModel>>();
            Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Invalid status code data!");
        }

        [Test]
        //Task6 API(2)
        public void VerifyListOfObjectsContainsCorrectNumberOfItems()
        {
            var expectedNumberOfItems = 13;
            var response = new TechController(new CustomRestClient()).GetTechItems<List<TechItemSingleResponseModel>>();

            Assert.That(response.TechModel?.Any(), Is.True, "Invalid data!");

            var actualNumberOgItems = response.TechModel.Select(x =>x.id).ToList().Count();

            Assert.That(expectedNumberOfItems, Is.EqualTo(actualNumberOgItems),
                $"The list of objects does not contain expected number of items '{expectedNumberOfItems}' but contains '{actualNumberOgItems}'");
        }

        [Test]
        //Task2 API(3)
        public void VerifyCapacityOFCreatedObject()
        {
            var techItem = new TechItemRequestModel()
            {
                name = "apple MacBook Pro 16",
                data = new TechData
                {
                    Capacity = "1234 GB",
                    CpuModel = "Intel Core i9",
                    HardDiskSize = "1 TB",
                    Price = (float)1867.99,
                    Year = 2019
                }
            };
            var createdItem =
                new TechController(new CustomRestClient()).AddTechItem<TechItemCreatedResponseModel>(techItem)
                    .TechModel;

            var receivedItem = new TechController(new CustomRestClient()).GetSingleTechItem<TechItemSingleResponseModel>(createdItem.id).TechModel;
            var receivedItemCapacity = receivedItem.data.Capacity;
            var receivedItemId = receivedItem.id;
            Assert.That(techItem.data.Capacity, Is.EqualTo(receivedItemCapacity), 
                $"The capacity of the created object {receivedItemCapacity} is equal to initial one {techItem.data.Capacity}");

            new TechController(new CustomRestClient()).DeleteSingleCreatedItem(receivedItemId);
        }

        [Test]
        //Task3 API(3)
        public void VerifyDeletedItemIsNotPresent()
        {
            var techItem = new TechItemRequestModel()
            {
                name = "Nadya Test Phone",
                data = new TechData
                {
                    Capacity = "1234 GB",
                    CpuModel = "Intel Core i9",
                    HardDiskSize = "1 TB",
                    Price = (float)9999.99,
                    Year = 2023
                }
            };
            var createdItem =
                new TechController(new CustomRestClient()).AddTechItem<TechItemCreatedResponseModel>(techItem)
                    .TechModel;

            var createdItemId = createdItem.id;
            new TechController(new CustomRestClient()).DeleteSingleCreatedItem(createdItemId);
            var response = new TechController(new CustomRestClient()).GetSingleTechItem<TechItemSingleResponseModel>(createdItem.id);

            Assert.That(response.Response.StatusCode.Equals(HttpStatusCode.NotFound), 
                $"The actual statuse {response.Response.StatusCode} is not equal to the expected 'NotFound'");
        }

        [Test]
        public void VerifyPatchOfProperty()
        {
            var techItem = new TechItemRequestModel()
            {
                name = "Nadya Test Phone",
                data = new TechData
                {
                    Capacity = "1234 GB",
                    CpuModel = "Intel Core i9",
                    HardDiskSize = "1 TB",
                    Price = (float)9999.99,
                    Year = 2023
                }
            };
            var createdItem =
                new TechController(new CustomRestClient()).AddTechItem<TechItemCreatedResponseModel>(techItem)
                    .TechModel;
            var createdItemId = createdItem.id;

            var updatedProperty = new
            {
                data = new
                {
                    Capacity = "12340 GB UPDATED"
                }
            };

            var updatedItem =
                new TechController(new CustomRestClient()).UpdateTechItem<TechItemCreatedResponseModel>(updatedProperty, createdItemId)
                .TechModel;
            var updatedItemCapacity = updatedItem.data.Capacity;

            Assert.That(updatedItemCapacity, Is.EqualTo(updatedProperty.data.Capacity), 
                $"The created item with 'Capacity' property of '{techItem.data.Capacity}' was updated." +
                $"The updated property '{updatedProperty.data.Capacity}' is not equal to '{updatedItem.data.Capacity}'");

            new TechController(new CustomRestClient()).DeleteSingleCreatedItem(updatedItem.id);
        }

        [Test]
        public void VerifyAllTechItemsAreReturned()
        {
            var response = new TechController(new CustomRestClient()).GetTechItems<List<TechItemSingleResponseModel>>();
            Assert.That(response.TechModel?.Any(), Is.True, "Invalid data!");
        }        
    }
}