using AdventOfCode.Days.Interface;
using System;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day8Executor : DailyExecuter
    {
        public Day8Executor(string input) : base(input) {}
        public Day8Executor() : base(DailyInputs.d8_list) {}

        public override object Step1()
        {
            var instance = new Core2020.Day8();
            Console.WriteLine($"Day8.1 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput).ToList();

            var result = instance.RunGame(data).Accumulation;
            Console.WriteLine($"Day8.1 : {result}");
            Console.WriteLine($"Day8.1 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day8();
            Console.WriteLine($"Day8.2 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput).ToList();

            var result = instance.TryRunGameProperly(data);
            Console.WriteLine($"Day8.2 : {result}");
            Console.WriteLine($"Day8.2 end : {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine();
            return result;
        }
    }
}
