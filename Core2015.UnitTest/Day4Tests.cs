using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2015.UnitTest
{
    [TestClass]
    public class Day4Tests
    {
        [TestClass]
        public class GetLowestMatch
        {
            [TestMethod]
            [Ignore]
            [DataRow("abcdef", 609043)]
            [DataRow("pqrstuv", 1048970)]
            public void When_KeyIs_Expect_LowestNumberToBe(string key, int expected)
            {
                var instance = new Day4();
                var result = instance.GetLowestMatch(key, "00000");
                result.Should().Be(expected);
            }
        }
    }
}
