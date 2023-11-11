using Framework.Domain;

namespace Hall.Domain.Models.ValueObjects
{
    public class TotalarType : Entity<int>
    {
        public int Id { get; }
        public string Name { get; }

        public TotalarType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}
