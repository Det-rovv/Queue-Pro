namespace Queue_Pro.Domain.Abstractions;

public interface IOrderedList<T>
{
    IReadOnlyCollection<OrderedItem<T>> Items { get; }
    
    void Enqueue(T element);
    
    T Dequeue();
    
    int GetNextOrder();

    void SwapElements(int order1, int order2);
}