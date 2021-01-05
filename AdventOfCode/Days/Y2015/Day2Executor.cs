using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2015
{
    public class Day2Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2015.Day2();
            var data = instance.PrepareData(CurrentInput);
            return instance.GetTotalSquareFeet(data);
        }

        public override object Step2()
        {
            var instance = new Core2015.Day2();
            var data = instance.PrepareData(CurrentInput);
            return instance.GetTotalLienearFeet(data);
        }

        public Day2Executor(string input) : base(input, "Day2") {}
        public Day2Executor() : base(DailyInputs.d2_list, "Day2") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
