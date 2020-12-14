using AdventOfCode.Days.Base;
using System;

namespace AdventOfCode.Days
{
    public class Day10Executor : DailyExecuter
    {
        public Day10Executor(string input) : base(input)
        {
        }

        public Day10Executor() : base(DailyInputs.d10_list)
        {
        }

        public override object Step1()
        {
            var instance = new Core2020.Day10();
            Console.WriteLine($"Day10.1 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.GetDifferenceProduct(data);
            Console.WriteLine($"Day10.1 : {result}");
            Console.WriteLine($"Day10.1 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day10();
            Console.WriteLine($"Day10.2 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);
            
            var result = instance.GetNumberOfWays(data);
            Console.WriteLine($"Day10.2 : {result}");
            Console.WriteLine($"Day10.2 end : {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine();
            return result;
        }
    }
}
