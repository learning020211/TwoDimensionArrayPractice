using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwoDimensionArrayPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TwoDimensionArrayPractice.Tests
{
    [TestClass()]
    public class TwoDimensionArrayIteratorTests
    {

        [TestMethod("HasNext")]
        [DataRow(@" 0,1,2
                    3,4,5", 6)]
        [DataRow(@" 0,1,2
                    3,4,5,
                    6,7,8", 9)]
        public void HasNextTest(string arrayItems, int expected)
        {
            int actual = 0;

            var iterator = new TwoDimensionArrayIterator<int>(arrayItems.To2DIntArray());
            for (; iterator.HasNext(); actual++)
                iterator.Next();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod("Next")]
        [DataRow(@" 0,1,2
                    3,4,5", "0,1,2,3,4,5")]
        [DataRow(@" 0,1,2
                    3,4,5,
                    6,7,8", "0,1,2,3,4,5,6,7,8")]
        public void NextTest(string arrayItems, string expected)
        {
            List<string> list = new List<string>();
            var iterator = new TwoDimensionArrayIterator<int>(arrayItems.To2DIntArray());
            for (; iterator.HasNext(); list.Add(iterator.Next().ToString()));

            string actual = string.Join(",", list.ToArray());

            Assert.AreEqual(expected, actual);
        }
    }
}