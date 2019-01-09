using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace Framework.Tests
{
    class Tests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string CITY_ORIGIN = "Minsk";
        private const string CITY_DISTINATION = "Paris";

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test] //+
        public void DisplayFoundFlightsDirectFlight()
        {
            steps.FillInFormWithClick(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterFlightInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithDirectFlight());
        }

        [Test] //+
        public void SearchForAirticketsWithLuggage()
        {
            steps.FillInFormWithClick(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterLuggageInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithoutLuggage());
        }

        [Test] //+
        public void DisplayFoundAirticketsAirlineBelavia()
        {
            steps.FillInFormWithClick(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterAircompanyInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithoutUrlImage());
        }

        [Test] //+
        public void AutocorrectionReturnDateFieldWhenChangingDepartureDateWithFlagBackAndForth()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate >= departDate);
        }

        [Test] //+
        public void SearchDataMatchWithDataEntered()
        {
            Dictionary<string, string> getDatasStsrtPage = steps.GetDatasStartPageWithClickSearch(steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION));
            Dictionary<string, string> getDatasFindTicketsPage = steps.GetDatasFindTicketsPage();
            Assert.IsTrue(getDatasStsrtPage["cityOrigin"] == getDatasFindTicketsPage["cityOrigin"]
                && getDatasStsrtPage["cityDestination"] == getDatasFindTicketsPage["cityDestination"]
                && getDatasStsrtPage["departDate"] == getDatasFindTicketsPage["departDate"]
                && getDatasStsrtPage["returnDate"] == getDatasFindTicketsPage["returnDate"]);
        }

        [Test] //+
        public void DisplayFoundAirticketsAgencyBelavia()
        {
            steps.FillInFormWithClick(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterAirportInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithAirportCDG());
        }

        [Test] //+
        public void DisplayFoundAirticketsAirportCDG()
        {
            steps.FillInFormWithClick(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterFlightInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithAirportCDG());
        }

        [Test]
        public void ExcessOfBabiesOverAdultsWhenSearchingForAirtickets()
        {
            steps.FillInFormAndSetCountBabies(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterFlightInFindTicketsPage();
            Assert.IsTrue(steps.isMessageIncorrectForm());
        }

        [Test]
        public void DisplayFoundAirticketsInOneWayWhenSelectedModeOneWay()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate > departDate);
        }

        [Test]
        public void ChangeArrivalCityInAirlineTicketsWhenEnteringNewArrivalCitySearchParameters()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate > departDate);
        }
    }
}
