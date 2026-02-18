## Problem
Given an array of distinct integers candidates and a target integer target, return a list of all unique combinations of candidates where the chosen numbers sum to target. You may return the combinations in any order.

The same number may be chosen from candidates an unlimited number of times. Two combinations are unique if the of at least one of the chosen numbers is different.

The test cases are generated such that the number of unique combinations that sum up to target is less than 150 combinations for the given input.

**Example 1:**

Input: candidates = [2,3,6,7], target = 7  
Output: [[2,2,3],[7]]  
Explanation:  
2 and 3 are candidates, and 2 + 2 + 3 = 7. Note that 2 can be used multiple times.  
7 is a candidate, and 7 = 7.  
These are the only two combinations.  

**Example 2:**

Input: candidates = [2,3,5], target = 8  
Output: [[2,2,2,2],[2,3,3],[3,5]]  

**Example 3:**

Input: candidates = [2], target = 1  
Output: []


## Explanation
For the decision tree, it would look at the potential candiates, then any count of those potential candidates. If it fails, then it backtracks then tries the next candidate with any potential count. We call backtrack on the same index to ensure the repeat of a potential candiate, then when we return from it either reaching the target or exceeding, we remove the last added number in our temporary list then start looking at the next candidate which is represented by index + 1.

## Solution
```
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> ans = new List<IList<int>>();

        backTrack(candidates, target, ans, new List<int>(), 0, target);
        
        return ans;
    }

    /* @param candidates List of integar we consider for reaching target
     * @param target The sum we are trying to reach with candidates
     * @param ans List we return with a unique combination of candidates
     * @tempList Temporary list to determine if group of candidates will sum to target
     * @i Index of candidates we are considering
     * @totalLeft The remaining number tempList needs to reach target
     * This function investigates a candidate with any potential count of that candidate and if it reaches target or exceeds then it backtracks to try the next candidate with any potential count.
     */
    private void backTrack(int[] candidates, int target, IList<IList<int>> ans, IList<int> tempList, int i, int totalLeft)
    {
        if (totalLeft == 0)
        {
            ans.Add(new List<int>(tempList));
            return;
        }

        if (totalLeft < 0 || i >= candidates.Length)
        {
            return;
        }

        tempList.Add(candidates[i]);
        backTrack(candidates, target, ans, tempList, i, totalLeft - candidates[i]);
        tempList.RemoveAt(tempList.Count - 1);
        backTrack(candidates, target, ans, tempList, i + 1, totalLeft);
    }
}
```

Below is an alternative solution that uses a for loop to iterate through candidates. j is used in backtrack() for i so that we don't restart at the start of candidates when backtracking but instead start at the current index to prevent duplicate combinations.
```
public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> ans = new List<IList<int>>();

        backTrack(candidates, target, ans, new List<int>(), 0, target);
        
        return ans;
    }

    /* @param candidates List of integar we consider for reaching target
     * @param target The sum we are trying to reach with candidates
     * @param ans List we return with a unique combination of candidates
     * @tempList Temporary list to determine if group of candidates will sum to target
     * @i Index of candidates we are considering
     * @totalLeft The remaining number tempList needs to reach target
     * This function investigates a candidate with any potential count of that candidate and if it reaches target or exceeds then it backtracks to try the next candidate with any potential count.
     */
    private void backTrack(int[] candidates, int target, IList<IList<int>> ans, IList<int> tempList, int i, int totalLeft)
    {
        if (totalLeft == 0)
        {
            ans.Add(new List<int>(tempList));
            return;
        }

        for (int j = i; j < candidates.Length; ++j)
        {
            if (candidates[j] > totalLeft) { break; }

            tempList.Add(candidates[j]);
            backTrack(candidates, target, ans, tempList, j, totalLeft - candidates[j]);
            tempList.RemoveAt(tempList.Count - 1);
        }
    }
}
```