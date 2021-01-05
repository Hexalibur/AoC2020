using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2015.UnitTest
{
    [TestClass]
    public class Day2Tests
    {
        [TestClass]
        public class GetTotalSquareFeet
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturn()
            {
                var input = @"2x3x4
1x1x10";
                var instance = new Core2015.Day2();
                var data = instance.PrepareData(input);
                var result = instance.GetTotalSquareFeet(data);
                result.Should().Be(58 + 43);
            }
        }

        [TestClass]
        public class GetTotalLienearFeet
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturn()
            {
                var input = @"2x3x4
1x1x10";
                var instance = new Core2015.Day2();
                var data = instance.PrepareData(input);
                var result = instance.GetTotalLienearFeet(data);
                result.Should().Be(34+14);
            }
        }
    }
}
