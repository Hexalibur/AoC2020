using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2015.UnitTest
{
    [TestClass]
    public class Day5Tests
    {
        [TestClass]
        public class HowManyStringsAreNice
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturn()
            {
                var input = @"
ugknbfddgicrmopn
aaa
jchzalrnumimnmhp
haegwjzuvuyypxyu
dvszwmarrgswjxmb";

                var instance = new Day5();
                var data = instance.PrepareData(input);
                var result = instance.HowManyStringsAreNice(data);
                result.Should().Be(2);
            }
        }

        [TestClass]
        public class IsStringNice
        {
            [TestMethod]
            [DataRow("ugknbfddgicrmopn", true)]
            [DataRow("aaa", true)]
            [DataRow("jchzalrnumimnmhp", false)]
            [DataRow("haegwjzuvuyypxyu", false)]
            [DataRow("dvszwmarrgswjxmb", false)]
            public void When_StringIs_Expect_NiceToBe(string str, bool expected)
            {
                var instance = new Day5();
                var result = instance.IsStringNice(str);
                result.Should().Be(expected);
            }
        }

        [TestClass]
        public class HowManyStringsAreNiceBonus
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturn()
            {
                var input = @"
qjhvhtzxzqqjkmpb
xxyxx
uurcxstgmygtbstg
ieodomkazucvgmuy";

                var instance = new Day5();
                var data = instance.PrepareData(input);
                var result = instance.HowManyStringsAreNiceBonus(data);
                result.Should().Be(2);
            }
        }

        [TestClass]
        public class IsStringNiceBonus
        {
            [TestMethod]
            [DataRow("qjhvhtzxzqqjkmpb", true)]
            [DataRow("xxyxx", true)]
            [DataRow("xxxxx", true)]
            [DataRow("xyxaaa", false)]
            [DataRow("aaaxyx", false)]
            [DataRow("xyxaaazyz", false)]
            [DataRow("uurcxstgmygtbstg", false)]
            [DataRow("ieodomkazucvgmuy", false)]
            public void When_StringIs_Expect_NiceToBe(string str, bool expected)
            {
                var instance = new Day5();
                var result = instance.IsStringNiceBonus(str);
                result.Should().Be(expected);
            }
        }

        [TestClass]
        public class ContainsPairOfLetterTwiceTests
        {
            [TestClass]
            public class IsNice
            {
                [TestMethod]
                [DataRow("xyxy", true)]
                [DataRow("aabcdefgaa", true)]
                [DataRow("aaa", false)]
                public void When_Example_Expect_CorrectReturn(string value, bool expected)
                {
                    var instance = new Day5.ContainsPairOfLetterTwice();
                    var result = instance.IsNice(value);
                    result.Should().Be(expected);
                }
            }
        }

        [TestClass]
        public class AtLeastOneRepeatedLetterWithAnotherBetweenTests
        {
            [TestClass]
            public class IsNice
            {
                [TestMethod]
                [DataRow("xyx", true)]
                [DataRow("abcdefeghi", true)]
                [DataRow("efe", true)]
                [DataRow("aaa", true)]
                public void When_Example_Expect_CorrectReturn(string value, bool expected)
                {
                    var instance = new Day5.AtLeastOneRepeatedLetterWithAnotherBetween();
                    var result = instance.IsNice(value);
                    result.Should().Be(expected);
                }
            }
        }
    }
}
