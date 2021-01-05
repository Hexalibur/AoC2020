using AdventOfCode.Days.Base;
using Core2020;

namespace AdventOfCode.Days.Y2020
{
    public class Day24Executor : DailyExecuter
    {
        public Day24Executor(string input) : base(input, "Day24")
        {
        }

        public Day24Executor() : base(DailyInputs.d24_list, "Day24")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
        public override object Step1()
        {
            var instance = new Day24();
            var data = instance.PrepareData(CurrentInput);
            return instance.GetNbBlackTilesAferNDays(data, 0);
        }

        public override object Step2()
        {
            var instance = new Day24();
            var data = instance.PrepareData(CurrentInput);
            return instance.GetNbBlackTilesAferNDays(data, 100);
        }
    }
}
