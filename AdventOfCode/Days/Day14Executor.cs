using AdventOfCode.Days.Base;
using System;
using Core2020;

namespace AdventOfCode.Days
{
    class Day14Executor: DailyExecuter

    {
        public Day14Executor(string input) : base(input)
        {
        }

        public Day14Executor() : base(DailyInputs.d14_list)
        {
        }

        public override object Step1()
        {
            var instance = new Core2020.Day14();
            Console.WriteLine($"Day14.1 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.GetSumOfAllValuesLeft(data, Day14.Mask.MaskApplication.Value);
            Console.WriteLine($"Day14.1 : {result}");
            Console.WriteLine($"Day14.1 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day14();
            Console.WriteLine($"Day14.1 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.GetSumOfAllValuesLeft(data, Day14.Mask.MaskApplication.Address);
            Console.WriteLine($"Day14.1 : {result}");
            Console.WriteLine($"Day14.1 end : {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine();
            return result;
        }
    }
}
