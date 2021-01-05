using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2015.UnitTest
{
    [TestClass]
    public class Day3Tests
    {
        [TestClass]
        public class CheckNumberOfDifferentHouses
        {
            [TestMethod]
            [DataRow(">", false, 2)]
            [DataRow("^>v<", false, 4)]
            [DataRow("^v^v^v^v^v", false, 2)]
            [DataRow("^v", true, 3)]
            [DataRow("^>v<", true, 3)]
            [DataRow("^v^v^v^v^v", true, 11)]
            public void When_InputIs_Expect_NbToBe(string directions, bool robotEnabled, int expected)
            {
                var instance = new Day3();
                var result = instance.CheckNumberOfDifferentHouses(directions.ToCharArray(), robotEnabled);
                result.Should().Be(expected);
            }
        }
    }
}
