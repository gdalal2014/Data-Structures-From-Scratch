using LinkedList;
using System.Security.Cryptography;

namespace Data_Structures_From_Scratch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var list = new LinkedList.LinkedList<int>(new Node<int>(rnd.Next()), new Node<int>(rnd.Next()));

            list.DisplayLinkedList();
            Console.WriteLine("Hello, World!");
        }
    }
}