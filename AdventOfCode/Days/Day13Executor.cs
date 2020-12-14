using AdventOfCode.Days.Base;
using System;

namespace AdventOfCode.Days
{
    public class Day13Executor : DailyExecuter

    {
        public Day13Executor(string input) : base(input)
        {
        }

        public Day13Executor() : base(DailyInputs.d13_list)
        {
        }

        public override object Step1()
        {
            var instance = new Core2020.Day13();
            Console.WriteLine($"Day13.1 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.GetEarliestBus(data);
            Console.WriteLine($"Day13.1 : {result}");
            Console.WriteLine($"Day13.1 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day13();
            Console.WriteLine($"Day13.2 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.GetEarliestMatchedSequence(data);
            Console.WriteLine($"Day13.2 : {result}");
            Console.WriteLine($"Day13.2 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }
    }
}
