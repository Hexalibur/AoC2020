using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day12Tests
    {
        [TestClass]
        public class ComputeManhattanDistance
        {
            [TestMethod]
            public void When_Example_Expect_Return_Ok()
            {
                var input = @"F10
N3
F7
R90
F11";

                var instance = new Day12();
                var data = instance.PrepareData(input);
                var result = instance.ComputeManhattanDistance(data);
                result.Should().Be(25);
            }

            [TestMethod]
            public void When_EveryDirection_Expect_Return_Zero()
            {
                var input = @"E10
S10
N10
W10";

                var instance = new Day12();
                var data = instance.PrepareData(input);
                var result = instance.ComputeManhattanDistance(data);
                result.Should().Be(0);
            }

            [TestMethod]
            public void When_RotateRight_And_Advance_AllDirection_Expect_Return_Zero()
            {
                var input = @"F10
R90
F10
R90
F10
R90
F10";

                var instance = new Day12();
                var data = instance.PrepareData(input);
                var result = instance.ComputeManhattanDistance(data);
                result.Should().Be(0);
            }

            [TestMethod]
            public void When_RotateLeft_And_Advance_AllDirection_Expect_Return_Zero()
            {
                var input = @"F10
L90
F10
L90
F10
L90
F10";

                var instance = new Day12();
                var data = instance.PrepareData(input);
                var result = instance.ComputeManhattanDistance(data);
                result.Should().Be(0);
            }

            [TestMethod]
            public void When_RotateTwiceOpposite_And_AdvanceTwice_Expect_Return_Double()
            {
                var input = @"F10
L90
R90
F10";

                var instance = new Day12();
                var data = instance.PrepareData(input);
                var result = instance.ComputeManhattanDistance(data);
                result.Should().Be(20);
            }

        }

        [TestClass]
        public class ComputeManhattanDistanceWayPoint
        {
            [TestMethod]
            public void When_Example_Expect_Return_Ok()
            {
                var input = @"F10
N3
F7
R90
F11";

                var instance = new Day12();
                var data = instance.PrepareData(input);
                var result = instance.ComputeManhattanDistanceWayPoint(data);
                result.Should().Be(286);
            }
        }

    }
}
