using System;
using System.Collections.Generic;
using System.Text;

namespace LargestBSTInBinaryTree
{
    class BinaryTreeNode
    {
        int data;
        BinaryTreeNode left;
        BinaryTreeNode right;

        public int GetData(){
            return data;
        }

        public BinaryTreeNode GetLeft() {
            return left;
        }

        public BinaryTreeNode GetRight() {
            return right;
        }

        public void SetData(int data) {
            this.data  = data;
        }

        public void SetLeft(BinaryTreeNode leftNode) {
            left = leftNode;
        }

        public void SetRight(BinaryTreeNode rightNode) {
            right = rightNode;
        }
    }
}
