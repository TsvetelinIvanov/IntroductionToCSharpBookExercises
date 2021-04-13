using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ArithmeticalExpressionWithMultiplyAndDivide
{
    class Program
    {
        static void Main()
        {
            try
            {
                string expression = Console.ReadLine();
                int[] numbers = expression.Split('+', '-', '*', '/').Select(int.Parse).ToArray();
                string operatorsString = "+-*/";
                char[] operators = expression.Where(c => operatorsString.Contains(c)).ToArray();
                ParsedExpression parsedExpression = new ParsedExpression
                {
                    numbers = numbers,
                    operators = operators
                };
                
                parsedExpression = CalculateMultiplicationAndDivision(parsedExpression);

                int result = CalculateAdditionAndSubtraction(parsedExpression);
                Console.WriteLine($"{expression} = {result}");
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

        private static ParsedExpression CalculateMultiplicationAndDivision(ParsedExpression parsedExpression)
        {
            Queue<int> numbers = new Queue<int>(parsedExpression.numbers);
            Queue<char> operators = new Queue<char>(parsedExpression.operators);

            Stack<int> newNumbers = new Stack<int>();
            Stack<char> newOperators = new Stack<char>();
            newNumbers.Push(numbers.Dequeue());
            while (numbers.Count > 0)
            {
                int number = numbers.Dequeue();
                char @operator = operators.Dequeue();
                if (@operator == '*')
                {
                    int previousNumber = newNumbers.Pop();
                    newNumbers.Push(previousNumber * number);
                }
                else if (@operator == '/')
                {
                    int previousNumber = newNumbers.Pop();
                    newNumbers.Push(previousNumber / number);
                }
                else
                {
                    newNumbers.Push(number);
                    newOperators.Push(@operator);
                }
            }

            parsedExpression.numbers = newNumbers.Reverse().ToArray();
            parsedExpression.operators = newOperators.Reverse().ToArray();

            return parsedExpression;
        }

        private static int CalculateAdditionAndSubtraction(ParsedExpression parsedExpression)
        {
            int[] numbers = parsedExpression.numbers;
            char[] operators = parsedExpression.operators;
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                char operation = operators[i - 1];
                int nextNumber = numbers[i];
                if (operation == '+')
                {
                    result += nextNumber;
                }
                else if (operation == '-')
                {
                    result -= nextNumber;
                }
            }

            return result;
        }
    }
}