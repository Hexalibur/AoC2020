using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    public class Day18Executor : DailyExecuter
    {
        public Day18Executor(string input) : base(input, "Day18")
        {
        }

        public Day18Executor() : base(DailyInputs.d18_list, "Day18")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day18();

            var data = instance.PrepareData(CurrentInput);

            return instance.GetSumOfAllEquations(data, false);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day18();

            var data = instance.PrepareData(CurrentInput);

            return instance.GetSumOfAllEquations(data, true);
        }
    }
}
