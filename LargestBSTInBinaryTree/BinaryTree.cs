using System;
using System.Collections.Generic;
using System.Text;

namespace LargestBSTInBinaryTree
{
    class BinaryTree
    {
        BinaryTreeNode head;

        public void SetHead(BinaryTreeNode binaryTreeNode) {
            head = binaryTreeNode;
        }

        public BinaryTreeNode GetHead() {
            return head;
        }

        public BinaryTreeNode Insert(int data){
            return _Insert(head, data);
        }

        private BinaryTreeNode _Insert(BinaryTreeNode binaryTreeNode, int data) {
            if (binaryTreeNode == null) {
                binaryTreeNode = new BinaryTreeNode();
                binaryTreeNode.SetData(data);
                return binaryTreeNode;
            }
            if (binaryTreeNode.GetData() < data){
                binaryTreeNode.SetRight(_Insert(binaryTreeNode.GetRight(), data));
            }
            else {
                binaryTreeNode.SetLeft(_Insert(binaryTreeNode.GetLeft(), data));
            }
            return binaryTreeNode;
        }

        public void PrintInorderTraversal(BinaryTreeNode binaryTreeNode) {
            if (binaryTreeNode == null) {
                return;
            }
            PrintInorderTraversal(binaryTreeNode.GetLeft());
            Console.WriteLine(binaryTreeNode.GetData()+"->");
            PrintInorderTraversal(binaryTreeNode.GetRight());
        }

        public void GetLargestBSTInBT(BinaryTree binaryTree) {
            ResultSet resultSet = new ResultSet();
            try
            {
                resultSet = _GetLargestBSTSize(binaryTree.GetHead());
                if (resultSet != null && resultSet.GetIsBST())
                {
                    Console.WriteLine();
                    Console.WriteLine("The given tree is completely a binary search tree!");
                }
                else if (resultSet != null && resultSet.GetIsBST() == false
                    && resultSet.GetBSTSize() != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("The size of the largest BST is " + resultSet.GetBSTSize());
                }
                else {
                    Console.WriteLine("There is no BST in the given tree!");
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }
        }

        private ResultSet _GetLargestBSTSize(BinaryTreeNode binaryTreeNode) {
            ResultSet resultSet = new ResultSet();
            if (binaryTreeNode == null) {
                resultSet.SetBSTMaxValue(int.MinValue);
                resultSet.SetBSTMinValue(int.MaxValue);
                resultSet.SetBSTSize(0);
                resultSet.SetIsBST(true);
                return resultSet;
            }

            if (binaryTreeNode.GetLeft() == null && binaryTreeNode.GetRight() == null) {
                resultSet.SetBSTSize(1);
                resultSet.SetIsBST(true);
                resultSet.SetBSTMinValue(binaryTreeNode.GetData());
                resultSet.SetBSTMaxValue(binaryTreeNode.GetData());
            }

            ResultSet leftResult = _GetLargestBSTSize(binaryTreeNode.GetLeft());
            ResultSet rightResult = _GetLargestBSTSize(binaryTreeNode.GetRight());

            resultSet.SetBSTSize(leftResult.GetBSTSize() + rightResult.GetBSTSize() + 1);
            //Verify if whole tree is a BST
            /* The entire tree will be a BST if the largest 
             * node in the left is less than the root and
             * the smallest node in the right is still
             * greater than the root.
             * Inaddition, the subtrees rooted at root
             * are binary search trees.
             */
            if (leftResult != null && rightResult != null &&
                leftResult.GetIsBST() != false &&
                rightResult.GetIsBST() != false && 
                leftResult.GetBSTMaxValue() < binaryTreeNode.GetData() &&
                rightResult.GetBSTMinValue() > binaryTreeNode.GetData())
            {
                resultSet.SetBSTMaxValue(
                    Math.Max(rightResult.GetBSTMaxValue(),
                        Math.Max(leftResult.GetBSTMaxValue(), 
                            binaryTreeNode.GetData()))
                    );

                resultSet.SetBSTMinValue(
                    Math.Min(leftResult.GetBSTMinValue(),
                        Math.Min(binaryTreeNode.GetData(),
                            rightResult.GetBSTMinValue()))
                    );
                
                resultSet.SetIsBST(true);
                return resultSet;
            }
            else {
                resultSet.SetBSTSize(Math.Max(leftResult.GetBSTSize(), 
                    rightResult.GetBSTSize()));
                resultSet.SetIsBST(false);
            }
            return resultSet;
        }
    }
}
