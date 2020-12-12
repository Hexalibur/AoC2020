using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day12
    {
        public List<IMovement> PrepareData(string input)
        {
            var factory = new MovementFactory();
            return input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None).Select(x => factory.CreateMovement(x)).ToList();
        }

        public int ComputeManhattanDistance(List<IMovement> data)
        {
            var ferry = new Ferry();

            data.ForEach(x => x.Move(ferry.FerryPosition));

            return Math.Abs(ferry.FerryPosition.EastWest) + Math.Abs(ferry.FerryPosition.NorthSouth);

        }

        public int ComputeManhattanDistanceWayPoint(List<IMovement> data)
        {
            var ferry = new Ferry();

            data.ForEach(x => x.MoveWaypoint(ferry.FerryPosition));

            return Math.Abs(ferry.FerryPosition.EastWest) + Math.Abs(ferry.FerryPosition.NorthSouth);

        }

        public class Ferry
        {
            public readonly Position FerryPosition;

            public Ferry()
            {
                FerryPosition = new Position();
            }
        }

        public class Position
        {
            public Position()
            {
                NorthSouth = 0;
                EastWest = 0;
                Direction = new East();
                WNorthSouth = 1;
                WEastWest = 10;
            }

            public int NorthSouth { get; set; }
            public int EastWest { get; set; }
            public int WNorthSouth { get; set; }
            public int WEastWest { get; set; }
            public IDirection Direction { get; set; }
        };

        public interface IDirection
        {
            IDirection GetNext();
            void Advance(Position origin, int units);
            void AdvanceWaypoint(Position origin, int units);
        }

        public class East : IDirection
        {
            public IDirection GetNext()
            {
                return new South();
            }

            public void Advance(Position origin, int units)
            {
                origin.EastWest += units;
            }

            public void AdvanceWaypoint(Position origin, int units)
            {
                origin.WEastWest += units;
            }
        }

        public class South : IDirection
        {
            public IDirection GetNext()
            {
                return new West();
            }

            public void Advance(Position origin, int units)
            {
                origin.NorthSouth -= units;
            }

            public void AdvanceWaypoint(Position origin, int units)
            {
                origin.WNorthSouth -= units;
            }
        }
        
        public class West : IDirection
        {
            public IDirection GetNext()
            {
                return new North();
            }

            public void Advance(Position origin, int units)
            {
                origin.EastWest -= units;
            }
            public void AdvanceWaypoint(Position origin, int units)
            {
                origin.WEastWest -= units;
            }
        }
        
        public class North : IDirection
        {
            public IDirection GetNext()
            {
                return new East();
            }

            public void Advance(Position origin, int units)
            {
                origin.NorthSouth += units;
            }

            public void AdvanceWaypoint(Position origin, int units)
            {
                origin.WNorthSouth += units;
            }
        }

        public class MovementFactory
        {
            public IMovement CreateMovement(string movement)
            {
                var direction = movement.Substring(0, 1);
                var units = int.Parse(movement.Substring(1));

                switch (direction)
                {
                    case "N": return new MoveNorth(units);
                    case "S": return new MoveSouth(units);
                    case "E": return new MoveEast(units);
                    case "W": return new MoveWest(units);
                    case "R": return new Rotate(units);
                    case "L": return new Rotate(units - 180);
                    case "F": return new Foward(units);
                }
                throw new InvalidOperationException($"Unsupported movement {movement}");
            }
        }

        public interface IMovement
        {
            void Move(Position origin);
            void MoveWaypoint(Position ferryPosition);
        }

        public class Rotate : IMovement
        {
            private int _degrees;

            public Rotate(int degrees)
            {
                _degrees = degrees;
                if (_degrees < 0) _degrees += 360;
                if (_degrees == 0) _degrees += 180;
            }

            public void Move(Position origin)
            {
                while (_degrees != 0)
                {
                    origin.Direction = origin.Direction.GetNext();
                    _degrees -= 90;
                }
            }

            public void MoveWaypoint(Position origin)
            {
                while (_degrees != 0)
                {
                    var newEastWest = origin.WNorthSouth;
                    origin.WNorthSouth = origin.WEastWest * -1;
                    origin.WEastWest = newEastWest;
                    _degrees -= 90;
                }
            }
        }

        public class Foward : IMovement
        {
            private readonly int _units;

            public Foward(int units)
            {
                _units = units;
            }
            public void Move(Position origin)
            {
                origin.Direction.Advance(origin, _units);
            }

            public void MoveWaypoint(Position origin)
            {
                origin.NorthSouth += (origin.WNorthSouth * _units);
                origin.EastWest += (origin.WEastWest * _units);
            }
        }

        public class MoveNorth : IMovement
        {
            private readonly int _units;
            private readonly IDirection _direction;

            public MoveNorth(int units)
            {
                _units = units;
                _direction = new North();
            }
            public void Move(Position origin)
            {
                _direction.Advance(origin, _units);
            }

            public void MoveWaypoint(Position origin)
            {
                _direction.AdvanceWaypoint(origin, _units);
            }
        }

        public class MoveEast : IMovement
        {
            private readonly int _units;
            private readonly IDirection _direction;

            public MoveEast(int units)
            {
                _units = units;
                _direction = new East();
            }
            public void Move(Position origin)
            {
                _direction.Advance(origin, _units);
            }

            public void MoveWaypoint(Position origin)
            {
                _direction.AdvanceWaypoint(origin, _units);
            }
        }

        public class MoveSouth : IMovement
        {
            private readonly int _units;
            private readonly IDirection _direction;

            public MoveSouth(int units)
            {
                _units = units;
                _direction = new South();
            }
            public void Move(Position origin)
            {
                _direction.Advance(origin, _units);
            }

            public void MoveWaypoint(Position origin)
            {
                _direction.AdvanceWaypoint(origin, _units);
            }
        }

        public class MoveWest : IMovement
        {
            private readonly int _units;
            private readonly IDirection _direction;

            public MoveWest(int units)
            {
                _units = units;
                _direction = new West();
            }
            public void Move(Position origin)
            {
                _direction.Advance(origin, _units);
            }

            public void MoveWaypoint(Position origin)
            {
                _direction.AdvanceWaypoint(origin, _units);
            }
        }
    }
}
