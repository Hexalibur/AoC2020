using System.Collections.Generic;
using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    class Day19Executor: DailyExecuter
    {
        public Day19Executor(string input) : base(input, "Day19")
        {
        }

        public Day19Executor() : base(DailyInputs.d19_list, "Day19")
        {
        }

        public override bool IsSkip1 => true;
        public override bool IsSkip2 => true;

        public override object Step1()
        {
            var instance = new Core2020.Day19();

            var data = instance.PrepareData(CurrentInput);

            return instance.HowManyMessagesMatchRule(data, 0);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day19();

            var data = instance.PrepareData(CurrentInput);

            var newRules = new List<string> {"8: 42 | 42 8", "11: 42 31 | 42 11 31"};

            return instance.HowManyMessagesMatchRule(data, 0, newRules);
        }
    }
}
