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
        string s = "baababbaabbaaabaabbabbbabaaaaaabaabababaaababbb";

        int ans = sln.MinimumDeletions(s);
        Console.WriteLine();
        Console.Write(ans);
    }
}


public class Solution
{
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