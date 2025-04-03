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

    public void AddToTail(int value)
    {
        if (head == null)
        {
            Initialize(value);
            return;
        }

        Node newNode = new Node(value); // Создаётся объект
        tail.Next = newNode; // В текущем хвосте создаётся ссылка на следующий объект
        tail = newNode; // новый хвост
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


    public void RemoveDuplicates() // Вариант 15
    {
        if (head == null) return;

        HashSet<int> seen = new HashSet<int>();
        Node current = head;
        seen.Add(current.Data);

        while (current.Next != null)
        {
            if (seen.Contains(current.Next.Data))
            {
                current.Next = current.Next.Next;
                if (current.Next == null) tail = current;
            }
            else
            {
                seen.Add(current.Next.Data);
                current = current.Next;
            }
        }
    }

}