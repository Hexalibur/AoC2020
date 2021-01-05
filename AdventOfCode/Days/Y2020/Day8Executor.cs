using System.Linq;
using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    public class Day8Executor : DailyExecuter
    {
        public Day8Executor(string input) : base(input, "Day8") {}
        public Day8Executor() : base(DailyInputs.d8_list, "Day8") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day8();

            var data = instance.PrepareData(CurrentInput).ToList();

            return instance.RunGame(data).Accumulation;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day8();

            var data = instance.PrepareData(CurrentInput).ToList();

            return instance.TryRunGameProperly(data);
        }
    }
}
