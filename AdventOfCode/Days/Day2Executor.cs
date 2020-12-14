using AdventOfCode.Days.Base;
using Core2020;
using System;

namespace AdventOfCode.Days
{
    public class Day2Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day2();
            var list = instance.PrepareData(CurrentInput);

            var result = instance.ValidatePasswords(list, typeof(Rule1));
            Console.WriteLine($"Day2.1 : {result}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day2();
            var list = instance.PrepareData(CurrentInput);

            var result = instance.ValidatePasswords(list, typeof(Rule2));
            Console.WriteLine($"Day2.2 : {result}");
            Console.WriteLine();
            return result;
        }
        public Day2Executor(string input) : base(input) {}
        public Day2Executor() : base(DailyInputs.d2_list) {}
    }
}
