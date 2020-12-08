using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day2
    {
        public int ValidatePasswords(IEnumerable<string> passwords, Type type)
        {
            return passwords.Count(p => IsValid(p, type));
        }

        public bool IsValid(string password, Type type)
        {
            var str = password.Split(':');

            IRule rule = type == typeof(Rule1) ? (IRule) new Rule1(str[0]) : (IRule) new Rule2(str[0]);

            return rule.Validate(str[1]);
        }

        public IList<string> PrepareData(string input)
        {
            return input.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
        }
    }

    public interface IRule
    {
        bool Validate(string password);
    }

    public class Rule1 : IRule
    {
        public char MandatoryChar { get; set; }
        public int MinOccurs { get; set; }
        public int MaxOccurs { get; set; }
        public Rule1(string rule)
        {
            var cleanRule = rule.Replace("-", " ");
            var parameters = cleanRule.Split(' ');
            MinOccurs = int.Parse(parameters[0]);
            MaxOccurs = int.Parse(parameters[1]);
            MandatoryChar = char.Parse(parameters[2]);
        }

        public bool Validate(string password)
        {
            var list = password.ToCharArray();
            var nbMandatory = list.Count(l => l == MandatoryChar);
            return nbMandatory >= MinOccurs && nbMandatory <= MaxOccurs;
        }
    }

    public class Rule2 : IRule
    {
        public char MandatoryChar { get; set; }
        public int PositionMustBe { get; set; }
        public int PositionMustNotBe { get; set; }
        public Rule2(string rule)
        {
            var cleanRule = rule.Replace("-", " ");
            var parameters = cleanRule.Split(' ');
            PositionMustBe = int.Parse(parameters[0]) - 1;
            PositionMustNotBe = int.Parse(parameters[1]) - 1;
            MandatoryChar = char.Parse(parameters[2]);
        }

        public bool Validate(string password)
        {
            var list = password.Trim().ToCharArray();
            return (list[PositionMustBe] == MandatoryChar && list[PositionMustNotBe] != MandatoryChar) ||
                   (list[PositionMustBe] != MandatoryChar && list[PositionMustNotBe] == MandatoryChar);
        }
    }

    
}
