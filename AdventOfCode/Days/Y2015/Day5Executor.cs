using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2015
{
    class Day5Executor: DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2015.Day5();

            var data = instance.PrepareData(CurrentInput);
            return instance.HowManyStringsAreNice(data);
        }

        public override object Step2()
        {
            var instance = new Core2015.Day5();

            var data = instance.PrepareData(CurrentInput);
            return instance.HowManyStringsAreNiceBonus(data);
        }

        public Day5Executor(string input) : base(input, "Day5") {}
        public Day5Executor() : base(DailyInputs.d5_list, "Day5") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
