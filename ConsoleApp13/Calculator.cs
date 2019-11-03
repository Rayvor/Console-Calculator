using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp13
{
    public class Calculator
    {
        Dictionary<string, Func<double, double, double>> _funcs = new Dictionary<string, Func<double, double, double>>
        {
            { "+" , (x, y) => x + y },
            { "-" , (x, y) => x - y },
            { "/" , (x, y) => x / y },
            { "*" , (x, y) => x * y },
            { "^" , (x, y) => Math.Pow(x, y) }
        };

        public string ConvertToPostfix(string input)
        {
            var stack = new Stack<string>();
            string result = string.Empty;

            if (input == string.Empty)
                throw new InvalidInputException("Input string is empty");

            foreach (char ch in input)
            {
                string symbol = ch.ToString();

                if (ch != '(' && ch != ')')
                    if (char.IsLetter(ch) || (!char.IsNumber(ch) && !_funcs.ContainsKey(symbol)))
                            throw new InvalidInputException("Invalid input string");

                if (char.IsNumber(ch))
                    result += ch + " ";
                else
                {
                    switch (symbol)
                    {
                        case "(":
                            stack.Push(symbol);
                            break;
                        case ")":
                            string s;
                            while ((s = stack.Pop()) != "(")
                                result += s + " ";
                            break;
                        default:
                            if (stack.Count > 0)
                                if (GetPriority(symbol) < GetPriority(stack.Peek()))
                                    if (stack.Count > 1)
                                        result += string.Format("{0} {1} ", stack.Pop(), stack.Pop());
                                    else
                                        result += string.Format("{0} ", stack.Pop());
                            stack.Push(symbol);
                            break;
                    }
                }
            }

            while(stack.Count > 0)
                result += stack.Pop() + " ";

            return result.Trim();
        }


        public double Calculate(string input)
        {
            var stack = new Stack<double>();

            input.Split(' ').ToList().ForEach((item) =>
            {
                if (_funcs.ContainsKey(item))
                {
                    var (y, x) = (stack.Pop(), stack.Pop());
                    stack.Push(_funcs[item](x, y));
                }
                else
                    if (double.TryParse(item, out double num))
                        stack.Push(num);
            });

            return stack.Pop();
        }

        private int GetPriority(string symbol)
        {
            switch (symbol)
            {
                case "(":
                case ")":
                    return 0;
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 4;
            }
        }
    }
}
