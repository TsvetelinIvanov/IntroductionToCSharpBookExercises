using System;
using System.Collections.Generic;
using System.Linq;

namespace _02IEnumerableExtensionMethods
{
    public static class IEnumerableExtensionMethods
    {
        public static int Length<T>(this IEnumerable<T> collection) where T : IComparable
        {
            return collection.ToArray().Length;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T min = collection.First();
            foreach (T item in collection)
            {
                if (item.CompareTo(min) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            T max = collection.First();
            foreach (T item in collection)
            {
                if (item.CompareTo(max) > 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public static decimal Sum<T>(this IEnumerable<T> collection)
        {
            decimal sum = 0;
            try
            {
                foreach (T item in collection)
                {
                    sum += Convert.ToDecimal(item);
                }
            }
            catch (FormatException fe)
            {
                throw new ArgumentException("Collection cannot be modifed with the default transformer!", fe);
            }
            catch (InvalidCastException ice)
            {
                throw new ArgumentException("Collection cannot be modifed with the default transformer!", ice);
            }

            return sum;
        }

        public static decimal Product<T>(this IEnumerable<T> collection)
        {
            decimal sum = 1;
            try
            {
                foreach (T item in collection)
                {
                    sum *= Convert.ToDecimal(item);
                }
            }
            catch (FormatException fe)
            {
                throw new ArgumentException("Collection cannot be modifed with the default transformer!", fe);
            }
            catch (InvalidCastException ice)
            {
                throw new ArgumentException("Collection cannot be modifed with the default transformer!", ice);
            }

            return sum;
        }

        public static decimal Average<T>(this IEnumerable<T> collection)
        {
            decimal sum = collection.Sum();
            decimal average = sum / collection.Count();

            return average;
        }
    }
}