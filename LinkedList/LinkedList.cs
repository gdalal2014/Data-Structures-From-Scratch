﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedList
{
    public class LinkedList<T> where T : IComparable<T>
    {

        public Node<T>? First { get; private set; } 
        public Node<T>? Last { get; private set; }


        public LinkedList()
        {
        }
        public LinkedList(Node<T> first)
        {
            First = first;
            Last = First;
            First.Next = null;
            Last.Next = null;
        }
        public LinkedList(Node<T> first, Node<T> last) 
        {
            First = first;
            Last = last;
            First.Next = Last;
            Last.Next = null;
        }


        public void InsertAtFirst (Node<T> node)
        {
            node.Next = First;
            Last ??= First;
            First = node;            
        }

        public void DeleteAtFirst()
        {
            if (First != null && First.Next != null)
            {
                var temp = First; 
                First = First.Next;
                temp = null;
            }


        }

        public void InsertAtLast(Node<T> node) 
        {

            if (Last == null)
            {
                Last = node;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }
        }

        public void DeleteAtLast()
        {
            if (Last != null && Last != First)
            {
                if (First == null) return;
                var currentNode = First;
                var previousNode = Last;
                while (currentNode?.Next != null)
                {
                    previousNode = currentNode;
                    currentNode = currentNode?.Next;
                }

                if (currentNode?.Next == null)
                {
                    Last = previousNode;
                    Last.Next = null;
                }
            }
        }

        public void FindInstance<TU>(TU instance) where TU : IComparable<TU>
        {
            Console.WriteLine();
            if (First == null) return;
            var nodePlace = 0;
            var currentNode = First;
            var found = false;
            while (currentNode?.Next != null)
            {
                if (currentNode != null && currentNode.Data != null && instance != null && (Equals(currentNode.Data, instance))) 
                { 
                    Console.WriteLine($"{instance} was found at Position number: {nodePlace}");
                    found = true;
                
                }
                currentNode = currentNode?.Next;
                nodePlace++;
            }

            if (!found) { Console.WriteLine($"{instance} was not found in the Linked List");  }
        }

        public void DisplayLinkedList()
        {
            Console.WriteLine();
            if (First == null) return;
            var currentNode = First;
            while(currentNode?.Next != null)
            {
                Console.WriteLine(currentNode?.Data?.ToString());
                currentNode = currentNode?.Next;
            }
           if (currentNode?.Next == null && currentNode.Data != null) Console.WriteLine(currentNode?.Data?.ToString());
            Console.WriteLine("End of Linked List");
        }
    }
}
