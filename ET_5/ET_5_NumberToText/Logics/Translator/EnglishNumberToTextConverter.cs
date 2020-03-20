using System;
using System.Text;

namespace ET_5_NumberToText.Logics.Translator
{
    public class EnglishNumberToTextConverter : NumberToTextConverter
    {
        #region private

        private readonly string minus = "minus";

        private readonly string[] zeroToNine =
        {
            "zero", "one", "two", "three", "four",
            "five", "six", "seven", "eight", "nine"
        };

        private readonly string[] tenToNineteen =
        {
            "ten", "eleven", "twelve", "thirteen", "fourteen",
            "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        private readonly string[] twentyToNinety =
        {
            "twenty", "thirty", "forty", "fifty",
            "sixty", "seventy", "eighty", "ninety"
        };

        private readonly string hundred = "hundred";

        private readonly string[] numberModifier =
        {
            "", "thousand", "million", "billion"
        };

        private const int DefaultQuanity = 3;

        #endregion


        public override bool CanConvertNumber(long number)
        {
            if(Math.Abs(number) > Math.Pow(10, (numberModifier.Length - 1) * DefaultQuanity) - 1)
            {
                return false;
            }
            return true;
        }

        public override string ConvertNumber(long number)
        {
            if (!CanConvertNumber(number))
            {
                throw new ArgumentException("Number is too big");
            }

            StringBuilder result = new StringBuilder();
            string space = " ";

            if (number == 0)
            {
                result.Append(zeroToNine[0]);
                return result.ToString();
            }
            if(number < 0)
            {
                result.Append(minus + space);
            }

            int[] digits = DivideNumberIntoParts(number, DefaultQuanity);
            int j = 0;
            int[] temp;
            bool needAddModifier = false;
            while(j < digits.Length)
            {
                temp = DivideNumberIntoParts(digits[j], 1);
                Array.Reverse(temp);

                if (temp.Length == 3 && temp[2] != 0)
                {
                    result.Append(zeroToNine[temp[2]] + space);
                    result.Append(hundred + space);
                    needAddModifier = true;
                }
                if (temp.Length >= 2 && temp[1] == 1)
                {
                    result.Append(tenToNineteen[temp[0]] + space);
                    needAddModifier = true;
                }
                else
                {
                    if (temp.Length >= 2 && temp[1] != 0)
                    {
                        result.Append(twentyToNinety[temp[1] - 2] + space);
                        needAddModifier = true;
                    }
                    if (temp.Length >= 1 && temp[0] != 0)
                    {
                        result.Append(zeroToNine[temp[0]] + space);
                        needAddModifier = true;
                    }
                }
                if (needAddModifier)
                {
                    result.Append(numberModifier[digits.Length - j - 1] + space);
                    needAddModifier = false;
                }

                j++;
            }

            return result.ToString();           
        }
    }
}
