using AutomationTests.Pages;
using NUnit.Framework;

namespace AutomationTests.Tests
{
    public class SampleFormTest : BaseTest
    {
        private SampleFormPage sampleFormPage;

        [SetUp]
        public void SetUp()
        {
            NavigateTo("http://www.globalsqa.com/samplepagetest/");
            sampleFormPage = new SampleFormPage(driver);
        }

        [Test]
        public void Test_FormSubmission()
        {
            bool passed = false;

            try
            {
                // Fill out the form
                sampleFormPage.EnterName("Jessica Jones");
                sampleFormPage.EnterEmail("jessica.jones@test.com");
                sampleFormPage.EnterWebsite("https://mytestsite.com");
                sampleFormPage.SelectExperience("1-3");
                sampleFormPage.SelectFunctionalTesting();
                sampleFormPage.SelectEducation("Graduate"); 
                sampleFormPage.EnterComments("This is a test");

                // Submit the form
                sampleFormPage.SubmitForm();

                // Verify submission success
                Assert.IsTrue(sampleFormPage.IsSubmissionSuccessful(), "Form Submission was unsuccesful");

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
