namespace Framework.Domain;


public abstract class ValueObject<T> where T : ValueObject<T>
{
    protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();

    public override bool Equals(object other) => this.Equals(other as T);

    public virtual bool Equals(T other) => !((ValueObject<T>) other == (ValueObject<T>) null) && this.GetAttributesToIncludeInEqualityCheck().SequenceEqual<object>(other.GetAttributesToIncludeInEqualityCheck());

    public static bool operator ==(ValueObject<T> left, ValueObject<T> right) => object.Equals((object) left, (object) right);

    public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !(left == right);

    public override int GetHashCode()
    {
        int hashCode = 17;
        foreach (object obj in this.GetAttributesToIncludeInEqualityCheck())
            hashCode = hashCode * 31 + (obj == null ? 0 : obj.GetHashCode());
        return hashCode;
    }
}