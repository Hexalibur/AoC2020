using AdventOfCode.Days.Base;

namespace AdventOfCode.Days.Y2020
{
    public class Day21Executor : DailyExecuter
    {
        public Day21Executor(string input) : base(input, "Day21")
        {
        }

        public Day21Executor() : base(DailyInputs.d21_list, "Day21")
        {
        }

        public override bool IsSkip1 => false;
        public override bool IsSkip2 => false;

        public override object Step1()
        {
            var instance = new Core2020.Day21();

            var data = instance.PrepareData(CurrentInput);

            return instance.HowManyTimesNonAllergensIngredientsAppear(data);
        }

        public override object Step2()
        {
            var instance = new Core2020.Day21();

            var data = instance.PrepareData(CurrentInput);

            return instance.GetCanonicalDangerousIngredients(data);
        }
    }
}
