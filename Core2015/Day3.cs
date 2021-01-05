using System.Collections.Generic;
using System.Linq;

namespace Core2015
{


    public class Day3
    {
        public class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
        public int CheckNumberOfDifferentHouses(char[] moves, bool robotEnabled)
        {
            var coordinateX = 0;
            var coordinateY = 0;

            var roboCoordinateX = 0;
            var roboCoordinateY = 0;

            var houses = new Dictionary<Coordinate, int>();
            var coordinate = new Coordinate(){X = 0, Y = 0};
            houses[coordinate] = 1;

            int turn = 0;

            foreach (var move in moves)
            {
                if (robotEnabled == false || turn == 0 || turn % 2 == 0)
                {
                    if (move == '^') coordinateY += 1;
                    if (move == 'v') coordinateY -= 1;
                    if (move == '<') coordinateX -= 1;
                    if (move == '>') coordinateX += 1;

                    var existingCoordinate = houses.Keys.SingleOrDefault(h => h.X == coordinateX && h.Y == coordinateY);
                    if (existingCoordinate == null)
                    {
                        var newCoordinate = new Coordinate(){X = coordinateX, Y = coordinateY};
                        houses[newCoordinate] = 1;
                    }
                    else
                    {
                        houses[existingCoordinate] += 1;
                    }
                }
                else
                {
                    if (move == '^') roboCoordinateY += 1;
                    if (move == 'v') roboCoordinateY -= 1;
                    if (move == '<') roboCoordinateX -= 1;
                    if (move == '>') roboCoordinateX += 1;

                    var existingCoordinate = houses.Keys.SingleOrDefault(h => h.X == roboCoordinateX && h.Y == roboCoordinateY);
                    if (existingCoordinate == null)
                    {
                        var newCoordinate = new Coordinate(){X = roboCoordinateX, Y = roboCoordinateY};
                        houses[newCoordinate] = 1;
                    }
                    else
                    {
                        houses[existingCoordinate] += 1;
                    }
                }

                turn++;
            }

            return houses.Keys.Count();
        }

    }
}
