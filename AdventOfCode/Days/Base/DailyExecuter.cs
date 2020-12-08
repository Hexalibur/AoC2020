namespace AdventOfCode.Days.Interface
{
    public abstract class DailyExecuter
    {
        public string CurrentInput;
        public DailyExecuter(string input)
        {
            CurrentInput = input;
        }
         public abstract object Step1();
         public abstract object Step2();
    }
}
