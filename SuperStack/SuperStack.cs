using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStack
{
    public class SuperStack<T> where T : IComparable<T>
    {
        public SuperStackNode<T>? First { get; private set; }
        public int? Count { get; private set; }

        public SuperStack() {
            First = null;
            Count = 0;
        }
        public SuperStack(SuperStackNode<T>? first)
        {
            Count = 0;
            if (first == null) throw new ArgumentNullException(nameof(first));
            First = first;
            First.Next = null;
            Count++;
        }

        public void Push(SuperStackNode<T>? superNode)
        {
            if (superNode == null) throw new ArgumentNullException(nameof(superNode));
            var nextNode = First;
            First = superNode;
            First.Next = nextNode;
            Count++;
        }

        public SuperStackNode<T> Pop()
        {
            if (First == null) throw new ArgumentNullException(nameof(First));
            var first = First;
            var nextNode = First.Next;
            First = nextNode;
            Count--;
            return first;
        }

        public SuperStackNode<T> Peek()
        {
            if (First == null) throw new ArgumentNullException(nameof(First));
            return First;

        }

        public bool FindFirstInstance<TU> (TU instance) where TU : IComparable<TU>
        {
            if (First == null) throw new ArgumentNullException(nameof(First));

            var currentNode = First;
            while (currentNode != null)
            {
                if (currentNode != null && currentNode.Data != null && instance != null && Equals(currentNode.Data, instance)) return true;
                currentNode = currentNode?.Next;
            }

            return false;
            
        }

        public int CountInstance<TU> (TU instance) where TU: IComparable<TU>
        {
            var count = 0;
            if (First == null) throw new ArgumentNullException(nameof(First));
            var currentNode = First;
            while (currentNode != null)
            {
                if (currentNode != null && currentNode.Data != null && instance != null && Equals(currentNode.Data, instance)) { count++; }
                currentNode = currentNode?.Next;
            }

            return count;
        }

        public void DisplayStackContents()
        {
            if (First == null) throw new ArgumentNullException(nameof(First));
            var currentNode = First;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode?.Data?.ToString());
                currentNode = currentNode?.Next;
            } 
            Console.WriteLine("End of Stack");
        }
    }
}
