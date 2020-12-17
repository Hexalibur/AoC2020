using AdventOfCode.Days.Base;

namespace AdventOfCode.Days
{
    public class Day3Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day3();
            var list = instance.PrepareData(CurrentInput);

            var patterns = new[] { new int[] {3,1},};

            return instance.CountTreesByPattern(list, patterns);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day3();
            var list = instance.PrepareData(CurrentInput);
            
            var patterns = new[]
            {
                new int[] {1,1},
                new int[] {3,1},
                new int[] {5,1},
                new int[] {7,1},
                new int[] {1,2}
            };

            return instance.CountTreesByPattern(list, patterns);
        }
        public Day3Executor(string input) : base(input, "Day3") {}
        public Day3Executor() : base(DailyInputs.d3_list, "Day3") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
