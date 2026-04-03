## Problem
Given a linked list, swap every two adjacent nodes and return its head. You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)

## Explanation
The solution:
1. Uses the previous node to the current node
2. Points previous node to the next node from the current node
3. Updates the current node to point to the next next node
4. Update the previous node's next next node to point to current node

We generate a previousNode with default value 0 and points to head so the solution still applies to the first 2 nodes.

### Example
[1, 2, 3, 4]

1. Initial setup  
previousNode = 0 -> 1 -> 2 -> 3 -> 4  
currentNode = 1 -> 2 -> 3 -> 4  

2. Point previousNode to currentNode.next (moves original 2nd node to after previousNode)  
previousNode = 0 -> 2 -> 3 -> 4  
currentNode = 1 -> 2 -> 3 -> 4

3. Point currentNode to previousNode.next.next (points original 1st node to nodes after original 2nd node)  
previousNode = 0 -> 2 -> 3 -> 4  
currentNode = 1 -> 3 -> 4

4. Point previousNode.next to currentNode (re-add original 1st node to after original 2nd node)  
previousNode = 0 -> 2 -> 1 -> 3 -> 4  
currentNode = 1 -> 3 -> 4

5. Point previousNode to to currentNode  
previousNode = 1 -> 3 -> 4  
currentNode = 1 -> 3 -> 4

6. Point currentNode to currentNode.next  
previousNode = 1 -> 3 -> 4  
currentNode = 3 -> 4

## Solution
```
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Program
{
    // Helper function to build linked list given an array of int
    public static ListNode ListNodeConstructor(int[] vals)
    {
        if (vals == null || vals.Length == 0)
        {
            return null;
        }

        ListNode head = new ListNode(vals[0]);
        ListNode curr = head;

        for (int i = 1; i < vals.Length; ++i)
        {
            curr.next = new ListNode(vals[i]);
            curr = curr.next;
        }
        
        return head;
    }

    public static void Main()
    {
        ListNode head = ListNodeConstructor([1,2,3, 4]);

        Solution sln = new Solution();
        ListNode ans = sln.SwapPairs(head);

        while (ans.next != null)
        {
            Console.Write(ans.val);
            ans = ans.next;
        }
        Console.WriteLine(ans.val);
        Console.ReadKey();
    }
}


public class Solution
{
    public ListNode SwapPairs(ListNode head)
{
    // Dummy Node ensures we always have a pointer to the first node
    ListNode dummyNode = new ListNode(0, head);

    ListNode prevNode = dummyNode;
    ListNode currNode = head;

    while (currNode != null && currNode.next != null) 
    {
        prevNode.next = currNode.next;
        currNode.next = prevNode.next.next;
        prevNode.next.next = currNode;

        prevNode = currNode;
        currNode = currNode.next;
    }

    return dummyNode.next;
    }
}
```