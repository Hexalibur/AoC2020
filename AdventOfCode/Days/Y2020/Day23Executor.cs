using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    public class Day23Executor : DailyExecuter
    {
        public Day23Executor(string input) : base(input, "Day23")
        {
        }

        public Day23Executor() : base(DailyInputs.d23_list, "Day23")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
        public override object Step1()
        {
            var instance = new Core2020.Day23();

            var data = instance.PrepareData(CurrentInput);

            return instance.Shuffle(data);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day23();

            var data = instance.PrepareData(CurrentInput, 1000000);

            return instance.ShuffleMillions(data);
        }
    }
}
