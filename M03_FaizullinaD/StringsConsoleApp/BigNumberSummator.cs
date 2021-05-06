namespace StringsConsoleApp
{
    public static class BigNumberSummator
    {
        private static bool IsNegative(string number)
        {
            return number.IndexOf('-') >= 0;
        }

        private static string RemoveSign(string number)
        {
            if (IsNegative(number))
                return number.Remove(number.IndexOf('-'), 1);
            else if (number.IndexOf('+') >= 0)
                return number.Remove(number.IndexOf('+'), 1);
            else
                return number;
        }

        private static string AddMinus(string number)
        {
            return number.Insert(0, "-");
        }

        private static string Max(string first, string second)
        {
            string max;
            if (first.Length > second.Length)
            {
                return first;
            }
            else if (first.Length < second.Length)
            {
                return second;
            }
            else
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] > second[i])
                        return first;
                    else if (first[i] < second[i])
                        return second;
                }
            }
            return null;
        }

        private static int GetAddIndex(string number, int i)
        {
            for (int j = i; j >= 0; j--)
            {
                if (number[j] > '0')
                {
                    return j;
                }
            }
            throw new System.Exception();
        }

        private static string SumSameSignedNumbers(string first, string second)
        {
            string result = string.Empty;

            string longer = (first.Length > second.Length) ? first : second;
            string shorter = (first.Length > second.Length) ? second : first;

            int additional = 0;
            int indexDiff = longer.Length - shorter.Length;

            for (int i = shorter.Length - 1; i >= 0; i--)
            {
                int longerDigit, shorterDigit;
                int.TryParse(longer[i + indexDiff].ToString(), out longerDigit);
                int.TryParse(shorter[i].ToString(), out shorterDigit);

                int sum = longerDigit + shorterDigit + additional;
                result = (sum % 10).ToString() + result;
                additional = sum / 10;
            }

            if (longer.Length > shorter.Length)
            {
                for (int i = indexDiff - 1; i >= 0; i--)
                {
                    int longerDigit;
                    int.TryParse(longer[i].ToString(), out longerDigit);

                    int sum = longerDigit + additional;
                    result = (sum % 10).ToString() + result;
                    additional = sum / 10;
                }
            }

            if (additional == 1)
                result = "1" + result;

            return result;
        }

        private static string SumDiffSignedNumbers(string first, string second)
        {
            string bigger, smaller;
            bool negativeFirst, negativeSecond;
            bool negativeResult;

            if (IsNegative(first))
            {
                negativeFirst = true;
                negativeSecond = false;
                first = RemoveSign(first);
                second = RemoveSign(second);
            } else
            {
                negativeFirst = false;
                negativeSecond = true;
                first = RemoveSign(first);
                second = RemoveSign(second);
            }

            string max = Max(first, second);
            if (max.Equals(first))
            {
                negativeResult = negativeFirst;
                bigger = first;
                smaller = second;
            } else if (max.Equals(second))
            {
                negativeResult = negativeSecond;
                bigger = second;
                smaller = first;
            } else
            {
                return "0";
            }

            var difference = GetDifference(bigger, smaller).TrimStart('0');
            return negativeResult ? AddMinus(difference) : difference;
        }

        private static string GetDifference(string bigger, string smaller)
        {
            string result = string.Empty;
            int addIndex = -1;
            int indexDiff = bigger.Length - smaller.Length;

            for (int i = smaller.Length - 1; i >= 0; i--)
            {
                int biggerDigit, smallerDigit;
                int.TryParse(bigger[indexDiff + i].ToString(), out biggerDigit);
                int.TryParse(smaller[i].ToString(), out smallerDigit);
                
                if (biggerDigit >= smallerDigit)
                {
                    if (addIndex == -1)
                    {
                        result = (biggerDigit - smallerDigit).ToString() + result;
                    }
                    else
                    {
                        if (addIndex == indexDiff + i)
                        {
                            var digit = biggerDigit - smallerDigit - 1;

                            if (digit < 0)
                            {
                                addIndex = GetAddIndex(bigger, indexDiff + i - 1);
                                result = (digit + 10).ToString() + result;
                            }
                            else
                            {
                                result = (biggerDigit - smallerDigit - 1).ToString() + result;
                                addIndex = -1;
                            }
                        }
                        else
                        {
                            result = (9 + biggerDigit - smallerDigit).ToString() + result;
                        }
                    }
                } else
                {
                    if (addIndex != -1)
                    {
                        if (addIndex != indexDiff + i)
                        {
                            result = (9 - smallerDigit).ToString() + result;
                        } else
                        {
                            var digit = biggerDigit - smallerDigit - 1;
                            if (digit < 0)
                            {
                                addIndex = GetAddIndex(bigger, indexDiff + i - 1);
                                result = (10 + digit).ToString() + result;
                            }
                            else
                            {
                                result = digit.ToString() + result;
                                addIndex = -1;
                            }
                        }
                    }
                    else
                    {
                        addIndex = GetAddIndex(bigger, indexDiff + i - 1);
                        result = (10 + biggerDigit - smallerDigit).ToString() + result;
                    }
                }
            }

            if (bigger.Length > smaller.Length)
            {
                for (int i = indexDiff - 1; i >= 0; i--)
                {
                    if (addIndex != -1)
                    {
                        int biggerDigit;
                        int.TryParse(bigger[i].ToString(), out biggerDigit);

                        if (addIndex == i)
                        {
                            result = (biggerDigit - 1).ToString() + result;
                            addIndex = -1;
                        }
                        else
                        {
                            result = "9".ToString() + result;
                        }
                    }
                    else
                    {
                        result = bigger[i] + result;
                    }
                }
            }
            
            return result;
        }
        
        public static string Sum(string first, string second)
        {
            if (!IsNegative(first) && !IsNegative(second))
            {
                first = RemoveSign(first);
                second = RemoveSign(second);
                return SumSameSignedNumbers(first, second);
            } else if (IsNegative(first) && IsNegative(second))
            {
                first = RemoveSign(first);
                second = RemoveSign(second);
                return AddMinus(SumSameSignedNumbers(first, second));
            }
            else
            {
                return SumDiffSignedNumbers(first, second);
            }
        }
    }
}
