using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2015
{
    public class Day4Executor: DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2015.Day4();
            return instance.GetLowestMatch(CurrentInput, "00000");
        }

        public override object Step2()
        {
            var instance = new Core2015.Day4();
            return instance.GetLowestMatch(CurrentInput, "000000");
        }

        public Day4Executor(string input) : base(input, "Day4") {}
        public Day4Executor() : base(DailyInputs.d4_list, "Day4") {}

        public override bool IsSkip1 => true;
        public override bool IsSkip2 => true;
    }
}
