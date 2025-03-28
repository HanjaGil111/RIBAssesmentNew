using NUnit.Framework;
using OpenQA.Selenium;
using DragAndDropAutomation.Tests.Drivers;
using DragAndDropAutomation.Tests.Pages;
using AutomationTests.Tests;

namespace DragAndDropAutomation.Tests.Tests
{
    [TestFixture]
    public class DragAndDropTests : BaseTest
    {
        private DragAndDropPage dragAndDropPage;

        [SetUp]
        public void SetUp()
        {
            NavigateTo("http://www.globalsqa.com/demo-site/draganddrop/");
            dragAndDropPage = new DragAndDropPage(driver);
        }

        [Test]
        public void TestDragAndDrop()
        {
            bool passed = false;

            try
            {
                dragAndDropPage.PerformDragAndDrop();
                Assert.IsTrue(dragAndDropPage.IsDropped(), "The element was not dropped into the trash bin.");
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