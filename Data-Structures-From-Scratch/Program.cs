using SuperLinkedList;
using System.Security.Cryptography;

namespace Data_Structures_From_Scratch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var list = new SuperLinkedList<int>(new SuperNode<int>(rnd.Next()), new SuperNode<int>(rnd.Next()));
            list.DisplayLinkedList();
        }
    }
}