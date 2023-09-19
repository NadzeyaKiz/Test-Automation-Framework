using TestAutomation.Epam.API.Models.SharedModels.Tech;

namespace TestAutomation.Epam.API.Models.ResponceModels.Tech
{
    public class TechItemSingleResponseModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public TechData? data { get; set; }
    }
}
