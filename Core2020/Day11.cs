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

            seats.ForEach(s => s.PopulateAdjacentSeats(seats));
            return seats;
        }

        public int HowManySeatsEndsUpOccupied(List<Seat> data, ISeatCalculationRule rule)
        {
            do
            {
                data.ForEach(x => x.ApplyStateChange());

                data.Where(x => x.CurrentState != Seat.SeatState.NotASeat)
                    .ToList()
                    .ForEach(x => x.CalculateNextState(data, rule));
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

                var nearingSeats = seat.GetNearingSeats().Where(x => x.CurrentState == Seat.SeatState.Occupied).ToList();

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

                var listSeeing = new List<int>()
                {
                    IsSeeignSomeone(seat, "left"),
                    IsSeeignSomeone(seat, "topleft"),
                    IsSeeignSomeone(seat, "top"),
                    IsSeeignSomeone(seat, "topright"),
                    IsSeeignSomeone(seat, "right"),
                    IsSeeignSomeone(seat, "bottomright"),
                    IsSeeignSomeone(seat, "bottom"),
                    IsSeeignSomeone(seat, "bottomleft")
                };

                var nbOccupied = listSeeing.Sum();

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

            private int IsSeeignSomeone(Seat seat, string direction)
            {
                var directedSeat = seat.GetSeatOfDirection(direction);

                if (directedSeat == null) return 0;

                if (directedSeat.CurrentState == Seat.SeatState.Occupied) return 1;
                if (directedSeat.CurrentState == Seat.SeatState.Empty) return 0;

                return IsSeeignSomeone(directedSeat, direction);
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

            public Seat LeftSeat { get; set; }
            public Seat TopLeftSeat { get; set; }
            public Seat TopSeat { get; set; }
            public Seat TopRightSeat { get; set; }
            public Seat RightSeat { get; set; }
            public Seat BottomRightSeat { get; set; }
            public Seat BottomSeat { get; set; }
            public Seat BottomLeftSeat { get; set; }
            public void PopulateAdjacentSeats(List<Seat> seats)
            {
                LeftSeat = seats.SingleOrDefault(x => x.Col == Col - 1 && x.Row == Row);
                TopLeftSeat = seats.SingleOrDefault(x => x.Col == Col - 1 && x.Row == Row - 1);
                TopSeat = seats.SingleOrDefault(x => x.Col == Col && x.Row == Row - 1);
                TopRightSeat = seats.SingleOrDefault(x => x.Col == Col + 1 && x.Row == Row - 1);
                RightSeat = seats.SingleOrDefault(x => x.Col == Col + 1 && x.Row == Row);
                BottomRightSeat = seats.SingleOrDefault(x => x.Col == Col + 1 && x.Row == Row + 1);
                BottomSeat = seats.SingleOrDefault(x => x.Col == Col && x.Row == Row + 1);
                BottomLeftSeat = seats.SingleOrDefault(x => x.Col == Col - 1 && x.Row == Row + 1);
            }

            public List<Seat> GetNearingSeats()
            {
                var list = new List<Seat>()
                {
                    LeftSeat,
                    TopLeftSeat,
                    TopSeat,
                    TopRightSeat,
                    RightSeat,
                    BottomRightSeat,
                    BottomSeat,
                    BottomLeftSeat
                };
                return list.Where(x => x != null).ToList();
            }

            public void CalculateNextState(List<Seat> allSeats, ISeatCalculationRule rule)
            {
                NextState = rule.CalculateNextState(this, allSeats);
            }

            public void ApplyStateChange()
            {
                CurrentState = NextState;
            }

            public Seat GetSeatOfDirection(string direction)
            {
                switch (direction)
                {
                    case "left": return LeftSeat;
                    case "topleft": return TopLeftSeat;
                    case "top": return TopSeat;
                    case "topright": return TopRightSeat;
                    case "right": return RightSeat;
                    case "bottomright": return BottomRightSeat;
                    case "bottom": return BottomSeat;
                    case "bottomleft": return BottomLeftSeat;
                }

                return null;
            }
        }
    }
}

