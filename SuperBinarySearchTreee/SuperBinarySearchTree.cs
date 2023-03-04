using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SuperBinarySearchTree
{
    public class SuperBinarySearchTree<T> where T : IComparable<T>
    {
        public SuperTreeNode<T>? Root { get; private set; }

        public SuperBinarySearchTree()
        {
            Root = null; 
        }

        public SuperBinarySearchTree(T data)
        {
            Root = new SuperTreeNode<T>(data);
        }

        /// <summary>
        /// 
        //    Iterative-Tree-Search(x, key)
        //          while x ≠ NIL and key ≠ x.key then
        //              if key<x.key then
        //                  x := x.left
        //              else
        //                  x := x.right
        //              end if
        //          repeat
        //          return x
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>

        public SuperTreeNode<T>? Search (T data) { 
            var searchNode = Root;

            while(searchNode != null)
            {
                if (data.CompareTo(searchNode.Data) == 0) return searchNode;
                else if (data.CompareTo(searchNode.Data) < 0) searchNode = searchNode.LeftChild;
                else if (data.CompareTo (searchNode.Data) > 0) searchNode = searchNode.RightChild;
            }
            return null;
        }

        /// <summary>
        /// Recursive-Tree-Search(x, key)
        //    if x = NIL or key = x.key then
        //        return x
        //    if key<x.key then
        //        return Recursive-Tree-Search(x.left, key)
        //    else
        //        return Recursive-Tree-Search(x.right, key)
        //    end if
        /// </summary>
        /// <param name="root"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public SuperTreeNode<T>? SearchRecursive(SuperTreeNode<T>? root, T data)
        {
            if (root == null || data.CompareTo(root.Data) == 0) { return root; }

            if (data.CompareTo(root.Data) < 0) return SearchRecursive(root.LeftChild, data);
            else if (data.CompareTo(root.Data) > 0) return SearchRecursive(root.RightChild, data);

            return null;
        }

        /// <summary>
        /// while x.right ≠ NIL then
        //      x := x.right
        //         repeat
        //      return x
        /// </summary>
        /// <returns></returns>
        private SuperTreeNode<T>? FindMinimum(SuperTreeNode<T> root)
        {
            var minimum = root;
            while (minimum?.LeftChild != null)
            {
                minimum = minimum.LeftChild;
            }
            return minimum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SuperTreeNode<T>? FindMaximum(SuperTreeNode<T> root)
        {
            var maximum = root;
            while (maximum?.RightChild != null)
            {
                maximum = maximum.RightChild;
            }
            return maximum;
        }

        /// <summary>
        /// BST-Successor(x)
        ///     if x.right ≠ NIL then
        ///       return BST-Minimum(x.right)
        ///     end if
        ///     y := x.parent
        ///     while y ≠ NIL and x = y.right then
        ///       x := y
        ///       y := y.parent
        ///     repeat
        ///     return y
        /// </summary>
        /// <returns></returns>
        public SuperTreeNode<T>? InOrderSuccessor(T data)
        {
            SuperTreeNode<T>? successor = null;
            var rootNode = Root;
            if (rootNode == null) return null;
            while (rootNode != null)
            {
                if (data.CompareTo(rootNode.Data) == 0 && rootNode?.RightChild == null) { return successor; }
                if (data.CompareTo(rootNode.Data) == 0 && rootNode?.RightChild != null) { return FindMinimum(rootNode.RightChild); }
                else if (rootNode != null && data.CompareTo(rootNode.Data) < 0)
                {
                    if (rootNode.LeftChild != null) { successor = rootNode; rootNode = rootNode.LeftChild; }
                    else { return successor; }
                }
                else if (rootNode != null && data.CompareTo(rootNode.Data) > 0)
                {
                    if (rootNode.RightChild != null)
                    {
                        rootNode = rootNode.RightChild;
                    }
                    else { return successor; }
                }
            }
            return successor;
        }

        public SuperTreeNode<T>? InOrderPredecessor(T data)
        {
            SuperTreeNode<T>? predecessor = null;
            var rootNode = Root;
            if (rootNode == null) return null;
            while (rootNode != null)
            {
                if (data.CompareTo(rootNode.Data) == 0 && rootNode?.LeftChild == null) { return predecessor; }
                if (data.CompareTo(rootNode.Data) == 0 && rootNode?.LeftChild != null) { return FindMaximum(rootNode.LeftChild); }
                else if (rootNode != null && data.CompareTo(rootNode.Data) < 0)    
                { 
                    if (rootNode.LeftChild != null) { rootNode = rootNode.LeftChild; }
                    else { return predecessor; }
                }
                else if (rootNode != null && data.CompareTo(rootNode.Data) > 0) {
                    if (rootNode.RightChild != null)
                    {
                        predecessor = rootNode; rootNode = rootNode.RightChild;
                    }
                    else { return predecessor; }
                }
            }
            return predecessor;

        }


        public bool Insert (T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var node = new SuperTreeNode<T>(data);
            var insertionRoot = Root;
            if (Root == null) { Root = node; return true; }
            while (insertionRoot != null) 
            {
                if (data.CompareTo(insertionRoot.Data) ==  0) {  return false; }

                else if (data.CompareTo(insertionRoot.Data) < 0)
                {
                    if (insertionRoot.LeftChild == null) { return insertionRoot.SetLeftChild(node); }
                    else { insertionRoot = insertionRoot.LeftChild; }
                }

                else if (data.CompareTo(insertionRoot.Data) > 0)
                {
                    if (insertionRoot.RightChild == null) { return insertionRoot.SetRightChild(node); }
                    else { insertionRoot = insertionRoot.RightChild; }
                }  
            }

            return false;
        }

        public bool Delete (T data)
        {
            throw new NotImplementedException();
        }
    }
}
