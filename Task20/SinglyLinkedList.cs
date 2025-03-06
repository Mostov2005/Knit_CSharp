class SinglyLinkedList
{
    private class Node
    {
        public int Data;
        public Node Next;
        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head, tail, temp;

    public void Initialize(int data)
    {
        head = new Node(data);
        tail = head;
    }

    public void AddToTail(int data)
    {
        if (head == null)
        {
            Initialize(data);
            return;
        }

        Node newNode = new Node(data);
        tail.Next = newNode;
        tail = newNode;
    }

    public int RemoveHead()
    {
        if (head == null) throw new InvalidOperationException("Список пуст");

        int value = head.Data;
        head = head.Next;
        if (head == null) tail = null;
        return value;
    }

    public void PrintList()
    {
        temp = head;
        while (temp != null)
        {
            Console.Write(temp.Data);
            temp = temp.Next;
            if (temp != null)
            {
                Console.Write(", ");
            }
        }
        System.Console.WriteLine();
    }

    public void RemoveAfterValue(int x) // Вариант 5 - После каждого элемента со значением х удалить один элемент
    {
        temp = head;
        while (temp != null && temp.Next != null)
        {
            if (temp.Data == x)
            {
                temp.Next = temp.Next.Next;
                if (temp.Next == null) tail = temp;
            }
            temp = temp.Next;
        }
    }
}