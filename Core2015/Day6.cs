using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2015
{
    public class Day6
    {
        public class Light
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool Lit { get; set; }
            public long Brightness { get; set; }

            public void Toggle()
            {
                Lit = !Lit;
                Brightness += 2;
            }

            public void TurnOff()
            {
                Lit = false;
                Brightness = Math.Max(0, Brightness - 1);
            }

            public void TurnOn()
            {
                Lit = true;
                Brightness += 1;
            }
        }

        public class Instruction
        {
            public int StartX { get; set; }
            public int StartY { get; set; }
            public int EndX { get; set; }
            public int EndY { get; set; }

            public string Action { get; set; }

            public static Instruction Create(string input)
            {
                var list = input.Replace("turn ", "").Split(' ');

                var start = list[1].Split(',');
                var end = list[3].Split(',');

                return new Instruction()
                {
                    Action = list[0],
                    StartX = int.Parse(start[0]),
                    StartY = int.Parse(start[1]),
                    EndX = int.Parse(end[0]),
                    EndY = int.Parse(end[1])
                };
            }
        }
        public List<Instruction> PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);

            return list.Select(Instruction.Create).ToList();
        }

        public int GetNbLitAfterAllInstructions(List<Instruction> instructions)
        {
            var grid = GetInitialGrid();

            ParseInstructions(grid, instructions);

            return grid.Count(l => l.Lit);
        }

        public long GetTotalBrightnessAfterAllInstructions(List<Instruction> instructions)
        {
            var grid = GetInitialGrid();

            ParseInstructions(grid, instructions);

            return grid.Sum(l => l.Brightness);
        }

        private void ParseInstructions(List<Light> grid, List<Instruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                var lights = grid.Where(g => g.X >= instruction.StartX && g.X <= instruction.EndX &&
                                             g.Y >= instruction.StartY && g.Y <= instruction.EndY).ToList();
                switch (instruction.Action)
                {
                    case "on" : 
                        lights.ForEach(x => x.TurnOn());
                        break;
                    case "off" : 
                        lights.ForEach(x => x.TurnOff());
                        break;
                    case "toggle" : 
                        lights.ForEach(x => x.Toggle());
                        break;
                }
            }
        }

        public List<Light> GetInitialGrid()
        {
            var list = new List<Light>();
            for (var x = 0; x < 1000; x++)
            {
                for (var y = 0; y < 1000; y++)
                {
                    list.Add(new Light()
                    {
                        Lit = false,
                        X = x,
                        Y = y,
                        Brightness = 0
                    });
                }

            }

            return list;
        }
    }
}
