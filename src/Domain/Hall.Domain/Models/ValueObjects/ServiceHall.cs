using Framework.Domain;

namespace Hall.Domain.Models.ValueObjects
{
    public class ServiceHall : Entity<int>
    {
        public int Id { get; }
        public string Name { get; }

        public ServiceHall(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

}
