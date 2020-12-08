using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day3Tests
    {
        [TestClass]
        public class CountTress
        {
            [TestMethod]
            [DataRow(1, 1, 2)]
            [DataRow(3, 1, 7)]
            [DataRow(5, 1, 3)]
            [DataRow(7, 1, 4)]
            [DataRow(1, 2, 2)]
            public void When_Example_Expect_RightValue(int right, int down, int expected)
            {
                var input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

                var instance = new Day3();
                var result = instance.CountTrees(instance.PrepareData(input), 
                    right, 
                    down);
                result.Should().Be(expected);

            }
        }

        [TestClass]
        public class CountTreesByPattern
        {
            [TestMethod]
            public void When_Example_Expect_RightValue()
            {
                var input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

                var patterns = new[]
                {
                    new int[] {1,1},
                    new int[] {3,1},
                    new int[] {5,1},
                    new int[] {7,1},
                    new int[] {1,2}

                };

                var instance = new Day3();
                var result = instance.CountTreesByPattern(instance.PrepareData(input), patterns);
                result.Should().Be(336);

            }
        }
    }
}
