using AdventOfCode.Days.Interface;
using System;

namespace AdventOfCode.Days
{
    public class Day9Executor : DailyExecuter
    {
        public Day9Executor(string input) : base(input) {}
        public Day9Executor() : base(DailyInputs.d9_list) {}

        public override object Step1()
        {
            var instance = new Core2020.Day9();
            var data = instance.PrepareData(CurrentInput);

            var result = instance.FindFirstInvalidNumber(data, 25);
            Console.WriteLine($"Day9.1 : {result}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day9();
            var data = instance.PrepareData(CurrentInput);
            
            var firstStepResult = instance.FindFirstInvalidNumber(data, 25);
            var result = instance.FindSumOfLowestAndHighestValuesFromAContinuousSum(data, firstStepResult);
            Console.WriteLine($"Day9.2 : {result}");
            return result;
        }
    }
}
