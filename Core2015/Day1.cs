using System.Linq;

namespace Core2015
{
    public class Day1
    {
        public int GetToFloor(string input)
        {
            return input.ToCharArray().Sum(c => c == '(' ? 1 : -1);
        }

        public int GetBasementPosition(string input)
        {
            var array = input.ToCharArray();
            var floor = 0;
            for (var i = 0; i < array.Length; i++)
            {
                floor += array[i] == '(' ? 1 : -1;

                if (floor == -1) return i + 1;
            }

            return array.Length;
        }
    }
}
