using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DragAndDropAutomation.Tests.Drivers
{
    public class WebDriverManager
    {
        private IWebDriver? driver;

        public IWebDriver GetDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public void QuitDriver()
        {
            driver?.Quit();
        }
    }
}
