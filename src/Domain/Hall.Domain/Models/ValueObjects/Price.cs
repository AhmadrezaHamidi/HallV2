using Framework.Domain;

namespace Hall.Domain.Models.ValueObjects
{
    public class Price : ValueObject<Price>
    {
        public decimal InitialAmountInDollars { get; }
        public string Currency { get; }

        public Price(decimal initialAmountInDollars, string currency)
        {
            InitialAmountInDollars = initialAmountInDollars;
            Currency = currency;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            throw new NotImplementedException();
        }
    }

}
