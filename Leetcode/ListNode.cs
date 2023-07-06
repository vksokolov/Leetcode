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
}