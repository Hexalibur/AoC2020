﻿using AdventOfCode.Days.Interface;
using Core2020;
using System;

namespace AdventOfCode.Days
{
    public class Day5Executor: DailyExecuter
    {
        public override object Step1()
        {
            var instance = new Core2020.Day5();
            var plane = new Day5.Plane()
            {
                Cols = 8,
                Rows = 128
            };
            var data = instance.PrepareData(CurrentInput);
            

            var result = instance.FindHighestSeatId(data, plane);
            Console.WriteLine($"Day5.1 : {result}");
            return result;
        }

        public override object Step2()
        {
            var instance = new Core2020.Day5();
            var plane = new Day5.Plane()
            {
                Cols = 8,
                Rows = 128
            };
            var data = instance.PrepareData(CurrentInput);

            var result = instance.FindSingleEmptySeatId(data, plane);
            Console.WriteLine($"Day5.2 : {result}");
            return result;
        }
        public Day5Executor(string input) : base(input) {}
        public Day5Executor() : base(DailyInputs.d5_list) {}
    }
}