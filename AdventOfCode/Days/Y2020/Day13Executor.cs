using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    public class Day13Executor : DailyExecuter

    {
        public Day13Executor(string input) : base(input, "Day13")
        {
        }

        public Day13Executor() : base(DailyInputs.d13_list, "Day13")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day13();
            var data = instance.PrepareData(CurrentInput);

            return instance.GetEarliestBus(data);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day13();

            var data = instance.PrepareData(CurrentInput);

            return instance.GetEarliestMatchedSequence(data);
        }
    }
}
