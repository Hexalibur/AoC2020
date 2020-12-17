using AdventOfCode.Days.Base;
using Core2020;

namespace AdventOfCode.Days
{
    class Day14Executor: DailyExecuter

    {
        public Day14Executor(string input) : base(input, "Day14")
        {
        }

        public Day14Executor() : base(DailyInputs.d14_list, "Day14")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day14();

            var data = instance.PrepareData(CurrentInput);

            return instance.GetSumOfAllValuesLeft(data, Day14.Mask.MaskApplication.Value);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day14();
            var data = instance.PrepareData(CurrentInput);

            return instance.GetSumOfAllValuesLeft(data, Day14.Mask.MaskApplication.Address);

        }
    }
}
