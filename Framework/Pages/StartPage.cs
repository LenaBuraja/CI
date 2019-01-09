﻿using OpenQA.Selenium;
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

        [FindsBy(How = How.XPath, Using = "//div[@class='indexFormBg']")]
        private IWebElement form;

        [FindsBy(How = How.XPath, Using = "//input[@id='submit']")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'date')][@name='depart_date']")]
        private IWebElement departDate;

        [FindsBy(How = How.XPath, Using = "//input[@id='return_date']")]
        private IWebElement returnDate;

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
            airportOrigin.Click();
            airportOrigin.Click();
            destinationName.Click();
            destinationName.SendKeys(cityDestination);
            destinationName.Click();
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
        }

        public void SetCountBabies()
        {
            form.Click();
            countBabies.Click();
            IList<IWebElement> items = countBabies.FindElements(By.XPath("...//ul/li"));
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
            form.Click();
            buttonSearch.Click();
        }
    }
}
