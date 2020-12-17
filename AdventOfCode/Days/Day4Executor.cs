using AdventOfCode.Days.Base;

namespace AdventOfCode.Days
{
    public class Day4Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day4();
            var data = instance.PrepareData(CurrentInput);

            return instance.ValidatePassports(data, true);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day4();
            var data = instance.PrepareData(CurrentInput);

            return instance.ValidatePassports(data, false);
        }
        public Day4Executor(string input) : base(input, "Day4") {}
        public Day4Executor() : base(DailyInputs.d4_list, "Day4") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
