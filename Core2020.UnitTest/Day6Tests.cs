using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day6Tests
    {
        [TestClass]
        public class CountDistinctYesAnswer
        {
            [TestMethod]
            public void When_Example_Expect_ReturnOk()
            {
                var input = @"abc

a
b
c

ab
ac

a
a
a
a

b";

                var instance = new Day6();
                var list = instance.PrepareData(input);
                var result = instance.CountDistinctYesAnswer(list);

                result.Should().Be(11);
            }
        }

        [TestClass]
        public class GetDistinctYesAnswerOfGroup
        {
            [TestMethod]
            public void When_InputIsValid_Expect_ArrayOfDistinctReturned()
            {
                var group = "abcx;abcy;abcz";

                var instance = new Day6();

                var array = instance.GetDistinctYesAnswerOfGroup(group);

                var expected = new[] { 'a','b','c','x','y','z'};

                array.Should().BeEquivalentTo(expected);
            }
        }

        [TestClass]
        public class CountCommonYesAnswer
        {
            [TestMethod]
            public void When_Example_Expect_ReturnOk()
            {
                var input = @"abc

a
b
c

ab
ac

a
a
a
a

b";

                var instance = new Day6();
                var list = instance.PrepareData(input);
                var result = instance.CountCommonYesAnswer(list);

                result.Should().Be(6);
            }
        }
    }
}
