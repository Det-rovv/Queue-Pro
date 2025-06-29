using Queue_Pro.Domain.Abstractions;

namespace Queue_Pro.Domain.Models;

public class UserQueue : IOrderedList<User>
{
    private IList<OrderedItem<User>> _users;
    
    public Guid Id { get; }
    
    public User Headman { get; }
    
    public IReadOnlyCollection<OrderedItem<User>> Items => _users.AsReadOnly();
    
    public string Title { get; }
    
    public TimeOnly JoinWindowStartTime { get; }
    
    public TimeOnly JoinWindowEndTime { get; }

    public UserQueue(Guid id, User headman, string title, TimeOnly joinWindowStartTime,
        TimeOnly joinWindowsEndTime, IList<OrderedItem<User>> users)
    {
        if (!IsCorrectQueue(users.ToList()))
        {
            throw new ArgumentException("Invalid queue order: expected contiguous Orders [1..N]");
        }
        
        Id = id;
        Headman = headman;
        Title = title;
        JoinWindowStartTime = joinWindowStartTime;
        JoinWindowEndTime = joinWindowsEndTime;
        _users = users;
    }
    
    protected UserQueue() { }
    
    public void Enqueue(User element)
    {
        var orderedUser = new OrderedItem<User>(element, GetNextOrder());
        _users.Add(orderedUser);
    }

    public User Dequeue()
    {
        return RemoveItem(1);
    }

    public int GetNextOrder()
    {
        return _users.Count + 1;
    }

    public void SwapElements(int order1, int order2)
    {
        var element1 = _users.FirstOrDefault(i => i.Order == order1);
        var element2 = _users.FirstOrDefault(i => i.Order == order2);
        
        if (element1 is null || element2 is null) throw new ArgumentNullException("Some of these elements does not exist");
        
        element1.Order = order2;
        element2.Order = order1;
    }
    
    private bool IsCorrectQueue<T>(IList<OrderedItem<T>> orderables)
    {
        var ordered = orderables.OrderBy(o => o).ToList();
        
        for (int i = 1; i <= ordered.Count(); i++)
        {
            if (ordered[i - 1].Order != i) return false;
        }
        
        return true;
    }
    
    private User RemoveItem(int order)
    {
        var toRemove = _users.FirstOrDefault(i => i.Order == order);
        if (toRemove is null) throw new InvalidOperationException($"No item with order: {order}");
        
        _users.Remove(toRemove);
        foreach (var item in _users.Where(i => i.Order > order))
        {
            item.Order--;
        }
        
        return toRemove.Item;
    }
}