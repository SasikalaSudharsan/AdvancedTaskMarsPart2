using NUnit.Framework;

namespace AdvancedTaskMarsPart2.AssertHelpers
{
    public class DescriptionAssertHelper
    {
        public static void assertAddDescriptionSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }
    }
}
