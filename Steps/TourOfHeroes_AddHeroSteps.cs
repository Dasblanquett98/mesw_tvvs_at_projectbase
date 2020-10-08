using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace TVVS_SPECFLOW.Steps
{
    [Binding]
    public class TourOfHeroes_AddHeroSteps
    {
        IWebDriver Browser;
        String URL = "https://angular-tour-of-heroes-example-lijua1.stackblitz.io/";
        String HEROES_SEARCH = "heroes";

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

        [Given(@"That I'm in Heroes view")]
        public void GivenThatIMInHeroesView()
        {
            // Navigate to URL
            this.Browser.Navigate().GoToUrl(URL + HEROES_SEARCH);
            Thread.Sleep(1000);

            // Check Pre-Conditions
            Assert.IsNotNull(this.Browser.FindElement(By.XPath("/html/body/my-app/my-heroes/h2")));
        }

        [When(@"I write a hero name '(.*)' AND I click Add")]
        public void WhenIWriteAHeroNameANDIClickAdd(string p0)
        {
            Assert.IsNotNull(this.Browser.FindElement(By.XPath("/html/body/my-app/my-heroes/div/input")));
            Assert.IsNotNull(this.Browser.FindElement(By.XPath("/html/body/my-app/my-heroes/div/button")));

            //write name
            this.Browser.FindElement(By.XPath("/html/body/my-app/my-heroes/div/input")).SendKeys(p0);
            //add
            this.Browser.FindElement(By.XPath("/html/body/my-app/my-heroes/div/button")).Click();

        }

        [Then(@"A Hero named '(.*)' should appear")]
        public void ThenAHeroNamedShouldAppear(string p0)
        {
            Assert.IsNotNull((this.Browser.FindElement(By.XPath(
                String.Format("//*[contains(text(), '{0}')]", p0)))));

        }
    }
}
