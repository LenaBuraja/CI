using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Framework.Pages
{
    class FindTicketsPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@role='flights-dates-depart']")]
        private IWebElement departDate;

        [FindsBy(How = How.XPath, Using = "//input[@role='flights-dates-return']")]
        private IWebElement returnDate;

        [FindsBy(How = How.XPath, Using = "//input[@name,'origin_name']")]
        private IWebElement originName;

        [FindsBy(How = How.XPath, Using = "//input[@name='destination_name']")]
        private IWebElement destinationName;

        [FindsBy(How = How.XPath, Using = "//label[@for='baggage_filter']")]
        private IWebElement labelLuggageFilter;

        [FindsBy(How = How.XPath, Using = "//label[@for='baggage_filter_1']")]
        private IWebElement filterLuggageAndBags;

        [FindsBy(How = How.XPath, Using = "//label[@for='stops_count_filter']")]
        private IWebElement filterStopsCount;

        [FindsBy(How = How.XPath, Using = "//label[@for='stops_count_filter_0']")]
        private IWebElement filterDirectFlight;

        [FindsBy(How = How.XPath, Using = "//div[@class='filter filter--airlines_filter']/div/div")]
        private IWebElement listAircompany;

        [FindsBy(How = How.XPath, Using = "//label[@for='airlines_filter']")]
        private IWebElement filterAircompany;

        [FindsBy(How = How.XPath, Using = "//div[@role='filter-toggler']")]
        private IWebElement listAirport;

        [FindsBy(How = How.XPath, Using = "//label[@for='arrival_airports']")]
        private IWebElement filterAirport;

        [FindsBy(How = How.XPath, Using = "//div[@class='filter filter--gates_filter']/div/div")]
        private IWebElement listAgency;

        [FindsBy(How = How.XPath, Using = "//label[@for='gates_filter']")]
        private IWebElement filterAgency;

        [FindsBy(How = How.XPath, Using = "//label[@for='airlines_filter_B2']")]
        private IWebElement filterAircompanyBelavia;

        [FindsBy(How = How.XPath, Using = "//section[@class='flight-brief-layovers']")]
        private IList<IWebElement> ticketsDirectFlight;

        [FindsBy(How = How.XPath, Using = "//div[@class='bags-info']")]
        private IList<IWebElement> ticketsWithLuggage;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ticket-action-airline-container')]")]
        private IList<IWebElement> ticketsAircompanyBelavia;

        [FindsBy(How = How.XPath, Using = "//div[@class='ticket-action__main_proposal']")]
        private IList<IWebElement> ticketsAgency;

        [FindsBy(How = How.XPath, Using = "//div[@class='flight-brief-layover__iata']")]
        private IList<IWebElement> ticketsAirport;

        private IWebDriver driver;

        public FindTicketsPage(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(this.driver, this);
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

        public void FilterAircompany()
        {
            listAircompany.Click();
            filterAircompany.Click();
            filterAircompanyBelavia.Click();
        }

        public void FilterAirport()
        {
            listAirport.Click();
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

        public HashSet<string> GetListAtributesTicketsFromAviakassa ()
        {
            HashSet<string> listAtributesTicketsFromAviakassa = new HashSet<string>();
            foreach (IWebElement elem in ticketsAgency)
            {
                if (elem.Displayed)
                {
                    listAtributesTicketsFromAviakassa.Add(elem.GetAttribute("value"));
                }
            }
            return listAtributesTicketsFromAviakassa;
        }

        public HashSet<string> GetListAtributesTicketsWithAirportCDG()
        {
            HashSet<string> listAtributesTicketsWithAirportCDG = new HashSet<string>();
            foreach (IWebElement elem in ticketsAirport)
            {
                if (elem.Displayed)
                {
                    listAtributesTicketsWithAirportCDG.Add(elem.GetAttribute("value"));
                }
            }
            return listAtributesTicketsWithAirportCDG;
        }

    }
}
