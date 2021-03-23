using System;
using System.Collections.Generic;
using System.Linq;

namespace _04LongestSequenceEqualNumbers
{
    public class LongestSequenceEqualNumbersTest
    {
        private readonly List<int> numbers1 = new List<int> { 1, 2, 3, 4, 4, 5, 5, 5, 6 };
        private readonly List<int> numbers2 = new List<int> { 1, 2, 3, 4, 5, 6 };
        private readonly List<int> numbers3 = new List<int> { 5, 5, 5 };

        private readonly List<int> equalNumbers1 = new List<int> { 5, 5, 5 };
        private readonly List<int> equalNumbers2 = new List<int> { 1 };

        public bool TestFindLongestSequenceEqualNumbers()
        {
            List<int> testEqualNumbers1 = Program.FindLongestSequenceEqualNumbers(this.numbers1);
            if (!this.equalNumbers1.SequenceEqual(testEqualNumbers1))
            {
                return false;
            }

            List<int> testEqualNumbers2 = Program.FindLongestSequenceEqualNumbers(this.numbers2);
            if (!this.equalNumbers2.SequenceEqual(testEqualNumbers2))
            {
                return false;
            }

            List<int> testEqualNumbers3 = Program.FindLongestSequenceEqualNumbers(this.numbers3);
            if (!this.equalNumbers1.SequenceEqual(testEqualNumbers3))
            {
                return false;
            }

            return true;
        }
    }
}