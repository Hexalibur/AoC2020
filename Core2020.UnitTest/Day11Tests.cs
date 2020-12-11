using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day11Tests
    {
        [TestClass]
        public class HowManySeatsEndsUpOccupied
        {
            [TestMethod]
            public void When_NoMoreThanFourNearingSeatsRule_Expect_GoodReturn()
            {
                var input = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

                var instance = new Day11();

                var data = instance.PrepareData(input);
                var result = instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFourNearingSeatsRule());
                result.Should().Be(37);
            }

            [TestMethod]
            public void When_NoMoreThanFiveNearingSeatsRule_Expect_GoodReturn()
            {
                var input = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

                var instance = new Day11();

                var data = instance.PrepareData(input);
                var result = instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFiveNearingSeatsRule());
                result.Should().Be(26);
            }
        }
        
    }
}
