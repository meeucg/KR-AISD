namespace KR;

//доп знчение isVisited
public class Node<T>
{
    public Node<T> Next { get; set; }    
    public T Val { get; set; }
    public bool isVisited { get; set; }

    public Node(Node<T> next, T val)
    { 
        Next = next;
        Val = val;
        isVisited = false;
    }
}
