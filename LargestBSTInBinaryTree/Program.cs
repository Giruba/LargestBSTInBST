using System;

namespace LargestBSTInBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Largest BST in BInary Tree!");
            Console.WriteLine("---------------------------");
            try {
                BinaryTree binaryTree = new BinaryTree();
                binaryTree.SetHead(ConstructTreeFromInput());
                binaryTree.GetLargestBSTInBT(binaryTree);
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }
            Console.ReadLine();
        }

        private static BinaryTreeNode ConstructTreeFromInput() {
            BinaryTree binaryTree = new BinaryTree();

            Console.WriteLine("Enter the number of nodes in the binary tree");
            try {
                int noOfNodes = int.Parse(Console.ReadLine());
                for (int i = 0; i < noOfNodes; i++) {
                    Console.WriteLine("Enter value "+(i+1)+":");
                    binaryTree.SetHead(binaryTree.Insert(int.Parse(Console.ReadLine())));
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }

            return binaryTree.GetHead();
        }
    }
}
