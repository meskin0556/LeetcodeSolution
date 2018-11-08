using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    public class Solution
    {
        //884. Uncommon Words from Two Sentences
        //We are given two sentences A and B.  (A sentence is a string of space separated words.Each word consists only of lowercase letters.)

        //A word is uncommon if it appears exactly once in one of the sentences, and does not appear in the other sentence.

        //Return a list of all uncommon words.

        //You may return the list in any order

        //Example 1:

        //Input: A = "this apple is sweet", B = "this apple is sour"
        //Output: ["sweet","sour"]

        //Example 2:

        //Input: A = "apple apple", B = "banana"
        //Output: ["banana"]

        public string[] UncommonFromSentences(string A, string B)
        {
            string C = A + " " + B;
            string[] arr = C.Split(' ');
            Dictionary<string, int> counter = new Dictionary<string, int>();
            foreach (string item in arr)
            {
                if (counter.ContainsKey(item))
                    counter[item]++;
                else
                    counter.Add(item, 1);
            }
            List<string> result = new List<string>();
            foreach (KeyValuePair<string, int> item in counter)
            {
                if (item.Value == 1)
                    result.Add(item.Key);
            }
            return result.ToArray();
        }

        //4. Median of Two Sorted Arrays
        //There are two sorted arrays nums1 and nums2 of size m and n respectively.
        //Find the median of the two sorted arrays.The overall run time complexity should be O(log (m+n)).
        //You may assume nums1 and nums2 cannot be both empty.
        //Example 1:

        //nums1 = [1, 3]
        //nums2 = [2]

        //The median is 2.0

        //Example 2:

        //nums1 = [1, 2]
        //nums2 = [3, 4]

        //The median is (2 + 3)/2 = 2.5
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int len1 = nums1.Length;
            int len2 = nums2.Length;


            if (len1 == 0)
            {
                return MedianValueInArray(nums2);
            }
            if (len2 == 0)
            {
                return MedianValueInArray(nums1);
            }
            int[] combine = new int[len1 + len2];
            int index1 = 0;
            int index2 = 0;
            for (int i = 0; i < combine.Length; i++)
            {
                if (index1 == len1)
                {
                    for (int j = i; j < combine.Length; j++)
                    {
                        combine[j] = nums2[index2];
                        index2++;
                    }
                    break;
                }
                if (index2 == len2)
                {
                    index2 = len2 - 1;
                    for (int j = i; j < combine.Length; j++)
                    {
                        combine[j] = nums1[index1];
                        index1++;
                    }
                    break;
                }
                if (nums1[index1] <= nums2[index2])
                {
                    combine[i] = nums1[index1];
                    index1++;
                }
                else
                {
                    combine[i] = nums2[index2];
                    index2++;
                }


            }
            return MedianValueInArray(combine);

        }

        private double MedianValueInArray(int[] num)
        {
            int length = num.Length;
            if (length % 2 == 0)
            {
                return (num[length / 2] + num[length / 2 - 1]) / 2.0;
            }
            else
            {
                return num[(length - 1) / 2];
            }
        }

        //65. Valid Number
        //Validate if a given string can be interpreted as a decimal number.

        //Some examples:
        //"0" => true
        //" 0.1 " => true
        //"abc" => false
        //"1 a" => false
        //"2e10" => true
        //" -90e3   " => true
        //" 1e" => false
        //"e3" => false
        //" 6e-1" => true
        //" 99e2.5 " => false
        //"53.5e93" => true
        //" --6 " => false
        //"-+3" => false
        //"95a54e53" => false

        //Note: It is intended for the problem statement to be ambiguous. You should gather all requirements up front before implementing one. However, here is a list of characters that can be in a valid decimal number:

        //    Numbers 0-9
        //    Exponent - "e"
        //    Positive/negative sign - "+"/"-"
        //    Decimal point - "."

        //Of course, the context of these characters also matters in the input.

        //Update (2015-02-10):
        //The signature of the C++ function had been updated.If you still see your function signature accepts a const char* argument, please click the reload button to reset your code definition.
        public bool IsNumber(string s)
        {
            char[] chars = s.Trim().ToCharArray();
            if (s.Length == 0) return false;
            bool eExist = false;
            bool signExist = false;
            bool numExist = false;
            bool dotExist = false;

            for (int i = 0; i < s.Length; i++)
            {
                char oldChar = '0';
                if (i > 0)
                    oldChar = s[i - 1];
                char newChar = s[i];
                switch (newChar)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        numExist = true;
                        break;
                    case '.':
                        if (dotExist || s.Length == 1 || eExist || (s.Length == 2 && signExist)) return false;
                        else dotExist = true;
                        break;

                    case 'e':
                        if (eExist || !numExist || s.Length == 1 || i == s.Length - 1) return false;
                        else eExist = true;
                        break;
                    case '+':
                    case '-':
                        if ((signExist && !eExist) || oldChar == '+' || oldChar == '-' || oldChar == '.' || s.Length == 1 || i == s.Length - 1 || (!eExist && i != 0)) return false;
                        else signExist = true;
                        break;


                    default:
                        return false;
                }
            }
            return true;

        }

    }
}
