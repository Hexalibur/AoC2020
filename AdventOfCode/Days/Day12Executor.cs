using AdventOfCode.Days.Base;
using System;

namespace AdventOfCode.Days
{
    public class Day12Executor : DailyExecuter
    {
        public Day12Executor(string input) : base(input)
        {
        }

        public Day12Executor() : base(DailyInputs.d12_list)
        {
        }

        public override object Step1()
        {
            var instance = new Core2020.Day12();
            Console.WriteLine($"Day12.1 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.ComputeManhattanDistance(data);
            Console.WriteLine($"Day12.1 : {result}");
            Console.WriteLine($"Day12.1 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day12();
            Console.WriteLine($"Day12.2 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.ComputeManhattanDistanceWayPoint(data);
            Console.WriteLine($"Day12.2 : {result}");
            Console.WriteLine($"Day12.2 end : {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine();
            return result;
        }
    }
}
