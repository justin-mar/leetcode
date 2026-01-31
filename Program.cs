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
        int[][] isWater = [[0, 0, 1], [1, 0, 0], [0, 0, 0]];

        int[][] ans = sln.HighestPeak(isWater);
        //Console.WriteLine();

        for (int i = 0; i < ans.Length; i++)
        {
            foreach (int j in ans[i])
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Solution
{
    /*
     * Multi-source shortest path BFS
     * Use water tiles a source for BFS
     * If adjacent tile is not set then set its height as +1 then enqueue
     * We start at each source and "ripple" out from there, thus there wouldn't be a tile with a height set that could be smaller as we would've reached it beforehand
     */
    public int[][] HighestPeak(int[][] isWater)
    {
        int m = isWater.Length;
        int n = isWater[0].Length;

        int[][] directions =
        [
            [-1, 0],      // Left
            [1, 0],      // Right
            [0, -1],      // Down
            [0, 1],       // Up
        ];


        int[][] height = new int[m][];

        // Set height's value to -1
        for (int i = 0; i < m; ++i)
        {
            height[i] = new int[n];
            Array.Fill(height[i], -1);
        }

        Queue<(int, int)> queue = new();

        // Enqueue water tiles
        for (int i = 0; i < m; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (isWater[i][j] == 1)
                {
                    height[i][j] = 0;
                    queue.Enqueue((i, j));
                }
            }
        }

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            foreach (var dir in directions)
            {
                int newX = x + dir[0];
                int newY = y + dir[1];

                // Check that newX and newY are in bound of height and value isn't decided
                if (newX >= 0 && newX < m && newY  >= 0 && newY < n && height[newX][newY] == -1)
                {
                    height[newX][newY] = height[x][y] + 1;
                    queue.Enqueue((newX, newY));
                }
            }
        }

        return height;
    }

    public void PrintQueue(Queue<(int, int)> queue)
    {
        Console.WriteLine("Queue:");
        foreach ((int, int) val in queue)
        {
            Console.WriteLine(val.Item1 + " " + val.Item2);
        }

        Console.WriteLine();
    }
}