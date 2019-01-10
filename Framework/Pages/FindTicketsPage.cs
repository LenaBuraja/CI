using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Framework.Pages
{
    class FindTicketsPage
    {
        [FindsBy(How = How.XPath, Using = "//input[@role='flights-dates-depart-value']")]
        private IWebElement departDate;

        [FindsBy(How = How.XPath, Using = "//input[@role='flights-dates-return-value']")]
        private IWebElement returnDate;

        [FindsBy(How = How.XPath, Using = "//span[@role='flights-origin_country__pseudo']")]
        private IWebElement originName;

        [FindsBy(How = How.XPath, Using = "//span[@role='flights-destination_country__pseudo']")]
        private IWebElement destinationName;

        [FindsBy(How = How.XPath, Using = "//input[@name='destination_name']")]
        private IWebElement inputDestinationName;

        [FindsBy(How = How.XPath, Using = "//button[@role='flights_submit']")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.XPath, Using = "//label[@for='baggage_filter']")]
        private IWebElement labelLuggageFilter;

        [FindsBy(How = How.XPath, Using = "//label[@for='baggage_filter_0']")]
        private IWebElement filterLuggageAndBags;

        [FindsBy(How = How.XPath, Using = "//label[@for='stops_count_filter']")]
        private IWebElement filterStopsCount;

        [FindsBy(How = How.XPath, Using = "//label[@for='stops_count_filter_0']")]
        private IWebElement filterDirectFlight;

        [FindsBy(How = How.XPath, Using = "//div[@class='filter filter--airlines_filter  ']/div/div")]
        private IWebElement listAircompany;

        [FindsBy(How = How.XPath, Using = "//label[@for='airlines_filter']")]
        private IWebElement filterAircompany;

        [FindsBy(How = How.XPath, Using = "//div[@role='filter-toggler'][@class='title title-dropdown semibold closed']")]
        private IWebElement listAirport;

        [FindsBy(How = How.XPath, Using = "//label[@for='arrival_airports']")]
        private IWebElement filterAirport;

        [FindsBy(How = How.XPath, Using = "//div[@class='filter filter--gates_filter  ']/div/div")]
        private IWebElement listAgency;

        [FindsBy(How = How.XPath, Using = "//label[@for='gates_filter']")]
        private IWebElement filterAgency;

        [FindsBy(How = How.XPath, Using = "//label[@for='gates_filter_190']")]
        private IWebElement filterAgencyBelavia;

        [FindsBy(How = How.XPath, Using = "//label[@for='airlines_filter_B2']")]
        private IWebElement filterAircompanyBelavia;

        [FindsBy(How = How.XPath, Using = "//label[@for='arrival_airports_CDG']")]
        private IWebElement filterAirportCDG;

        [FindsBy(How = How.XPath, Using = "//section[@class='flight-brief-layovers']//footer")]
        private IList<IWebElement> ticketsDirectFlight;

        [FindsBy(How = How.XPath, Using = "//div[@class='bags-info__icons bags-info__icons--baggage']/i")]
        private IList<IWebElement> ticketsWithLuggage;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ticket-action-airline-container')]//img")]
        private IList<IWebElement> ticketsAircompanyBelavia;

        [FindsBy(How = How.XPath, Using = "//div[@class='ticket-action__main_proposal ticket-action__main_proposal--']")]
        private IList<IWebElement> ticketsAgency;

        [FindsBy(How = How.XPath, Using = "//div[@class='flight flight--depart']//div[@class='flight-brief-layover__iata']/span")]
        private IList<IWebElement> ticketsAirport;

        [FindsBy(How = How.XPath, Using = "//div[@class='ticket-details']//div")]
        private IList<IWebElement> ticketsDetails;

        [FindsBy(How = How.XPath, Using = "//div[@class='message message--bad_search_params']")]
        private IWebElement messageError;

        private IWebDriver driver;

        public FindTicketsPage(IWebDriver _driver)
        {
            this.driver = _driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void SetOtherArrivialCityAndSearch(string city)
        {
            inputDestinationName.Click();
            inputDestinationName.Clear();
            inputDestinationName.SendKeys(city);
            buttonSearch.Click();
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
            return originName.Text;
        }

        public string GetDestinationCity()
        {
            return destinationName.Text;
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
            filterAirport.Click();
            filterAirportCDG.Click();
        }

        public void FilterAgency()
        {
            listAgency.Click();
            filterAgency.Click();
            filterAgencyBelavia.Click();
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
                    listAtributesTicketsLuggage.Add(elem.GetAttribute("class"));
                }
            }
            return listAtributesTicketsLuggage;
        }

        public HashSet<string> GetListAtributesTicketsUrlImage()
        {
            HashSet<string> listAtributesTicketsUrlImage = new HashSet<string>();
            foreach (IWebElement elem in ticketsAircompanyBelavia)
            {
                if (elem.Displayed)
                {
                    listAtributesTicketsUrlImage.Add(elem.GetAttribute("src"));
                    Console.WriteLine(elem.GetAttribute("src"));
                }
            }
            return listAtributesTicketsUrlImage;
        }

        public HashSet<string> GetListAtributesTicketsFromBelavia ()
        {
            HashSet<string> listAtributesTicketsFromBelavia = new HashSet<string>();
            foreach (IWebElement elem in ticketsAgency)
            {
                if (elem.Displayed)
                {
                    listAtributesTicketsFromBelavia.Add(elem.Text);
                    Console.WriteLine(elem.Text);
                }
            }
            return listAtributesTicketsFromBelavia;
        }

        public HashSet<string> GetListAtributesTicketsWithAirportCDG()
        {
            HashSet<string> listAtributesTicketsWithAirportCDG = new HashSet<string>();
            foreach (IWebElement elem in ticketsAirport)
            {
                if (elem.Displayed && ticketsAirport.IndexOf(elem) % 2 == 1)
                {
                    listAtributesTicketsWithAirportCDG.Add(elem.Text);
                }
            }
            return listAtributesTicketsWithAirportCDG;
        }

        public HashSet<string> GetListElimentDetailsTikets()
        {
            HashSet<string> listElimentDtailsTikets = new HashSet<string>();
            foreach (IWebElement elem in ticketsDetails)
            {
                if (elem.Displayed)
                {
                    listElimentDtailsTikets.Add(elem.GetAttribute("class"));
                }
            }
            return listElimentDtailsTikets;
        }

        public bool GetMessageError()
        {
            Console.WriteLine(driver.PageSource.Contains("message message--bad_search_params"));
            return driver.PageSource.Contains("message message--bad_search_params");
        }

    }
}
