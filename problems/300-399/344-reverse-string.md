## Problem
Write a function that reverses a string. The input string is given as an array of characters s.

You must do this by modifying the input array in-place with O(1) extra memory.


Example 1:
>Input: s = ["h","e","l","l","o"]  
>Output: ["o","l","l","e","h"]

Example 2:
>Input: s = ["H","a","n","n","a","h"]  
>Output: ["h","a","n","n","a","H"]


Constraints:
* 1 <= s.length <= 105
* s[i] is a printable ascii character.

## Solution
### Recursive
Traverse the string and swap with the corresponding char on the other end. Track both left and right index of characters we are swapping, starts with:  
left = 0  
right = s.Length - 1  

then left increases by 1 while right decreases by 1 as the string is traversed
```
public class Solution
{
    public void ReverseString(char[] s)
    {
        helper(s, 0, s.Length - 1);
    }

    private void helper(char[] s, int left, int right)
    {
        if (left > right)
        {
            return;
        }
        char temp = s[left];
        s[left] = s[right];
        s[right] = temp;
        helper(s, ++left, --right);
    }
}
```