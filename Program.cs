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

public class Program {
    public static void Main() {
        Solution sln = new Solution();

        // Input
        int[] rating = [2, 5, 3, 4, 1];

        int ans = sln.NumTeams(rating);
        Console.Write(ans);
    }
}


public class Solution {
    public int NumTeams(int[] rating) {
        int ans = 0;
        // Track amount of ratings greather/smaller than rating at index
        int[] smaller = new int[rating.Length];
        int[] greater = new int[rating.Length];

        // Iterate through rating and populate arrays with number of ratings greater/smaller rating at index
        for (int i = 0; i < rating.Length; i++) {
            for (int j = i + 1; j < rating.Length; j++) {
                if (rating[i] < rating[j]) {
                    greater[i]++;
                } else if (rating[i] > rating[j]) { 
                    smaller[i]++; 
                }
            }
        }

        // Iterate through rating and add number at greater[j] or smaller[j] for applicable asc and desc order
        for (int i = 0; i < rating.Length; i++) {
            for (int j = i + 1; j < rating.Length; j++) {
                // If rating[i] < rating[j] then order is asc so greater[j] is the numer of applicable teams
                if (rating[i] < rating[j]) {
                    ans += greater[j];
                }
                // If rating[i] > rating[j] then order is desc so smaller[j] is the number of applicable teams
                else if (rating[i] > rating[j]) {
                    ans += smaller[j];
                }
            }
        }

        return ans;
    }
}