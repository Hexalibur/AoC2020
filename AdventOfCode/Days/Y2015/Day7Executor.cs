using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2015
{
    class Day7Executor : DailyExecuter
    {
        public Day7Executor(string input) : base(input, "Day7")
        {
        }

        public Day7Executor() : base(DailyInputs.d7_list, "Day7")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
        public override object Step1()
        {
            var instance = new Core2015.Day7();

            var data = instance.PrepareData(CurrentInput);

            return instance.GetSignalProvidedToWire(data, "a");
        }

        public override object Step2()
        {
            var instance = new Core2015.Day7();

            var data = instance.PrepareData(CurrentInput);

            return instance.DoSomethingElse(data);
        }
    }
}
