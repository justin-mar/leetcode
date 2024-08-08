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
        int rows = 1;
        int cols = 4;
        int rStart = 0;
        int cStart = 0;

        int[][] ans = sln.SpiralMatrixIII(rows, cols, rStart, cStart);
        //Console.WriteLine();
        //Console.Write(ans);

        for (int i = 0; i < ans.Length; i++)
        {
            Console.Write("[");
            for (int j = 0; j < 2; j++)
            {
                Console.Write(ans[i][j]);
                if (j == 0)
                {
                    Console.Write(",");
                }
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
}


public class Solution
{
    /* Going right or left increases the number of cells you visit in that row by 1 while going up or down uses the same number of cells as previous left/right
     * 
     * 7    8   9
     * 6    1   2
     * 5    4   3
     * 
     * In the above 1->2 is one space, 2->3 is one space, then you go 3->5 which is 2 space, 5->7 is 2 space, 7->9 plus 1 off grid is 3 space
     */
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        /*
         * direction = 0 -> East
         * direction = 1 -> South
         * direction = 2 -> West
         * direction = 3 -> North
         */
        int[][] dir = [[0, 1], [1, 0], [0, -1], [-1, 0]];
        int[][] traversed = new int[rows * cols][];
        int index = 0;

        for (int step = 1, direction = 0; index < rows * cols;)
        {
            // Step increases every 2 turns 
            for (int i = 0; i < 2; ++i)
            {
                for (int j = 0; j < step; ++j)
                {
                    // If we are in a valid position on the matrix, then add it to traversed array
                    if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                    {
                        traversed[index] = [rStart, cStart];
                        ++index;
                    }
                    // Traverse through matrix
                    rStart += dir[direction][0];
                    cStart += dir[direction][1];
                }
                // Calculate next iteration's direction
                direction = (direction + 1) % 4;
            }
            ++step;
        }
        return traversed;
    }
}