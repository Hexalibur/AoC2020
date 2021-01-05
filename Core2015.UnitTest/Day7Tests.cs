using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2015.UnitTest
{
    [TestClass]
    public class Day7Tests
    {
        [TestClass]
        public class GetSignalProvidedToWire
        {
            [TestMethod]
            [DataRow("d", 72)]
            [DataRow("e", 507)]
            [DataRow("f", 492)]
            [DataRow("g", 114)]
            [DataRow("h", 65412)]
            [DataRow("i", 65079)]
            [DataRow("x", 123)]
            [DataRow("y", 456)]
            public void When_Example_Expect_ReturnGoodValue(string wire, int signals)
            {
                var input = @"123 -> x
456 -> y
x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i";
                var instance = new Day7();
                var data = instance.PrepareData(input);
                var result = instance.GetSignalProvidedToWire(data, wire);
                result.Should().Be(signals);

            }
        }
        [TestClass]
        public class DoSomethingElse
        {
            [TestMethod]
            public void When_Example_Expect_ReturnGoodValue()
            {
                var input = @"";
                var instance = new Day7();
                var data = instance.PrepareData(input);
                var result = instance.DoSomethingElse(data);
                result.Should().Be(0);
            }
        }
    }
}
