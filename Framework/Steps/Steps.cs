using Framework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Framework.Steps
{
    class Steps
    {

        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.Driver.GetDriver();
        }

        public void CloseBrowser()
        {
            Driver.Driver.CloseBrowser();
        }

        public StartPage FillInForm(string cityOrigin, string cityDestination)
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenPage();
            startPage.setCitiesOriginAndDestination(cityOrigin, cityDestination);
            DateTime dateCurent = DateTime.Today;
            startPage.SetDepartDate(dateCurent.AddMonths(1));
            startPage.SetReturnDate(dateCurent.AddMonths(1).AddDays(3));
            return startPage;
        }

        public StartPage FillInFormForModeOneWay(string cityOrigin, string cityDestination)
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenPage();
            DateTime dateCurent = DateTime.Today;
            startPage.SetDepartDate(dateCurent.AddMonths(1));
            return startPage;
        }

        public void ClickButtonForSearch(StartPage startPage)
        {
            startPage.ClickButtonSearch();
        }

        public void FillInFormWithClick(string cityOrigin, string cityDestination)
        {
            FillInForm(cityOrigin, cityDestination).ClickButtonSearch();
        }

        public void FillInFormForModeOneWayWithClick(string cityOrigin, string cityDestination)
        {
            FillInFormForModeOneWay(cityOrigin, cityDestination).ClickButtonSearch();
        }

        public void FillInFormAndSetCountBabies(string cityOrigin, string cityDestination)
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenPage();
            startPage.SetCountBabies();
            startPage.setCitiesOriginAndDestination(cityOrigin, cityDestination);
            DateTime dateCurent = DateTime.Today;
            startPage.SetDepartDate(dateCurent.AddMonths(1));
            startPage.SetReturnDate(dateCurent.AddMonths(1).AddDays(3));
            startPage.ClickButtonSearch();
        }

        public void OnlySetDepartDate()
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenPage();
            DateTime dateCurent = DateTime.Today;
            startPage.SetDepartDate(dateCurent.AddMonths(1));
        }

        public void SetOtherArrivialCity(string city) {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.SetOtherArrivialCityAndSearch(city);
        }

        private StartPage OpenStartPage()
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenPage();
            return startPage;
        }

        public string GetDefaultReturnDate(StartPage startPage)
        {
            return startPage.GetReturnDate();
        }

        public string GetReturnDate(StartPage startPage)
        {
            DateTime date = DateTime.Parse(this.GetDefaultReturnDate(startPage));
            startPage.SetDepartDate(date.AddMonths(1));
            return startPage.GetReturnDate();
        }

        public string GetDepartDate(StartPage startPage)
        {
            return startPage.GetDepartDate();
        }

        public List<string> GetDates()
        {
            StartPage startPage = this.OpenStartPage();
            List<string> dates = new List<string>();
            dates.Add(this.GetReturnDate(startPage));
            dates.Add(this.GetDepartDate(startPage));
            return dates;
        }

        public Dictionary<string, string> GetDatasStartPage(StartPage startPage)
        {
            Dictionary<string, string> getDatas = new Dictionary<string, string>();
            getDatas["cityOrigin"] = startPage.GetOriginCity();
            getDatas["cityDestination"] = startPage.GetDestinationCity();
            getDatas["departDate"] = startPage.GetDepartDate();
            getDatas["returnDate"] = startPage.GetReturnDate();
            return getDatas;
        }

        public Dictionary<string, string> GetDatasStartPageWithClickSearch(StartPage startPage)
        {
            Dictionary<string, string> getDatas = this.GetDatasStartPage(startPage);
            this.ClickButtonForSearch(startPage);
            return getDatas;
        }

        public Dictionary<string, string> GetDatasFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            Dictionary<string, string> getDatas = new Dictionary<string, string>();
            getDatas["cityOrigin"] = findTicketsPage.GetOriginCity();
            getDatas["cityDestination"] = findTicketsPage.GetDestinationCity();
            getDatas["departDate"] = findTicketsPage.GetDepartDate();
            getDatas["returnDate"] = findTicketsPage.GetReturnDate();
            return getDatas;
        }

        public void FilterLuggageInFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.FilterLuggage();
        }

        public void FilterFlightInFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.FilterFlight();
        }

        public void FilterAircompanyInFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.FilterAircompany();
        }

        public void FilterAgencyInFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.FilterAgency();
        }

        public void FilterAirportInFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.FilterAirport();
        }

        public bool isAllTicketsWithDirectFlight()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsDirectFlight = findTicketsPage.GetListAtributesTicketsDirectFlight();
            return listAtributesTicketsDirectFlight.Count != 0 ? listAtributesTicketsDirectFlight.Contains("flight-brief-layovers__direct_flight") && (listAtributesTicketsDirectFlight.Count == 1) : true;
        }

        public bool isAllTicketsWithoutLuggage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsLuggage = findTicketsPage.GetListAtributesTicketsLuggage();
            bool isWithoutLuggage = true;
            foreach (string item in listAtributesTicketsLuggage)
            {
                if (!item.Contains("without-baggage"))
                {
                    isWithoutLuggage = false;
                    break;
                }
            }
            return listAtributesTicketsLuggage.Count != 0 ? isWithoutLuggage && (listAtributesTicketsLuggage.Count == 1) : true;
        }

        public bool isAllTicketsWithoutUrlImage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsUrlImage = findTicketsPage.GetListAtributesTicketsUrlImage();
            return listAtributesTicketsUrlImage.Count != 0 ? listAtributesTicketsUrlImage.Contains("http://nano.avia-booking.com/images/airline/120/35/gravity=west/B2@2x.png") && (listAtributesTicketsUrlImage.Count == 1) : true;
        }

        public bool isAllTicketsFromBelavia()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsFromBelavia = findTicketsPage.GetListAtributesTicketsFromBelavia();
            return listAtributesTicketsFromBelavia.Count != 0 ? listAtributesTicketsFromBelavia.Contains("Belavia") && (listAtributesTicketsFromBelavia.Count == 1) : true;
        }

        public bool isAllTicketsWithAirportCDG()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsWithAirportCDG = findTicketsPage.GetListAtributesTicketsWithAirportCDG();
            return listAtributesTicketsWithAirportCDG.Count != 0 ? listAtributesTicketsWithAirportCDG.Contains("CDG") && (listAtributesTicketsWithAirportCDG.Count == 1) : true;
        }

        public bool isAllTicketsInModeOneWay()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listElimentDtailsTikets = findTicketsPage.GetListElimentDetailsTikets();
            return listElimentDtailsTikets.Count != 0 ? !listElimentDtailsTikets.Contains("flight flight--return") : true;
        }

        public bool isTiketsWithNewCity()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAirports = findTicketsPage.GetListAtributesTicketsWithAirportCDG();
            bool isValidAirport = true;
            foreach(string airport in listAirports)
            {
                isValidAirport = airport.Contains("LHR") || airport.Contains("LGW") || airport.Contains("LCY");
                if (!isValidAirport) break;
            }
            return isValidAirport;
        }

        public bool isMessageIncorrectForm()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            return findTicketsPage.GetMessageError();
        }
    }
}
