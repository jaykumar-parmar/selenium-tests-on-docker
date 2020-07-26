using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest
{
    [TestClass]
    public class AngularTableTest
    {
        private RemoteWebDriver _driver;
        
        [TestInitialize]
        public void TestInitialize()
        {
            var options = new ChromeOptions();
            
            var remoteWebDriverUrl = "http://standalone-chrome:4444/wd/hub";
            
            _driver = new RemoteWebDriver(new Uri(remoteWebDriverUrl), options);

            IWait<IWebDriver> wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30.00));
            wait.Until(driver1 => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://web-app:4200/");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TestMethod]
        public void Test_Table_Paginator_Should_Bring_Page_2_Data()
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                var nextButton = _driver.FindElementByClassName("mat-paginator-navigation-next");
                nextButton.Click();

                var tableBody = _driver.FindElementByTagName("tbody");
                var rows = tableBody.FindElements(By.TagName("tr"));
                
                var firstRow = rows[0];
                var firstRowNumber = firstRow.FindElements(By.TagName("td"))[0];

                var lastRow = rows[4];
                var lastRowNumber = lastRow.FindElements(By.TagName("td"))[0];

                Assert.AreEqual("6", firstRowNumber.Text.Trim());
                Assert.AreEqual("10", lastRowNumber.Text.Trim());
                //var paginatorLabel = _driver.FindElementByClassName("mat-paginator-range-label");
                //var expectedString = "6 - 10 of 20";
                //Assert.AreEqual(paginatorLabel.Text, expectedString);
            }
            finally
            {
                _driver.Quit();
            }
        }
    }
}




