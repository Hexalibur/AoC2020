using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day20
    {
        public List<Square> PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n\r\n", "\r\r", "\n\n"},
                StringSplitOptions.None);
            return list.Select(Square.Create).ToList();
        }
        
        public long GetProductOfAllCorner(List<Square> data)
        {
            var corners = FindCorners(data);
            long product = 1;
            foreach (var corner in corners)
            {
                product *= corner.Id;
            }

            return product;
        }


        public List<Square> FindCorners(List<Square> squares)
        {
            Arrange(squares);

            return squares.Where(x => new List<Square>(){x.Top, x.Bottom,x.Right,x.Left}.Where(s => s != null).Count() == 2).ToList();
        }

        public long FindSeaMonster(List<Square> squares)
        {
            Arrange(squares);
            var image = ProcessImage(squares);
            var seaMonster = GetSeaMonster();

            long nb = 0;

            while (nb == 0)
            {
                for (var flip = 0; flip < 2; flip++)
                {
                    for (var turn = 0; turn < 4; turn++)
                    {
                        nb = GetNbSeaMonsterInImage(image, seaMonster);
                        if (nb > 0) break;
                        image = Turn(image);
                    }

                    image = Flip(image);
                    if (nb > 0) break;
                }
            }

            var seaMonsterValue = seaMonster.Sum(x => x.Count(y => y == '#'));
            var imageValue = squares.Sum(s => s.Image.Sum(i => i.Count(x => x == '#')));
            return imageValue - (seaMonsterValue * nb);

        }

        public List<List<char>> Turn(List<List<char>> input)
        {
            var newImage = new List<List<char>>();
            for (var x = 0; x < input.Count; x++)
            {
                var line = input.Select(l => l[x]).ToList();
                line.Reverse();
                newImage.Add(line);
            }
            return newImage;
        }

        public List<List<char>> Flip(List<List<char>> input)
        {
            input.ForEach(x => x.Reverse());

            return input;
        }

        public long GetNbSeaMonsterInImage(List<List<char>> image, List<List<char>> seaMonster)
        {
            var nbSeaMonster = 0;
            for (var x = 0; x < image.Count - seaMonster.Count; x++)
            {
                for (var y = 0; y < image[0].Count - seaMonster[0].Count; y++)
                {
                    var notMatch = false;
                    for (var mX = 0; mX < seaMonster.Count; mX++)
                    {
                        for (var mY = 0; mY < seaMonster[0].Count; mY++)
                        {
                            if (seaMonster[mX][mY] == '#')
                            {
                                if (image[x + mX][y + mY] != '#')
                                {
                                    notMatch = true;
                                    break;
                                }
                            }
                        }

                        if (notMatch) break;
                    }

                    if (!notMatch) nbSeaMonster++;
                }
            }

            return nbSeaMonster;
        }


        public List<List<char>> GetSeaMonster()
        {
            var input = @"..................#.
#....##....##....###
.#..#..#..#..#..#...";

            /*var input = @".#..#..#..#..#..#...
#....##....##....###
..................#.";*/

            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);

            var monster = new List<List<char>>();
            foreach (var l in list)
            {
                monster.Add(l.ToCharArray().ToList());
            }

            return monster;
        }

        public List<List<char>> ProcessImage(List<Square> squares)
        {
            ArrangeImage(squares);
            var startingSquare = squares.Single(s => s.Top == null && s.Left == null);
           
            var image = new List<List<char>>();

            do
            {
                for (var x = 0; x < startingSquare.Image.Count; x++)
                {
                    image.Add(ProcessLine(startingSquare, x));
                }

                startingSquare = startingSquare.Bottom;
            } while (startingSquare != null);

            return image;
        }

        public void ArrangeImage(List<Square> squares)
        {
            foreach (var s in squares)
            {
                s.PositionImage();
                s.TrimImage();
            }
        }
        public List<char> ProcessLine(Square square, int line)
        {
            var startingSquare = square;
            var image = new List<char>();

            
            do
            {
                for (var x = 0; x < startingSquare.Image[line].Length; x++)
                {
                    image.Add(startingSquare.Image[line][x]);
                }

                startingSquare = startingSquare.Right;
            } while (startingSquare != null);

            return image;
        }

        public void Arrange(List<Square> squares)
        {
            if (squares.All(x => x.Placed)) throw new Exception("Already Arranged!!!");
           
            squares[0].Placed = true;

            while (!squares.All(x => x.Placed) || squares.Any(x => x.Borders.Count(b => b.Adjacent == null) > 2))
            {
                foreach (var placed in squares.Where(x => x.Placed))
                {
                    foreach (var border in placed.Borders.Where(b => b.Adjacent == null))
                    {
                        var value = new string(border.Value);
                        var searchOrientation = border.Orientation == 'T' ? 'B' : 
                            border.Orientation == 'R' ? 'L' : 
                            border.Orientation == 'B' ? 'T' : 'R';

                        foreach (var other in squares.Where(x => x != placed))
                        {
                            for (var flip = 0; flip < 2; flip++)
                            {
                                for (var turn = 0; turn < 4; turn++)
                                {
                                    var matchingBorder = other.Borders.SingleOrDefault(x => x.Orientation == searchOrientation && x.Adjacent == null);
                                    if (matchingBorder != null && new string(matchingBorder.Value) == value)
                                    {
                                        switch (border.Orientation)
                                        {
                                            case 'T':
                                                placed.Top = other;
                                                other.Bottom = placed;
                                                border.Adjacent = other;
                                                matchingBorder.Adjacent = placed;
                                                other.Placed = true;
                                                break;
                                            case 'R':
                                                placed.Right = other;
                                                other.Left = placed;
                                                border.Adjacent = other;
                                                matchingBorder.Adjacent = placed;
                                                other.Placed = true;
                                                break;
                                            case 'B':
                                                placed.Bottom = other;
                                                other.Top = placed;
                                                border.Adjacent = other;
                                                matchingBorder.Adjacent = placed;
                                                other.Placed = true;
                                                break;
                                            case 'L':
                                                placed.Left = other;
                                                other.Right = placed;
                                                border.Adjacent = other;
                                                matchingBorder.Adjacent = placed;
                                                other.Placed = true;
                                                break;
                                        }
                                    }

                                    if (!other.Placed) 
                                        other.TurnRight();
                                    else
                                        break;
                                }

                                if (!other.Placed)
                                    other.Flip();
                                else
                                    break;
                            }

                            if (border.Adjacent != null) break;
                        }

                    }
                }
            }
        }

        public class Border
        {
            public char Orientation { get; set; }
            public char[] Value { get; set; }

            public Square Adjacent { get; set; }

            public void TurnRight()
            {
                if (Orientation == 'R' || Orientation == 'L') Array.Reverse(Value);

                Orientation =
                    Orientation == 'T' ? 'R' : 
                    Orientation == 'R' ? 'B' : 
                    Orientation == 'B' ? 'L' : 'T';

            }

            public void Flip()
            {
                Array.Reverse(Value);
            }
        }

        public class Square
        {
            public long Id;
            public List<Border> Borders;
            public List<char[]> Image;
            public Square Top;
            public Square Bottom;
            public Square Left;
            public Square Right;
            
            public bool Flipped = false;
            public int Turns = 0;
            public bool Placed = false;
            public static Square Create(string input)
            {
                var list = input.Split(
                    new[] {"\r\n", "\r", "\n"},
                    StringSplitOptions.None);

                var id = int.Parse(list[0].Replace("Tile ", "").Replace(":", ""));

                var image = new List<char[]>();
                for (var i = 1; i < list.Length; i++)
                {
                    image.Add(list[i].ToCharArray());
                }

                return new Square()
                {
                    Id = id,
                    Image = image,
                    Borders = new List<Border>()
                    {
                        FindTopBorder(image),
                        FindRightBorder(image),
                        FindBottomBorder(image),
                        FindLeftBorder(image)
                    }
                };
            }

            public void PositionImage()
            {
                if (new string(Image[0].ToArray()) ==
                    new string(Borders.Single(b => b.Orientation == 'T').Value)) return;
                for (var flip = 0; flip < 2; flip++)
                {
                    for (var turn = 0; turn < 4; turn++)
                    {
                        if (new string(Image[0].ToArray()) ==
                            new string(Borders.Single(b => b.Orientation == 'T').Value)) return;
                        TurnImageRight();
                    }
                    if (new string(Image[0].ToArray()) ==
                        new string(Borders.Single(b => b.Orientation == 'T').Value)) return;
                    FlipImage();
                }

                throw new Exception("Can't position image");
            }

            public void TrimImage()
            {
                var realImage = new List<char[]>();
                for (var x = 1; x < Image.Count() - 1; x++)
                {
                    var line = new List<char>();
                    for (var y = 1; y < Image[x].Length - 1; y++)
                    {
                        line.Add(Image[x][y]);
                    }
                    realImage.Add(line.ToArray());
                }

                Image = realImage;
            }

            public static Border FindTopBorder(List<char[]> image)
            {
                return new Border()
                {
                    Orientation = 'T',
                    Value = (char[])image.First().Clone()
                }; 
            }

            public static Border FindRightBorder(List<char[]> image)
            {
                var border = new List<char>();
                foreach (var line in image)
                {
                    border.Add(line.Last());
                }
                return new Border()
                {
                    Orientation = 'R',
                    Value = border.ToArray()
                }; 
            }

            public static Border FindBottomBorder(List<char[]> image)
            {
                return new Border()
                {
                    Orientation = 'B',
                    Value = (char[])image.Last().Clone()
                }; 
            }

            public static Border FindLeftBorder(List<char[]> image)
            {
                var border = new List<char>();
                foreach (var line in image)
                {
                    border.Add(line.First());
                }
                
                return new Border()
                {
                    Orientation = 'L',
                    Value = border.ToArray()
                }; 
            }

            public void TurnRight()
            {
                if (Placed) throw new Exception("Already placed!");

                if (Turns == 3) 
                    Turns = 0;
                else
                    Turns++;
                
                Borders.ForEach(x => x.TurnRight());
            }

            public void Flip()
            {
                if (Placed) throw new Exception("Already placed!");

                Flipped = !Flipped;

                Borders.Single(x => x.Orientation == 'T').Flip();
                Borders.Single(x => x.Orientation == 'B').Flip();
                var left = Borders.Single(x => x.Orientation == 'L');
                var right = Borders.Single(x => x.Orientation == 'R');
                left.Orientation = 'R';
                right.Orientation = 'L';
            }

            public void FlipImage()
            {
                //Image.Reverse();
                Image.ForEach(Array.Reverse);
            }

            public void TurnImageRight()
            {
                var newImage = new List<char[]>();
                for (var x = 0; x < Image.Count; x++)
                {
                    var line = Image.Select(l => l[x]).ToList();
                    line.Reverse();
                    newImage.Add(line.ToArray());
                }
                Image = newImage;
            }
        }
    }
}
