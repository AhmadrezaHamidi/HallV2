namespace Framework.Domain;

public class Entity<TKey>
{
    public TKey Id { get; protected set; }
    public DateTime CreatedDateTime { get; set; }=DateTime.Now;
}