using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day17
    {
        public class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
            public int W { get; set; }

            public bool IsSelf(int x, int y, int z, int w)
            {
                return x == X && y == Y && z == Z && w == W;
            }

            public bool IsNeighborOf(int x, int y, int z, int w)
            {
                if (IsSelf(x, y, z, w)) return false;

                return x >= X - 1 && x <= X + 1 && y >= Y - 1 && y <= Y + 1 && z >= Z - 1 && z <= Z + 1 && w >= W - 1 && w <= W + 1;
            }
        }

        public List<Coordinate> PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);

            var data = list.Select(x => x.ToCharArray()).ToArray();

            var actives = new List<Coordinate>();

            for (var x = 0; x < data.Length; x++)
            {
                for (var y = 0; y < data[x].Length; y++)
                {
                    if (data[x][y] == '#') actives.Add(new Coordinate()
                    {
                        X = x,
                        Y = y,
                        Z = 0,
                        W = 0
                    });
                }
            }

            return actives;
        }

        public int Cycle(List<Coordinate> initialActives, int runs, bool useFourthDimension)
        {
            var currentActives = initialActives.Select(x => x).ToList();
            for (var r = 0; r < runs; r++)
            {
                var minX = currentActives.Min(x => x.X) - 1;
                var maxX = currentActives.Max(x => x.X) + 1;
                
                var minY = currentActives.Min(x => x.Y) - 1;
                var maxY = currentActives.Max(x => x.Y) + 1;
                
                var minZ = currentActives.Min(x => x.Z) - 1;
                var maxZ = currentActives.Max(x => x.Z) + 1;

                var minW = useFourthDimension ? currentActives.Min(x => x.W) - 1 : 0;
                var maxW = useFourthDimension ? currentActives.Max(x => x.W) + 1: 0;

                var newActives= new List<Coordinate>();

                for (var w = minW; w <= maxW; w++)
                {
                    for (var z = minZ; z <= maxZ; z++)
                    {
                        for (var x = minX; x <= maxX; x++)
                        {
                            for (var y = minY; y <= maxY; y++)
                            {
                                var coordinate = currentActives.SingleOrDefault(c => c.Z == z && c.X == x && c.Y == y && c.W == w);
                                var nbActiveNeighbor = currentActives.Count(c => c.IsNeighborOf(x, y, z, w));

                                if (coordinate == null)
                                {
                                    if (nbActiveNeighbor == 3) newActives.Add(new Coordinate(){
                                        X = x,
                                        Y = y,
                                        Z = z,
                                        W = w
                                    });
                                }
                                else
                                {
                                    if (nbActiveNeighbor == 2 || nbActiveNeighbor == 3)
                                    {
                                        newActives.Add(new Coordinate(){
                                            X = x,
                                            Y = y,
                                            Z = z,
                                            W = w
                                        });
                                    }
                                }
                            }
                        }
                    }
                }

                currentActives = newActives.Select(x => x).ToList();
            }

            return currentActives.Count();
        }
    }
}
