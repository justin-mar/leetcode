# 1105. Filling Bookcase Shelves

## Problem
You are given an array books where books[i] = [thicknessi, heighti] indicates the thickness and height of the ith book. You are also given an integer shelfWidth.

We want to place these books in order onto bookcase shelves that have a total width shelfWidth.

We choose some of the books to place on this shelf such that the sum of their thickness is less than or equal to shelfWidth, then build another level of the shelf of the bookcase so that the total height of the bookcase has increased by the maximum height of the books we just put down. We repeat this process until there are no more books to place.

Note that at each step of the above process, the order of the books we place is the same order as the given sequence of books.
* For example, if we have an ordered list of 5 books, we might place the first and second book onto the first shelf, the third book on the second shelf, and the fourth and fifth book on the last shelf.

*Return the minimum possible height that the total bookshelf can be after placing shelves in this manner.*

Example 1:  
>Input: books = [[1,1],[2,3],[2,3],[1,1],[1,1],[1,1],[1,2]], shelfWidth = 4  
>Output: 6  
>Explanation:  
>The sum of the heights of the 3 shelves is 1 + 3 + 2 = 6.  
>Notice that book number 2 does not have to be on the first shelf.  

Constraints:
* 1 <= books.length <= 10
* 1 <= thicknessi <= shelfWidth <= 1000  
* 1 <= heighti <= 1000

## Explanation

### Bottom-Up Dynamic Programming
We are adding books in order so we can define the subproblem f(i) as the minimum possible height of bookcase when containing all books up to book i. This allows incrementally calculating the bookcase height.

Base Case:
* For i = 0, there are no books so f(0) = 0

To compute f(i), we either:
* New Shelf: place book i on a new shelf. The height would then be books[i][1] + f(i-1), where f(i-1) is the minimum height of all books up to i-1
* Combine Books: place book i on a new shelf along with previous books. We would need to iterate through the previous books and consider which arrangement yields the minimum height.
    * For each possible number of previous book that can fit in the new shelf level, we calculate the theoretical height of the book case in each arrangement for the one with the smallest height

## Code
```
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

            // Create new shelf level to test adding book i-1 to
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

                // Calculate bookcase height of this arrangement
                int possibleHeight = minHeight[j] + currShelfHeight;

                // Get lesser of previously calculated min height or current possible height
                minHeight[i] = Math.Min(minHeight[i], possibleHeight);
            }
        }
        return minHeight[n];
    }
}
```

0
1
3
inf