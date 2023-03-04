using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SuperLinkedList
{
    public class SuperLinkedList<T> where T : IComparable<T>
    {

        public SuperLinkedListNode<T>? First { get; private set; } 
        public SuperLinkedListNode<T>? Last { get; private set; }


        public SuperLinkedList()
        {
        }
        public SuperLinkedList(SuperLinkedListNode<T> first)
        {
            First = first;
            Last = First;
            First.Next = null;
            Last.Next = null;
        }
        public SuperLinkedList(SuperLinkedListNode<T> first, SuperLinkedListNode<T> last) 
        {
            First = first;
            Last = last;
            First.Next = Last;
            Last.Next = null;
        }


        public void InsertAtFirst (SuperLinkedListNode<T> node)
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

        public void InsertAtLast(SuperLinkedListNode<T> node) 
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
            if (First == null) return;
            var currentNode = First;
            while(currentNode!= null)
            {
                Console.WriteLine(currentNode?.Data?.ToString());
                currentNode = currentNode?.Next;
            }
            Console.WriteLine("End of Linked List");
        }
    }
}
