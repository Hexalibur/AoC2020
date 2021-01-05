using AdventOfCode.Days.Base;
using Core2020;

namespace AdventOfCode.Days.Y2020
{
    public class Day2Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day2();

            var list = instance.PrepareData(CurrentInput);

            return instance.ValidatePasswords(list, typeof(Rule1));
        }

        public override object Step2()
        {
            var instance = new Core2020.Day2();

            var list = instance.PrepareData(CurrentInput);

            return instance.ValidatePasswords(list, typeof(Rule2));
        }
        public Day2Executor(string input) : base(input, "Day2") {}
        public Day2Executor() : base(DailyInputs.d2_list, "Day2") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
