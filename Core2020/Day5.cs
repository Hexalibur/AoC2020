using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day5
    {
        public class Plane
        {
            public int Rows { get; set; }
            public int Cols { get; set; }
        }
        public string[] PrepareData(string input)
        {
            return input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);
        }

        public int FindSingleEmptySeatId(IEnumerable<string> cards, Plane plane)
        {
            var seats = GeneratePossibleIds(plane);

            PlacePassenger(seats, cards, plane);

            return seats.Single(x => x.Value == false && seats.ContainsKey(x.Key - 1) && seats.ContainsKey(x.Key + 1) && seats[x.Key - 1] && seats[x.Key + 1] ).Key;
        }

        public  Dictionary<int, bool> GeneratePossibleIds(Plane plane)
        {
            var list = new Dictionary<int, bool>();
            for (var row = 0; row < plane.Rows; row++)
            {
                for (var col = 0; col < plane.Cols; col++)
                {
                    list.Add(ComputeSeatId(row, col), false);
                }
            }

            return list;
        }

        public void PlacePassenger(Dictionary<int, bool> seats, IEnumerable<string> passengers, Plane plane)
        {
            foreach (var c in passengers)
            {
                var id = ComputeCardSeatId(c, plane);
                seats[id] = true;
            }
        }

        public int FindHighestSeatId(IEnumerable<string> cards, Plane plane)
        {
            var ids = cards.Select(c => ComputeCardSeatId(c, plane));

            return ids.Max(x => x);
        }

        public int ComputeCardSeatId(string card, Plane plane)
        {
            var steps = card.ToCharArray();

            var actualMinRow = 0;
            var actualMaxRow = plane.Rows - 1;
            var actualMinCol = 0;
            var actualMaxCol =  plane.Cols - 1;

            foreach(var s in steps)
            {
                switch (s)
                {
                    case 'F':
                    {
                        actualMaxRow = (actualMaxRow - (actualMaxRow - actualMinRow)/2) - 1;
                        break;
                    }
                    case 'B':
                    {
                        actualMinRow = (actualMinRow + (actualMaxRow - actualMinRow)/2) + 1;
                        break;
                    }
                    case 'L':
                    {
                        actualMaxCol = (actualMaxCol - (actualMaxCol - actualMinCol)/2) - 1;
                        break;
                    }
                    case 'R':
                    {
                        actualMinCol = (actualMinCol + (actualMaxCol - actualMinCol)/2) + 1;
                        break;
                    }
                }
            }

            if (actualMinRow != actualMaxRow) throw new Exception("Row not found!");
            if (actualMinCol != actualMaxCol) throw new Exception("Col not found!");

            return ComputeSeatId(actualMinRow, actualMinCol);
        }

        public int ComputeSeatId(int row, int col)
        {
            return row * 8 + col;
        }


    }
}
