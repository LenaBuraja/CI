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
        private const string CITY_ORIGIN = "Минск";
        private const string CITY_DISTINATION = "Париж";

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

        [Test]
        public void DisplayFoundFlightsDirectFlight()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterFlightInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithDirectFlight());
        }

        [Test]
        public void SearchForAirticketsWithLuggage()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterLuggageInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithoutBag() && steps.isAllTicketsWithoutLuggage());
        }

        [Test]
        public void DisplayFoundAirticketsAirlineBelavia()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterAirportInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithoutUrlImage());
        }

        [Test]
        public void AutocorrectionReturnDateFieldWhenChangingDepartureDateWithFlagBackAndForth()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate >= departDate);
        }

        [Test]
        public void SearchDataMatchWithDataEntered()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            Dictionary<string, string> getDatasStsrtPage = steps.GetDatasStartPage();
            Dictionary<string, string> getDatasFindTicketsPage = steps.GetDatasFindTicketsPage();
            Assert.IsTrue(getDatasStsrtPage["cityOrigin"] == getDatasFindTicketsPage["cityOrigin"]
                && getDatasStsrtPage["cityDestination"] == getDatasFindTicketsPage["cityDestination"]
                && getDatasStsrtPage["departDate"] == getDatasFindTicketsPage["departDate"]
                && getDatasStsrtPage["returnDate"] == getDatasFindTicketsPage["returnDate"]);
        }

        [Test]
        public void DisplayFoundAirticketsAgencyAviakassa()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterFlightInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsFromAviakassa());
        }

        [Test]
        public void DisplayFoundAirticketsAirportCDG()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterFlightInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithAirportCDG());
        }

        [Test]
        public void ExcessOfBabiesOverAdultsWhenSearchingForAirtickets()
        {
            steps.FillInFormAndSetCountBabies(CITY_ORIGIN, CITY_DISTINATION, 4);
            steps.FilterFlightInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsFromAviakassa());
        }
    }
}
