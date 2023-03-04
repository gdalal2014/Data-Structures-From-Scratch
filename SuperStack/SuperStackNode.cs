using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperStack
{
    public class SuperStackNode<T> where T : IComparable<T>
    {
        public T? Data { get; set; }

        public SuperStackNode<T>? Next { get; set; }
        public SuperStackNode(T? data) 
        {
            Data = data;
        }
    }
}
