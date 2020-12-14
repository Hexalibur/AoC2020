using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day14Tests
    {

        [TestClass]
        public class GetSumOfAllValuesLeft
        {
            [TestMethod]
            public void When_Example_Star1_Expect_GoodReturn()
            {
                var input = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";

                var instance = new Day14();
                var data = instance.PrepareData(input);
                var result = instance.GetSumOfAllValuesLeft(data, Day14.Mask.MaskApplication.Value);
                result.Should().Be(165);

            }
            
            [TestMethod]
            public void When_Bonus_Example_Expect_GoodReturn()
            {
                    var input = @"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1";

                var instance = new Day14();
                var data = instance.PrepareData(input);
                var result = instance.GetSumOfAllValuesLeft(data, Day14.Mask.MaskApplication.Address);
                result.Should().Be(208);

            }
        }
    }
}
