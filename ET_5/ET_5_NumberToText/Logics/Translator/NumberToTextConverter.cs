using System;
using System.Collections.Generic;

namespace ET_5_NumberToText.Logics.Translator
{
    public abstract class NumberToTextConverter
    {
        public abstract bool CanConvertNumber(long number);
        public abstract string ConvertNumber(long number);

        public int[] DivideNumberIntoParts(long number, int quantity)
        {
            if(quantity <= 0)
            {
                throw new ArgumentException(
                    "Quantity can't be less than zero");
            }

            number = Math.Abs(number);
            List<int> result = new List<int>();
            int divider = (int)Math.Pow(10, quantity);

            while (number > 0)
            {
                result.Add((int)(number % divider));
                number /= divider;
            }

            result.Reverse();

            return result.ToArray();
        }
    }
}
