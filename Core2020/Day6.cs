using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day6
    {
        public IEnumerable<string> PrepareData(string raw)
        {
            var input = raw;

            input = input.Replace("\r\n", ";");
            input = input.Replace(";;", "/");
            input = input.Replace(" ", ";");

            return input.Split('/');
        }

        public int CountDistinctYesAnswer(IEnumerable<string> input)
        {
            return input.Select(i => GetDistinctYesAnswerOfGroup(i).Count()).Sum();
        }

        public IEnumerable<char> GetDistinctYesAnswerOfGroup(string group)
        {
            return group.Replace(";", "").ToCharArray().Distinct().ToArray();
        }

        public int CountCommonYesAnswer(IEnumerable<string> input)
        {
            var values = new List<int>();
            foreach (var group in input)
            {
                var distinctValues = GetDistinctYesAnswerOfGroup(group);

                var persons = group.Split(';').Select(x => x.ToCharArray());

                values.Add(distinctValues.Count(v => persons.All(p => p.Any(a => a == v))));
            }

            return values.Sum();
        }
    }
}
