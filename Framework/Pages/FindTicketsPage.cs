using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Framework.Pages
{
    class FindTicketsPage
    {
        [FindsBy(How = How.XPath, Using = "//label[@for='baggage_filter']")]
        private IWebElement labelLuggageFilter;

        [FindsBy(How = How.XPath, Using = "//label[@for='baggage_filter_1']")]
        private IWebElement filterLuggageAndBags;

        [FindsBy(How = How.XPath, Using = "//label[@for='stops_count_filter']")]
        private IWebElement filterStopsCount;

        [FindsBy(How = How.XPath, Using = "//label[@for='stops_count_filter_0']")]
        private IWebElement filterDirectFlight;

        [FindsBy(How = How.XPath, Using = "//div[@class='title title-dropdown semibold closed'][contains(.,'Авиакомпании')]")]
        private IWebElement listAircompany;

        [FindsBy(How = How.XPath, Using = "//label[@for='airlines_filter']")]
        private IWebElement filterAircompany;

        [FindsBy(How = How.XPath, Using = "//label[@class='label-block name airlines-label g-text-overflow'][contains(.,'БелавиаТолько')]")]
        private IWebElement filterAircompanyBelavia;

        [FindsBy(How = How.XPath, Using = "//section[@class='flight-brief-layovers']")]
        private IList<IWebElement> ticketsDirectFlight;

        [FindsBy(How = How.XPath, Using = "//div[@class='bags-info']")]
        private IList<IWebElement> ticketsWithLuggage;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ticket-action-airline-container')]")]
        private IList<IWebElement> ticketsAircompanyBelavia;

        private IWebDriver driver;

        public FindTicketsPage(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void FilterLuggage()
        {
            labelLuggageFilter.Click();
            filterLuggageAndBags.Click();
        }

        public void FilterFlight()
        {
            filterStopsCount.Click();
            filterDirectFlight.Click();
        }

        public void FilterAirport()
        {
            listAircompany.Click();
            filterAircompany.Click();
            filterAircompanyBelavia.Click();
        }

        public HashSet<string> GetListAtributesTicketsDirectFlight()
        {
            HashSet<string> listAtributesTicketsDirectFlight = new HashSet<string>();
            foreach (IWebElement elem in ticketsDirectFlight)
            {
                if (elem.Displayed)
                {
                    listAtributesTicketsDirectFlight.Add(elem.GetAttribute("class"));
                }
            }
            return listAtributesTicketsDirectFlight;
        }

        public HashSet<string> GetListAtributesTicketsLuggage()
        {
            HashSet<string> listAtributesTicketsLuggage = new HashSet<string>();
            foreach (IWebElement elem in ticketsWithLuggage)
            {
                if (elem.Displayed)
                {
                    listAtributesTicketsLuggage.Add(elem.FindElement(By.XPath("./div[@class='bags-info__icons--baggage']/i")).GetAttribute("class"));
                }
            }
            return listAtributesTicketsLuggage;
        }

        public HashSet<string> GetListAtributesTicketsHandbags()
        {
            HashSet<string> listAtributesTicketsHandbags = new HashSet<string>();
            foreach (IWebElement elem in ticketsWithLuggage)
            {
                if (elem.Displayed)
                {
                    listAtributesTicketsHandbags.Add(elem.FindElement(By.XPath("./div[@class='bags-info__icons--handbags']/i")).GetAttribute("class"));
                }
            }
            return listAtributesTicketsHandbags;
        }

        public HashSet<string> GetListAtributesTicketsUrlImage()
        {
            HashSet<string> listAtributesTicketsUrlImage = new HashSet<string>();
            foreach (IWebElement elem in ticketsAircompanyBelavia)
            {
                if (elem.Displayed)
                {
                    listAtributesTicketsUrlImage.Add(elem.FindElement(By.XPath("//img")).GetAttribute("src"));
                }
            }
            return listAtributesTicketsUrlImage;
        }

        //создать метод для установки ценны на слайдере
        //получить в px длину слайдера
        //получить какой ценовой диапазон
    }
}
