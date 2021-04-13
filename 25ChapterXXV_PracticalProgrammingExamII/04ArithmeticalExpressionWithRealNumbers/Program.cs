using System;
using System.Collections.Generic;
using System.Linq;

namespace _04ArithmeticalExpressionWithRealNumbers
{
    class Program
    {
        static void Main()
        {
            try
            {
                string expression = Console.ReadLine();
                double[] numbers = expression.Split('+', '-', '*', '/').Select(double.Parse).ToArray();
                string operatorsString = "+-*/";
                char[] operators = expression.Where(c => operatorsString.Contains(c)).ToArray();
                ParsedExpression parsedExpression = new ParsedExpression
                {
                    numbers = numbers,
                    operators = operators
                };

                parsedExpression = CalculateMultiplicationAndDivision(parsedExpression);

                double result = CalculateAdditionAndSubtraction(parsedExpression);
                Console.WriteLine($"{expression} = {result:f2}");
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
            Queue<double> numbers = new Queue<double>(parsedExpression.numbers);
            Queue<char> operators = new Queue<char>(parsedExpression.operators);

            Stack<double> newNumbers = new Stack<double>();
            Stack<char> newOperators = new Stack<char>();
            newNumbers.Push(numbers.Dequeue());
            while (numbers.Count > 0)
            {
                double number = numbers.Dequeue();
                char @operator = operators.Dequeue();
                if (@operator == '*')
                {
                    double previousNumber = newNumbers.Pop();
                    newNumbers.Push(previousNumber * number);
                }
                else if (@operator == '/')
                {
                    if (number == 0)
                    {
                        throw new DivideByZeroException();
                    }

                    double previousNumber = newNumbers.Pop();
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

        private static double CalculateAdditionAndSubtraction(ParsedExpression parsedExpression)
        {
            double[] numbers = parsedExpression.numbers;
            char[] operators = parsedExpression.operators;
            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                char operation = operators[i - 1];
                double nextNumber = numbers[i];
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