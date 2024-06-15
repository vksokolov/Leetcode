using System.Collections.Generic;
using System.Text;

namespace Leetcode;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override string ToString()
    {
        var node = this;
        var sb = new StringBuilder();
            
        sb.Append('[');
        sb.Append(val);
            
        while (node.next != null)
        {
            node = node.next;
            sb.Append(',');
            sb.Append(' ');
            sb.Append(node.val);
        }

        sb.Append(']');

        return sb.ToString();
    }
    
    public static ListNode Create(int?[] inputArray)
    {
        if (inputArray.Length == 0) return null;

        var index = 0;
        var rootValue = inputArray[index++];
        if (rootValue == null) return null;

        var root = new ListNode(rootValue.Value);
        var nodeQueue = new Queue<ListNode>();
        nodeQueue.Enqueue(root);

        while (nodeQueue.Count > 0 && index < inputArray.Length)
        {
            var curNode = nodeQueue.Dequeue();
            var nextVal = index < inputArray.Length ? inputArray[index++] : null;

            if (nextVal != null)
            {
                curNode.next = new ListNode(nextVal.Value);
                nodeQueue.Enqueue(curNode.next);
            }
        }

        return root;
    }
}