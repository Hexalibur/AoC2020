using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day19
    {
        public class PuzzleData
        {
            public List<Rule> Rules { get; set; }
            public List<string> Messages { get; set; }

            public void ReplaceRule(List<Rule> ruleToReplace)
            {
                foreach (var rule in ruleToReplace)
                {
                    var old = Rules.Single(x => x.Id == rule.Id);
                    Rules[Rules.IndexOf(old)] = rule;
                }
            }
        }

        public class Rule
        {
            public List<List<int>> SubRules { get; set; }
            public List<List<char>> PossibleMatches { get; set; }

            public int Id;
            
            public List<List<char>> GetPossibleMatches(List<Rule> rules, string value, int length = 0)
            {
                var possibleMatches = new List<List<char>>();

                if (length >= value.Length) return possibleMatches;

                if (PossibleMatches.Count > 0)
                {
                    possibleMatches.AddRange(PossibleMatches); 
                }

                foreach (var sub in SubRules)
                {
                    var subList = new List<List<char>>();

                    foreach (var ruleId in sub)
                    {
                        var rule = rules.Single(r => r.Id == ruleId);

                        var possibles = rule.GetPossibleMatches(rules, value, length + 1);

                        if (!possibles.Any()) continue;

                        var newSubList = new List<List<char>>();

                        if (subList.Count == 0) newSubList = possibles.Select(x => x).ToList();
                        foreach (var list in possibles)
                        {
                            foreach (var previous in subList)
                            {
                                var concat = previous.Concat(list).ToList();
                                newSubList.Add(concat);
                            }
                        }
                        subList = newSubList.Select(x => x).ToList();
                    }

                    possibleMatches.AddRange(subList);
                }

                return possibleMatches.Where(x => value.Contains(new string(x.ToArray()))).ToList();
            }

            public List<List<char>> GetPossibleMatches(List<Rule> rules)
            {
                var possibleMatches = new List<List<char>>();

                if (PossibleMatches.Count > 0)
                {
                    possibleMatches.AddRange(PossibleMatches); 
                }

                foreach (var sub in SubRules)
                {
                    var subList = new List<List<char>>();

                    foreach (var ruleId in sub)
                    {
                        var rule = rules.Single(r => r.Id == ruleId);

                        var possibles = rule.GetPossibleMatches(rules);

                        var newSubList = new List<List<char>>();

                        if (subList.Count == 0) newSubList = possibles.Select(x => x).ToList();
                        foreach (var list in possibles)
                        {
                            foreach (var previous in subList)
                            {
                                newSubList.Add(previous.Concat(list).ToList());
                            }
                        }
                        subList = newSubList.Select(x => x).ToList();
                    }

                    possibleMatches.AddRange(subList);
                }

                return possibleMatches;
            }

            public static Rule Create(string input)
            {
                var data = input.Split(':');
                var id = int.Parse(data[0]);
                var possibleMatches = new List<List<char>>();
                var subRules = new List<List<int>>();
                if (data[1].Contains("'"))
                {
                    var chars = new List<char>();
                    chars.Add(data[1].Replace("'", "").Trim()[0]);
                    possibleMatches.Add(chars);
                }
                else
                {
                    var subs = data[1].Split('|');
                    foreach (var sub in subs)
                    {
                        var rules = sub.Trim().Split(' ');
                        var ruleId = rules.Select(int.Parse).ToList();
                        subRules.Add(ruleId);
                    }
                }

                return new Rule()
                {
                    Id = id,
                    PossibleMatches = possibleMatches,
                    SubRules = subRules
                };
            }

        }

        public PuzzleData PrepareData(string input)
        {
            var regions = input.Split(
                new[] {"\r\n\r\n", "\r\r", "\n\n"},
                StringSplitOptions.None);

            var rules = regions[0].Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None).ToList();

            var messages = regions[1].Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None).ToList();

            return new PuzzleData()
            {
                Rules = rules.Select(Rule.Create).ToList(),
                Messages = messages
            };


        }

        public long HowManyMessagesMatchRule(PuzzleData data, int ruleToMatch, List<string> newRules = null)
        {
            if (newRules != null)
            {
                var rules = newRules.Select(Rule.Create).ToList();
                data.ReplaceRule(rules);
            }

            var rule = data.Rules.Single(r => r.Id == ruleToMatch);
            return data.Messages.Count(m => rule.GetPossibleMatches(data.Rules, m).Any(p => IsMatch(m, p)));

            //var possibleMatches = rule.GetPossibleMatches(data.Rules).Select(x => new string(x.ToArray())).ToList();

            //return data.Messages.Count(m => possibleMatches.Contains(m));
        }

        public bool IsMatch(string value, List<char> matching)
        {
            var matchingString = new string(matching.ToArray());

            return value == matchingString;
        }
    }
}
