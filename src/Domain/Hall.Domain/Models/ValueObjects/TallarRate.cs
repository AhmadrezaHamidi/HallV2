using Framework.Domain;

namespace Hall.Domain.Models.ValueObjects
{
    public class TallarRate : ValueObject<TallarRate>
    {
        public int RateCount { get; }
        public int RateSum { get; }
        public int AverageRate { get; }

        public TallarRate(int rateCount, int rateSum, int averageRate)
        {
            RateCount = rateCount;
            RateSum = rateSum;
            AverageRate = averageRate;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            throw new NotImplementedException();
        }
    }

}
