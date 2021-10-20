﻿using System;
using System.Collections.Generic;

namespace SQ3_ПереводИнфикснойЗаписи_В_Постфиксную_РасчетПостфиксной
{
    internal class Program
    {
        private static readonly HashSet<string> HPO = new HashSet<string> {"*", "/"};

        private static readonly HashSet<string> LPO = new HashSet<string> {"+", "-"};

        private static readonly Dictionary<string, Func<double, double, double>> Operators =
            new Dictionary<string, Func<double, double, double>>
            {
                {"+", Plus},
                {"-", Subtract},
                {"*", Multiply},
                {"/", Divide}
            };

        public static void Main()
        {
            var infixString = Console.ReadLine();
            var postfixList = Transform(infixString);
            Console.WriteLine(string.Join(" ", postfixList));
            Console.WriteLine(CalculatePostfix(postfixList));
        }

        private static double CalculatePostfix(List<string> postfixList)
        {
            var numbers = new Stack<double>();
            double numb1;
            double numb2;
            for (var i = 0; i < postfixList.Count; i++)
                if (Operators.ContainsKey(postfixList[i]))
                {
                    numb2 = numbers.Pop();
                    numb1 = numbers.Pop();
                    numbers.Push(Operators[postfixList[i]](numb1, numb2));
                }
                else
                {
                    numbers.Push(double.Parse(postfixList[i]));
                }

            return numbers.Pop();
        }

        private static List<string> Transform(string infixString)
        {
            var input = infixString.Split();
            var output = new List<string>();
            var operators = new Stack<string>();
            for (var i = 0; i < input.Length; i++)
                switch (input[i])
                {
                    case "+":
                        if (operators.Count > 0 && (HPO.Contains(operators.Peek()) || LPO.Contains(operators.Peek())))
                            output.Add(operators.Pop());
                        operators.Push("+");
                        break;
                    case "-":
                        if (operators.Count > 0 && (HPO.Contains(operators.Peek()) || LPO.Contains(operators.Peek())))
                            output.Add(operators.Pop());
                        operators.Push("-");
                        break;
                    case "*":
                        if (operators.Count > 0 && HPO.Contains(operators.Peek()))
                            output.Add(operators.Pop());
                        operators.Push("*");
                        break;
                    case "/":
                        if (operators.Count > 0 && HPO.Contains(operators.Peek()))
                            output.Add(operators.Pop());
                        operators.Push("/");
                        break;
                    case "(":
                        operators.Push("(");
                        break;
                    case ")":
                        while (operators.Peek() != "(")
                            output.Add(operators.Pop());
                        operators.Pop();
                        break;
                    default:
                        output.Add(input[i]);
                        break;
                }

            while (operators.Count > 0)
                output.Add(operators.Pop());

            return output;
        }

        private static double Plus(double numb1, double numb2) => numb1 + numb2;

        private static double Subtract(double numb1, double numb2) => numb1 - numb2;

        private static double Multiply(double numb1, double numb2) => numb1 * numb2;

        private static double Divide(double numb1, double numb2) => numb1 / numb2;
    }
}