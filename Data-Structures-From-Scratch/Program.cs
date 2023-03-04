using SuperBinarySearchTree;
using SuperLinkedList;
using SuperStack;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Data_Structures_From_Scratch
{
    public class Program
    {
        static void Main(string[] args)
        {
            //RunStackProtocol();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"Run Number {i}");
                RunBinarySearchTreeProtocol();
                Console.WriteLine();
            }

        }

        public static void RunStackProtocol ()
        {
            var timer = new Stopwatch();
            timer.Start();
            var rnd = new Random();
            var rndCase = new Random();
            var stack = new SuperStack<int>();

            for (long i = 0; i < 1; i++)
            {
                switch (rndCase.Next(1, 4))
                {
                    case 1:
                        stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(0, 11)));
                        Console.WriteLine($"Case 1: Loop Iteration: {i}");
                        continue;

                    case 2:
                        if (stack.Count == 0) { Console.WriteLine($"Case 2 Early Exit 1: Loop Iteration: {i}"); continue; }
                        stack.Pop();
                        if (stack.Count == 0) { Console.WriteLine($"Case 2 Early Exit 2: Loop Iteration: {i}"); continue; }
                        stack.Pop();
                        if (stack.Count == 0) { Console.WriteLine($"Case 2 Early Exit 3: Loop Iteration: {i}"); continue; }
                        stack.Pop();
                        Console.WriteLine($"Case 2 Full Iteration: Loop Iteration: {i}");
                        continue;

                    case 3:
                        if (stack.Count > 0) stack.Pop();
                        stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(0, 6)));
                        stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(5, 11)));
                        Console.WriteLine($"Case 3: Loop Iteration: {i}");
                        continue;


                    default:
                        Console.WriteLine($"Case Default: Loop Iteration: {i}");
                        continue;

                }
            }
            Console.WriteLine();
            stack.DisplayStackContents();


            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"Does {i} exist in the stack: {stack.FindFirstInstance<int>(i)}");
                Console.WriteLine($"How many times does {i} show up in the stack: {stack.CountInstance<int>(i)}");
            }

            Console.WriteLine($"Stack Count: {stack.Count}");
            timer.Stop();
            Console.WriteLine($"Total Elapsed time {timer.Elapsed}");
        }

        public static void RunBinarySearchTreeProtocol()
        {
            var timer = new Stopwatch();
            timer.Start();
            var rnd = new Random();
            var bst = new SuperBinarySearchTree<int>();
            var arrayOfKeys = new int[10];

            for (int i = 0; i < 10; i++)
            {
                var rndValue = rnd.Next(0, 100);
                arrayOfKeys[i] = rndValue;
                bst.Insert(rndValue);
            }

            Console.WriteLine("Predecessor Test:");

            for (int i = 0; i < 10; i++)
            {
                var key = arrayOfKeys[i];
                var prec = bst.InOrderPredecessor(key);
                if (prec != null && prec?.Data !=null )
                {
                    Console.WriteLine($"The predecessor of node {key} is {prec.Data}");
                }
                else
                {
                    Console.WriteLine($"The predecessor doesn't exist for node: {key}");
                }

            }

            Console.WriteLine() ;
            Console.WriteLine("Sucessor Test:");

            for (int i = 0; i < 10; i++)
            {
                var key = arrayOfKeys[i];
                var succ = bst.InOrderSuccessor(key);
                if (succ != null && succ?.Data != null)
                {
                    Console.WriteLine($"The Sucessor of node {key} is {succ.Data}");
                }
                else
                {
                    Console.WriteLine($"The Sucessor doesn't exist for node: {key}");
                }

            }

            timer.Stop();
            Console.WriteLine($"Total Elapsed time {timer.Elapsed}");
        }
    }
}