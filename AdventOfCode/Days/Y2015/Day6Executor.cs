using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2015
{
    class Day6Executor: DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2015.Day6();

            var data = instance.PrepareData(CurrentInput);
            return instance.GetNbLitAfterAllInstructions(data);
        }

        public override object Step2()
        {
            var instance = new Core2015.Day6();

            var data = instance.PrepareData(CurrentInput);
            return instance.GetTotalBrightnessAfterAllInstructions(data);
        }

        public Day6Executor(string input) : base(input, "Day6") {}
        public Day6Executor() : base(DailyInputs.d6_list, "Day6") {}

        public override bool IsSkip1 => true;
        public override bool IsSkip2 => true;
    }
}
