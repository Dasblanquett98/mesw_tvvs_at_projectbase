using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace TVVS_SPECFLOW.Steps
{
    [Binding]
    public class TourOfHeroes_CheckTopHeroesSteps
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
        [Given(@"That Im in Dashboard view AND I have the Hero '(.*)'")]
        public void GivenThatImInDashboardViewANDIHaveTheHero(string p0)
        {
            // Navigate to URL
            this.Browser.Navigate().GoToUrl(URL + DASH);
            Thread.Sleep(1000);

            // Check Pre-Conditions
            Assert.IsNotNull(this.Browser.FindElement(By.XPath("/html/body/my-app/my-dashboard/h3")));

            string[] heroes = p0.Split(",");

            foreach(String hero in heroes)
            {
                Assert.IsNotNull((this.Browser.FindElement(By.XPath(
     String.Format("//*[contains(text(), '{0}')]", hero)))));
            }
        }
        
        [When(@"I Click'(.*)'")]
        public void WhenIClick(string p0)
        {
            this.Browser.FindElement(By.XPath(
                 String.Format("//*[contains(text(), '{0}')]", p0))).Click();
        }
        
        [Then(@"Mr\.Nice Information should appear with Id > (.*) and Name as'(.*)'")]
        public void ThenMr_NiceInformationShouldAppearWithIdAndNameAs(int p0, string p1)
        {
            Assert.IsNotNull((this.Browser.FindElement(By.XPath(
                String.Format("//*[contains(text(), '{0}')]", p1)))));
        }
    }
}
