using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day15Tests
    {
        [TestClass]
        public class GetSpokenNumber
        {
            [TestMethod]
            [DataRow("0,3,6", 2020, 436)]
            [DataRow("1,3,2", 2020, 1)]
            [DataRow("2,1,3", 2020, 10)]
            [DataRow("1,2,3", 2020, 27)]
            [DataRow("2,3,1", 2020, 78)]
            [DataRow("3,2,1", 2020, 438)]
            [DataRow("3,1,2", 2020, 1836)]
            /*
             //Performances issues
             [DataRow("0,3,6", 30000000, 175594)]
            [DataRow("1,3,2", 30000000, 2578)]
            [DataRow("2,1,3", 30000000, 3544142)]
            [DataRow("1,2,3", 30000000, 261214)]
            [DataRow("2,3,1", 30000000, 6895259)]
            [DataRow("3,2,1", 30000000, 18)]
            [DataRow("3,1,2", 30000000, 362)]*/
            public void When_Example_Expect_GoodReturn(string input, int position, long spokenNumber)
            {
                var instance = new Day15();
                var data = instance.PrepareData(input);
                var result = instance.GetSpokenNumber(data, position);
                result.Should().Be(spokenNumber);
            }
        }
    }
}
