using NUnit.Framework;

namespace AdvancedTaskMarsPart2.AssertHelpers
{
    public class EducationAssertHelper
    {
        public static void assertAddEducationSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertDeleteEducationSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }
    }
}
