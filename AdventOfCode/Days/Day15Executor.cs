using AdventOfCode.Days.Base;
using System;

namespace AdventOfCode.Days
{
    class Day15Executor: DailyExecuter

    {
        public Day15Executor(string input) : base(input)
        {
        }

        public Day15Executor() : base(DailyInputs.d15_list)
        {
        }

        public override object Step1()
        {
            var instance = new Core2020.Day15();
            Console.WriteLine($"Day15.1 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.GetSpokenNumber(data, 2020);
            Console.WriteLine($"Day15.1 : {result}");
            Console.WriteLine($"Day15.1 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day15();
            Console.WriteLine($"Day15.2 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.GetSpokenNumber(data, 30000000);
            Console.WriteLine($"Day15.2 : {result}");
            Console.WriteLine($"Day15.2 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }
    }
}
