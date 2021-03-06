using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Follow up for problem "Populating Next Right Pointers in Each Node".
   
// What if the given tree could be any binary tree? Would your previous solution still work?
   
// Note:
   
// You may only use constant extra space.
// For example,
// Given the following binary tree,
   
//          1
//        /  \
//       2    3
//      / \    \
//     4   5    7
// After calling your function, the tree should look like:
   
//          1 -> NULL
//        /  \
//       2 -> 3 -> NULL
//      / \    \
//     4-> 5 -> 7 -> NULL

namespace LeetSharp
{
    [TestClass]
    public class Q117_PopulatingNextRightPointersinEachNodeII
    {
        public TreeNodeWithNext Connect(BinaryTree input)
        {
            TreeNodeWithNext root = input.ConvertToTreeNodeWithNext();
            Connect(root);

            return root;
        }

        private void Connect(TreeNodeWithNext root)
        {
            if (root == null)
                return;

            Connect(root.Left, root);
            Connect(root.Right, root);

            Connect(root.Right);
            Connect(root.Left);
        }

        private void Connect(TreeNodeWithNext current, TreeNodeWithNext parent)
        {
            if (current == null)
                return;

            if (current != parent.Right && parent.Right != null)
            {
                current.Next = parent.Right;
            }
            else
            {
                while (parent.Next != null)
                {
                    parent = parent.Next;
                    if (parent.Left != null || parent.Right != null)
                    {
                        current.Next = parent.Left == null ? parent.Right : parent.Left;
                        break;
                    }
                }
            }
        }

        public string SolveQuestion(string input)
        {
            return Connect(input.ToBinaryTree()).SerializeTreeNodeWithNext();
        }

        [TestMethod]
        public void Q117_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q117_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
