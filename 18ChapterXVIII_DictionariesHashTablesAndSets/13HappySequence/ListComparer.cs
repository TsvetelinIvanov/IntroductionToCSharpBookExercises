using System.Collections.Generic;

namespace _13HappySequence
{
    public class ListComparer : IComparer<List<int>>
    {
        public int Compare(List<int> firstList, List<int> secondList)
        {
            if (firstList.Count == secondList.Count)
            {
                for (int i = 0; i < firstList.Count; i++)
                {
                    if (firstList[i] != secondList[i])
                    {
                        return firstList[i].CompareTo(secondList[i]);
                    }
                }

                return 0;
            }
            else
            {
                return -1 * firstList.Count.CompareTo(secondList.Count);
            }
        }
    }
}