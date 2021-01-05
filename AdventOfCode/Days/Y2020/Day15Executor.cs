using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    class Day15Executor: DailyExecuter

    {

        public Day15Executor(string input) : base(input, "Day15")
        {
        }

        public Day15Executor() : base(DailyInputs.d15_list, "Day15")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => true;

        public override object Step1()
        {
            var instance = new Core2020.Day15();

            var data = instance.PrepareData(CurrentInput);

            return  instance.GetSpokenNumber(data, 2020);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day15();
            var data = instance.PrepareData(CurrentInput);

            return instance.GetSpokenNumber(data, 30000000);
        }
    }
}
