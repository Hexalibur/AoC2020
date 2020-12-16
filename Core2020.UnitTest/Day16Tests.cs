using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day16Tests
    {
        [TestClass]
        public class GetSumOfInvalidNumbers
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturnValue()
            {
                var input = @"class: 1-3 or 5-7
row: 6-11 or 33-44
seat: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";

                var instance = new Day16();
                var data = instance.PrepareData(input);
                var result = instance.GetSumOfInvalidNumbers(data);
                result.Should().Be(71);
            }
        }

        [TestClass]
        public class FindRuleOrder  
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturnValue()
            {
                var input = @"class: 0-1 or 4-19
row: 0-5 or 8-19
seat: 0-13 or 16-19

your ticket:
11,12,13

nearby tickets:
3,9,18
15,1,5
5,14,9";

                var instance = new Day16();
                var data = instance.PrepareData(input);
                var result = instance.FindRuleOrder(data);
                result.Single(r => r.Key == 0).Value.RuleName.Should().Be("row");
                result.Single(r => r.Key == 1).Value.RuleName.Should().Be("class");
                result.Single(r => r.Key == 2).Value.RuleName.Should().Be("seat");
            }
        }

        [TestClass]
        public class GetDepartureProduct  
        {
            [TestMethod]
            public void When_Example_Expect_GoodReturnValue()
            {
                var input = @"class: 0-1 or 4-19
departure row: 0-5 or 8-19
departure seat: 0-13 or 16-19

your ticket:
11,12,13

nearby tickets:
3,9,18
15,1,5
5,14,9";

                var instance = new Day16();
                var data = instance.PrepareData(input);
                var result = instance.GetDepartureProduct(data);
                result.Should().Be(11 * 13);
            }
        }
    }
}
