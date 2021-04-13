using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05ArithmeticalExpressionWithParentheses
{
    class Program
    {
        static void Main()
        {
            try
            {
                string expression = Console.ReadLine();                
                string[] tokens = SplitInTokens(expression);
                
                string[] reversePolishNotation = UseShuntingYardAlgorithm(tokens);
                
                double result = CalculateReversePolishNotation(reversePolishNotation);
                Console.WriteLine($"{expression} = {result:f2}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.GetType() + ": " + ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.GetType() + ": " + fe.Message);
            }
            catch (DivideByZeroException dbze)
            {
                Console.WriteLine(dbze.GetType() + ": " + dbze.Message);
            }
        }

        private static string[] SplitInTokens(string expression)
        {
            List<string> tokens = new List<string>();
            char[] operatorsAndParentheses = new char[] { '+', '-', '*', '/', '(', ')' };
            StringBuilder token = new StringBuilder();
            foreach (char character in expression)
            {
                if (operatorsAndParentheses.Contains(character))
                {
                    if (token.Length > 0)
                    {
                        tokens.Add(token.ToString());
                    }

                    tokens.Add(character.ToString());
                    token.Clear();
                }
                else
                {
                    token.Append(character.ToString());
                }
            }

            if (token.Length > 0)
            {
                tokens.Add(token.ToString());
            }

            return tokens.ToArray();
        }

        private static string[] UseShuntingYardAlgorithm(string[] tokens)
        {            
            Queue<string> outputQueue = new Queue<string>();
            Stack<string> operatorsStack = new Stack<string>();
            Queue<string> tokensQueue = new Queue<string>(tokens);
            while (tokensQueue.Count > 0)
            {
                string token = tokensQueue.Dequeue();
                if (IsTokenNumber(token))
                {
                    outputQueue.Enqueue(token);
                }
                else if (IsTokenOperator(token))
                {
                    while (operatorsStack.Count > 0 && IsTokenOperator(operatorsStack.Peek()) && GetOperatorPrecedence(token) <= GetOperatorPrecedence(operatorsStack.Peek()))
                    {
                        outputQueue.Enqueue(operatorsStack.Pop());
                    }

                    operatorsStack.Push(token);
                }
                else if (token == "(")
                {
                    operatorsStack.Push(token);
                }
                else if (token == ")")
                {
                    string poppedOperator = operatorsStack.Pop();
                    while (poppedOperator != "(")
                    {
                        outputQueue.Enqueue(poppedOperator);
                        poppedOperator = operatorsStack.Pop();
                    }
                }
            }

            while (operatorsStack.Count > 0)
            {
                outputQueue.Enqueue(operatorsStack.Pop());
            }

            return outputQueue.ToArray();
        }

        private static bool IsTokenNumber(string token)
        {
            try
            {
                double.Parse(token);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool IsTokenOperator(string token)
        {
            string[] operators = new string[] { "+", "-", "*", "/" };

            return operators.Contains(token);
        }

        private static int GetOperatorPrecedence(string @operator)
        {
            if (@operator == "+" || @operator == "-")
            {
                return 1;
            }                
            else if (@operator == "*" || @operator == "/")
            {
                return 2;
            }                
            else
            {
                throw new ArgumentException("Unknown operator: " + @operator);
            }
        }

        private static double CalculateReversePolishNotation(string[] reversePolishNotation)
        {
            Stack<double> outputStack = new Stack<double>();
            Queue<string> tokensQueue = new Queue<string>(reversePolishNotation);
            while (tokensQueue.Count > 0)
            {
                string token = tokensQueue.Dequeue();
                if (IsTokenNumber(token))
                {
                    outputStack.Push(double.Parse(token));
                }
                else
                {
                    double result = CalculateOperation(token, outputStack.Pop(), outputStack.Pop());
                    outputStack.Push(result);
                }
            }

            return outputStack.Pop();
        }

        private static double CalculateOperation(string @operator, double number, double otherNumber)
        {
            double result;
            switch (@operator)
            {
                case "+":
                    result = number + otherNumber;
                    break;
                case "-":
                    result = otherNumber - number;
                    break;
                case "*":
                    result = number * otherNumber;
                    break;
                case "/":
                    if (number == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    
                    result = otherNumber / number;
                    break;
                default:
                    throw new ArgumentException("Unknown operator: " + @operator);
            }

            return result;
        }        
    }
}