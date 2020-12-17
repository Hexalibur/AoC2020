using AdventOfCode.Days.Base;

namespace AdventOfCode.Days
{
    public class Day10Executor : DailyExecuter
    {
        public Day10Executor(string input) : base(input, "Day10")
        {
        }

        public Day10Executor() : base(DailyInputs.d10_list, "Day10")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day10();
            var data = instance.PrepareData(CurrentInput);

            return instance.GetDifferenceProduct(data);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day10();
            var data = instance.PrepareData(CurrentInput);
            
            return instance.GetNumberOfWays(data);
        }
    }
}
