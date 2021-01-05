using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    public class Day9Executor : DailyExecuter
    {
        public Day9Executor(string input) : base(input, "Day9") {}
        public Day9Executor() : base(DailyInputs.d9_list, "Day9") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day9();

            var data = instance.PrepareData(CurrentInput);

            return instance.FindFirstInvalidNumber(data, 25);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day9();
            var data = instance.PrepareData(CurrentInput);
            
            var firstStepResult = instance.FindFirstInvalidNumber(data, 25);
            return instance.FindSumOfLowestAndHighestValuesFromAContinuousSum(data, firstStepResult);
        }
    }
}
