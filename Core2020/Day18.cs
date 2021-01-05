using System;
using System.Collections.Generic;
using System.Linq;

namespace Core2020
{
    public class Day18
    {
        public List<string> PrepareData(string input)
        {
            return input.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None).ToList();
        }

        public long GetSumOfAllEquations(List<string> input, bool mathsInReverse)
        {
            var results = input.Select(x => ResolveEquation(x, mathsInReverse));
            return results.Sum();
        }

        public long ResolveEquation(string equation, bool mathsInReverse)
        {
            var tokens = ParseEquation(equation);
            var rpn = ShuntingYard(tokens, mathsInReverse);
            
            return ComputeRPN(rpn);
        }

        public long ComputeRPN(Stack<Token> rpn)
        {
            var token = rpn.Pop();
            if (token.GetType() != typeof(Number))
            {
                var left = ComputeRPN(rpn);
                var right = ComputeRPN(rpn);

                if (((Operator) token).OperatorValue == '+') return left + right;
                if (((Operator) token).OperatorValue == '*') return left * right;
            }

            return ((Number) token).NumberValue;
        }

        public Stack<Token> ShuntingYard(List<Token> tokens, bool mathsInReverse)
        {
            var output = new Stack<Token>();
            var operators = new Stack<Token>();
            foreach (var token in tokens)
            {
                if (token.GetType() == typeof(Number)) output.Push(token);
                if (token.GetType() == typeof(Operator))
                {
                    while (operators.Count > 0 && 
                           !(operators.Peek().GetType() == typeof(Parenthesis) && ((Parenthesis)operators.Peek()).Direction == '(') &&
                           (!mathsInReverse || (operators.Peek().GetType() == typeof(Operator) && ((Operator) operators.Peek()).Precedence > ((Operator)token).Precedence )))
                    {
                        output.Push(operators.Pop());
                    }
                    operators.Push(token);
                }
                if (token.GetType() == typeof(Parenthesis) && ((Parenthesis)token).Direction == '(') operators.Push(token);
                if (token.GetType() == typeof(Parenthesis) && ((Parenthesis) token).Direction == ')')
                {
                    while (operators.Count > 0 && !(operators.Peek().GetType() == typeof(Parenthesis) && ((Parenthesis)operators.Peek()).Direction == '('))
                    {
                        output.Push(operators.Pop());
                    }

                    operators.Pop();
                }
            }

            while (operators.Count > 0)
            {
                output.Push(operators.Pop());
            }

            return output;
        }

        public List<Token> ParseEquation(string equation)
        {
            var correctEquation = equation.Replace("(", "( ").Replace(")", " )");
            var list = correctEquation.Split(' ');

            var factory = new TokenFactory();
            return list.Select(x => factory.CreateToken(x)).ToList();
        }

        public class TokenFactory
        {
            public Token CreateToken(string value)
            {
                if (value == "+" || value == "*") return new Operator()
                {
                    Value = value,
                    OperatorValue = value[0],
                    Precedence = value == "+" ? 1 : 0
                };

                if (value == "(" || value == ")") return new Parenthesis()
                {
                    Value = value,
                    Direction = value[0]
                };

                return new Number()
                {
                    Value = value,
                    NumberValue = int.Parse(value)
                };
            }
        }

        public class Token
        {
            public string Value { get; set; }
        }

        public class Number : Token
        {
            public int NumberValue { get; set; }
        }

        public class Operator : Token
        {
            public char OperatorValue { get; set; }
            public int Precedence { get; set; }
        }

        public class Parenthesis : Token
        {
            public char Direction { get; set; }
        }
    }
}
