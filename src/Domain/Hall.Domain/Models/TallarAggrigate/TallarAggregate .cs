using Framework.Domain;
using Hall.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hall.Domain.Models.TallarAggrigate
{
    public class TallarAggregate : AggregateRoot<Guid>
    {
        public Guid Id { get; }
        public int Capacity { get; private set; }
        public Location TallarAddress { get; private set; }
        public Price Price { get; private set; }
        public TotalarType TotalarType { get; private set; }
        public List<Service> Services { get; private set; }
        public List<TallarRate> Rates { get; private set; }
        public List<TallarComment> Comments { get; private set; }

        public TallarAggregate(Guid id, int capacity, Location tallarAddress, Price price,
            TotalarType totalarType)
        {
            Id = id;
            Capacity = capacity;
            TallarAddress = tallarAddress;
            Price = price;
            TotalarType = totalarType;
            Services = new List<Service>();
            Rates = new List<TallarRate>();
            Comments = new List<TallarComment>();
        }

        public void ChangeCapacity(int newCapacity)
        {
            Capacity = newCapacity;
        }

        public void AddService(Service service)
        {
            Services.Add(service);
        }

        public void AddRate(TallarRate rate)
        {
            Rates.Add(rate);
        }

        public void AddComment(TallarComment comment)
        {
            Comments.Add(comment);
        }
    }

}
