using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day1
    {
        public int FindFinalTwoNumbers(IList<int> list)
        {
            foreach (var i1 in list)
            {
                var i2 = list.Where(i => i1 + i == 2020);

                if (i2.Any())
                {
                    return i1 * i2.Single();
                }
            }
            return 0;
        }

        public int FindFinalThreeNumbers(IList<int> list)
        {
            foreach (var i1 in list)
            {
                foreach (var i2 in list.Where(i=> i != i1))
                {
                    var i3 = list.Where(i => i1 + i2 + i == 2020);

                    if (i3.Any())
                    {
                        return i1 * i2 * i3.Single();
                    }
                }
            }
            return 0;
        }

        public int[] PrepareData(string currentInput)
        {
            return currentInput.Split(',').Select(int.Parse).ToArray();
        }
    }
}
