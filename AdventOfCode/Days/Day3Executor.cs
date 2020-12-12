using AdventOfCode.Days.Interface;
using System;

namespace AdventOfCode.Days
{
    public class Day3Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day3();
            var list = instance.PrepareData(CurrentInput);

            var patterns = new[] { new int[] {3,1},};

            var result = instance.CountTreesByPattern(list, patterns);
            Console.WriteLine($"Day3.1 : {result}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day3();
            var list = instance.PrepareData(CurrentInput);
            
            var patterns = new[]
            {
                new int[] {1,1},
                new int[] {3,1},
                new int[] {5,1},
                new int[] {7,1},
                new int[] {1,2}
            };

            var result = instance.CountTreesByPattern(list, patterns);
            Console.WriteLine($"Day3.2 : {result}");
            Console.WriteLine();
            return result;
        }
        public Day3Executor(string input) : base(input) {}
        public Day3Executor() : base(DailyInputs.d3_list) {}
    }
}
