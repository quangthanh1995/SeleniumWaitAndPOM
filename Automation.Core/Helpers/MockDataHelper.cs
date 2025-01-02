using Newtonsoft.Json;

namespace Automation.Core.Helpers
{
    public class MockDataHelper
    {
        public static dynamic LoadMockData(string filePath, string key)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The mock data file was not found: {filePath}");
            }

            var jsonData = File.ReadAllText(filePath);

            var data = JsonConvert.DeserializeObject<dynamic>(jsonData);

            return data[key];
        }
    }
}
