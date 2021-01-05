using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    public class Day6Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day6();

            var data = instance.PrepareData(CurrentInput);

            return instance.CountDistinctYesAnswer(data);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day6();

            var data = instance.PrepareData(CurrentInput);

            return instance.CountCommonYesAnswer(data);
        }
        public Day6Executor(string input) : base(input, "Day6") {}
        public Day6Executor() : base(DailyInputs.d6_list, "Day6") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
