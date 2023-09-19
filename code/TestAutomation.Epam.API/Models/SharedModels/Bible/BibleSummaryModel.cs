
using Newtonsoft.Json;

namespace TestAutomation.Epam.API.Models.SharedModels.Bible
{
    public class BibleSummaryModel
    {
        public Bible[] data { get; set; }
    }

    public class Bible
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("dbl Id")]
        public string DblId { get; set; }
        public string abbreviation { get; set; }
        public string abbreviationLocal { get; set; }
        public Language language { get; set; }
        public Country[] countries { get; set; }
        public string name { get; set; }
        public string nameLocal { get; set; }
        public string description { get; set; }
        public string descriptionLocal { get; set; }
        public string relatedDbl { get; set; }
        public string type { get; set; }
        public DateTime updatedAt { get; set; }
        public Audiobible[] audioBibles { get; set; }
    }

    public class Language
    {
        public string id { get; set; }
        public string name { get; set; }
        public string nameLocal { get; set; }
        public string script { get; set; }
        public string scriptDirection { get; set; }
    }

    public class Country
    {
        public string id { get; set; }
        public string name { get; set; }
        public string nameLocal { get; set; }
    }

    public class Audiobible
    {
        public string id { get; set; }
        public string name { get; set; }
        public string nameLocal { get; set; }
        public string description { get; set; }
        public string descriptionLocal { get; set; }
    }
}
