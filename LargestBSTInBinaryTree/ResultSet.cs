using System;
using System.Collections.Generic;
using System.Text;

namespace LargestBSTInBinaryTree
{
    class ResultSet
    {
        int BSTSize;
        bool isBST;
        int BSTMinValue;
        int BSTMaxValue;

        public int GetBSTSize() {
            return BSTSize;
        }

        public bool GetIsBST() {
            return isBST;
        }

        public int GetBSTMinValue() {
            return BSTMinValue;
        }

        public int GetBSTMaxValue() {
            return BSTMaxValue;
        }

        public void SetBSTSize(int size) {
            BSTSize = size;
        }

        public void SetBSTMinValue(int value) {
            BSTMinValue = value;
        }

        public void SetBSTMaxValue(int value) {
            BSTMaxValue = value;
        }

        public void SetIsBST(bool value) {
            isBST = value;
        }
    }
}
