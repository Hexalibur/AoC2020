using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day2Tests
    {
        [TestClass]
        public class ValidatePasswords
        {
            [TestMethod]
            public void When_RuleIsRule1_Expect_ReturnGoodNumber()
            {
                var passwords = new [] {"1-3 a: abcde",
                    "1-3 b: cdefg",
                    "2-9 c: ccccccccc"};
                var instance = new Day2();

                var result = instance.ValidatePasswords(passwords, typeof(Rule1));
                result.Should().Be(2);
            }
            [TestMethod]
            public void When_RuleIsRule2_Expect_ReturnGoodNumber()
            {
                var passwords = new [] {"1-3 a: abcde",
                    "1-3 b: cdefg",
                    "2-9 c: ccccccccc"};
                var instance = new Day2();

                var result = instance.ValidatePasswords(passwords, typeof(Rule2));
                result.Should().Be(1);
            }
        }

        [TestClass]
        public class IsValid
        {
            [TestMethod]
            [DataRow("1-3 a: abcde",true, typeof(Rule1))]
            [DataRow(    "1-3 b: cdefg", false, typeof(Rule1))]
            [DataRow("2-9 c: ccccccccc", true, typeof(Rule1))]
            [DataRow("1-3 a: abcde",true, typeof(Rule2))]
            [DataRow(    "1-3 b: cdefg", false, typeof(Rule2))]
            [DataRow("2-9 c: ccccccccc", false, typeof(Rule2))]
            public void When_PasswordIs_Expect_Return(string value, bool expected, Type type)
            {
                var instance = new Day2();

                var result = instance.IsValid(value, type);
                result.Should().Be(expected);
            }
        }

        [TestClass]
        public class Rule1Tests
        {
            [TestClass]
            public class Concstrutor
            {
                [TestMethod]
                public void When_InputIsValid_Expect_RuleWellBuilt()
                {
                    var param = "1-2 a";
                    var instance = new Rule1(param);

                    var expected = new
                    {
                        MandatoryChar = 'a',
                        MinOccurs = 1,
                        MaxOccurs = 2,
                    };
                    instance.Should().BeEquivalentTo(expected);
                }
            }

            [TestClass]
            public class Validate
            {
                [TestMethod]
                public void When_ContainsNone_Expect_ReturnFalse()
                {
                    var param = "2-4 a";
                    var instance = new Rule1(param);
                    var result = instance.Validate("00000");
                    result.Should().BeFalse();
                }
                
                [TestMethod]
                public void When_ContainsNotEnough_Expect_ReturnFalse()
                {
                    var param = "2-4 a";
                    var instance = new Rule1(param);
                    var result = instance.Validate("00000a");
                    result.Should().BeFalse();
                }
                
                [TestMethod]
                public void When_ContainsTooMuch_Expect_ReturnFalse()
                {
                    var param = "2-4 a";
                    var instance = new Rule1(param);
                    var result = instance.Validate("00000aaaaaa");
                    result.Should().BeFalse();
                }
                
                [TestMethod]
                public void When_ContainsExactlyMin_Expect_ReturnTrue()
                {
                    var param = "2-4 a";
                    var instance = new Rule1(param);
                    var result = instance.Validate("00000aa");
                    result.Should().BeTrue();
                }
                
                [TestMethod]
                public void When_ContainsExactlyMax_Expect_ReturnTrue()
                {
                    var param = "2-4 a";
                    var instance = new Rule1(param);
                    var result = instance.Validate("00000aaaa");
                    result.Should().BeTrue();
                }
                
                [TestMethod]
                public void When_ContainsInBetween_Expect_ReturnTrue()
                {
                    var param = "2-4 a";
                    var instance = new Rule1(param);
                    var result = instance.Validate("00000aaa");
                    result.Should().BeTrue();
                }
            }
        }

        [TestClass]
        public class Rule2Tests
        {
            [TestClass]
            public class Concstrutor
            {
                [TestMethod]
                public void When_InputIsValid_Expect_RuleWellBuilt()
                {
                    var param = "1-2 a";
                    var instance = new Rule2(param);

                    var expected = new
                    {
                        MandatoryChar = 'a',
                        PositionMustBe = 0,
                        PositionMustNotBe = 1,
                    };
                    instance.Should().BeEquivalentTo(expected);
                }
            }

            [TestClass]
            public class Validate
            {
                [TestMethod]
                [DataRow("1-3 a", "abcde", true)]
                [DataRow("1-3 a", "abade", false)]
                [DataRow("1-3 a", "cbade", true)]
                [DataRow("1-3 b", "cdefg", false)]
                [DataRow("2-9 c", "ccccccccc", false)]
                public void When_Input_Expect_Return(string rule, string password, bool expected)
                {
                    var instance = new Rule2(rule);
                    var result = instance.Validate(password);
                    result.Should().Be(expected);
                }
            }
        }
    }
}
