using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationTests.Pages
{
    public class SampleFormPage
    {
        private IWebDriver driver;
        private Actions actions;

        private By nameField = By.Id("g2599-name");
        private By emailField = By.Id("g2599-email");
        private By websiteField = By.Id("g2599-website");
        private By experienceDropdown = By.Id("g2599-experienceinyears");
        private By functionalTestingCheckbox = By.XPath("//input[@value='Functional Testing']");
        private By educationRadioButton(string value) => By.XPath($"//input[@name='g2599-education' and @value='{value}']");
        private By commentsField = By.Id("contact-form-comment-g2599-comment");
        private By submitButton = By.XPath("//button[text()='Submit']");
        private By confirmationMessage = By.XPath("//h3[contains(text(),'Message Sent')]");

        // Constructor
        public SampleFormPage(IWebDriver driver)
        {
            this.driver = driver;
            this.actions = new Actions(driver);
        }

        // Methods to interact with the form
        public void EnterName(string name)
        {
            driver.FindElement(nameField).SendKeys(name);
            actions.SendKeys(Keys.Tab).Perform();
        }

        public void EnterEmail(string email)
        {
            driver.FindElement(emailField).SendKeys(email);
            actions.SendKeys(Keys.Tab).Perform();
        }

        public void EnterWebsite(string website)
        {
            driver.FindElement(websiteField).SendKeys(website);
            actions.SendKeys(Keys.Tab).Perform();
        }

        public void SelectExperience(string experience)
        {
            driver.FindElement(experienceDropdown).SendKeys(experience);
        }

        public void SelectFunctionalTesting()
        {
            driver.FindElement(functionalTestingCheckbox).Click();

        }
        public void SelectEducation(string education)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            // Hide ad iframe if present
            js.ExecuteScript("let ad = document.getElementById('aswift_7_host'); if(ad) ad.style.display = 'none';");

            IWebElement radioButton = driver.FindElement(educationRadioButton(education));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", radioButton);
            js.ExecuteScript("arguments[0].click();", radioButton);
        }

        public void EnterComments(string comment)
        {
            driver.FindElement(commentsField).SendKeys(comment);
        }

        public void SubmitForm()
        {
            driver.FindElement(submitButton).Click();
        }
        public bool IsSubmissionSuccessful()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Wait for the element to exist first
                IWebElement confirmation = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                    .ElementExists(By.XPath("//h3[contains(text(),'Message Sent')]")));

                // Scroll to the element
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", confirmation);

                // Wait for it to be visible
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.XPath("//h3[contains(text(),'Message Sent')]")));

                return confirmation.Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
 }
