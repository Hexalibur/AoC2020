using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day21
    {
        public List<Food> PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);

            return list.Select(Food.Create).ToList();
        }

        public class Food
        {
            public List<string> Foreign { get; set; }
            public List<string> English { get; set; }

            public static Food Create(string x)
            {
                var clean = x.Replace(" (contains ", ";").Replace(")", "").Replace(", ", " ");

                var parts = clean.Split(';');
                return new Food()
                {
                    Foreign = parts[0].Split(' ').ToList(),
                    English = parts[1].Split(' ').ToList()
                };

            }
        }

        public long HowManyTimesNonAllergensIngredientsAppear(List<Food> data)
        {
            var dico = GetDico(data);

            return data.SelectMany(x => x.Foreign).Count(x => !dico.ContainsValue(x));
        }

        private Dictionary<string, string> GetDico(List<Food> data)
        {
            var distinctForeign = data.SelectMany(x => x.Foreign).Distinct().ToList();
            var distinctEnglish = data.SelectMany(x => x.English).Distinct().ToList();

            var dico = new Dictionary<string, string>();

            while (!distinctEnglish.All(e => dico.ContainsKey(e)))
            {
                foreach (var e in distinctEnglish)
                {
                    var appearences = data.Where(x => x.English.Contains(e)).ToList();
                    var foreigns = distinctForeign.Where(x => appearences.All(a => a.Foreign.Contains(x))).ToList();

                    if (foreigns.Count(f => !dico.ContainsValue(f)) == 1)
                    {
                        dico.Add(e, foreigns.Single(f => !dico.ContainsValue(f)));
                    }
                }
            }

            return dico;
        }

        public string GetCanonicalDangerousIngredients(List<Food> data)
        {
            var dico = GetDico(data);

            return string.Join(",", dico.OrderBy(d => d.Key).Select(d => d.Value).ToArray());
        }
    }
}
