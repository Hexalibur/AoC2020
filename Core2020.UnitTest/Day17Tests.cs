using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day17Tests
    {
        [TestClass]
        public class Cycle
        {
            [TestMethod]
            [DataRow(false, 112)]
            [DataRow(true, 848)]
            public void When_UseFourthDimensionIs_Expect_ReturnGoodNumber(bool useFourthDimension, int expected)
            {
                var input = @".#.
..#
###";
                var instance = new Day17();
                var data = instance.PrepareData(input);
                var result = instance.Cycle(data, 6, useFourthDimension);
                result.Should().Be(expected);
            }
        }
    }
}
