using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2015
{
    public class Day2
    {
        public class PresentDimension
        {
            public int L { get; set; }
            public int W { get; set; }
            public int H { get; set; }

            public static PresentDimension Create(string input)
            {
                var values = input.Split('x');
                return new PresentDimension()
                {
                    L = int.Parse(values[0]),
                    W = int.Parse(values[1]),
                    H = int.Parse(values[2])
                };
            }

            public int GetSmallestSide()
            {
                var sides = new List<int> {L * W, W * H, H * L};
                sides.Sort();
                return sides.First();
            }

            public long GetSquareFeet()
            {
                return 2 * (L * W) + 2 * (W * H) + 2 * (H * L) + GetSmallestSide();
            }

            public long GetLinearFeet()
            {
                var sides = new List<int> {L, W, H};
                sides.Sort();

                return sides[0] + sides[0] + sides[1] + sides[1] + L * W * H;
            }
        }

        public List<PresentDimension> PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);

            return list.Select(PresentDimension.Create).ToList();
        }

        public long GetTotalSquareFeet(List<PresentDimension> data)
        {
            return data.Sum(x => x.GetSquareFeet());
        }

        public long GetTotalLienearFeet(List<PresentDimension> data)
        {
            return data.Sum(x => x.GetLinearFeet());
        }
    }
}
