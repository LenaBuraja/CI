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
    }
}
