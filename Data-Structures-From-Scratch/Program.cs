using SuperLinkedList;
using SuperStack;
using System.Security.Cryptography;

namespace Data_Structures_From_Scratch
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var list = new SuperLinkedList<int>(new SuperLinkedList.SuperNode<int>(rnd.Next()), new SuperLinkedList.SuperNode<int>(rnd.Next()));
            list.DisplayLinkedList();
            Console.WriteLine();
            var stack = new SuperStack<int>(new SuperStack.SuperNode<int>(rnd.Next()));
            stack.Push(new SuperStack.SuperNode<int>(rnd.Next()));
            Console.WriteLine(stack.Pop().Data.ToString());
            stack.Push(new SuperStack.SuperNode<int>(rnd.Next()));
            stack.Push(new SuperStack.SuperNode<int>(rnd.Next()));
            stack.Push(new SuperStack.SuperNode<int>(rnd.Next()));
            Console.WriteLine(stack.Pop().Data.ToString());
            stack.Push(new SuperStack.SuperNode<int>(rnd.Next()));
            

            Console.WriteLine($"Stack Count: {stack.Count}");
            Console.WriteLine();
            stack.DisplayStackContents();
        }
    }
}