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

        public void FillInForm(string cityOrigin, string cityDestination)
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenPage();
            startPage.setCitiesOriginAndDestination(cityOrigin, cityDestination);
            DateTime dateCurent = DateTime.Today;
            startPage.SetDepartDate(dateCurent.AddMonths(1));
            startPage.SetReturnDate(dateCurent.AddMonths(1).AddDays(3));
            startPage.ClickButtonSearch();
        }

        public void FillInFormForModeOneWay(string cityOrigin, string cityDestination)
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenPage();
            DateTime dateCurent = DateTime.Today;
            startPage.SetDepartDate(dateCurent.AddMonths(1));
            startPage.ClickButtonSearch();
        }

        public void FillInFormAndSetCountBabies(string cityOrigin, string cityDestination, int countBabies)
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenPage();
            startPage.setCitiesOriginAndDestination(cityOrigin, cityDestination);
            DateTime dateCurent = DateTime.Today;
            startPage.SetDepartDate(dateCurent.AddMonths(1));
            startPage.SetReturnDate(dateCurent.AddMonths(1).AddDays(3));
            startPage.SetCountBabies(countBabies);
            startPage.ClickButtonSearch();
        }

        public void OnlySetDepartDate()
        {
            StartPage startPage = new StartPage(driver);
            startPage.OpenPage();
            DateTime dateCurent = DateTime.Today;
            startPage.SetDepartDate(dateCurent.AddMonths(1));
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

        public Dictionary<string, string> GetDatasStartPage()
        {
            StartPage startPage = this.OpenStartPage();
            Dictionary<string, string> getDatas = new Dictionary<string, string>();
            getDatas["cityOrigin"] = startPage.GetOriginCity();
            getDatas["cityDestination"] = startPage.GetDestinationCity();
            getDatas["departDate"] = startPage.GetDepartDate();
            getDatas["returnDate"] = startPage.GetReturnDate();
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

        public void FilterAirportInFindTicketsPage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            findTicketsPage.FilterAirport();
        }

        public bool isAllTicketsWithDirectFlight()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsDirectFlight = findTicketsPage.GetListAtributesTicketsDirectFlight();
            return listAtributesTicketsDirectFlight.Contains("direct_flight") && (listAtributesTicketsDirectFlight.Count == 1);
        }

        public bool isAllTicketsWithoutBag()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsHandbags = findTicketsPage.GetListAtributesTicketsHandbags();
            return listAtributesTicketsHandbags.Contains("unknown-handbags") && (listAtributesTicketsHandbags.Count == 1);
        }

        public bool isAllTicketsWithoutLuggage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsLuggage = findTicketsPage.GetListAtributesTicketsLuggage();
            return listAtributesTicketsLuggage.Contains("without-baggage") && (listAtributesTicketsLuggage.Count == 1);
        }

        public bool isAllTicketsWithoutUrlImage()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsUrlImage = findTicketsPage.GetListAtributesTicketsUrlImage();
            return listAtributesTicketsUrlImage.Contains("/images/airline/120/35/gravity=west/B2@2x.png") && (listAtributesTicketsUrlImage.Count == 1);
        }

        public bool isAllTicketsFromAviakassa()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsFromAviakassa = findTicketsPage.GetListAtributesTicketsFromAviakassa();
            return listAtributesTicketsFromAviakassa.Contains("Aviakassa") && (listAtributesTicketsFromAviakassa.Count == 1);
        }

        public bool isAllTicketsWithAirportCDG()
        {
            FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
            HashSet<string> listAtributesTicketsWithAirportCDG = findTicketsPage.GetListAtributesTicketsWithAirportCDG();
            return listAtributesTicketsWithAirportCDG.Contains("CDG") && (listAtributesTicketsWithAirportCDG.Count == 1);
        }

        //public bool isMessageIncorrectForm()
        //{
        //    FindTicketsPage findTicketsPage = new FindTicketsPage(driver);
        //    return listAtributesTicketsWithAirportCDG.Contains("CDG");
        //}
    }
}
