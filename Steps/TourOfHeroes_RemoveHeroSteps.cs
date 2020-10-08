using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace TVVS_SPECFLOW.Steps
{
    [Binding]
    public class TourOfHeroes_RemoveHeroSteps
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
        [Given(@"That Im in Heroes view and '(.*)' is shown")]
        public void GivenThatITornadoIsShown(string p0)
        {
            // Navigate to URL
            this.Browser.Navigate().GoToUrl(URL + HEROES_SEARCH);
            Thread.Sleep(1000);

            // Check Pre-Conditions
            Assert.IsNotNull(this.Browser.FindElement(By.XPath("/html/body/my-app/my-heroes/h2")));

            Assert.IsNotNull((this.Browser.FindElement(By.XPath(
String.Format("//*[contains(text(), '{0}')]", "m9")))));


        }

        [When(@"when I click delete near the'(.*)' name")]
        public void WhenWhenIClickDeleteNearTheName(string p0)
        {
            Assert.IsNotNull((this.Browser.FindElement(By.XPath(
String.Format("//*[contains(text(), '{0}')]/..//button", "m9")))));

            this.Browser.FindElement(By.XPath(
String.Format("//*[contains(text(), '{0}')]/..//button", "m9"))).Click();

        }
        [Then(@"'(.*)'shouldn't be in My Heroes list")]
        public void ThenShouldnTBeInMyHeroesList(string p0)
        {
            Assert.IsNull((this.Browser.FindElement(By.XPath(
String.Format("//*[contains(text(), '{0}')]", "m9")))));
        }
    }
}
