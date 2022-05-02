using System;
using tama.Domain.BaseDomain;

namespace tama.Domain.Entity
{
    public class TransActionEntity : BaseDomainEntity 
    {
        public TransActionEntity(string userId, string seryalNumber, int cost)
        {
            Id = Guid.NewGuid().ToString();
            IsDeleted = false;
            CreateAt = DateTime.Now;
            UserId = userId;
            SeryalNumber = seryalNumber;
            Cost = cost;
        }

        public string UserId { get; set; }
        public string SeryalNumber { get; set; }
        public int Cost { get; set; }
    }
}