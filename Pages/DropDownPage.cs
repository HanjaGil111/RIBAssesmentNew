using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.Pages
{
    public class DropdownPage
    {
        private IWebDriver driver;
        private By dropdownLocator = By.XPath("//select"); 

        public DropdownPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectCountry(string countryName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement dropdownElement = wait.Until(d => d.FindElement(dropdownLocator));

            // Select from dropdown
            SelectElement select = new SelectElement(dropdownElement);
            select.SelectByText(countryName);
        }

        public string GetSelectedCountry()
        {
            IWebElement dropdownElement = driver.FindElement(dropdownLocator);
            SelectElement select = new SelectElement(dropdownElement);
            return select.SelectedOption.Text;
        }
    }
}
