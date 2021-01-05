using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2015
{
    public class Day1Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2015.Day1();
            return instance.GetToFloor(CurrentInput);
        }

        public override object Step2()
        {
            var instance = new Core2015.Day1();
            return instance.GetBasementPosition(CurrentInput);
        }

        public Day1Executor(string input) : base(input, "Day1") {}
        public Day1Executor() : base(DailyInputs.d1_list, "Day1") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
