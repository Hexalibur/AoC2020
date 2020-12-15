using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day15
    {
        public int[] PrepareData(string input)
        {
            var list = input.Split(',');
            return list.Select(int.Parse).ToArray();
        }

        public long GetSpokenNumber(int[] data, int position)
        {
            var spokenNumbers = new List<long>();
            var lastIndexes = new Dictionary<long, List<int>>();
            for (var i = 0; i < position; i++)
            {
                long numberToAdd = 0;
                if (i < data.Length)
                {
                    numberToAdd = data[i];
                }
                else
                {
                    var lastSpoken = spokenNumbers.Last();
                    if (lastIndexes[lastSpoken].Count == 1)
                    {
                        numberToAdd = 0;
                    }
                    else
                    {
                        var lastIndex = lastIndexes[lastSpoken].Count() - 2;

                        numberToAdd = i - 1 - lastIndexes[lastSpoken][lastIndex];
                    }
                }

                spokenNumbers.Add(numberToAdd);
                if (lastIndexes.ContainsKey(numberToAdd))
                {
                    lastIndexes[numberToAdd].Add(i);
                }
                else
                {
                    lastIndexes.Add(numberToAdd, new List<int>() {i});    
                }
                
            }

            return spokenNumbers.Last();
        }
    }
}
