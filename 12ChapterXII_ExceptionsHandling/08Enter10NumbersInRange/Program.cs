using System;
using System.IO;

namespace _08Enter10NumbersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int count = 0;
            int previousNumber = 0;

            while (count < 10)
            {
                try
                {
                    int nexNumber = ReadNumber(start, end);
                    if (previousNumber >= nexNumber)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    previousNumber = nexNumber;
                    count++;
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    Console.WriteLine(aoore.Message);
                }
            }
        }

        static int ReadNumber(int start, int end)
        {
            int number = 0;
            try
            {                
                number = int.Parse(Console.ReadLine());
                if ((number < start) || (number > end))
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (OutOfMemoryException oome)
            {
                Console.WriteLine(oome.Message);
            }
            catch (ArgumentOutOfRangeException aoore)
            {
                Console.WriteLine(aoore.Message);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return number;
        }
    }
}