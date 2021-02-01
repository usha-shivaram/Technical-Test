using CaleroMDSLEndToEndSample.PageObjects.Forms;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace CaleroMDSLEndToEndSample.Tests.Bindings
{
    [Binding]
    public class FormBindings
    {
        InputFormSubmitPage inputPage;
        private readonly IWebDriver _driver;

        public FormBindings(IWebDriver driver)
        {
            _driver = driver;
            inputPage = new InputFormSubmitPage(_driver);
        }

        [Given(@"that I am viewing the Input Form Demo page")]
        public void GivenThatIAmViewingTheInputFormDemoPage()
        {
            new InputFormSubmitPage(_driver).Navigate();
            Assert.IsTrue(inputPage.IsInputFormPageDisplayed(), "Input form with validations");
        }

        [Then(@"I should be able to complete all the fields on the form and submit it")]
        public void ThenIShouldBeAbleToCompleteAllTheFieldsOnTheFormAndSubmitIt(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                string field = row.Values.ToList().FirstOrDefault();
                string value = row.Values.ElementAtOrDefault(1);
                inputPage.EnterFieldValue(field, value);        
            }
        }

        [Then(@"I click on Send button")]
        public void ThenIClickOnSendButton()
        {
            inputPage.ClickSendButton();
        }  

    }
}
