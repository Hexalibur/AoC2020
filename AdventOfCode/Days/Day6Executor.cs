using AdventOfCode.Days.Base;
using System;

namespace AdventOfCode.Days
{
    public class Day6Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day6();
            Console.WriteLine($"Day6.1 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.CountDistinctYesAnswer(data);
            Console.WriteLine($"Day6.1 : {result}");
            Console.WriteLine($"Day6.1 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            
            var instance = new Core2020.Day6();
            Console.WriteLine($"Day6.2 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.CountCommonYesAnswer(data);
            Console.WriteLine($"Day6.2 : {result}");
            Console.WriteLine($"Day6.2 end : {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine();
            return result;
        }
        public Day6Executor(string input) : base(input) {}
        public Day6Executor() : base(DailyInputs.d6_list) {}
    }
}
