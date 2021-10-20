using System;
using System.Collections.Generic;
using System.Linq;

namespace YR1_ГенераторВыражений
{
    internal class Program
    {
        private static Dictionary<string,string> equvivalentes = new Dictionary<string, string>
        {
            {"0+1", "1"}, {"1*2", "2"},
            {"0+2", "2"}, {"1*x", "x"},
            {"0+x", "x"}, {"2*2", "4"},
            {"0+0", "0"}, {"2*x", "2*x"},
            {"1+1", "2"}, {"x*x", "x*x"},
            {"1+2", "3"}, {"0-1", "-1"},
            {"1+x", "1+x"}, {"0-2", "-2"},
            {"2+2", "4"}, {"0-x", "-x"},
            {"2+x", "2+x"}, {"0-0", "0"},
            {"x+x", "2*x"}, {"1-0", "1"},
            {"0*0", "0"}, {"1-1", "0"},
            {"0*1", "0"}, {"1-2", "-1"},
            {"0*2", "0"}, {"1-x", "1-x"},
            {"0*x", "0"}, {"2-0", "2"},
            {"1*1", "1"}, {"2-1", "1"},
            {"2-2", "0"}, {"2-x", "2-x"},
            {"x-0", "x"}, {"x-1", "x-1"},
            {"x-2", "x-2"}, {"x-x", "0"}
        };

        private enum ElementType
        {
            Numb,
            Op,
            Skob,
            X,
        }

        private class Element
        {
            public ElementType TypeOfEl;
            public string Simbols;
            public int Value;
            public int Index;
            public readonly int Count;

            public Element(ElementType typeOfEl, string simbols, int value, int index, int count)
            {
                TypeOfEl = typeOfEl;
                Simbols = simbols;
                Value = value;
                Index = index;
                Count = count;
            }
        }

        private class Expression : IComparable<Expression>
        {
            public int Length;

            public string[] StrExp;

            public Expression(int length)
            {
                Length = length;
                StrExp = new string[length];
            }


            public int CompareTo(Expression other)
            {
                if (ReferenceEquals(this, other))
                    return 0;
                if (ReferenceEquals(null, other))
                    return 1;
                return Compare(StrExp, other.StrExp);
            }

            private int Compare(string[] strExp, string[] otherStrExp)
            {
                
            }
        }


        private static void Main()
        {
            var numbers = new[] {"0", "1", "2"};
            var x = "x";
            var operators = new[] {"+", "-", "*"};
            var l = int.Parse(Console.ReadLine());
            var expressions = new HashSet<string>();
            for (var i = 1; i <= l; i++)
                foreach (var str in GenerateExpLenI(i, numbers, operators, x))
                    expressions.Add(str);
        }

        private static IEnumerable<string> GenerateExpLenI(int len,
            string[] numbers, string[] operators, string x)
        {
            var exp = "";

            return null;
        }

        private int ParseToMath(string expression)
        {
            var numbersS = new[] {"0", "1", "2"};
            var xS = "x";
            var operatorsS = new[] {"+", "-"};
            var operatorsH = new[] {"*"};
            var numbers = new Stack<int>();
            var operators = new Stack<string>();
            var x = 11;
            var isShoudCalc = false;
            foreach (var simb in expression)
            {
                var str = new string(simb,1);
                if (numbersS.Contains(str))
                {
                    var n = int.Parse(str);
                    if (isShoudCalc)
                    {
                        numbers.Push(Calculate(numbers.Pop(), n,operators.Pop()));
                        isShoudCalc = false;
                    }
                    else
                    {
                        numbers.Push(n);
                    }
                }
                else if (operatorsS.Contains(str))
                {
                    operators.Push(str);
                }
                else if (operatorsH.Contains(str))
                {
                    operators.Push(str);
                    isShoudCalc = true;
                }
                else
                {
                    numbers.Push(x);
                }
            }


        }

        private static int Calculate(int firstN, int secondN, string op)
        {
            switch (op)
            {
                case "+":
                    return firstN + secondN;
                case "-":
                    return firstN - secondN;
                case "*":
                    return firstN * secondN;
                default:
                    throw new ArgumentException();
            }
        }
    }
}