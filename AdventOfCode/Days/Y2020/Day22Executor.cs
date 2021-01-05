using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    public class Day22Executor : DailyExecuter
    {
        public Day22Executor(string input) : base(input, "Day22")
        {
        }

        public Day22Executor() : base(DailyInputs.d22_list, "Day22")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day22();

            var data = instance.PrepareData(CurrentInput);

            return instance.CalculateWinnerScore(data);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day22();

            var data = instance.PrepareData(CurrentInput);

            return instance.CalculateWinnerRecursiveScore(data);
        }
    }
}
