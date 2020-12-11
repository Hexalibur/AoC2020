using AdventOfCode.Days.Interface;
using Core2020;
using System;

namespace AdventOfCode.Days
{
    public class Day11Executor : DailyExecuter
    {
        public Day11Executor(string input) : base(input)
        {
        }

        public Day11Executor() : base(DailyInputs.d11_list)
        {
        }

        public override object Step1()
        {
            var instance = new Core2020.Day11();
            var data = instance.PrepareData(CurrentInput);
            
            Console.WriteLine($"Day11.1 Start : {DateTime.Now.ToLongTimeString()}");
            var result = instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFourNearingSeatsRule());
            Console.WriteLine($"Day11.1 : {result}");
            Console.WriteLine($"Day11.1 Stop :{DateTime.Now.ToLongTimeString()}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day11();
            var data = instance.PrepareData(CurrentInput);
            
            Console.WriteLine($"Day11.2 Start : {DateTime.Now.ToLongTimeString()}");
            var result = instance.HowManySeatsEndsUpOccupied(data, new Day11.NoMoreThanFiveNearingSeatsRule());
            Console.WriteLine($"Day11.2 : {result}");
            Console.WriteLine($"Day11.2 Stop :{DateTime.Now.ToLongTimeString()}");
            return result;
        }
    }
}
