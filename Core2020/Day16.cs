using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Core2020
{
    public class Day16
    {
        public class TicketFieldRuleRange
        {
            public long Min { get; set; } 
            public long Max { get; set; }

            public bool IsValid(long value)
            {
                return value >= Min && value <= Max;
            }
        }
        public class TicketFieldRule
        {
            public string RuleName { get; set; }
            public TicketFieldRuleRange[] Ranges { get; set; }

            public bool IsValid(long value)
            {
                return Ranges.Any(x => x.IsValid(value));
            }
        }

        public class Ticket
        {
            public long[] Values { get; set; }

            public long[] GetInvalidValues(TicketFieldRule[] rules)
            {
                return Values.Where(v => rules.All(r => !r.IsValid(v))).ToArray();
            }
            public long[] GetValidValues(TicketFieldRule[] rules)
            {
                return Values.Where(v => rules.Any(r => r.IsValid(v))).ToArray();
            }

            public bool IsValid(TicketFieldRule[] rules)
            {
                return Values.All(v => rules.Any(r => r.IsValid(v)));
            }
        }

        public class PuzzleData
        {
            public TicketFieldRule[] Rules { get; set; }
            public Ticket YourTicket { get; set; }
            public Ticket[] Tickets { get; set; }

        }
        public PuzzleData PrepareData(string input)
        {
            var list = input.Split(
                new[] {"\r\n\r\n", "\r\r", "\n\n"},
                StringSplitOptions.None);

            return new PuzzleData()
            {
                Rules = CreateTicketFieldRules(list[0]),
                YourTicket = CreateYourTicket(list[1]),
                Tickets = CreateTickets(list[2]),
            };
        }



        private Ticket[] CreateTickets(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None).ToList();
            list.RemoveAt(0);
            return list.Select(CreateTicket).ToArray();
        }

        private Ticket CreateYourTicket(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);

            return CreateTicket(list[1]);
        }

        private Ticket CreateTicket(string input)
        {
            return new Ticket()
            {
                Values = input.Split(',').Select(long.Parse).ToArray()
            };
        }

        private TicketFieldRule[] CreateTicketFieldRules(string input)
        {
            var list = input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);
            return list.Select(CreateTickerFieldRule).ToArray();
        }

        private TicketFieldRule CreateTickerFieldRule(string input)
        {
            var list = input.Split(':');

            return new TicketFieldRule()
            {
                RuleName = list[0],
                Ranges = CreateTickerFieldRuleRanges(list[1])
            };
        }

        private TicketFieldRuleRange[] CreateTickerFieldRuleRanges(string input)
        {
            var list = input.Split(
                new[] {" or "},
                StringSplitOptions.None);

            return list.Select(CreateTickerFieldRuleRange).ToArray();
        }

        private TicketFieldRuleRange CreateTickerFieldRuleRange(string input)
        {
            var list = input.Split('-');
            return new TicketFieldRuleRange()
            {
                Min = long.Parse(list[0]),
                Max = long.Parse(list[1])
            };
        }

        public long GetSumOfInvalidNumbers(PuzzleData data)
        {
            return data.Tickets.SelectMany(t => t.GetInvalidValues(data.Rules)).Sum();
        }

        public long GetDepartureProduct(PuzzleData data)
        {
            var ruleOrder = FindRuleOrder(data);

            long result = 1;
            foreach(var rule in ruleOrder.OrderBy(r => r.Key))
            {
                if (rule.Value.RuleName.StartsWith("departure"))
                {
                    result *= data.YourTicket.Values[rule.Key];
                }
            }

            return result;
        }

        public Dictionary<int, TicketFieldRule> FindRuleOrder(PuzzleData data)
        {
            var validTickets = data.Tickets.Where(t => t.IsValid(data.Rules)).ToArray();

            var ruleOrder = new Dictionary<int, TicketFieldRule>();

            while (ruleOrder.Keys.Count < data.YourTicket.Values.Length)
            {
                for (var i = 0; i < data.YourTicket.Values.Length; i++)
                {
                    var values = validTickets.Select(x => x.Values[i]);
                    var rules = data.Rules.Where(r => !ruleOrder.ContainsValue(r)).Where(r => values.All(v => r.IsValid(v))).ToList();

                    if (rules.Count() == 1)
                    {
                        ruleOrder.Add(i, rules.Single());
                    }
                }
            }

            return ruleOrder;
        }
    }
}
