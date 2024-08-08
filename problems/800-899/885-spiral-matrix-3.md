# Spiral Matrix III

## Problem
You start at the cell (rStart, cStart) of an rows x cols grid facing east. The northwest corner is at the first row and column in the grid, and the southeast corner is at the last row and column.

You will walk in a clockwise spiral shape to visit every position in this grid. Whenever you move outside the grid's boundary, we continue our walk outside the grid (but may return to the grid boundary later.). Eventually, we reach all rows * cols spaces of the grid.

Return an array of coordinates representing the positions of the grid in the order you visited them.

Input: rows = 1, cols = 4, rStart = 0, cStart = 0  
Output: [[0,0],[0,1],[0,2],[0,3]]  

Constraints:
* 1 <= rows, cols <= 100
* 0 <= rStart < rows
* 0 <= cStart < cols

## Explanation
If we simulate the movement:
* Move 1 East
* Move 1 South
* Move 2 West
* Move 2 North
* Move 3 East
* Move 3 South
* Move 4 West
* Move 4 North

There is a pattern where the distance traversed increases when going East/West which occurs every 2 times. We can store the directional movements in an array so that East corresponds to (x+0, y+1) and South to (x+1, y+0). If the cell we traverse to is in the matrix, then we add it to a traversed array

## Code
```
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
```