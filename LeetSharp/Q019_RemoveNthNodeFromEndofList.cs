using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a linked list, remove the nth node from the end of list and return its head.
// For example,
//   Given linked list: 1->2->3->4->5, and n = 2.
//   After removing the second node from the end, the linked list becomes 1->2->3->5.
//
// Note:
// Given n will always be valid.
// Try to do this in one pass.

namespace LeetSharp
{
    [TestClass]
    public class Q019_RemoveNthNodeFromEndofList
    {
        public ListNode<int> RemoveNthFromEnd(ListNode<int> head, int n)
        {
            if (head == null)
                return null;

            ListNode<int> slow = head, fast = head;
            for (int i = 0; i < n; i++)
                fast = fast.Next;

            if (fast == null)
                return head.Next;

            while (fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next;
            }

            slow.Next = slow.Next.Next;

            return head;
        }

        public string SolveQuestion(string input)
        {
            return RemoveNthFromEnd(input.GetToken(0).ToListNode<int>(), input.GetToken(1).ToInt()).SerializeListNode();
        }

        [TestMethod]
        public void Q019_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q019_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
