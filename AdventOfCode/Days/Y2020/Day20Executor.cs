using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    public class Day20Executor : DailyExecuter
    {
        public Day20Executor(string input) : base(input, "Day20")
        {
        }

        public Day20Executor() : base(DailyInputs.d20_list, "Day20")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day20();

            var data = instance.PrepareData(CurrentInput);

            return instance.GetProductOfAllCorner(data);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day20();

            var data = instance.PrepareData(CurrentInput);

            return instance.FindSeaMonster(data);
        }
    }
}
