using AdventOfCode.Days.Base;
using Core2020;

namespace AdventOfCode.Days.Y2020
{
    class Day25Executor : DailyExecuter
    {
        public Day25Executor(string input) : base(input, "Day25")
        {
        }

        public Day25Executor() : base(DailyInputs.d25_list, "Day25")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
        public override object Step1()
        {
            var instance = new Day25();
            var data = instance.PrepareData(CurrentInput);
            return instance.GetEncryptionKey(data);
        }

        public override object Step2()
        {
            var instance = new Day25();
            var data = instance.PrepareData(CurrentInput);
            return instance.GetEncryptionKey(data);
        }
    }
}
