using PileOfBeans.Haystack;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PileOfBeans.Test.Unit
{
    [TestClass]
    public class HaystackTest
    {
        private PileOfBeans.Haystack.Haystack hobj;
        private SortByColorResult sobj;
        private List<Straw> Reds;
        private List<Straw> Greens;
        private List<Straw> Blues;
        private List<Straw> Grays;

        [TestInitialize]
        public void Initialize()
        {
            // TODO: Initialize anything the tests may need to share...
            hobj = new PileOfBeans.Haystack.Haystack();
            hobj.Pile.Clear();
            // Build the pile..Put 5 in each color
            hobj.Pile.Add(new Straw(17.3M, 43, 43, 43)); // Gray
            hobj.Pile.Add(new Straw(5.6M, 180, 91, 120)); //Red
            hobj.Pile.Add(new Straw(7.8M, 1, 52, 189));//Blue
            hobj.Pile.Add(new Straw(6.1M, 67, 67, 67));//Gray
            hobj.Pile.Add(new Straw(7.2M, 95, 221, 174));//Green
            hobj.Pile.Add(new Straw(15.9M, 9, 42, 45));//Blue//Duplicate
            hobj.Pile.Add(new Straw(9.9M, 132, 132, 132));//Gray
            hobj.Pile.Add(new Straw(9.3M, 132, 81, 111));//Red
            hobj.Pile.Add(new Straw(14.4M, 79, 160, 121));//Green
            hobj.Pile.Add(new Straw(15.9M, 9, 42, 45));//Blue//Duplicate
            hobj.Pile.Add(new Straw(13.2M, 77, 211, 222));//Blue
            hobj.Pile.Add(new Straw(12.1M, 63, 63, 17));//Red//Two same
            hobj.Pile.Add(new Straw(11.7M, 23, 10, 8));//Red
            hobj.Pile.Add(new Straw(19.3M, 255, 255, 255));//Gray//Duplicate
            hobj.Pile.Add(new Straw(7.0M, 5, 12, 9));//Green
            hobj.Pile.Add(new Straw(8.8M, 9, 111, 111));//Green//Two same
            hobj.Pile.Add(new Straw(15.9M, 236, 180, 123));//Red
            hobj.Pile.Add(new Straw(11.7M, 96, 41, 159));//Blue
            hobj.Pile.Add(new Straw(9.1M, 50, 78, 71));//Green
            hobj.Pile.Add(new Straw(19.3M, 255, 255, 255));//Gray//Duplicate

            IHaystackOrganizer obj = new IHaystackImplementor();
            sobj = obj.SortByColor(hobj);

            Reds = new List<Straw>();
            Greens = new List<Straw>();
            Blues = new List<Straw>();
            Grays = new List<Straw>();

            Reds.Add(new Straw(5.6M, 180, 91, 120));
            Reds.Add(new Straw(9.3M, 132, 81, 111));
            Reds.Add(new Straw(11.7M, 23, 10, 8));
            Reds.Add(new Straw(12.1M, 63, 63, 17));
            Reds.Add(new Straw(15.9M, 236, 180, 123));

            Greens.Add(new Straw(7.0M, 5, 12, 9));
            Greens.Add(new Straw(7.2M, 95, 221, 174));
            Greens.Add(new Straw(8.8M, 9, 111, 111));
            Greens.Add(new Straw(9.1M, 50, 78, 71));
            Greens.Add(new Straw(14.4M, 79, 160, 121));

            Blues.Add(new Straw(7.8M, 1, 52, 189));
            Blues.Add(new Straw(11.7M, 96, 41, 159));
            Blues.Add(new Straw(13.2M, 77, 211, 222));
            Blues.Add(new Straw(15.9M, 9, 42, 45));

            Grays.Add(new Straw(6.1M, 67, 67, 67));
            Grays.Add(new Straw(9.9M, 132, 132, 132));
            Grays.Add(new Straw(17.3M, 43, 43, 43));
            Grays.Add(new Straw(19.3M, 255, 255, 255));
        }

        [TestMethod]
        public void CheckHayStackCount()
        {
            Assert.AreEqual(sobj.Reds.Count, Reds.Count); //true
            Assert.AreEqual(sobj.Greens.Count, Greens.Count); //true
            Assert.AreEqual(sobj.Blues.Count, Blues.Count); //true
            Assert.AreEqual(sobj.Grays.Count, Grays.Count); //true
        }

        [TestMethod]
        public void CheckHayStackDuplicates()
        {
            int actualDuplicates = 2;
            int totallength = hobj.Pile.Count;
            int expectedDuplicates = totallength - (sobj.Reds.Count + sobj.Greens.Count + sobj.Blues.Count + sobj.Grays.Count);
            Assert.AreEqual(expectedDuplicates, actualDuplicates); //true
        }

        [TestMethod]
        public void CheckRedStrawsSortedByLength()
        {
            for(int i=0; i< Reds.Count; i++)
            {
                Assert.AreEqual(sobj.Reds[i].LengthInCm, Reds[i].LengthInCm);
                Assert.AreEqual(sobj.Reds[i].ColorRed, Reds[i].ColorRed);
                Assert.AreEqual(sobj.Reds[i].ColorGreen, Reds[i].ColorGreen);
                Assert.AreEqual(sobj.Reds[i].ColorBlue, Reds[i].ColorBlue);
            }
        }

        [TestMethod]
        public void CheckGreenStrawsSortedByLength()
        {
            for (int i = 0; i < Greens.Count; i++)
            {
                Assert.AreEqual(sobj.Greens[i].LengthInCm, Greens[i].LengthInCm);
                Assert.AreEqual(sobj.Greens[i].ColorRed, Greens[i].ColorRed);
                Assert.AreEqual(sobj.Greens[i].ColorGreen, Greens[i].ColorGreen);
                Assert.AreEqual(sobj.Greens[i].ColorBlue, Greens[i].ColorBlue);
            }
        }

        [TestMethod]
        public void CheckBlueStrawsSortedByLength()
        {
            for (int i = 0; i < Blues.Count; i++)
            {
                Assert.AreEqual(sobj.Blues[i].LengthInCm, Blues[i].LengthInCm);
                Assert.AreEqual(sobj.Blues[i].ColorRed, Blues[i].ColorRed);
                Assert.AreEqual(sobj.Blues[i].ColorGreen, Blues[i].ColorGreen);
                Assert.AreEqual(sobj.Blues[i].ColorBlue, Blues[i].ColorBlue);
            }
        }

        [TestMethod]
        public void CheckGrayStrawsSortedByLength()
        {
            for (int i = 0; i < Grays.Count; i++)
            {
                Assert.AreEqual(sobj.Grays[i].LengthInCm, Grays[i].LengthInCm);
                Assert.AreEqual(sobj.Grays[i].ColorRed, Grays[i].ColorRed);
                Assert.AreEqual(sobj.Grays[i].ColorGreen, Grays[i].ColorGreen);
                Assert.AreEqual(sobj.Grays[i].ColorBlue, Grays[i].ColorBlue);
            }
        }


    }
}
