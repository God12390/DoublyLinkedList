using System.Diagnostics.CodeAnalysis;

public class Node
{
    public char Data { get; set; }
    public Node Previous { get; set; }
    public Node Next { get; set; }

    public Node(char data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}
public class LinkedList
{
    public Node Head { get; set; }
    public Node Tail { get; set; } 
    private int CountOfElements { get; set; }

    public int FindFirstEntry()
    {
        for (int i = 0; i < CountOfElements; i++)
        {
            if (this[i] == '№')
                return i;
        }
        return -1;
    }

    public int CountElementWithOddIndx()
    {
        int sum = 0;
        for (int i = 0; i < CountOfElements; i++)
        {
            if (i % 2 != 0)
                sum += Convert.ToInt32(this[i]);
        }
        return sum;
    }

    public LinkedList GetNewLinkedList(int value)
    {
        LinkedList newLinkedList = new LinkedList();
        Node temp = Head;
        while (temp != null)
        {
            if (Convert.ToInt32(temp.Data) > value)
            {
                newLinkedList.Add(temp.Data);
            }
            temp = temp.Next;
        }
        return newLinkedList;
    }
    public void RemoveElementsThatGreaterThanAvarage()
    {
        int average = GetAvarageValue();

        Node current = Head;
        while (current != null)
        {
            Node nextNode = current.Next; // Зберігаємо посилання на наступний вузол перед видаленням поточного

            if (Convert.ToInt32(current.Data) > average)
            {
                Remove(current); // Видаляємо поточний вузол, якщо його значення більше за середнє
            }
            current = nextNode; // Переходимо до наступного вузла
        }
    }
    public char this[int index]
    {
        get
        {
            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                if (current == null) 
                {
                    throw new IndexOutOfRangeException();
                }
                current = current.Next;
            }
            return current.Data;
        }
        set
        {
            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                if (current == null)
                {
                    throw new IndexOutOfRangeException();
                }
                current = current.Next;
            }
            current.Data = value;
        }
    }
    public void PrintList()
    {
        Node element = Head;
        while (element != null)
        {
            Console.Write(element.Data + " ");
            element = element.Next;
        }
    }



    public int GetAvarageValue() 
    {
        int avarage = 0;
        for (int i = 0; i < CountOfElements; i++)
        {
            avarage += this[i];
        }
        return avarage / CountOfElements;
    }
    public void Remove(Node node)
    {
        if (node == Head){
            Head = node.Next;
        }
        if (node == Tail){
            Tail = node.Previous;
        }
        if (node.Previous != null){
            node.Previous.Next = node.Next;
        }
        if (node.Next != null){
            node.Next.Previous = node.Previous;
        }
        CountOfElements--;
    }
    public void Add(char data)
    {
        Node element = new Node(data);
        if (Head == null)
        {
            Head = element;
            Tail = element;
        }
        else
        {
            Tail.Next = element;
            element.Previous = Tail;
            Tail = element;
        }
        CountOfElements++;
    }

}

class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();
        list.Add('1');
        list.Add('2');
        list.Add('3');
        list.Add('4');
        list.Add('№');
        list.Add('6');
        list.Add('7');
        list.Add('8');
        list.PrintList();
        Console.WriteLine("Перше входження: " + list.FindFirstEntry());
        list.PrintList();

    }
}