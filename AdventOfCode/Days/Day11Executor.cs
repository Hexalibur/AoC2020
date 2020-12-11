using AdventOfCode.Days.Interface;
using Core2020;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Days
{
    public class Day11Executor : DailyExecuter
    {
        private List<Day11.Seat> data;
        public Day11Executor(string input) : base(input)
        {
            var instance = new Core2020.Day11();
            data = instance.PrepareData(CurrentInput);
        }

        public Day11Executor() : base(DailyInputs.d11_list)
        {
        }

        public override object Step1()
        {
            var instance = new Core2020.Day11();

            var result = instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFourNearingSeatsRule());

            Console.WriteLine($"Day11.1 : {result}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day11();
            
            var result = instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFiveNearingSeatsRule());

            Console.WriteLine($"Day11.2 : {result}");
            return result;
        }
    }
}
