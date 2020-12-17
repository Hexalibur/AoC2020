using System;

namespace AdventOfCode.Days.Base
{
    public abstract class DailyExecuter
    {
        public abstract bool IsSkip1 { get; }
        public abstract bool IsSkip2 { get; }

        public string CurrentInput;
        public string DayName;
        public DailyExecuter(string input, string name)
        {
            CurrentInput = input;
            DayName = name;
        }
         public abstract object Step1();
         public abstract object Step2();

         public object ExecuteStep1()
         {
             if (IsSkip1)
             {
                 Skip(1);
                 return 0;
             }
             Start(1);
             var result = Step1();
             Result(1, result);
             Stop(1);
             return result;
         }

         public object ExecuteStep2()
         {
             if (IsSkip2)
             {
                 Skip(2);
                 return 0;
             }

             Start(2);
             var result = Step2();
             Result(2, result);
             Stop(2);
             return result;
         }

         public void Start(int step)
         {
             Console.WriteLine($"{DayName}.{step} start : {DateTime.Now.ToLongTimeString()}");
         }
         public void Result(int step, object result)
         {
             Console.WriteLine($"{DayName}.{step} : {result}");
         }
         
         public void Stop(int step)
         {
             Console.WriteLine($"{DayName}.{step} stop : {DateTime.Now.ToLongTimeString()}");
             Console.WriteLine();
         }
         public void Skip(int step)
         {
             Console.WriteLine($"{DayName}.{step} skip for performance issues");
             Console.WriteLine();
         }
    }
}
