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
            var timer = new Stopwatch();
            timer.Start();
            RunStackProtocol();
            //RunBinarySearchTreeProtocol();
            timer.Stop();
            Console.WriteLine($"Total Elapsed time {timer.Elapsed}");

        }

        public static void RunStackProtocol()
        {
            var rnd = new Random();
            var rndCase = new Random();
            var stack = new SuperStack<int>();

            for (long i = 0; i < 1000000; i++)
            {
                switch (rndCase.Next(1, 6))
                {
                    case 1:
                        stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(0, 11)));
                        Console.WriteLine($"Case 1: Loop Iteration: {i}");
                        continue;

                    case 2:
                        if (stack.Count == 0) { Console.WriteLine($"Case 2 Early Exit 1: Loop Iteration: {i}"); continue; }
                        else { stack.Pop(); }
                        if (stack.Count == 0) { Console.WriteLine($"Case 2 Early Exit 2: Loop Iteration: {i}"); continue; }
                        else { stack.Pop(); }
                        if (stack.Count == 0) { Console.WriteLine($"Case 2 Early Exit 3: Loop Iteration: {i}"); continue; }
                        else { stack.Pop(); }
                        Console.WriteLine($"Case 2 Full Iteration: Loop Iteration: {i}");
                        continue;

                    case 3:
                        if (stack.Count > 0) stack.Pop();
                        stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(0, 6)));
                        stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(5, 11)));
                        Console.WriteLine($"Case 3: Loop Iteration: {i}");
                        continue;

                    case 4:
                        var rndCeiling = rndCase.Next(0, 11);
                        if (stack.Count == 0) { Console.WriteLine($"Case 4 Early Exit 1: Loop Iteration: {i}");
                            for (int rndCounter =0; rndCounter < rndCeiling; rndCounter++)
                            {
                                stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(0, 6)));
                                stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(5, 11)));
                            }

                            continue; }
                        else { stack.Pop(); }

                        if (stack.Count == 0) { Console.WriteLine($"Case 4 Early Exit 2: Loop Iteration: {i}"); continue; }
                        else { stack.Pop(); }
                        for (int rndCounter = 0; rndCounter < rndCeiling; rndCounter++)
                        {
                            stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(0, 6)));
                            stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(5, 11)));
                        }
                        if (stack.Count == 0) { Console.WriteLine($"Case 4 Early Exit 3: Loop Iteration: {i}");
                            for (int rndCounter = 0; rndCounter < rndCeiling; rndCounter++)
                            {
                                stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(0, 6)));
                                stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(5, 11)));
                            }
                            continue; }
                        else { stack.Pop(); }
                        for (int rndCounter = 0; rndCounter < rndCeiling; rndCounter++)
                        {
                            stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(0, 6)));
                            stack.Push(new SuperStack.SuperStackNode<int>(rnd.Next(5, 11)));
                        }
                        Console.WriteLine($"Case 4 Full Iteration: Loop Iteration: {i}");
                        continue;

                    case 5:
                        var randomCeiling = rnd.Next(0, (int)(stack?.Count));
                        for (int rndCounter = 0; rndCounter < randomCeiling; rndCounter++)
                        {
                            stack.Pop();
                        }
                        continue;


                    default:
                        Console.WriteLine($"Case Default: Loop Iteration: {i}");
                        continue;

                }
            }
            Console.WriteLine();
            Console.WriteLine("Stack Contents: ");
            stack.DisplayStackContents();
            Console.WriteLine();

            Console.WriteLine("How many of the following Exist in the Stack: ");
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"Does {i} exist in the stack: {stack.FindFirstInstance<int>(i)}");
                Console.WriteLine($"How many times does {i} show up in the stack: {stack.CountInstance<int>(i)}");
            }
            Console.WriteLine();

            Console.WriteLine($"Stack Count: {stack.Count}");
            Console.WriteLine();
        }

        public static void RunBinarySearchTreeProtocol()
        {
        for (int runValue = 0; runValue < 25; runValue++)
        {
            Console.WriteLine($"Run Number {runValue}");
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
            Console.WriteLine();
            Console.WriteLine("Delete Interative Test: ");
            var insert = rnd.Next(0, 100);
            var insertValue = bst.Insert(insert);
            Console.WriteLine($"Inserting {insert}: Succesful Insert: {insertValue}");
            Console.WriteLine($"Pre Order Traversal is the following Post Insertion: ");
            bst.PreOrderTraversal();
            Console.WriteLine();
            Console.WriteLine($"Inorder Traversal is the following Post Insertion: ");
            bst.InOrderTraversal();
            Console.WriteLine();
            Console.WriteLine($"Post Order Traversal is the following Post Insertion: ");
            bst.PostOrderTraversal();
            Console.WriteLine();
            Console.WriteLine();
            var deleteValue = bst.DeleteIterative(insert);
            Console.WriteLine($"Deleting {insert}: Succesful Delete: {deleteValue}");
            Console.WriteLine($"Pre Order Traversal is the following Post Insertion: ");
            bst.PreOrderTraversal();
            Console.WriteLine();
            Console.WriteLine($"Inorder Traversal is the following Post Insertion: ");
            bst.InOrderTraversal();
            Console.WriteLine();
            Console.WriteLine($"Post Order Traversal is the following Post Insertion: ");
            bst.PostOrderTraversal();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Delete Recursive Test: ");
            var insert2 = rnd.Next(0, 100);
            var insertValue2 = bst.Insert(insert2);
            Console.WriteLine($"Inserting {insert2}: Succesful Insert: {insertValue2}");
            Console.WriteLine($"Pre Order Traversal is the following Post Insertion: ");
            bst.PreOrderTraversal();
            Console.WriteLine();
            Console.WriteLine($"Inorder Traversal is the following Post Insertion: ");
            bst.InOrderTraversal();
            Console.WriteLine();
            Console.WriteLine($"Post Order Traversal is the following Post Insertion: ");
            bst.PostOrderTraversal();
            Console.WriteLine();
            Console.WriteLine();
            var deleteValue2 = bst.Delete(insert2);
            Console.WriteLine($"Deleting {insert2}: Succesful Delete: {deleteValue2}");
            Console.WriteLine($"Pre Order Traversal is the following Post Insertion: ");
            bst.PreOrderTraversal();
            Console.WriteLine();
            Console.WriteLine($"Inorder Traversal is the following Post Insertion: ");
            bst.InOrderTraversal();
            Console.WriteLine();
            Console.WriteLine($"Post Order Traversal is the following Post Insertion: ");
            bst.PostOrderTraversal();
            Console.WriteLine();
            Console.WriteLine();
            }
        }
    }
}