using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day9
    {
        public List<long> PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);
            return list.Select(long.Parse).ToList();
        }

        public long FindFirstInvalidNumber(List<long> list, int offsetSize)
        {
            for (var i = offsetSize; i < list.Count; i++)
            {
                if (!IsIndexValid(i, list, offsetSize)) return list[i];
            }

            return 0;
        }

        public long FindSumOfLowestAndHighestValuesFromAContinuousSum(List<long> list, long value)
        {
            for (var start = 0; start < list.Count; start++)
            {
                var sum = list[start];
                var end = start;

                var lowest = list[start];
                var highest = list[start];
                do
                {
                    end++;

                    if (list[end] > highest) highest = list[end];
                    if (list[end] < lowest) lowest = list[end];

                    sum += list[end];
                } while (sum < value && end < list.Count);

                if (sum == value) return lowest + highest;
            }

            return 0;
        }

        public bool IsIndexValid(int i, List<long>  list, int offsetSize)
        {
            var number = list[i];

            return CanFindSum(number, i, list, offsetSize);
        }

        public bool CanFindSum(long value, int startIndex, List<long> list, int offsetSize)
        {
            var offsetList = list.GetRange((startIndex - offsetSize), offsetSize);

            foreach (var i1 in offsetList)
            {
                var i2 = offsetList.Where(i => i1 + i == value);

                if (i2.Any()) return true;
            }

            return false;
        }
    }
}
