using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace CaleroMDSLEndToEndSample.Tests
{
    [Binding]
    public class SpecflowHooks
    {
        private readonly IObjectContainer _objectContainer;

        public SpecflowHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
                throw new ArgumentNullException(nameof(scenarioContext));

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test");
            driver.Manage().Window.Maximize();

            _objectContainer.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _objectContainer.Resolve<IWebDriver>();

            driver.Quit();
            driver.Dispose();

            _objectContainer.Dispose();
        }
    }
}
