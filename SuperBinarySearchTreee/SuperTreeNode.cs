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

    public void SetLeftChild (SuperTreeNode<T>? node)
    {
        LeftChild = node;
    }

    public void SetData(T data) => this.Data = data;

    public void SetRightChild(SuperTreeNode<T>? node)
    {
        RightChild = node;
    }


    public bool HasLeftChild()
    {
        if(LeftChild != null) return true;
        return false;
    }

    public bool HasRightChild()
    {
        if (RightChild != null) return true;
        return false;
    }
}
