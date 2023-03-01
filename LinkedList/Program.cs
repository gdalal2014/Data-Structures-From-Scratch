namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);
            var experimentalLinkedList = new LinkedList<int>(node1);

            experimentalLinkedList.InsertAtFirst(node2);
            experimentalLinkedList.InsertAtFirst(node3);

            experimentalLinkedList.InsertAtFirst(new Node<int>(12));
            experimentalLinkedList.InsertAtFirst(new Node<int>(23));
            experimentalLinkedList.DeleteAtFirst();
            experimentalLinkedList.InsertAtFirst(new Node<int>(14));
            experimentalLinkedList.InsertAtLast(new Node<int>(300));
            experimentalLinkedList.InsertAtLast(new Node<int>(500));
            experimentalLinkedList.InsertAtFirst(new Node<int>(30489));
            experimentalLinkedList.DeleteAtLast();
            experimentalLinkedList.FindInstance(14);
            experimentalLinkedList.FindInstance(322);

            experimentalLinkedList.DisplayLinkedList();

            Console.WriteLine($"The Value of the First Node is {experimentalLinkedList?.First?.Data}");
            Console.WriteLine($"The Value of the Last Node is {experimentalLinkedList?.Last?.Data}");

        }
    }
}