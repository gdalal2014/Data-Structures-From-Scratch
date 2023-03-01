using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLinkedList
{
    public class SuperNode<T> where T : IComparable<T>
    {
        public T? Data { get; set; }

        public SuperNode<T>? Next { get; set; }
        public SuperNode(T? data) 
        {
            Data = data;
        }
    }
}
