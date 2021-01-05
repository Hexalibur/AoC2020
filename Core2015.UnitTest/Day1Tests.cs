using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2015.UnitTest
{
    [TestClass]
    public class Day1Tests
    {
        [TestClass]
        public class GetToFloor
        {
            [TestMethod]
            [DataRow("(())", 0)]
            [DataRow("()()", 0)]
            [DataRow("(((", 3)]
            [DataRow("(()(()(", 3)]
            [DataRow("))(((((", 3)]
            [DataRow("())", -1)]
            [DataRow("))(", -1)]
            [DataRow(")))", -3)]
            [DataRow(")())())", -3)]
            public void When_Example_Expect_GoodValue(string input, int expectedFloor)
            {
                var instance = new Day1();
                var result = instance.GetToFloor(input);

                result.Should().Be(expectedFloor);
            }
        }

        [TestClass]
        public class GetBasementPosition
        {
            [TestMethod]
            [DataRow(")", 1)]
            [DataRow("()())", 5)]
            public void When_Example_Expect_GoodValue(string input, int expected)
            {
                var instance = new Day1();
                var result = instance.GetBasementPosition(input);

                result.Should().Be(expected);
            }
        }
    }
}
