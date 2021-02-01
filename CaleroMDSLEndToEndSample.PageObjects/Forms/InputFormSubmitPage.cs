using OpenQA.Selenium;
using System.Threading;


namespace CaleroMDSLEndToEndSample.PageObjects.Forms
{
    public class InputFormSubmitPage
    {
        private readonly IWebDriver _driver;
        
        public InputFormSubmitPage(IWebDriver driver)
        {
            _driver = driver;
        }

        //private IWebElement FirstNameTextBox => _driver.FindElement(By.Name("first_name"));
        public IWebElement GetFieldByLabel(string field) => _driver.FindElement(By.XPath($"//*[@id='contact_form']/fieldset/div/label[contains(text(),'{field}')]//following-sibling::div//input|//*[@id='contact_form']/fieldset/div/label[contains(text(),'{field}')]//following-sibling::div//select|//*[@id='contact_form']/fieldset/div/label[contains(text(),'{field}')]//following-sibling::div//textarea"));
        public IWebElement sendButton => _driver.FindElement(By.XPath("//*[@id='contact_form']//button"));
        public IWebElement inputFormPage => _driver.FindElement(By.XPath("//div[@class='col-md-6 text-left']//h2"));

        /// <summary>
        /// Navigate to the Input Form Submit Page
        /// </summary>
        public InputFormSubmitPage Navigate()
        {
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/input-form-demo.html");
            return this;
        }
        public bool IsInputFormPageDisplayed()
        {
            string text = inputFormPage.Text;
            return text.Equals("Input form with validations");
        }
        public void EnterFieldValue(string field, string value)
        {
            IWebElement label = GetFieldByLabel(field); 
            label.SendKeys(value);               
            Thread.Sleep(2000);
        }
        public void ClickSendButton()
        {
            sendButton.Click();
        }
       
    }
}
