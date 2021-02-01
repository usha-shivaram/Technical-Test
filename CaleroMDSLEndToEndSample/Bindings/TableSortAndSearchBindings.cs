using CaleroMDSLEndToEndSample.PageObjects.Forms;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;

namespace CaleroMDSLEndToEndSample.Tests.Bindings
{
    [Binding]
    public class TableSortAndSearchBindings
    {
        TableSortAndSearchPage searchPage;
        private readonly IWebDriver _driver;

        public TableSortAndSearchBindings(IWebDriver driver)
        {
            _driver = driver;
            searchPage = new TableSortAndSearchPage(_driver);
        }

        [Given(@"that I am viewing the Table Sort And Search Demo Page")]
        public void GivenThatIAmViewingTableSortAndSearchDemoThePage()
        {
            new TableSortAndSearchPage(_driver).Navigate();
            Assert.IsTrue(searchPage.IsTableFormDisplayed(), "Table Sort And Search Demo page not displayed ");
        }

        [Then(@"the following (.*) people should be listed in the (.*) office")]
        public void ThenTheFollowingPeopleShouldBeListedInTheSanFranciscoOffice(int resultCount, string filterCriteria, Table table)
        {
            searchPage.EnterfilterCriteria(filterCriteria);
            string[] fieldLabels = searchPage.GetFilterResults();    
            string[] fieldValues = searchPage.GetFieldValues();             
            string[] values = table.Rows.Select(r => r.Values.ToList().FirstOrDefault()).ToArray(); 
            Assert.IsTrue(values.SequenceEqual(fieldValues), " Employees name do not match"); 
            Assert.AreEqual(resultCount, values.Count(), resultCount + " Employees Count doesn't match");
        }
       
    }
}

