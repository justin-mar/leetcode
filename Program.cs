using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Solution sln = new Solution();

        // Input
        int[] candidates = [10, 1, 2, 7, 6, 1, 5];
        int target = 8;

        IList<IList<int>> ans = sln.CombinationSum2(candidates, target);
        //Console.WriteLine();
        //Console.Write(ans);

        foreach (var i in ans)
        {
            Console.Write("[");
            foreach (int j in i)
            {
                Console.Write(j);
            }
            Console.WriteLine("]");
        }
    }
}

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

    private void Backtrack(IList<IList<int>> answer, IList<int> tempList, int[] candidates, int totalLeft, int index)
    {
        if (totalLeft == 0)
        {
            answer.Add(new List<int>(tempList));
            return;
        }

        for (int i = index; i < candidates.Length; ++i)
        {
            if (i > index && candidates[i] == candidates[i - 1]) { continue; }      // Prevent reusing numbers
            if (candidates[i] > totalLeft) { break; }

            tempList.Add(candidates[i]);
            Backtrack(answer, tempList, candidates, totalLeft - candidates[i], i + 1);      // Check for all possible combinations
            tempList.RemoveAt(tempList.Count - 1);      // Backtrack tempList
        }
    }
}