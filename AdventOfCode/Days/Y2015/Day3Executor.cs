using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2015
{
    public class Day3Executor: DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2015.Day3();
            return instance.CheckNumberOfDifferentHouses(CurrentInput.ToCharArray(), false);
        }

        public override object Step2()
        {
            var instance = new Core2015.Day3();
            return instance.CheckNumberOfDifferentHouses(CurrentInput.ToCharArray(), true);
        }

        public Day3Executor(string input) : base(input, "Day3") {}
        public Day3Executor() : base(DailyInputs.d3_list, "Day3") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
