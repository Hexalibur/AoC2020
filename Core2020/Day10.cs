using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day10
    {
        public int[] PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);
            return list.Select(int.Parse).ToArray();
        }

        public int GetDifferenceProduct(int[] list)
        {
            var differences = new Dictionary<int, int>();
            var currentValue = 0;

            var sortedList = list.OrderBy(x => x);

            foreach (var newValue in sortedList)
            {
                var diff = newValue - currentValue;
                if (differences.ContainsKey(diff))
                {
                    differences[diff]++;
                }
                else
                {
                    differences.Add(diff, 1);    
                }


                currentValue = newValue;
            }

            return differences[1] *(differences[3]+1);
        }

        public long GetNumberOfWays(IEnumerable<int> list)
        {
            var orderedList = list.OrderByDescending(x => x).ToList();

            var values = InitializeValues(orderedList);

            foreach (var value in orderedList)
            {
                foreach (var subValue in orderedList.Where(x => x > value && x <= value + 3))
                {
                    values[value] += values[subValue];
                }
            }

            return values.Where(x => x.Key <= 3 ).Sum(x => x.Value);
        }

        public Dictionary<int, long> InitializeValues(List<int> list)
        {
            var newList = new Dictionary<int, long>();
            foreach (var i in list.OrderByDescending(x => x))
            {
                newList.Add(i, 0);
            }

            newList[list.Max()] = 1;

            return newList;
        }
    }
}
