using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace TVVS_SPECFLOW.Features
{
    [Binding]
    public class DisplayingBookDetailsSteps
    {

        IWebDriver Browser;
        String URL = "https://localhost:44309/";
        String CATALOG_SEARCH = "Catalog/Search";

        [BeforeScenario]
        public void Init()
        {
            this.Browser = new ChromeDriver();
        }

        [AfterScenario]
        public void Close()
        {
            this.Browser.Close();
            this.Browser.Dispose();
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table table)
        {
            // Navigate to URL
            this.Browser.Navigate().GoToUrl(URL + CATALOG_SEARCH);
            Thread.Sleep(1000);

            // Check Pre-Conditions
            foreach (var row in table.Rows)
            {
                Assert.IsNotNull(this.Browser.FindElement(
                    By.XPath(
                        String.Format("//*[contains(text(), '{0}')]", row["Title"]
                        ))));
            }
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string p0)
        {
            // Open book details
            this.Browser.FindElement(By.XPath(
                String.Format("//*[contains(text(), '{0}')]", p0))).Click();
        }

        [Then(@"the book details should show")]
        public void ThenTheBookDetailsShouldShow(Table table)
        {
            // Check details values

            // Check price
            Assert.IsTrue(this.Browser.FindElement(
                By.Id("price")).Text.Contains(table.Rows[0]["Price"]));

            // Check author
            Assert.IsTrue(this.Browser.FindElement(
    By.Id("author")).Text.Contains(table.Rows[0]["Author"]));
            // Check Title
            Assert.IsTrue(this.Browser.FindElement(
By.Id("title")).Text.Contains(table.Rows[0]["Price"]));
        }
    }
}
