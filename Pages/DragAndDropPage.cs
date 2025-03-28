using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace DragAndDropAutomation.Tests.Pages
{
    public class DragAndDropPage
    {
        private IWebDriver driver;
        private By iframeLocator = By.XPath("//div[@rel-title='Photo Manager']//iframe");
        private By dragBox = By.XPath("//*[@id='gallery']/li[1]");
        private By dropBox = By.XPath("//*[@id='trash']");
        public DragAndDropPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void PerformDragAndDrop()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Wait for iframe and switch to it
            IWebElement iframeElement = wait.Until(ExpectedConditions.ElementIsVisible(iframeLocator));
            driver.SwitchTo().Frame(iframeElement);

            // Wait for elements to be present
            IWebElement source = wait.Until(ExpectedConditions.ElementIsVisible(dragBox));
            IWebElement target = wait.Until(ExpectedConditions.ElementIsVisible(dropBox));

            // Perform drag and drop
            Actions actions = new Actions(driver);
            actions.DragAndDrop(source, target).Perform();

            // Switch back to main page
            driver.SwitchTo().DefaultContent();
        }

        public bool IsDropped()
        {
            driver.SwitchTo().Frame(driver.FindElement(iframeLocator)); // Ensure inside iframe
            return driver.FindElements(dropBox).Count > 0;
            
    
        }
    }
}
