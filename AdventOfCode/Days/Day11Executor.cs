using AdventOfCode.Days.Interface;
using Core2020;
using System;
using System.Collections.Generic;

namespace AdventOfCode.Days
{
    public class Day11Executor : DailyExecuter
    {
        private bool IsSkip = true;

        private List<Day11.Seat> data;
        public Day11Executor(string input) : base(input)
        {
        }

        public Day11Executor() : base(DailyInputs.d11_list)
        {
        }

        public override object Step1()
        {
            if (IsSkip)
            {
                Console.WriteLine($"Day11.1 : Skip");
                return 0;
            }
            Console.WriteLine($"Day11 prepare data start : {DateTime.Now.ToLongTimeString()}");
            var instance = new Core2020.Day11();
            data = instance.PrepareData(CurrentInput);
            Console.WriteLine($"Day11 prepare data end : {DateTime.Now.ToLongTimeString()}");
            
            Console.WriteLine($"Day11.1 start : {DateTime.Now.ToLongTimeString()}");
            var result = instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFourNearingSeatsRule());
            
            Console.WriteLine($"Day11.1 : {result}");
            Console.WriteLine($"Day11.1 end : {DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            if (IsSkip)
            {
                Console.WriteLine($"Day11.2 : Skip");
                return 0;
            }
            Console.WriteLine($"Day11.2 start : {DateTime.Now.ToLongTimeString()}");
            var instance = new Core2020.Day11();
            if (data == null) data = instance.PrepareData(CurrentInput);
            
            var result = instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFiveNearingSeatsRule());

            Console.WriteLine($"Day11.2 : {result}");
            Console.WriteLine($"Day11.2 end : {DateTime.Now.ToLongTimeString()}");
            Console.WriteLine();
            return result;
        }
    }
}
