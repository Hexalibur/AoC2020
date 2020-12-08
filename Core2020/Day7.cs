using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day7
    {
        public IEnumerable<string> PrepareData(string input)
        {
            return input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);
        }

        public int FindNbOfBagColorContainingAtLeastOneSpecifiedBagColor(IEnumerable<string> definitions,
            string searchColor)
        {
            var colors = ParseBagColors(definitions);

            return Search(colors, searchColor).Count();
        }

        public int FindNbOfBagColorContainedInOneSpecifiedBagColor(IEnumerable<string> definitions,
            string searchColor)
        {
            var colors = ParseBagColors(definitions);

            return CountBags(colors, searchColor) - 1;
        }

        public IList<BagColor> Search(IList<BagColor> allColors, string searchColor)
        {
            var foundColors = allColors.Where(x => x.ContainedColors.ContainsKey(searchColor)).ToList();
            var allMatchedColors = foundColors.Concat(foundColors.SelectMany(x => Search(allColors, x.Name)));

            return allMatchedColors.Distinct().ToList();
        }

        public int CountBags(IList<BagColor> allColors, string searchColor)
        {
            var color = allColors.Single(x => x.Name == searchColor);

            return 1 + color.ContainedColors.Sum(x => x.Value * CountBags(allColors, x.Key));
        }

        public IList<BagColor> ParseBagColors(IEnumerable<string> definitions)
        {
            return definitions.Select(CreateBagColor).ToList();
        }

        public BagColor CreateBagColor(string definition)
        {
            var infos = definition.Split(new []{" bags contain "}, StringSplitOptions.None);

            return new BagColor()
            {
                Name = infos[0],
                ContainedColors = CreateContainedColors(infos[1])
            };

        }
        public Dictionary<string, int> CreateContainedColors(string info)
        {
            if (info == "no other bags.") return  new Dictionary<string, int>();

            var colors = CleanColorDefinition(info).Split(';');

            var contained = new Dictionary<string, int>();

            foreach (var color in colors)
            {
                var nb = int.Parse(color.Split(' ').First());
                var name = color.Substring(color.IndexOf(' '));

                if (nb > 0) contained.Add(name.Trim(), nb);
            }

            return contained;
        }

        public string CleanColorDefinition(string info)
        {
            return info.Replace(" bags", "")
                .Replace(" bag", "")
                .Replace(".", "")
                .Replace(", ", ";");
        }

        public class BagColor
        {
            public string Name { get; set; }
            public Dictionary<string, int> ContainedColors { get; set; }
        }
    }
}
