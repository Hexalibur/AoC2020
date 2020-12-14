using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day13Tests
    {
        [TestClass]
        public class GetEarliestBus
        {
            [TestMethod]
            public void When_Example_Expect_Return_Ok()
            {
                var input = @"939
7,13,x,x,59,x,31,19";

                var instance = new Day13();
                var data = instance.PrepareData(input);
                var result = instance.GetEarliestBus(data);
                result.Should().Be(295);
            }
        }

        [TestClass]
        public class GetEarliestMatchedSequence
        {
            [TestMethod]
            public void When_Example1_Expect_Return_Ok()
            {
                var input = @"939
7,13,x,x,59,x,31,19";

                var instance = new Day13();
                var data = instance.PrepareData(input);
                var result = instance.GetEarliestMatchedSequence(data);
                result.Should().Be(1068781);
            }
            [TestMethod]
            public void When_Example2_Expect_Return_Ok()
            {
                var input = @"939
67,7,59,61";

                var instance = new Day13();
                var data = instance.PrepareData(input);
                var result = instance.GetEarliestMatchedSequence(data);
                result.Should().Be(754018);
            }
            [TestMethod]
            public void When_Example3_Expect_Return_Ok()
            {
                var input = @"939
67,x,7,59,61";

                var instance = new Day13();
                var data = instance.PrepareData(input);
                var result = instance.GetEarliestMatchedSequence(data);
                result.Should().Be(779210);
            }
            [TestMethod]
            public void When_Example4_Expect_Return_Ok()
            {
                var input = @"939
67,7,x,59,61";

                var instance = new Day13();
                var data = instance.PrepareData(input);
                var result = instance.GetEarliestMatchedSequence(data);
                result.Should().Be(1261476);
            }
            [TestMethod]
            public void When_Example5_Expect_Return_Ok()
            {
                var input = @"939
1789,37,47,1889";

                var instance = new Day13();
                var data = instance.PrepareData(input);
                var result = instance.GetEarliestMatchedSequence(data);
                result.Should().Be(1202161486);
            }
            [TestMethod]
            public void When_Example6_Expect_Return_Ok()
            {
                var input = @"939
x,x,3,4,5";

                var instance = new Day13();
                var data = instance.PrepareData(input);
                var result = instance.GetEarliestMatchedSequence(data);
                result.Should().Be(1);
            }

            [TestMethod]
            public void When_Example7_Expect_Return_Ok()
            {
                var input = @"939
7,5,4,x,6";

                var instance = new Day13();
                var data = instance.PrepareData(input);
                var result = instance.GetEarliestMatchedSequence(data);
                result.Should().Be(14);
            }
        }
    }
}
