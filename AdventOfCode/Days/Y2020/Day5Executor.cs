using AdventOfCode.Days.Base;
using Core2020;

namespace AdventOfCode.Days.Y2020
{
    public class Day5Executor: DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day5();

            var plane = new Day5.Plane()
            {
                Cols = 8,
                Rows = 128
            };
            var data = instance.PrepareData(CurrentInput);
            

            return instance.FindHighestSeatId(data, plane);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day5();

            var plane = new Day5.Plane()
            {
                Cols = 8,
                Rows = 128
            };
            var data = instance.PrepareData(CurrentInput);

            return instance.FindSingleEmptySeatId(data, plane);
        }
        public Day5Executor(string input) : base(input, "Day5") {}
        public Day5Executor() : base(DailyInputs.d5_list, "Day5") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
