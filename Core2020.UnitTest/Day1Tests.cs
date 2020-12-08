using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day1Tests
    {
        [TestClass]
        public class FindFinalTwoNumbers
        {
            
            [TestMethod]
            public void When_Example_Should_BeOk()
            {
                var list = new[]
                {
                    1721,
                    979,
                    366,
                    299,
                    675,
                    1456
                };

                var instance = new Day1();
                var result = instance.FindFinalTwoNumbers(list);
                result.Should().Be(514579);
            }
        }

        [TestClass]
        public class FindFinalThreeNumbers
        {
            [TestMethod]
            public void When_Example_Should_BeOk()
            {
                var list = new[]
                {
                    1721,
                    979,
                    366,
                    299,
                    675,
                    1456
                };

                var instance = new Day1();
                var result = instance.FindFinalThreeNumbers(list);
                result.Should().Be(241861950);
            }
        }
    }
}
