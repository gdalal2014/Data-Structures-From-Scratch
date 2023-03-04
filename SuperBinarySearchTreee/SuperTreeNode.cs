using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBinarySearchTree;

public class SuperTreeNode<T> where T : IComparable<T>
{

    public T? Data { get; private set; }
    public SuperTreeNode<T>? LeftChild { get; private set; }
    public SuperTreeNode<T>? RightChild { get; private set; }
    public SuperTreeNode(T data) 
    {
        Data = data;  
    }

    public SuperTreeNode()
    {
        Data = default; LeftChild = null; RightChild = null;
    }

    public bool SetLeftChild (SuperTreeNode<T> node)
    {
        if (node == null || LeftChild != null) return false;
        LeftChild = node;
        return true;
    }

    public bool SetRightChild(SuperTreeNode<T> node)
    {
        if (node == null || RightChild != null) return false;
        RightChild = node;
        return true;
    }

    public bool RemoveLeftChild()
    {
        if (LeftChild == null) return true;
        LeftChild = null;
        return true;
    }

    public bool RemoveRightChild()
    {
        if (RightChild == null) return true;
        RightChild = null;
        return true;
    }
}
