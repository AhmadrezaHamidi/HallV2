using Framework.Domain;

namespace Hall.Domain.Models.ValueObjects
{
    public class TallarComment : Entity<int>
    {
        public int Id { get; }
        public int TallarId { get; }
        public string Comment { get; }

        public TallarComment(int id, int tallarId, string comment)
        {
            Id = id;
            TallarId = tallarId;
            Comment = comment;
        }
    }

}
