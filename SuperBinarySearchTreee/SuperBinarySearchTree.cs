using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public SuperTreeNode<T>? Search(T data)
        {
            var searchNode = Root;

            while (searchNode != null)
            {
                if (data.CompareTo(searchNode.Data) == 0) return searchNode;
                else if (data.CompareTo(searchNode.Data) < 0) searchNode = searchNode.LeftChild;
                else if (data.CompareTo(searchNode.Data) > 0) searchNode = searchNode.RightChild;
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
                else if (rootNode != null && data.CompareTo(rootNode.Data) > 0)
                {
                    if (rootNode.RightChild != null)
                    {
                        predecessor = rootNode; rootNode = rootNode.RightChild;
                    }
                    else { return predecessor; }
                }
            }
            return predecessor;

        }


        public bool Insert(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var node = new SuperTreeNode<T>(data);
            var insertionRoot = Root;
            if (Root == null) { Root = node; return true; }
            while (insertionRoot != null)
            {
                if (data.CompareTo(insertionRoot.Data) == 0) { return false; }

                else if (data.CompareTo(insertionRoot.Data) < 0)
                {
                    if (insertionRoot.LeftChild == null) { insertionRoot.SetLeftChild(node); return true; }
                    else { insertionRoot = insertionRoot.LeftChild; }
                }

                else if (data.CompareTo(insertionRoot.Data) > 0)
                {
                    if (insertionRoot.RightChild == null) { insertionRoot.SetRightChild(node); return true; }
                    else { insertionRoot = insertionRoot.RightChild; }
                }
            }

            return false;
        }

        /// <summary>
        /// Shift_Nodes(BST, u, v)
        ///     if u.parent = NIL then
        ///       BST.root := v
        ///     else if u = u.parent.left then
        ///       u.parent.left := v
        ///     else
        ///       u.parent.right := v
        ///     end if
        ///     if v ≠ NIL then
        ///       v.parent := u.parent
        ///     end if
        /// </summary>
        /// <param name="data"></param>
        private void ShiftNodes(T data)
        {
            throw new NotImplementedException();

        }

        /// <summary>
        /// Follow the below steps to solve the problem:
        ///      If the root is NULL, then return root(Base case)
        ///      If the key is less than the root’s value, then set root->left = deleteNode(root->left, key)
        ///      If the key is greater than the root’s value, then set root->right = deleteNode(root->right, key)
        ///      Else check
        ///      If the root is a leaf node then return null
        ///      else if it has only the left child, then return the left child
        ///      else if it has only the right child, then return the right child
        ///      else set the value of root as of its inorder successor and recur to delete the node with the value of the inorder successor
        ///      Return
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private SuperTreeNode<T>? Delete(SuperTreeNode<T>? root, T? data)
        {
            if (data == null) return null;
            var rootNode = root;
            if (rootNode == null)
            {
                return rootNode;
            }
            if (data.CompareTo(rootNode.Data) < 0)
            {
                var returnNode = Delete(rootNode.LeftChild, data);
                rootNode.SetLeftChild(returnNode);
            }
            if (data.CompareTo(rootNode.Data) > 0)
            {
                var returnNode = Delete(rootNode.RightChild, data);
                rootNode.SetRightChild(returnNode);
            }
            if (data.CompareTo(rootNode.Data) == 0)
            {
                if (!rootNode.HasLeftChild() && !rootNode.HasRightChild())
                {
                    rootNode = null;
                    return rootNode;
                }
                else if (!rootNode.HasLeftChild() && rootNode.HasRightChild())
                {
                    var temp = rootNode;
                    rootNode = rootNode.RightChild;
                    temp = null;
                }
                else if (rootNode.HasLeftChild() && !rootNode.HasRightChild())
                {
                    var temp = rootNode;
                    rootNode = rootNode.LeftChild;
                    temp = null;
                }
                else
                {   SuperTreeNode<T>? minValueNode = null;
                    if (rootNode != null && rootNode.RightChild != null)
                    {
                        minValueNode = FindMinimum(rootNode.RightChild);
                    }
                    else
                    {
                        return null;
                    }

                    if (minValueNode != null && minValueNode.Data != null)
                    {
                        rootNode.SetData(minValueNode.Data);
                        rootNode.SetRightChild(Delete(rootNode.RightChild, minValueNode.Data));
                    }
                    else
                    { return null; }
                }
            }
            return rootNode;
        }

        public bool Delete(T data)
        {
            var deletionReturn = Delete(Root, data);
            if (deletionReturn != null) return true;
            return false;
        }

        private bool? DeleteIterative (SuperTreeNode<T>? root, T? data)
        {
            if (data == null) return false;
            if (root == null)
            {
                return false;
            }

            SuperTreeNode<T> previousNode = null;
            var currentRootNode = Root;

            while (currentRootNode != null && currentRootNode.Data != null && data.CompareTo(currentRootNode.Data) != 0)
            {
                previousNode = currentRootNode;
                if (currentRootNode != null && currentRootNode.Data != null && data.CompareTo(currentRootNode.Data) < 0)
                {
                    currentRootNode = currentRootNode.LeftChild;
                }
                else if (currentRootNode != null && currentRootNode.Data != null && data.CompareTo(currentRootNode.Data) > 0)
                {
                    currentRootNode = currentRootNode.RightChild;
                }
            }

            if (currentRootNode == null) return false;
            if (!currentRootNode.HasRightChild() && !currentRootNode.HasLeftChild())
            {
                if (previousNode != null && previousNode.HasLeftChild() && previousNode.LeftChild.Equals(currentRootNode))
                {
                    previousNode.SetLeftChild(null);
                }
                else if (previousNode != null && previousNode.HasRightChild() && previousNode.RightChild.Equals(currentRootNode))
                {
                    previousNode.SetRightChild(null);
                }
                currentRootNode = null;
                return true;
            }
            if ((!currentRootNode.HasLeftChild() && currentRootNode.HasRightChild()) || (!currentRootNode.HasRightChild() && currentRootNode.HasLeftChild()))
            {
                SuperTreeNode<T>? temporaryCurrentNode = null;

                if (currentRootNode.HasLeftChild() && !currentRootNode.HasRightChild())
                {
                    temporaryCurrentNode =  currentRootNode.LeftChild;
                }

                else if (currentRootNode.HasRightChild() && !currentRootNode.HasLeftChild())
                {
                    temporaryCurrentNode = currentRootNode.RightChild;
                }
                if (previousNode == null) return false;
                
                if (currentRootNode.Equals(previousNode.LeftChild))
                {
                    previousNode.SetLeftChild(temporaryCurrentNode);
                }
                else
                {
                    previousNode.SetRightChild(temporaryCurrentNode);
                }
                currentRootNode = null;
                return true;
            }

            else
            {
                SuperTreeNode<T>? minValueNode = null;
                if (currentRootNode != null && currentRootNode.RightChild != null)
                {
                    minValueNode = FindMinimum(currentRootNode.RightChild);
                }
                else
                {
                    return false;
                }

                if (minValueNode != null && minValueNode.Data != null)
                {
                    SuperTreeNode<T>? previousTempNode = null;
                    currentRootNode.SetData(minValueNode.Data);
                    var temp = currentRootNode.RightChild;


                    while (temp != null && minValueNode.Data.CompareTo(temp.Data) != 0)
                    {
                        previousTempNode = temp;
                        if (temp.HasLeftChild() && minValueNode.Data.CompareTo(temp.Data) < 0) temp = temp.LeftChild;
                        else if (temp.HasRightChild() && minValueNode.Data.CompareTo(temp.Data) > 0) temp = temp.RightChild;
                    }

                    if (minValueNode.Data.CompareTo(temp.Data) == 0)
                    {
                      
                        if (previousTempNode != null && previousTempNode.HasLeftChild() && previousTempNode.LeftChild.Equals(temp)) { previousTempNode.SetLeftChild(null); }
                        else if (previousTempNode != null && previousTempNode.HasLeftChild() && previousTempNode.LeftChild.Equals(temp)) { previousTempNode.SetRightChild(null); }
                        else if (previousTempNode == null && currentRootNode.HasRightChild() && minValueNode.Data.CompareTo(currentRootNode.RightChild.Data) == 0)
                        {
                            currentRootNode.SetRightChild(null);
                        }
                        else if (previousTempNode == null && !currentRootNode.HasRightChild() && minValueNode.Data.CompareTo(currentRootNode.LeftChild.Data) == 0)
                        {
                            currentRootNode.SetLeftChild(null);
                        }
                        else
                        { 
                            return false; 
                        }
                    }
                }
                else
                { 
                    return false; 
                }

               
            }

            return true;

        }

        public bool DeleteIterative(T data)
        {
           return DeleteIterative(Root, data) ?? false;
           
        }

        /// <summary>
        /// Inorder-Tree-Walk(x)
        ///  if x ≠ NIL then
        ///    Inorder-Tree-Walk(x.left)
        ///    visit node
        ///    Inorder-Tree-Walk(x.right)
        ///  end if
        /// </summary>
        private void InOrderTraversal(SuperTreeNode<T>? root)
        {
            var startingNode = root;
            if (startingNode == null) return;
            if (startingNode.HasLeftChild())
            {
                InOrderTraversal(startingNode?.LeftChild);
            }
            if (startingNode != null && startingNode.Data != null) { Console.Write($"{startingNode.Data} "); }
            
            if (startingNode != null && startingNode.HasRightChild())
            {
                InOrderTraversal(startingNode?.RightChild);
            }
        }

        public void InOrderTraversal() { InOrderTraversal(Root); }

        private void PreOrderTraversal(SuperTreeNode<T>? root)
        {
            var startingNode = root;
            if (startingNode == null) return;
            if (startingNode != null && startingNode.Data != null) { Console.Write($"{startingNode.Data} "); }
            if (startingNode.HasLeftChild())
            {
                PreOrderTraversal(startingNode?.LeftChild);
            }
            if (startingNode != null && startingNode.HasRightChild())
            {
                PreOrderTraversal(startingNode?.RightChild);
            }
        }

        public void PreOrderTraversal() { PreOrderTraversal(Root); }
    

    private void PostOrderTraversal(SuperTreeNode<T>? root)
    {
        var startingNode = root;
        if (startingNode == null) return;

        if (startingNode.HasLeftChild())
        {
            PostOrderTraversal(startingNode?.LeftChild);
        }
        if (startingNode != null && startingNode.HasRightChild())
        {
            PostOrderTraversal(startingNode?.RightChild);
        }
        if (startingNode != null && startingNode.Data != null) { Console.Write($"{startingNode.Data} "); }
    }

    public void PostOrderTraversal() { PostOrderTraversal(Root); }
}
}
