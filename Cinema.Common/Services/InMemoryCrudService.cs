namespace Cinema.Common.Services;

public class InMemoryCrudService<T> : ICrudService<T> where T : class
{
    private readonly Dictionary<Guid, T> _storage = new();

    public void Create(T element)
    {
        var idProp = element.GetType().GetProperty("Id")
            ?? throw new Exception("Element does not have Id property");

        var id = (Guid)(idProp.GetValue(element) ?? throw new Exception("Id is null"));
        _storage[id] = element;
    }

    public T Read(Guid id) => _storage[id];

    public IEnumerable<T> ReadAll() => _storage.Values;

    public void Update(T element)
    {
        var idProp = element.GetType().GetProperty("Id")
            ?? throw new Exception("Element does not have Id property");

        var id = (Guid)(idProp.GetValue(element) ?? throw new Exception("Id is null"));
        _storage[id] = element;
    }

    public void Remove(Guid id) => _storage.Remove(id);
}
