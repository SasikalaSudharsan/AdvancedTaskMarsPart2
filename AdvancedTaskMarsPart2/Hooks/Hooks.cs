using AdvancedTaskMarsPart2.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AdvancedTaskMarsPart2.Hooks
{
    [Binding]
    public class Hooks : CommonDriver
    {
        public static ExtentReports extent;
        public static ExtentTest test;

        [BeforeTestRun]
        public static void ExtentStart()
        {
            extent = new ExtentReports();
            var SparkReporter = new ExtentSparkReporter("D:\\Sasikala\\MVP_Studio\\AdvancedTaskPart2\\AdvancedTaskMarsPart2\\AdvancedTaskMarsPart2\\ExtentReport\\ExtentReport.html");
            extent.AttachReporter(SparkReporter);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            test = extent.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            // Capture screenshot if scenario fails
            if (ScenarioContext.Current.TestError != null)
            {
                string scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
                Console.WriteLine($"Scenario '{scenarioTitle}' failed: {ScenarioContext.Current.TestError.Message}");
                CaptureScreenshot(scenarioTitle);
                test.Fail($"Scenario '{scenarioTitle}' failed: {ScenarioContext.Current.TestError.Message}");
            }
            else
            {
                test.Pass("Scenario passed");
            }
            driver.Quit();
        }

        [AfterTestRun]
        public static void ExtentClose()
        {
            extent.Flush(); 
        }

        public void CaptureScreenshot(string scenarioTitle)
        {
            string screenshotFileName = $"screenshot_{scenarioTitle}";
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string filePath = "D:\\Sasikala\\MVP_Studio\\AdvancedTaskPart2\\AdvancedTaskMarsPart2\\AdvancedTaskMarsPart2\\Screenshot";
            string screenshotPath = Path.Combine(filePath, $"{screenshotFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(screenshotPath);
        }
    }
}