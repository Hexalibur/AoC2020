using AdventOfCode.Days.Base;
using System;

namespace AdventOfCode.Days
{
    class Day16Executor: DailyExecuter

    {
        public Day16Executor(string input) : base(input)
        {
        }

        public Day16Executor() : base(DailyInputs.d16_list)
        {
        }

        public override object Step1()
        {
            var instance = new Core2020.Day16();
            Console.WriteLine($"Day16.1 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.GetSumOfInvalidNumbers(data);
            Console.WriteLine($"Day16.1 : {result}");
            Console.WriteLine($"Day16.1 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day16();
            Console.WriteLine($"Day16.2 start : {DateTime.Now.ToLongTimeString()}");
            var data = instance.PrepareData(CurrentInput);

            var result = instance.GetDepartureProduct(data);
            Console.WriteLine($"Day16.2 : {result}");
            Console.WriteLine($"Day16.2 end : {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine();
            return result;
        }
    }
}
