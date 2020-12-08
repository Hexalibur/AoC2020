using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Core2020.UnitTest
{
    [TestClass]
    public class Day7Tests
    {
        [TestClass]
        public class FindNbOfBagColorContainedInOneSpecifiedBagColor
        {
            [TestMethod]
            [DataRow("shiny gold",32)]
            [DataRow("vibrant plum",11)]
            [DataRow("dotted black",0)]
            public void When_InputIs_Expect_Sum(string name, int nb)
            {
                var input = new string[] {"light red bags contain 1 bright white bag, 2 muted yellow bags.",
                    "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                    "bright white bags contain 1 shiny gold bag.",
                    "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                    "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                    "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                    "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                    "faded blue bags contain no other bags.",
                    "dotted black bags contain no other bags."};

                var instance = new Day7();
                var result = instance.FindNbOfBagColorContainedInOneSpecifiedBagColor(input, name);
                result.Should().Be(nb);
            }

            [TestMethod]
            public void When_InputIsValid_Expect_SumReturned()
            {
                var input = new string[] {"shiny gold bags contain 2 dark red bags.",
                    "dark red bags contain 2 dark orange bags.",
                    "dark orange bags contain 2 dark yellow bags.",
                    "dark yellow bags contain 2 dark green bags.",
                    "dark green bags contain 2 dark blue bags.",
                    "dark blue bags contain 2 dark violet bags.",
                    "dark violet bags contain no other bags."};

                var instance = new Day7();
                var result = instance.FindNbOfBagColorContainedInOneSpecifiedBagColor(input, "shiny gold");
                result.Should().Be(126);
            }
        }

        [TestClass]
        public class FindNbOfBagColorContainingAtLeastOneSpecifiedBagColor
        {
            [TestMethod]
            [DataRow("anycolor",0)]
            [DataRow("shiny gold",4)]
            [DataRow("dotted black",7)]
            public void When_InputIsValid_Expect_GoodValueReturned(string name, int nb)
            {
                var input = new string[] {"light red bags contain 1 bright white bag, 2 muted yellow bags.",
                    "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                    "bright white bags contain 1 shiny gold bag.",
                    "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                    "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                    "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                    "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                    "faded blue bags contain no other bags.",
                    "dotted black bags contain no other bags."};

                var instance = new Day7();
                var result = instance.FindNbOfBagColorContainingAtLeastOneSpecifiedBagColor(input, name);
                result.Should().Be(nb);
            }
        }

        [TestClass]
        public class CountBags
        {
            [TestMethod]
            public void When_InputIsValid_Expect_ListWellBuilt()
            {
                var input = new string[] {
                    "shiny gold bags contain 2 vibrant plum bags.",
                    "vibrant plum bags contain 3 dotted black bags.",
                    "dotted black bags contain no other bags."};

                var instance = new Day7();
                var colors = instance.ParseBagColors(input);
                var result = instance.CountBags(colors, "shiny gold");
                result.Should().Be(9);
            }
        }

        [TestClass]
        public class Search
        {
            [TestMethod]
            public void When_InputIsValid_Expect_ListWellBuilt()
            {
                var input = new string[] {
                    "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                    "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                    "dotted black bags contain no other bags."};

                var instance = new Day7();
                var colors = instance.ParseBagColors(input);
                var result = instance.Search(colors, "dotted black");
                result.Should().HaveCount(2);
                result.Select(x => x.Name).Should().Contain(new[] {"vibrant plum", "shiny gold"});
            }

            [TestMethod]
            public void When_ManySame_Expect_ColorReturnedOnce()
            {
                var input = new string[] {
                    "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                    "dark olive bags contain 1 dotted black bags.",
                    "vibrant plum bags contain 1 dotted black bags.",
                    "dotted black bags contain no other bags."};

                var instance = new Day7();
                var colors = instance.ParseBagColors(input);
                var result = instance.Search(colors, "dotted black");
                result.Should().HaveCount(3);
                result.Select(x => x.Name).Should().Contain(new[] {"vibrant plum", "shiny gold", "dark olive"});
            }
        }

        [TestClass]
        public class CreateContainedColors
        {
            [TestMethod]
            public void When_InputIsValid_Expect_DictionaryWellBuilt()
            {
                var input = "11 bright white bag, 22 muted yellow bags.";

                var instance = new Day7();
                var result = instance.CreateContainedColors(input);
                result.Should().ContainKey("bright white").WhichValue.Should().Be(11);
                result.Should().ContainKey("muted yellow").WhichValue.Should().Be(22);
            }

            [TestMethod]
            public void When_ConatinAZero_Expect_ZeroNotInDictionary()
            {
                var input = "0 bright white bag, 22 muted yellow bags.";

                var instance = new Day7();
                var result = instance.CreateContainedColors(input);
                result.Should().NotContainKey("bright white");
            }
        }

        [TestClass]
        public class CreateBagColor
        {
            [TestMethod]
            public void When_InputIsValid_Expect_DictionaryWellBuilt()
            {
                var input = "light red bags contain 111 bright white bag, 222 muted yellow bags.";

                var instance = new Day7();
                var result = instance.CreateBagColor(input);
                result.Name.Should().Be("light red");
                result.ContainedColors.Should().ContainKey("bright white").WhichValue.Should().Be(111);
                result.ContainedColors.Should().ContainKey("muted yellow").WhichValue.Should().Be(222);
            }
        }

        [TestClass]
        public class ParseBagColors
        {
            [TestMethod]
            public void When_InputIsValid_Expect_BagColorsListWellBuilt()
            {
                var input = new string[] {"light red bags contain 1 bright white bag, 2 muted yellow bags.",
                    "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                    "bright white bags contain 1 shiny gold bag.",
                    "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                    "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                    "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                    "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                    "faded blue bags contain no other bags.",
                    "dotted black bags contain no other bags."};

                var instance = new Day7();
                var result = instance.ParseBagColors(input);
                result.Select(x => x.Name).Should().Contain(new List<string>()
                {
                    "light red", "dark orange", "bright white", "muted yellow", "shiny gold", "dark olive",
                    "vibrant plum", "faded blue", "dotted black"
                });

                result.Single(x => x.Name == "faded blue").ContainedColors.Should().BeEmpty();
                result.Single(x => x.Name == "vibrant plum").ContainedColors.Should().ContainKey("faded blue").WhichValue.Should().Be(5);
            }
        }

        [TestClass]
        public class CleanColorDefinition
        {
            [TestMethod]
            public void When_InputIsValid_Expect_InfoToBeCleaned()
            {
                var info = "1 bright white bag, 2 muted yellow bags.";
                var instance = new Day7();
                var result = instance.CleanColorDefinition(info);
                result.Should().Be("1 bright white;2 muted yellow");
            }
        }
    }
}
