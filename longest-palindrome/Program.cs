using System;
using System.Collections.Generic;

public class Solution
{
    public int LongestPalindrome(string s)
    {
        // Dictionary to count occurrences of each character
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (charCounts.ContainsKey(c))
            {
                charCounts[c]++;
            }
            else
            {
                charCounts[c] = 1;
            }
        }

        int length = 0;
        bool oddCountFound = false;

        // Calculate the length of the longest palindrome
        foreach (int count in charCounts.Values)
        {
            if (count % 2 == 0)
            {
                length += count;
            }
            else
            {
                length += count - 1;
                oddCountFound = true;
            }
        }

        // If there was an odd count, we can add one character to the middle
        if (oddCountFound)
        {
            length++;
        }

        return length;
    }

    static void Main(string[] args)
    {
        Solution solution = new Solution();

        // Test cases
        string s1 = "abccccdd";
        Console.WriteLine("Input: " + s1);
        Console.WriteLine("Output: " + solution.LongestPalindrome(s1));  // Output: 7

        string s2 = "a";
        Console.WriteLine("Input: " + s2);
        Console.WriteLine("Output: " + solution.LongestPalindrome(s2));  // Output: 1
    }
}
