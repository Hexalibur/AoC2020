using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    class Day16Executor: DailyExecuter

    {
        public Day16Executor(string input) : base(input, "Day16")
        {
        }

        public Day16Executor() : base(DailyInputs.d16_list, "Day16")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day16();

            var data = instance.PrepareData(CurrentInput);

            return instance.GetSumOfInvalidNumbers(data);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day16();
            var data = instance.PrepareData(CurrentInput);

            return instance.GetDepartureProduct(data);
        }
    }
}
