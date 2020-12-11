using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day11
    {
        public List<Seat> PrepareData(string input)
        {
            
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);

            var arrays = list.Select(x => x.ToCharArray()).ToArray();

            var seats = new List<Seat>();

            for (var row = 0; row < arrays.Length; row++)
            {
                var array = arrays[row];
                for (var col = 0; col < array.Length; col++)
                {
                    seats.Add(Seat.CreateSeat(array[col], row, col));
                }
            }
            return seats;
        }

        public int HowManySeatsEndsUpOccupied(List<Seat> data, ISeatCalculationRule rule)
        {
            var nbExecution = 0;
            do
            {
                data.ForEach(x => x.ApplyStateChange());

                data.Where(x => x.CurrentState != Seat.SeatState.NotASeat)
                    .ToList()
                    .ForEach(x => x.CalculateNextState(data, rule));

                nbExecution++;

                Console.WriteLine($"{DateTime.Now.ToLongTimeString()} - {nbExecution} - {data.Count(x => x.CurrentState != x.NextState)}");

            } while (data.Any(x => x.CurrentState != x.NextState));

            return data.Count(x => x.CurrentState == Seat.SeatState.Occupied);
        }

        public interface ISeatCalculationRule
        {
            Seat.SeatState CalculateNextState(Seat seat, List<Seat> allSeats);
        }

        public class NoMoreThanFourNearingSeatsRule : ISeatCalculationRule
        {
            public Seat.SeatState CalculateNextState(Seat seat, List<Seat> allSeats)
            {
                if (seat.CurrentState == Seat.SeatState.NotASeat) return Seat.SeatState.NotASeat;

                var nearingSeats = allSeats.Where(n => n.Col >= seat.Col - 1 &&
                                                       n.Col <= seat.Col + 1 &&
                                                       n.Row >= seat.Row - 1 &&
                                                       n.Row <= seat.Row + 1 &&
                                                       n != seat &&
                                                       n.CurrentState == Seat.SeatState.Occupied).ToList();

                switch (seat.CurrentState)
                {
                    case Seat.SeatState.Empty when !nearingSeats.Any():
                        return Seat.SeatState.Occupied;
                    case Seat.SeatState.Occupied when nearingSeats.Count >= 4:
                        return Seat.SeatState.Empty;
                    default:
                        return seat.CurrentState;
                }
            }
        }

        public class NoMoreThanFiveNearingSeatsRule : ISeatCalculationRule
        {
            public Seat.SeatState CalculateNextState(Seat seat, List<Seat> allSeats)
            {
                
                if (seat.CurrentState == Seat.SeatState.NotASeat) return Seat.SeatState.NotASeat;

                var nbOccupied = CalculateNbOccupied(seat, allSeats);

                switch (seat.CurrentState)
                {
                    case Seat.SeatState.Empty when nbOccupied == 0:
                        return Seat.SeatState.Occupied;
                    case Seat.SeatState.Occupied when nbOccupied >= 5:
                        return Seat.SeatState.Empty;
                    default:
                        return seat.CurrentState;
                }
            }

            private int CalculateNbOccupied(Seat seat, List<Seat> allSeats)
            {
                var directions = new List<List<Seat>>()
                {
                    //tops
                    allSeats.Where(x => x.Col == seat.Col && x.Row < seat.Row).OrderByDescending(x => x.Row).ToList(),
                    //lefts
                    allSeats.Where(x => x.Col < seat.Col && x.Row == seat.Row).OrderByDescending(x => x.Col).ToList(),
                    //topLefts
                    allSeats.Where(x => x.Col < seat.Col && x.Row < seat.Row && x.Col - seat.Col == x.Row - seat.Row).OrderByDescending(x => x.Row).ThenByDescending(x => x.Col).ToList(),
                    //topRights
                    allSeats.Where(x => x.Col > seat.Col && x.Row < seat.Row && x.Col - seat.Col == (x.Row - seat.Row) * -1).OrderByDescending(x => x.Row).ThenBy(x => x.Col).ToList(),

                    //bottoms
                    allSeats.Where(x => x.Col == seat.Col && x.Row > seat.Row).OrderBy(x => x.Row).ToList(),
                    //rights
                    allSeats.Where(x => x.Col > seat.Col && x.Row == seat.Row).OrderBy(x => x.Col).ToList(),
                    //bottomRights
                    allSeats.Where(x => x.Col > seat.Col && x.Row > seat.Row && x.Col - seat.Col == x.Row - seat.Row).OrderBy(x => x.Row).ThenBy(x => x.Col).ToList(),
                    //bottomLefts
                    allSeats.Where(x => x.Col < seat.Col && x.Row > seat.Row && x.Col - seat.Col == (x.Row - seat.Row) *-1).OrderBy(x => x.Row).ThenByDescending(x => x.Col).ToList(),

                };
                return directions.Sum(IsOccupied);
            }

            private int IsOccupied(IEnumerable<Seat> seats)
            {
                foreach (var seat in seats)
                {
                    switch (seat.CurrentState)
                    {
                        case Seat.SeatState.Occupied:
                            return 1;
                        case Seat.SeatState.Empty:
                            return 0;
                    }
                }

                return 0;
            }
        }


        public class Seat
        {
            public enum SeatState
            {
                Empty,
                Occupied,
                NotASeat
            }

            public static Seat CreateSeat(char value, int row, int col)
            {

                return new Seat()
                {
                    CurrentState = value == '.' ? SeatState.NotASeat : SeatState.Empty,
                    NextState = value == '.' ? SeatState.NotASeat : SeatState.Empty,
                    Row = row,
                    Col = col
                };
            } 

            public SeatState CurrentState { get; set; }
            public SeatState NextState { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }

            public void CalculateNextState(List<Seat> allSeats, ISeatCalculationRule rule)
            {
                NextState = rule.CalculateNextState(this, allSeats);
            }

            public void ApplyStateChange()
            {
                CurrentState = NextState;
            }

        }
    }
}
