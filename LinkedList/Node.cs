using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node<T> where T : IComparable<T>
    {
        public T? Data { get; set; }

        public Node<T>? Next { get; set; }
        public Node(T? data) 
        {
            Data = data;
        }
    }
}
