﻿namespace Chapter11
{
    public class Sequence
    {
        private static int currentValue = 0;

        private Sequence()
        {

        }

        public static int NextValue()
        {
            currentValue++;

            return currentValue;
        }
    }
}