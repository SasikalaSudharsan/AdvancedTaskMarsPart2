using AdvancedTaskMarsPart2.Model;
using Newtonsoft.Json;

namespace AdvancedTaskMarsPart2.Utilities
{
    public class PasswordManager
    {
        public void WriteNewPasswordToJson(string newPassword)
        {
            // Read existing JSON data from UserInformation.json
            string currentDirectory = "D:\\Sasikala\\MVP_Studio\\AdvancedTaskPart2\\AdvancedTaskMarsPart2\\AdvancedTaskMarsPart2";
            string filePath = Path.Combine(currentDirectory, "TestData", "UserInformation.json");
            string json = File.ReadAllText(filePath);
            List<UserInformation> userDataList = JsonConvert.DeserializeObject<List<UserInformation>>(json);

            // Find the user with the specified username
            UserInformation user = userDataList.FirstOrDefault(u => u.UserName == "sasi.ei34@gmail.com");

            if (user != null)
            {
                // Update the password
                user.Password = newPassword;

                // Serialize the updated data back to JSON
                string updatedJson = JsonConvert.SerializeObject(userDataList, Formatting.Indented);

                // Write the updated JSON back to the file
                File.WriteAllText(filePath, updatedJson);
            }
            else
            {
                Console.WriteLine("User not found in UserInformation.json");
            }
        }
    }
}
