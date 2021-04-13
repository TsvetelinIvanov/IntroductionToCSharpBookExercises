using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06ValidateArithmeticalExpression
{
    class Program
    {
        static void Main()
        {
            try
            {
                string expression = Console.ReadLine();
                
                string[] tokens = SplitInTokens(expression);
                tokens = ProcessNegativeNumbers(tokens);
                
                string[] reversePolishNotation = UseShuntingYardAlgorithm(tokens);
                
                double result = CalculateReversePolishNotation(reversePolishNotation);
                Console.WriteLine($"{expression} = {result:f2}");
            }
            catch (ValidationException ve)
            {
                Console.WriteLine(ve.GetType() + ": " + ve.Message);
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

        private static string[] ProcessNegativeNumbers(string[] tokens)
        {
            List<string> processedTokens = new List<string>();
            for (int i = 0; i < tokens.Length; i++)
            {                
                if (tokens[i] == "-")
                {                    
                    if (i == 0)
                    {                        
                        processedTokens.Add("-1");
                        processedTokens.Add("*");
                    }                    
                    else if (i != (tokens.Length - 1) && IsTokenNumber(tokens[i + 1]) && (IsTokenOperator(tokens[i - 1]) || tokens[i - 1] == "(" || tokens[i - 1] == "(") )
                    {                        
                        processedTokens.Add(tokens[i] + tokens[i + 1]);                        
                        i++;
                    }
                    else
                    {                        
                        processedTokens.Add(tokens[i]);
                    }
                }
                else
                {
                    processedTokens.Add(tokens[i]);
                }
            }

            return processedTokens.ToArray();
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

        private static string[] UseShuntingYardAlgorithm(string[] tokens)
        {            
            const string Number = "Number";
            const string Operator = "Operator";

            string expectedToken = Number;
            Queue<string> outputQueue = new Queue<string>();
            Stack<string> operatorsStack = new Stack<string>();
            Queue<string> tokensQueue = new Queue<string>(tokens);

            while (tokensQueue.Count > 0)
            {
                string token = tokensQueue.Dequeue();
                if (IsTokenNumber(token))
                {
                    if (expectedToken == Operator)
                    {
                        throw new ValidationException();
                    }
                    
                    expectedToken = Operator;
                    outputQueue.Enqueue(token);
                }
                else if (IsTokenOperator(token))
                {
                    if (expectedToken == Number)
                    {
                        throw new ValidationException();
                    }
                    
                    expectedToken = Number;
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
                    if (operatorsStack.Count == 0)
                    {
                        throw new ValidationException();
                    }

                    string @operator = operatorsStack.Pop();
                    while (@operator != "(")
                    {                        
                        if (operatorsStack.Count == 0)
                        {
                            throw new ValidationException();
                        }

                        outputQueue.Enqueue(@operator);
                        @operator = operatorsStack.Pop();
                    }
                }
                else
                {
                    throw new ValidationException();
                }
            }

            while (operatorsStack.Count > 0)
            {
                string @operator = operatorsStack.Pop();
                if (@operator == "(")
                {
                    throw new ValidationException();
                }

                outputQueue.Enqueue(@operator);
            }

            return outputQueue.ToArray();
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
                throw new ValidationException();
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
                    try
                    {
                        double result = CalculateOperation(token, outputStack.Pop(), outputStack.Pop());
                        outputStack.Push(result);
                    }
                    catch (InvalidOperationException ioe)
                    {
                        throw new ValidationException("Invalid expression! " + ioe.Message);
                    }
                }
            }

            if (outputStack.Count != 1)
            {
                throw new ValidationException();
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
                    throw new ValidationException();
            }

            return result;
        }
    }
}