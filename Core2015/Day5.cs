using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2015
{
    public class Day5
    {
        public bool IsStringNice(string str )
        {
            var rules = new IRule[] { new AtLeastOneLetterAppearingTwiceInARowRule(), new AtLeastThreeVowelsRule(), new DoesNotContainsNaughtyRule() };
            return rules.All(x => x.IsNice(str));
        }

        public bool IsStringNiceBonus(string str )
        {
            var rules = new IRule[] { new ContainsPairOfLetterTwice(), new AtLeastOneRepeatedLetterWithAnotherBetween() };

            return rules.All(x => x.IsNice(str));
        }

        public interface IRule
        {
            bool IsNice(string str);
        }

        public class AtLeastThreeVowelsRule : IRule
        {
            public readonly char[] Vowels = new[] { 'a','e','i','o','u' };
            
            public bool IsNice(string str)
            {
                var nbVowels = 0;
                var array = str.ToCharArray();
                foreach (var vowel in Vowels)
                {
                    nbVowels += array.Count(x => x == vowel);
                }

                return nbVowels >= 3;
            }
        }

        public class AtLeastOneLetterAppearingTwiceInARowRule : IRule
        {
            public bool IsNice(string str)
            {
                if (str.Length < 2) return false;
                var array = str.ToCharArray();
                for (var i = 0; i < array.Length -1; i++)
                {
                    if (array[i] == array[i + 1]) return true;
                }

                return false;
            }
        }

        public class DoesNotContainsNaughtyRule : IRule
        {
            public readonly string[] Naughties = new[] { "ab","cd","pq","xy" };
            public bool IsNice(string str)
            {
                foreach (string naughty in Naughties)
                {
                    if (str.Contains(naughty)) return false;
                }

                return true;
            }
        }

        public class AtLeastOneRepeatedLetterWithAnotherBetween : IRule
        {
            public bool IsNice(string str)
            {
                if (str.Length < 3) return false;
                var array = str.ToCharArray();
                for (var i = 0; i < array.Length -2; i++)
                {
                    if (array[i] == array[i + 2]) return true;
                }

                return false;
            }
        }

        public class ContainsPairOfLetterTwice : Day5.IRule
        {
            public bool IsNice(string str)
            {
                if (str.Length < 4) return false;
                var array = str.ToCharArray();

                for (var i = 0; i < array.Length -3; i++)
                {
                    for (var x = i + 2; x < array.Length - 1; x++)
                    {
                        if (array[x] == array[i] && array[i + 1] == array[x + 1])
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public List<string> PrepareData(string input)
        {
            return input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None).ToList();
            
        }

        public int HowManyStringsAreNice(List<string> data)
        {
            return data.Count(IsStringNice);
        }

        public int HowManyStringsAreNiceBonus(List<string> data)
        {
            var dico = new Dictionary<string, bool>();
            foreach (var d in data)
            {
                dico.Add(d, IsStringNiceBonus(d));
                
            }
            return data.Count(IsStringNiceBonus);
        }
    }
}
