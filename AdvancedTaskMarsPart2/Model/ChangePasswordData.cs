
namespace AdvancedTaskMarsPart2.Model
{
    public class ChangePasswordData
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string ExpectedMessage { get; set; }
    }
}
