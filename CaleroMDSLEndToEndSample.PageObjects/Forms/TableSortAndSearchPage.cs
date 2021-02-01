using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace CaleroMDSLEndToEndSample.PageObjects.Forms
{
    public class TableSortAndSearchPage
    {
        private readonly IWebDriver _driver;

        public TableSortAndSearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement isTableformpagedisplayed => _driver.FindElement(By.XPath($"//div[@class='col-md-6 text-left']//h2"));
        public IWebElement searchBox => _driver.FindElement(By.XPath("//*[@id='example_filter']/label/input"));
        public By filterResults = By.XPath("//*[@id='example']/thead/tr/th[1]");
        public By fieldValues = By.XPath("//*[@id='example']/tbody/tr//following-sibling::td[@class='sorting_1']");



        /// <summary>
        /// Navigate to the Input Form Submit Page
        /// </summary>
        public TableSortAndSearchPage Navigate()
        {
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/table-sort-search-demo.html");
            return this;
        }
        public bool IsTableFormDisplayed()
        {
            string text = isTableformpagedisplayed.Text;
            return text.Equals("Table Sort And Search Demo");
        }
        public void EnterfilterCriteria(string name)
        {
            searchBox.Click();
            searchBox.SendKeys(name);
        }
        public string[] GetFilterResults()

        {
            return ConvertElementsToText(filterResults);
        }
        public string[] ConvertElementsToText(By elements)
        {
            var itemList = GetAllElements(elements);
            return itemList.Select(i => i.Text).ToArray();
        }
        public ReadOnlyCollection<IWebElement> GetAllElements(By locator)
        {
            return _driver.FindElements(locator);
        }
        public string[] GetFieldValues()
        {
            return ConvertElementsToText(fieldValues);
        }

    }
}
