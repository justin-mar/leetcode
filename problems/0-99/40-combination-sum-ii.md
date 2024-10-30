# Combination Sum II

## Problem
Given a collection of candidate numbers (candidates) and a target number (target), find all unique combinations in candidates where the candidate numbers sum to target.

Each number in candidates may only be used once in the combination.

Note: The solution set must not contain duplicate combinations.

Example 1:  
>Input: candidates = [10,1,2,7,6,1,5], target = 8  
>Output:   
>[  
>[1,1,6],  
>[1,2,5],  
>[1,7],  
>[2,6]  
>]  

Example 2:  
>Input: candidates = [2,5,2,1,2], target = 5  
>Output:  
>[  
>[1,2,2],  
>[5]  
>]  

Constraints:  
* 1 <= candidates.length <= 100
* 1 <= candidates[i] <= 50
* 1 <= target <= 30

## Explanation
Backtracking can be used to efficiently generate all possible combinations recursively. Backtracking incrementally builds candidates to the solutions and abandons a candidate (backtracks) if a candidate can't lead to a final solution. For this problem, we can discard the candidate solution when it exceeds the target value.

When we evaluate a number we have 2 options:
1. We add the current array element to the combination array and move this combination to the next index recursively.  
2. We remove the element from the current combination array and move this combination to the next index.

Therefore, for every index, we explore 2 possibilities of including and excluding that value and calculated the combination sum of the maintained combination array.  
If the desired sum is reached, we can append the list to the answer list.

Since we need to return unique combinations, we can optimize by grouping equal values together. Then when we remove an element and the next element is the same, we can simply skip over it.  
Otherwise, we would repeat those calculations and we would need to get only the unique answers at the end.

If frequency of element is *freq*, you need to make backtracking calls for all its possible frequencies between 0 and *freq*, then we can simply pickup them from the beginning of its group in the sorted array.

## Code
```
public class Solution
{
    // For each subsequent number, we test either adding it or passing over it
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        IList<IList<int>> list = new List<IList<int>>();
        Array.Sort(candidates);
        Backtrack(list, new List<int>(), candidates, target, 0);
        return list;
    }

    /*
     * @param answer The unique combination of candidates that equals target
     * @param tempList A temporary list used to store potential answers
     * @param candidates The array of candidate values
     * @param totalLeft target - sum of values in tempList
     * @param index The index of candidate values we checked
     */
    private void Backtrack(IList<IList<int>> answer, IList<int> tempList, int[] candidates, int totalLeft, int index)
    {
        if (totalLeft == 0)
        {
            answer.Add(new List<int>(tempList));
            return;
        }

        for (int i = index; i < candidates.Length; ++i)
        {
            if (i > index && candidates[i] == candidates[i - 1]) { continue; }      // Continue pass the same number if we backtracked it already
            if (candidates[i] > totalLeft) { break; }

            tempList.Add(candidates[i]);
            Backtrack(answer, tempList, candidates, totalLeft - candidates[i], i + 1);      // Check for all possible combinations
            tempList.RemoveAt(tempList.Count - 1);      // Backtrack tempList
        }
    }
}
```