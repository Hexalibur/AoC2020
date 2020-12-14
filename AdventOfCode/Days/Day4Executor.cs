using AdventOfCode.Days.Base;
using System;

namespace AdventOfCode.Days
{
    public class Day4Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day4();
            var data = instance.PrepareData(CurrentInput);

            var result = instance.ValidatePassports(data, true);
            Console.WriteLine($"Day4.1 : {result}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day4();
            var data = instance.PrepareData(CurrentInput);

            var result = instance.ValidatePassports(data, false);
            Console.WriteLine($"Day4.2 : {result}");
            Console.WriteLine();
            return result;
        }
        public Day4Executor(string input) : base(input) {}
        public Day4Executor() : base(DailyInputs.d4_list) {}
    }
}
