using System.Collections.Generic;

namespace Leetcode;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public static TreeNode Create(int?[] inputArray)
    {

        if (inputArray.Length == 0) return null;

        var index = 0;
        var rootValue = inputArray[index++];
        if (rootValue == null) return null;

        var root = new TreeNode(rootValue.Value);
        var nodeQueue = new Queue<TreeNode>();
        nodeQueue.Enqueue(root);

        while (nodeQueue.Count > 0 && index < inputArray.Length)
        {
            var curNode = nodeQueue.Dequeue();
            var leftVal = index < inputArray.Length ? inputArray[index++] : null;
            var rightVal = index < inputArray.Length ? inputArray[index++] : null;

            if (leftVal != null)
            {
                curNode.left = new TreeNode(leftVal.Value);
                nodeQueue.Enqueue(curNode.left);
            }

            if (rightVal != null)
            {
                curNode.right = new TreeNode(rightVal.Value);
                nodeQueue.Enqueue(curNode.right);
            }
        }

        return root;
    }
}