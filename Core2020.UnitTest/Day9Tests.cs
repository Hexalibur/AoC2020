using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day9Tests
    {
        [TestClass]
        public class FindFirstInvalidNumber
        {
            [TestMethod]
            public void When_Example_Expect_ReturnGoodValue()
            {
                var instance = new Day9();
                var input = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

                var list = instance.PrepareData(input);
                var result = instance.FindFirstInvalidNumber(list, 5);
                result.Should().Be(127);

            }
        }

        [TestClass]
        public class FindContinuousSum
        {
            [TestMethod]
            public void When_Example_Expect_ReturnGoodValue()
            {
                var instance = new Day9();
                var input = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

                var list = instance.PrepareData(input);
                var result = instance.FindSumOfLowestAndHighestValuesFromAContinuousSum(list, 127);
                result.Should().Be(62);

            }
        }
    }
}
