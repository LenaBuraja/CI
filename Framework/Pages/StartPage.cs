using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Framework.Pages
{
    class StartPage
    {
        private const string BASE_URL = "http://avia-booking.com/";

        [FindsBy(How = How.XPath, Using = "//input[@id='origin_name']")]
        private IWebElement originName;

        [FindsBy(How = How.XPath, Using = "//input[@id='destination_name']")]
        private IWebElement destinationName;

        [FindsBy(How = How.XPath, Using = "//label[@for='infants']/../span/div/div")]
        private IWebElement countBabies;

        [FindsBy(How = How.XPath, Using = "//span[@class='avs_ac_iata'][contains(.,'MSQ')]")]
        private IWebElement airportOrigin;

        [FindsBy(How = How.XPath, Using = "//span[@class='avs_ac_iata'][contains(.,'PAR')]")]
        private IWebElement airportDestination;

        [FindsBy(How = How.XPath, Using = "//div[@class='bottomSubmit']")]
        private IWebElement form;

        [FindsBy(How = How.XPath, Using = "//input[@id='submit']")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'date')][@name='depart_date']")]
        private IWebElement departDate;

        [FindsBy(How = How.XPath, Using = "//input[@id='return_date']")]
        private IWebElement returnDate;

        [FindsBy(How = How.XPath, Using = "//div[@class='datePickers secondDiv aviasales_error_field_container']/img[@class='ui-datepicker-trigger']")]
        private IWebElement returnDateCalendar;

        [FindsBy(How = How.XPath, Using = "//div[@class='datePickers firstDiv aviasales_error_field_container']/img[@class='ui-datepicker-trigger']")]
        private IWebElement departDateCalendar;

        private IWebDriver driver;

        public StartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void setCitiesOriginAndDestination(string cityOrigin, string cityDestination)
        {
            originName.Click();
            originName.SendKeys(cityOrigin);
            originName.Click();
            Thread.Sleep(2000);
            airportOrigin.Click();
            airportOrigin.Click();
            destinationName.Click();
            destinationName.SendKeys(cityDestination);
            destinationName.Click();
            Thread.Sleep(2000);
            airportDestination.Click();
            airportDestination.Click();
        }

        public void SetDepartDate(DateTime valueDate)
        {
            departDate.Clear();
            departDate.SendKeys(valueDate.ToString("yyyy-MM-dd"));
            departDate.SendKeys(Keys.Enter);
        }

        public void SetReturnDate(DateTime valueDate)
        {
            returnDate.Clear();
            returnDate.SendKeys(valueDate.ToString("yyyy-MM-dd"));
            returnDate.SendKeys(Keys.Enter);
            returnDateCalendar.Click();
        }

        public void SetCountBabies()
        {
            Thread.Sleep(2000);
            countBabies.Click();
            Thread.Sleep(2000);
            IList<IWebElement> items = countBabies.FindElements(By.XPath("(//div[@class='dropdown'])[3]/ul/li"));
            items[items.Count - 1].Click();
        }

        public string GetDepartDate()
        {
            return departDate.GetAttribute("value");
        }

        public string GetReturnDate()
        {
            return returnDate.GetAttribute("value");
        }

        public string GetOriginCity()
        {
            return originName.GetAttribute("value");
        }

        public string GetDestinationCity()
        {
            return destinationName.GetAttribute("value");
        }

        public Dictionary<string, string> GetDatas()
        {
            Dictionary<string, string> getDatas = new Dictionary<string, string>();
            return getDatas;
        }

        public void ClickButtonSearch()
        {
            buttonSearch.Click();
        }
    }
}
