using AdventOfCode.Days.Base;
using System;

namespace AdventOfCode.Days
{
    public class Day1Executor: DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day1();
            var list = instance.PrepareData(CurrentInput);
            var result = instance.FindFinalTwoNumbers(list);
            
            Console.WriteLine($"Day1.1 : {result}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day1();
            var list = instance.PrepareData(CurrentInput);
            var result = instance.FindFinalThreeNumbers(list);
            
            Console.WriteLine($"Day1.2 : {result}");
            Console.WriteLine();
            return result;
        }

        public Day1Executor(string input) : base(input) {}
        public Day1Executor() : base(DailyInputs.d1_list) {}
    }
}
