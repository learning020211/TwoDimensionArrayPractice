using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwoDimensionArrayPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDimensionArrayPractice.Tests
{
    [TestClass()]
    public class LocationHelperTests
    {
        [TestMethod("SetCurrentLocation")]
        [DataRow(@"0,1,2
                   3,4,5", 1, 2, false)]
        [DataRow(@"0,1,2
                   3,4,5", 2, 2, true)]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 2, 2, false)]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 3, 2, true)]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", -1, 0, true)]
        public void SetCurrentLocationExceptionTest(string arrayItems, int row, int column, bool exception)
        {
            var helper = new LocationHelper<int>(arrayItems.To2DIntArray());
            Action action = () => helper.SetCurrentLocation(row, column);
            if (exception)
                Assert.ThrowsException<ArgumentOutOfRangeException>(action);
            else
                action();
        }

        [TestMethod("MoveRight")]
        [DataRow(@"0,1,2
                   3,4,5", 0, 0, "1,2")]
        [DataRow(@"0,1,2
                   3,4,5", 1, 1, "5")]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 1, 0, "4,5")]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 0, 2, "")]
        public void MoveRightTest(string arrayItems, int row, int column, string expected)
        {
            var helper = new LocationHelper<int>(arrayItems.To2DIntArray());
            helper.SetCurrentLocation(row, column);
            List<string> list = new List<string>();
            for (; helper.CanMoveRight(); list.Add(helper.MoveRight().Value.ToString())) ;

            var actual = string.Join(",", list.ToArray());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod("MoveUp")]
        [DataRow(@"0,1,2
                   3,4,5", 0, 0, "")]
        [DataRow(@"0,1,2
                   3,4,5", 1, 1, "1")]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 2, 2, "5,2")]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 1, 1, "1")]
        public void MoveUpTest(string arrayItems, int row, int column, string expected)
        {
            var helper = new LocationHelper<int>(arrayItems.To2DIntArray());
            helper.SetCurrentLocation(row, column);
            List<string> list = new List<string>();
            for (; helper.CanMoveUp(); list.Add(helper.MoveUp().Value.ToString())) ;

            var actual = string.Join(",", list.ToArray());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod("MoveLeft")]
        [DataRow(@"0,1,2
                   3,4,5", 0, 0, "")]
        [DataRow(@"0,1,2
                   3,4,5", 1, 1, "3")]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 1, 2, "4,3")]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 2, 2, "7,6")]
        public void MoveLeftTest(string arrayItems, int row, int column, string expected)
        {
            var helper = new LocationHelper<int>(arrayItems.To2DIntArray());
            helper.SetCurrentLocation(row, column);
            List<string> list = new List<string>();
            for (; helper.CanMoveLeft(); list.Add(helper.MoveLeft().Value.ToString())) ;

            var actual = string.Join(",", list.ToArray());
            Assert.AreEqual(expected, actual);
        }

        [TestMethod("MoveDown")]
        [DataRow(@"0,1,2
                   3,4,5", 0, 0, "3")]
        [DataRow(@"0,1,2
                   3,4,5", 1, 1, "")]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 0, 1, "4,7")]
        [DataRow(@"0,1,2
                   3,4,5,
                   6,7,8", 1, 2, "8")]
        public void MoveDownTest(string arrayItems, int row, int column, string expected)
        {
            var helper = new LocationHelper<int>(arrayItems.To2DIntArray());
            helper.SetCurrentLocation(row, column);
            List<string> list = new List<string>();
            for (; helper.CanMoveDown(); list.Add(helper.MoveDown().Value.ToString())) ;

            var actual = string.Join(",", list.ToArray());
            Assert.AreEqual(expected, actual);
        }
    }
}