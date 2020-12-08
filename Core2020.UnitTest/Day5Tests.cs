using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day5Tests
    {
        [TestClass]
        public class ComputeCardSeatId
        {
            [TestMethod]
            [DataRow("FBFBBFFRLR",357)]
            [DataRow("BFFFBBFRRR",567)]
            [DataRow("FFFBBBFRRR",119)]
            [DataRow("BBFFBBFRLL",820)]
            public void When_CardIs_Expect_Id(string card, int id)
            {
                var instance = new Day5();

                var plane = new Day5.Plane()
                {
                    Cols = 8,
                    Rows = 128
                };

                var result = instance.ComputeCardSeatId(card, plane);
                result.Should().Be(id);
            }
        }

        [TestClass]
        public class FindHighestSeatId
        {
            [TestMethod]
            public void When_InputIsValid_Expect_HighestId()
            {
                var cards = new[]
                {
                    "BFFFBBFRRR",
                    "FFFBBBFRRR",
                    "BBFFBBFRLL",
                };
                var plane = new Day5.Plane()
                {
                    Cols = 8,
                    Rows = 128
                };
                var instance = new Day5();
                var result = instance.FindHighestSeatId(cards, plane);
                result.Should().Be(820);
            }
        }

        [TestClass]
        public class GeneratePossibleIds
        {
            [TestMethod]
            public void When_InputIsValid_Expect_AllIdsGenerated()
            {
                var plane = new Day5.Plane()
                {
                    Cols = 8,
                    Rows = 128
                };
                var instance = new Day5();
                var result = instance.GeneratePossibleIds(plane);
                result.Should().HaveCount(plane.Cols * plane.Rows);
            }
        }

        [TestClass]
        public class ComputeSeatId
        {
            [TestMethod]
            [DataRow(44, 5, 357)]
            [DataRow(70, 7, 567)]
            [DataRow(14, 7, 119)]
            [DataRow(102, 4, 820)]
            public void When_InputIsValid_Expect_IdWellComputed(int row, int col, int expected)
            {
                var instance = new Day5();
                var result = instance.ComputeSeatId(row, col);
                result.Should().Be(expected);
            }
        }

        [TestClass]
        public class PlacePassenger
        {
            [TestMethod]
            public void When_InputIsValid_Expect_PassengersPlaced()
            {
                var cards = new[]
                {
                    "BFFFBBFRRR",
                    "FFFBBBFRRR",
                    "BBFFBBFRLL",
                };
                var plane = new Day5.Plane()
                {
                    Cols = 8,
                    Rows = 128
                };

                var instance = new Day5();
                var seats = instance.GeneratePossibleIds(plane);

                instance.PlacePassenger(seats, cards, plane);

                var list = new int[] {567, 119, 820};
                seats.Where(x => !list.Contains(x.Key)).All(x => x.Value == false);
                seats.Where(x => list.Contains(x.Key)).All(x => x.Value == true);
            }
        }


    }
}
