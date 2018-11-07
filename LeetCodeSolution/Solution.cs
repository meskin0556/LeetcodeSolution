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


    }
}
