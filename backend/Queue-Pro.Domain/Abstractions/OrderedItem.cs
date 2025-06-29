namespace Queue_Pro.Domain.Abstractions;

public class OrderedItem<T>
{
    public OrderedItem(T item, int order)
    {
        Item = item;
        Order = order;
    }
    
    public OrderedItem() { }
    
    public T Item { get; set; }
    public int Order { get; set; }
}