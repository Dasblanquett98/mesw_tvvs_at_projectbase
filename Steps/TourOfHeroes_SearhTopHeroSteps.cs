using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace TVVS_SPECFLOW.Steps
{
    [Binding]
    public class TourOfHeroes_SearhTopHeroSteps
    {
        private IWebDriver Browser;
        String URL = "https://angular-tour-of-heroes-example-lijua1.stackblitz.io/";
        String DASH = "dashboard";

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

        [Given(@"That I'm in Dashboard view")]
        public void GivenThatIMInDashboardView()
        {
            // Navigate to URL
            this.Browser.Navigate().GoToUrl(URL + DASH);
            Thread.Sleep(1000);

            // Check Pre-Conditions
            Assert.IsNotNull(this.Browser.FindElement(By.XPath("/html/body/my-app/my-dashboard/h3")));
        }


        [When(@"I write a hero name '(.*)' in searchbar")]
        public void WhenIWriteAHeroNameInSearchbar(string p0)
        {
            Assert.IsNotNull(this.Browser.FindElement(By.Id("search-box")));
            this.Browser.FindElement(By.Id("search-box")).SendKeys(p0);

            Thread.Sleep(5000);

            Assert.IsNotNull(this.Browser.FindElement(By.ClassName("search-result")));
            this.Browser.FindElement(By.ClassName("search-result")).Click();
        }

        [Then(@"A Hero named ""(.*)"" should appear")]
        public void ThenAHeroNamedShouldAppear(string p0)
        {
            Assert.IsNotNull((this.Browser.FindElement(By.XPath(
                 String.Format("//*[contains(text(), '{0}')]", p0)))));
        }
    }
}
