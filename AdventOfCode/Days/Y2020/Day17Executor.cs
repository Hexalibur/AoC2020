using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    class Day17Executor: DailyExecuter

    {
        public Day17Executor(string input) : base(input, "Day17")
        {
        }

        public Day17Executor() : base(DailyInputs.d17_list, "Day17")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => true;

        public override object Step1()
        {
            var instance = new Core2020.Day17();

            var data = instance.PrepareData(CurrentInput);

            return instance.Cycle(data, 6, false);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day17();

            var data = instance.PrepareData(CurrentInput);

            return instance.Cycle(data, 6, true);
        }
    }
}
