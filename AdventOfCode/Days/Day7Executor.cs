using AdventOfCode.Days.Interface;
using System;

namespace AdventOfCode.Days
{
    public class Day7Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day7();
            var data = instance.PrepareData(CurrentInput);

            var result = instance.FindNbOfBagColorContainingAtLeastOneSpecifiedBagColor(data, "shiny gold");
            Console.WriteLine($"Day7.1 : {result}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day7();
            var data = instance.PrepareData(CurrentInput);

            var result = instance.FindNbOfBagColorContainedInOneSpecifiedBagColor(data, "shiny gold");
            Console.WriteLine($"Day7.2 : {result}");
            return result;
        }
        public Day7Executor(string input) : base(input) {}
        public Day7Executor() : base(DailyInputs.d7_list) {}
    }
}
