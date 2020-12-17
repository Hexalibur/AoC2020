using AdventOfCode.Days.Base;

namespace AdventOfCode.Days
{
    public class Day12Executor : DailyExecuter
    {
        public Day12Executor(string input) : base(input, "Day12")
        {
        }

        public Day12Executor() : base(DailyInputs.d12_list, "Day12")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day12();

            var data = instance.PrepareData(CurrentInput);

            return instance.ComputeManhattanDistance(data);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day12();

            var data = instance.PrepareData(CurrentInput);

            return instance.ComputeManhattanDistanceWayPoint(data);
        }
    }
}
