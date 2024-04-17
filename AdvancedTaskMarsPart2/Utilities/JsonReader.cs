using Newtonsoft.Json;

namespace AdvancedTaskMarsPart2.Utilities
{
    public class JsonReader
    {
        public static List<T> LoadData<T>(string jsonFileName)
        {
            string currentDirectory = "D:\\Sasikala\\MVP_Studio\\AdvancedTaskPart2\\AdvancedTaskMarsPart2\\AdvancedTaskMarsPart2";
            string filePath = Path.Combine(currentDirectory, "TestData", jsonFileName);
            using (StreamReader reader = new StreamReader(filePath))
            {
                var jsonContent = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(jsonContent);
            }
        }
    }
}
