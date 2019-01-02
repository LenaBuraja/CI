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

        [Test] //6
        public void DisplayFoundFlightsDirectFlight()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterFlightInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithDirectFlight());
        }

        [Test] //2
        public void SearchForAirticketsWithLuggage()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterLuggageInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithoutBag() && steps.isAllTicketsWithoutLuggage());
        }

        [Test] //5
        public void DisplayFoundAirticketsAirlineBelavia()
        {
            steps.FillInForm(CITY_ORIGIN, CITY_DISTINATION);
            steps.FilterAirportInFindTicketsPage();
            Assert.IsTrue(steps.isAllTicketsWithoutUrlImage());
        }

        [Test] //3
        public void AutocorrectionReturnDateFieldWhenChangingDepartureDateWithFlagBackAndForth()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate > departDate);
        }

        [Test] //1
        public void FoundTicketsAccordanceSpecifiedClass()
        {
            ////div[@class="whideSelect"]/*/div[@class="whideSelect"]/ul/li
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate > departDate);
        }

        [Test] //4 FoundTicketsAccordanceSpecifiedPriceRange
        public void FoundTicketsAccordanceSpecifiedPriceRange()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate > departDate);
        }

        [Test] //7 FoundFlightsAccordanceSpecifiedTimeRange
        public void FoundFlightsAccordanceSpecifiedTimeRange()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate > departDate);
        }

        [Test] //8 ImplementationOfSearchTicketForSpecialsOffer
        public void ImplementationOfSearchTicketForSpecialsOffer()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate > departDate);
        }

        [Test] //9 ExcessOfBabiesOverAdultsWhenSearchingForAirtickets
        public void ExcessOfBabiesOverAdultsWhenSearchingForAirtickets()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate > departDate);
        }

        [Test] //10 RightPricesWhenMonitoringPrices
        public void RightPricesWhenMonitoringPrices()
        {
            List<string> listDates = steps.GetDates();
            DateTime returnDate = DateTime.Parse(listDates[0]);
            DateTime departDate = DateTime.Parse(listDates[1]);
            Assert.IsTrue(returnDate > departDate);
        }


    }
}
