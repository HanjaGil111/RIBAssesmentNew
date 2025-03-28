using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);

        }
        protected void SaveTestEvidence(string testName, bool isSuccess)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string folderPath = Path.Combine("TestEvidence", $"{testName}_{timestamp}");
            Directory.CreateDirectory(folderPath);

            // Save Screenshot 
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotPath = Path.Combine(folderPath, "screenshot.png");
            screenshot.SaveAsFile(screenshotPath);

            // Save Result
            string resultPath = Path.Combine(folderPath, "result.txt");
            string resultText = isSuccess ? "Test PASSED" : "Test FAILED";
            File.WriteAllText(resultPath, resultText);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}