using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLinkedList
{
    public class SuperLinkedListNode<T> where T : IComparable<T>
    {
        public T? Data { get; set; }

        public SuperLinkedListNode<T>? Next { get; set; }
        public SuperLinkedListNode(T? data) 
        {
            Data = data;
        }
    }
}
