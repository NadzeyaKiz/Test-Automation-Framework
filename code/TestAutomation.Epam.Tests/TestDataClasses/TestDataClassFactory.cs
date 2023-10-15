using TestAutomation.Utilities;

namespace TestAutomation.Epam.Tests.TestDataClasses
{
    public static class TestDataClassFactory
    {
        public static List<T> GetTestData<T>(string fileName) where T : class
        {
            Logger.Info($"Parsing test data from file TestData\\{fileName}");
            if (!File.Exists($"TestData\\{fileName}"))
            {
                throw new Exception($"File does not exist 'TestData\\{fileName}'");
            }

            try
            {
                var json = File.ReadAllText($"TestData\\{fileName}");
                return JsonParser.DeserializeJsonToList<T>(json);
            }
            catch (Exception ex)
            {
                Logger.Info($"Parsing test data from file TestData\\{fileName} failed with exception");
                throw;
            }
        }
    }
}
