using NUnit.Framework;

namespace AdvancedTaskMarsPart2.AssertHelpers
{
    public class CertificationsAssertHelper
    {
        public static void assertAddCertificationSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }

        public static void assertDeleteCertificationSuccessMessage(String expected, String actual)
        {
            Assert.That(expected == actual, "Actual message and expected message do not match");
        }
    }
}
