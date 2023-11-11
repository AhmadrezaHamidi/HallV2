namespace Framework.Domain;

public abstract class Id<T>
{
    public T Value { get; private set; }
    protected Id(T value)
    {
        Value = value;
    }
}