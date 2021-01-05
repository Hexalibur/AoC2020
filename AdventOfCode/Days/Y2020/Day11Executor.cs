using System.Collections.Generic;
using AdventOfCode.Days.Base;
using Core2020;

namespace AdventOfCode.Days.Y2020
{
    public class Day11Executor : DailyExecuter
    {
        private List<Day11.Seat> data;
        public Day11Executor(string input) : base(input, "Day11")
        {
        }

        public Day11Executor() : base(DailyInputs.d11_list, "Day11")
        {
        }

        public override bool IsSkip1 => true;
        public override bool IsSkip2 => true;

        public override object Step1()
        {
            var instance = new Core2020.Day11();
            data = instance.PrepareData(CurrentInput);
            return instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFourNearingSeatsRule());
        }

        public override object Step2()
        {
            var instance = new Core2020.Day11();
            if (data == null) data = instance.PrepareData(CurrentInput);
            
            return instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFiveNearingSeatsRule());
        }
    }
}
