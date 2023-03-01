using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStack
{
    public class SuperStack<T> where T : IComparable<T>
    {
        public SuperNode<T>? First { get; private set; }
        public int? Count { get; private set; }

        public SuperStack() { }
        public SuperStack(SuperNode<T>? first)
        {
            Count = 0;
            if (first == null) throw new ArgumentNullException(nameof(first));
            First = first;
            First.Next = null;
            Count++;
        }

        public void Push(SuperNode<T>? superNode)
        {
            if (superNode == null) throw new ArgumentNullException(nameof(superNode));
            var nextNode = First;
            First = superNode;
            First.Next = nextNode;
            Count++;
        }

        public SuperNode<T> Pop()
        {
            if (First == null) throw new ArgumentNullException(nameof(First));
            var first = First;
            var nextNode = First.Next;
            First = nextNode;
            Count--;
            return first;
        }

        public SuperNode<T> Peek()
        {
            if (First == null) throw new ArgumentNullException(nameof(First));
            return First;

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
