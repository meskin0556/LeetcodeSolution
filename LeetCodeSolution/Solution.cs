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
            s = s.Trim();
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

        //149. Max Points on a Line
        //Given n points on a 2D plane, find the maximum number of points that lie on the same straight line.

        //Example 1:

        //Input: [[1,1],[2,2],[3,3]]
        //Output: 3
        //Explanation:
        //^
        //|
        //|        o
        //|     o
        //|  o  
        //+------------->
        //0  1  2  3  4

        //Example 2:

        //Input: [[1,1],[3,2],[5,3],[4,1],[2,3],[1,4]]
        //Output: 4
        //Explanation:
        //^
        //|
        //|  o
        //|     o o
        //|        o
        //|  o o
        //+------------------->
        //0  1  2  3  4  5  6


        public class Point
        {
            public int x;
            public int y;
            public Point() { x = 0; y = 0; }
            public Point(int a, int b) { x = a; y = b; }
        }

        private class Line
        {
            public double slope;
            public double offset;
            public Line(double slope, double offset) { this.slope = slope; this.offset = offset; }
            public Line(Point A, Point B)
            {
                if (A.x == B.x)
                {
                    slope = 0;
                }
                else
                {
                    slope = (double)((A.y - B.y) / (A.x - B.x));
                }

                offset = A.y - A.y * slope;
            }
        }
        private class LineEqualityComparer : IEqualityComparer<Line>
        {
            #region IEqualityComparer<Customer> Members

            public bool Equals(Line x, Line y)
            {
                return ((x.slope == y.slope) && (x.offset == y.offset));
            }

            public int GetHashCode(Line obj)
            {

                return obj.slope.GetHashCode() + obj.offset.GetHashCode();
            }

            #endregion
        }
        public int MaxPoints(Point[] points)
        {
            if (points.Length < 3) return points.Length;
            Dictionary<string, HashSet<int>> allLines = new Dictionary<string, HashSet<int>>();
            //var lineEqualityComparer = new LineEqualityComparer();
            Point A, B;
            decimal slope, offset;
            for (int i = 0; i < points.Length - 1; i++)
            {
                A = points[i];
                for (int j = i + 1; j < points.Length; j++)
                {
                    B = points[j];
                    //if (A.x == B.x && A.y == B.y)
                    //{
                    //    foreach (HashSet<int> set in allLines.Values)
                    //    {
                    //        if (set.Contains(i) && !set.Contains(j))
                    //            set.Add(j);
                    //        if (!set.Contains(i) && set.Contains(j))
                    //            set.Add(i);
                    //    }
                    //}

                    if (A.x == B.x)
                    {
                        slope = 9999999;
                        offset = B.x;
                    }
                    else
                    {
                        slope = ((decimal)A.y - (decimal)B.y) / ((decimal)A.x - (decimal)B.x);
                        offset = (decimal)(A.y + B.y) - (decimal)(A.x + B.x) * slope;
                    }

                    //double[] line = new double[] { slope, offset };
                    string line = slope.ToString() + "|" + offset.ToString();
                    if (allLines.Keys.Contains(line))
                    {
                        if (!allLines[line].Contains(i))
                        {
                            allLines[line].Add(i);
                        }
                        if (!allLines[line].Contains(j))
                        {
                            allLines[line].Add(j);
                        }
                    }
                    else
                    {
                        HashSet<int> set = new HashSet<int>();
                        set.Add(i);
                        set.Add(j);
                        allLines.Add(line, set);
                    }
                }


            }
            int maxValue = 0;


            foreach (KeyValuePair<string, HashSet<int>> item in allLines)
            {
                if (maxValue < item.Value.Count)
                    maxValue = item.Value.Count;
            }

            return maxValue;

        }

        //146. LRU Cache
        //Design and implement a data structure for Least Recently Used(LRU) cache.It should support the following operations: get and put.

        //get(key) - Get the value(will always be positive) of the key if the key exists in the cache, otherwise return -1.
        //put(key, value) - Set or insert the value if the key is not already present.When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.

        //Follow up:
        //Could you do both operations in O(1) time complexity?

        //Example:

        //LRUCache cache = new LRUCache(2 /* capacity */ );

        //        cache.put(1, 1);
        //cache.put(2, 2);
        //cache.get(1);       // returns 1
        //cache.put(3, 3);    // evicts key 2
        //cache.get(2);       // returns -1 (not found)
        //cache.put(4, 4);    // evicts key 1
        //cache.get(1);       // returns -1 (not found)
        //cache.get(3);       // returns 3
        //cache.get(4);       // returns 4、

        /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */

        public class LRUCache
        {
            private Dictionary<int, int> store;
            private List<int> history;


            public LRUCache(int capacity)
            {
                store = new Dictionary<int, int>(capacity);
                history = new List<int>(capacity);

            }

            public int Get(int key)
            {
                if (store.ContainsKey(key))
                {
                    history.Remove(key);
                    history.Insert(0, key);
                    return store[key];
                }
                else
                {
                    return -1;
                }
            }

            public void Put(int key, int value)
            {
                if (store.ContainsKey(key))
                {
                    store[key] = value;
                    history.Remove(key);
                    history.Insert(0, key);
                    return;
                }
                if (history.Capacity == history.Count)
                {
                    int outKey = history.Last();
                    store.Remove(outKey);
                    history.Remove(outKey);
                    store.Add(key, value);
                    history.Insert(0, key);
                }
                else
                {
                    store.Add(key, value);
                    history.Insert(0, key);
                }
            }
        }


        //564. Find the Closest Palindrome
        //Given an integer n, find the closest integer(not including itself), which is a palindrome.

        //The 'closest' is defined as absolute difference minimized between two integers.


        //Example 1:


        //Input: "123"
        //Output: "121"


        //Note:


        //The input n is a positive integer represented by string, whose length will not exceed 18.

        //If there is a tie, return the smaller one as answer.
        public string NearestPalindromic(string n)
        {
            int length = n.Length;
            if (length == 1) return (long.Parse(n) - 1).ToString();
            if (n == Math.Pow(10, length - 1).ToString()) return (long.Parse(n) - 1).ToString();
            if (n == (Math.Pow(10, length - 1) + 1).ToString()) return (long.Parse(n) - 2).ToString();
            if (n == (Math.Pow(10, length) - 1).ToString()) return (long.Parse(n) + 2).ToString();
            if (length % 2 == 0)
            {

                string left = n.Substring(0, length / 2);
                string leftUp = (long.Parse(left) + 1).ToString();
                string leftDn = (long.Parse(left) - 1).ToString();

                long result = long.Parse(left + Reverse(left));
                long delta = Math.Abs(result - long.Parse(n));
                if (delta == 0) delta = long.MaxValue;

                long resultUp = long.Parse(leftUp + Reverse(leftUp));
                long deltaUp = Math.Abs(resultUp - long.Parse(n));

                long resultDn = long.Parse(leftDn + Reverse(leftDn));
                long deltaDn = Math.Abs(resultDn - long.Parse(n));

                if (delta <= deltaUp && delta < deltaDn) return result.ToString();
                if (deltaUp < delta && deltaUp < deltaDn) return resultUp.ToString();
                if (deltaDn <= deltaUp && deltaDn <= delta) return resultDn.ToString();

                return "";


            }
            else
            {
                string left = n.Substring(0, (length + 1) / 2);

                string leftUp = (long.Parse(left) + 1).ToString();
                string leftDn = (long.Parse(left) - 1).ToString();

                long result = long.Parse(left + Reverse(left).Substring(1));
                long delta = Math.Abs(result - long.Parse(n));
                if (delta == 0) delta = int.MaxValue;

                long resultUp = long.Parse(leftUp + Reverse(leftUp).Substring(1));
                long deltaUp = Math.Abs(resultUp - long.Parse(n));

                long resultDn = long.Parse(leftDn + Reverse(leftDn).Substring(1));
                long deltaDn = Math.Abs(resultDn - long.Parse(n));


                if (delta <= deltaUp && delta < deltaDn) return result.ToString();
                if (deltaUp < delta && deltaUp < deltaDn) return resultUp.ToString();
                if (deltaDn <= deltaUp && deltaDn <= delta) return resultDn.ToString();
                return "";
            }

        }

        private string Reverse(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //5. Longest Palindromic Substring
        //Given a string s, find the longest palindromic substring in s.You may assume that the maximum length of s is 1000.

        //Example 1:

        //Input: "babad"
        //Output: "bab"
        //Note: "aba" is also a valid answer.

        //Example 2:

        //Input: "cbbd"
        //Output: "bb"
        public string LongestPalindrome(string s)
        {
            if (s.Length == 0) return "";
            if (s.Length == 1) return s;
            if (s.Length == 2)
            {
                if (s[0] == s[1]) return s;
                else return s[0].ToString();
            }
            //Dictionary<int, string> Palindrome = new Dictionary<int, string>();

            int startindex=1 ;
            int maxLength=1 ;


            for (int i = 1; i < s.Length; i++)
            {
                // find ABA
                int left = i - 1;
                int right = i + 1;
                //Palindrome.Add(i, s[i].ToString());
                while (left >= 0 && right < s.Length)
                {
                    if (s[left] == s[right])
                    {
                        //Palindrome[i] = s[left] + Palindrome[i] + s[right];
                        if (maxLength < right - left + 1)
                        {
                            maxLength = right-left + 1;
                            startindex = left;
                        }
                        left--;
                        right++;
                    }
                    else
                    {

                        break;
                    }

                }
                //find ABBA 
                if (s[i - 1] == s[i])
                {
                    //Palindrome.Add(-i, s[i - 1].ToString() + s[i].ToString());
                    if(maxLength<2)
                    {
                        startindex = i - 1;
                        maxLength = 2;
                    }
                    left = i - 2;
                    right = i + 1;
                    while (left >= 0 && right < s.Length)
                    {
                        if (s[left] == s[right])
                        {
                            //Palindrome[-i] = s[left] + Palindrome[-i] + s[right];
                            if (maxLength < right - left + 1)
                            {
                                maxLength = right - left + 1;
                                startindex = left;
                            }
                            left--;
                            right++;
                        }
                        else
                        {
                            break;
                        }

                    }

                }
            }
            return s.Substring(startindex, maxLength);
            //string longest = "";
            //foreach (KeyValuePair<int, string> item in Palindrome)
            //{
            //    if (item.Value.Length > longest.Length)
            //        longest = item.Value;
            //}
            //return longest;



        }
    }
}




//126. Word Ladder II
//Given two words(beginWord and endWord), and a dictionary's word list, find all shortest transformation sequence(s) from beginWord to endWord, such that:

//Only one letter can be changed at a time
//Each transformed word must exist in the word list.Note that beginWord is not a transformed word.

//Note:

//Return an empty list if there is no such transformation sequence.

//All words have the same length.

//All words contain only lowercase alphabetic characters.
//You may assume no duplicates in the word list.
//You may assume beginWord and endWord are non-empty and are not the same.


//Example 1:


//Input:
//beginWord = "hit",
//endWord = "cog",
//wordList = ["hot", "dot", "dog", "lot", "log", "cog"]


//Output:
//[
//  ["hit","hot","dot","dog","cog"],
// ["hit","hot","lot","log","cog"]
//]

//Example 2:

//Input:
//beginWord = "hit"
//endWord = "cog"
//wordList = ["hot","dot","dog","lot","log"]

//Output: []

//Explanation: The endWord "cog" is not in wordList, therefore no possible transformation.


