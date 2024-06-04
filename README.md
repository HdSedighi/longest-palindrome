# Intuition
<!-- Describe your first thoughts on how to solve this problem. -->
The first thought in solving this problem is to recognize that a palindrome reads the same forward and backward. To maximize the length of a palindrome, we need to use as many pairs of characters as possible and can include at most one character with an odd count in the center.

# Approach
<!-- Describe your approach to solving the problem. -->
1. Use a dictionary to count the occurrences of each character in the string.
2. Iterate through the character counts:
- If a character count is even, it can fully contribute to the palindrome length.
- If a character count is odd, the largest even number less than the count can contribute, and we note that there's at least one odd count.
3. If there was an odd count, we can place one odd character in the center of the palindrome.
4. Sum up the contributions to get the length of the longest possible palindrome.
Complexity
# Time complexity:
<!-- Add your time complexity here, e.g. $$O(n)$$ -->
The time complexity is O(n), where n is the length of the string. This is because we need to iterate through the string once to count character frequencies and then iterate through the dictionary of counts.

- Space complexity:
<!-- Add your space complexity here, e.g. $$O(n)$$ -->
The space complexity is O(1) in terms of the alphabet size, because the dictionary will contain at most 52 entries (for lowercase and uppercase English letters). If we consider the input size as the parameter, then it would be O(n) for storing the counts in the worst case when every character is unique.

# Code
```
public class Solution {
    public int LongestPalindrome(string s) {
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
}
```
