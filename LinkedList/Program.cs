namespace SuperLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var node1 = new SuperLinkedListNode<int>(1);
            var node2 = new SuperLinkedListNode<int>(2);
            var node3 = new SuperLinkedListNode<int>(3);
            var experimentalLinkedList = new SuperLinkedList<int>(node1);

            experimentalLinkedList.InsertAtFirst(node2);
            experimentalLinkedList.InsertAtFirst(node3);

            experimentalLinkedList.InsertAtFirst(new SuperLinkedListNode<int>(12));
            experimentalLinkedList.InsertAtFirst(new SuperLinkedListNode<int>(23));
            experimentalLinkedList.DeleteAtFirst();
            experimentalLinkedList.InsertAtFirst(new SuperLinkedListNode<int>(14));
            experimentalLinkedList.InsertAtLast(new SuperLinkedListNode<int>(300));
            experimentalLinkedList.InsertAtLast(new SuperLinkedListNode<int>(500));
            experimentalLinkedList.InsertAtFirst(new SuperLinkedListNode<int>(30489));
            experimentalLinkedList.DeleteAtLast();
            experimentalLinkedList.FindInstance(14);
            experimentalLinkedList.FindInstance(322);

            experimentalLinkedList.DisplayLinkedList();

            Console.WriteLine($"The Value of the First Node is {experimentalLinkedList?.First?.Data}");
            Console.WriteLine($"The Value of the Last Node is {experimentalLinkedList?.Last?.Data}");

        }
    }
}