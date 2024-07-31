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
        int[][] books = [[1, 1], [2, 3], [1, 3], [1, 1]];
        int shelfwidth = 4;

        int ans = sln.MinHeightShelves(books, shelfwidth);
        //Console.WriteLine();
        Console.Write(ans);
    }
}


public class Solution
{
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        int n = books.Length;
        int[] minHeight = new int[n + 1];           // minimum height to accodomate first i books

        // If no books then we have a height of 0
        minHeight[0] = 0;

        // Iterate through books
        for (int i = 1; i <= n; i++)
        {
            minHeight[i] = int.MaxValue;

            // Test new book by first putting on its own shelf level
            int currShelfWidth = 0;
            int currShelfHeight = 0;

            // Iterate from i-1 book to first book and calculate minHeight as you add books to new shelf level
            for (int j = i - 1; j >= 0; j--)
            {
                int currBookThickness = books[j][0];
                int currBookHeight = books[j][1];

                currShelfWidth += currBookThickness;

                if (currShelfWidth > shelfWidth)
                {
                    break;
                }

                currShelfHeight = Math.Max(currShelfHeight, currBookHeight);

                // Calculate height of adding book j to current shelf level
                int possibleHeight = minHeight[j] + currShelfHeight;

                // Get lesser of previously calculated height or current possible height
                minHeight[i] = Math.Min(minHeight[i], possibleHeight);
            }
        }
        return minHeight[n];
    }
}