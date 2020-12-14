using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day13
    {
        public class PuzzleData
        {
            public long EarliestDepart { get; set; }
            public List<int> BusIds { get; set; }
        }
        public PuzzleData PrepareData(string input)
        {
            var data = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);

            return new PuzzleData()
            {
                EarliestDepart = long.Parse(data[0]),
                BusIds = data[1].Split(',').Select(x => int.Parse(x.Replace('x', '0'))).ToList()
            };
        }


        public long GetEarliestBus(PuzzleData data)
        {
            var min = data.BusIds.Where(x => x != 0).Select(x => new 
            { id = x, 
                minDepart = CalculateNextBus(data.EarliestDepart, x),
                index = data.BusIds.IndexOf(x)

            }).OrderBy(x => x.minDepart).First();

            return (min.minDepart - data.EarliestDepart) * min.id;
        }

        public long CalculateNextBus(long currentTime, int id)
        {

            decimal rest = (decimal)currentTime / (decimal)id;
            rest = rest - Math.Floor(rest);
            return (long)(currentTime + (id - Math.Round(rest * id)));
        }

        public long GetEarliestMatchedSequence(PuzzleData data)
        {
            long increment = 1;
            long timestamp = increment;

            foreach (var id in data.BusIds.Where(x => x != 0))
            {
                var index = data.BusIds.IndexOf(id);
                while (!IsValid(timestamp, id, index))
                {
                    timestamp += increment;
                }

                increment *= id;
            }

            return timestamp;
        }

        public bool IsValid(long timestamp, long id, int index)
        {
            return (timestamp+index) % id == 0;
        }
    }
}

