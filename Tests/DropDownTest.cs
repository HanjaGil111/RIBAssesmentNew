using AutomationTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.Input;

namespace AutomationTests.Tests
{
    public class DropdownTest : BaseTest
    {
        private DropdownPage dropdownPage;

        [SetUp]
        public void SetUp()
        {
            NavigateTo("http://www.globalsqa.com/demo-site/select-dropdown-menu/");
            dropdownPage = new DropdownPage(driver);
        }

        [Test]
        public void TestSelectCountryFromDropdown()
        {
            bool passed = false;

            try
            {
                dropdownPage.SelectCountry("South Africa");
                Assert.That(dropdownPage.GetSelectedCountry(), Is.EqualTo("South Africa"), "The selected country is incorrect.");
                passed = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                SaveTestEvidence("SamplePageTest", passed);
    }
}
    }
}
