using Framework.Domain;
using Hall.Domain.Models.TallarAggrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hall.Domain.Models.ValueObjects
{
    public class Location : ValueObject<Location>
    {
        public string Address { get; }
        public string MapString { get; }

        public Location(string address, string mapString)
        {
            Address = address;
            MapString = mapString;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
  yield return Address;
            yield return MapString;        }
    }
}
