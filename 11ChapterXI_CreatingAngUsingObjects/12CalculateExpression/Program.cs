using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _12CalculateExpression
{
    class Program
    {
        private static Dictionary<string, int> precedence = new Dictionary<string, int>() { { "+", 2 }, { "-", 2 }, { "*", 4 }, { "/", 4 }, { "ln", 8 }, { "pow", 8 }, { "sqrt", 8 } };
        private static Stack<string> operators = new Stack<string>();
        private static Queue<string> numbers = new Queue<string>();       

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine("The input string: " + input);            
            string resultString = ShuntingYard(input);
            Console.WriteLine("Reversed Polish Notation: " + resultString);            
            List<string> tokens = resultString.Split().ToList();
            Console.WriteLine("Result: " + ReversePolish(tokens));            
        }

        private static string ShuntingYard(String input)
        {
            if (input.StartsWith("-"))
            {
                input = 0 + input;
            }

            if (input.Contains(", -"))
            {
                input = input.Replace(", -", ", 0-");
            }
                
            if (input.Contains(",-"))
            {
                input = input.Replace(",-", ",0-");
            }
                
            if (input.Contains("( -"))
            {
                input = input.Replace("( -", "( 0-");
            }
                
            if (input.Contains("(-"))
            {
                input = input.Replace("(-", "(0-");
            }                
            
            StringBuilder numberBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char next = input.ElementAt(i);
                if (next == ' ')
                {
                    continue;
                }                    

                if (IsNumber(next))
                {
                    numberBuilder.Append(next);
                    if (i == input.Length - 1)
                    {
                        numberBuilder.Append(" ");
                        string numberString = numberBuilder.ToString();
                        numbers.Enqueue(numberString);
                        numberBuilder.Clear();
                    }
                }
                else
                {
                    if (numberBuilder.Length > 0 || i == input.Length - 1)
                    {
                        numberBuilder.Append(" ");
                        string numberString = numberBuilder.ToString();
                        numbers.Enqueue(numberString);
                        numberBuilder.Clear();
                    }

                    if (next == 'l')
                    {
                        string fn = "" + input.ElementAt(i) + input.ElementAt(i + 1);
                        operators.Push(fn);
                    }
                    else if (next == 'p')
                    {
                        string fn = "" + input.ElementAt(i) + input.ElementAt(i + 1) + input.ElementAt(i + 2);
                        operators.Push(fn);
                    }
                    else if (next == 's')
                    {
                        string fn = "" + input.ElementAt(i) + input.ElementAt(i + 1) + input.ElementAt(i + 2) + input.ElementAt(i + 3);
                        operators.Push(fn);
                    }
                    else if (next == ',')
                    {
                        while (operators.Peek() != "(")
                        {
                            numbers.Enqueue(operators.Pop() + " ");
                        }
                    }
                    else if (IsOperator(next))
                    {
                        precedence.TryGetValue(next.ToString(), out int firstValue);
                        while (operators.Count > 0)
                        {
                            precedence.TryGetValue(operators.Peek(), out int secondValue);
                            if (firstValue <= secondValue && next.ToString() != operators.Peek())
                            {
                                numbers.Enqueue(operators.Pop() + " ");
                            }
                            else
                            {
                                break;
                            }                                
                        }

                        string operation = next.ToString();
                        operators.Push(operation);
                        continue;
                    }
                    else if (next == '(')
                    {
                        operators.Push(next.ToString());
                    }
                    else if (next == ')')
                    {
                        while (operators.Peek() != "(")
                        {
                            numbers.Enqueue(operators.Pop() + " ");
                        }

                        if (operators.Peek() == "(")
                        {
                            operators.Pop();
                        }

                        if (operators.Count > 0 && (operators.Peek() == "ln" || operators.Peek() == "pow" || operators.Peek() == "sqrt"))
                        {
                            numbers.Enqueue(operators.Pop() + " ");
                        }
                    }
                }
            }

            while (operators.Count > 0)
            {
                numbers.Enqueue(operators.Pop() + " ");
            }

            StringBuilder resultBuilder = new StringBuilder(input.Length);
            foreach (string numberString in numbers)
            {
                resultBuilder.Append(numberString);
            }

            return resultBuilder.ToString();
        }

        private static bool IsNumber(char next)
        {
            switch (next)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '.':
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsOperator(char next)
        {
            switch (next)
            {
                case '+':
                case '-':
                case '/':
                case '*':
                    return true;
                default:
                    return false;
            }
        }

        private static string ReversePolish(List<string> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                string temp = "";
                switch (tokens[i])
                {
                    case "+":
                        temp = (double.Parse(tokens[i - 1]) + double.Parse(tokens[i - 2])).ToString();
                        tokens[i] = temp;
                        tokens.RemoveRange(i - 2, 2);
                        ReversePolish(tokens);
                        break;
                    case "-":
                        temp = (double.Parse(tokens[i - 2]) - double.Parse(tokens[i - 1])).ToString();
                        tokens[i] = temp;
                        tokens.RemoveRange(i - 2, 2);
                        ReversePolish(tokens);
                        break;
                    case "/":
                        temp = (double.Parse(tokens[i - 2]) / double.Parse(tokens[i - 1])).ToString();
                        tokens[i] = temp;
                        tokens.RemoveRange(i - 2, 2);
                        ReversePolish(tokens);
                        break;
                    case "*":
                        temp = (double.Parse(tokens[i - 2]) * double.Parse(tokens[i - 1])).ToString();
                        tokens[i] = temp;
                        tokens.RemoveRange(i - 2, 2);
                        ReversePolish(tokens);
                        break;
                    case "ln":
                        temp = Math.Log(double.Parse(tokens[i - 1])).ToString();
                        tokens[i] = temp;
                        tokens.RemoveRange(i - 1, 1);
                        ReversePolish(tokens);
                        break;
                    case "sqrt":
                        temp = Math.Sqrt(double.Parse(tokens[i - 1])).ToString();
                        tokens[i] = temp;
                        tokens.RemoveRange(i - 1, 1);
                        ReversePolish(tokens);
                        break;
                    case "pow":
                        temp = Math.Pow(double.Parse(tokens[i - 2]), double.Parse(tokens[i - 1])).ToString();
                        tokens[i] = temp;
                        tokens.RemoveRange(i - 2, 2);
                        ReversePolish(tokens);
                        break;
                    default:
                        break;
                }
            }

            return tokens[0];
        }
    }
}