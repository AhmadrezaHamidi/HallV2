using Framework.Domain;

namespace Hall.Domain.Models.ValueObjects
{
    public class Service : Entity<int>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Service(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}
