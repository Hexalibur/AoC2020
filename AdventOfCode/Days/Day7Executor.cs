using AdventOfCode.Days.Base;

namespace AdventOfCode.Days
{
    public class Day7Executor : DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day7();

            var data = instance.PrepareData(CurrentInput);

            return instance.FindNbOfBagColorContainingAtLeastOneSpecifiedBagColor(data, "shiny gold");
        }

        public override object Step2()
        {
            var instance = new Core2020.Day7();

            var data = instance.PrepareData(CurrentInput);

            return instance.FindNbOfBagColorContainedInOneSpecifiedBagColor(data, "shiny gold");
        }
        public Day7Executor(string input) : base(input, "Day7") {}
        public Day7Executor() : base(DailyInputs.d7_list, "Day7") {}

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;
    }
}
