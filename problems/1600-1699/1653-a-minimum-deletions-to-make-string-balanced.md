# 1653. Minimum Deletions to Make String Balanced

## Problem

You are given a string s consisting only of characters 'a' and 'b'​​​​.

You can delete any number of characters in s to make s balanced. s is balanced if there is no pair of indices (i,j) such that i < j and s[i] = 'b' and s[j]= 'a'.

Return the minimum number of deletions needed to make s balanced.

Example 1:

> Input: s = "aababbab"  
> Output: 2  
> Explanation: You can either:  
> Delete the characters at 0-indexed positions 2 and 6 ("aababbab" -> "aaabbb"), or  
> Delete the characters at 0-indexed positions 3 and 6 ("aababbab" -> "aabbbb").

Example 2:

> Input: s = "bbaaaaabb"  
> Output: 2  
> Explanation: The only solution is to delete the first two characters.

Constraints:
* 1 <= s.length <= 105
* s[i] is 'a' or 'b'​​.

## Explanation
We iterate through the string and track each occurence of a 'b'. If we encounter an 'a' while the b count is not zero, then we either need to delete a previous 'b' or the 'a'.  
For example, "bba" would require deleting the 'a' instead of the 2 'b'.  
Therefore, for each 'a', we delete at most 1 character and decrease the b count by 1. That way, if there is a final string of a's after a string of b, it only deletes the minimum amount (if we reach the end with b count non-zero, then we delete the a's, otherwise we delete the b's).

## Code

```
public class Solution {
    public int MinimumDeletions(string s)
    {
        int deletion = 0;
        int BCount = 0;

        foreach (char c in s)
        {
            if (c == 'b')
            {
                BCount++;
            }
            else if (BCount > 0)
            {
                deletion++;
                BCount--;
            }
        }
        return deletion;
    }
}
```