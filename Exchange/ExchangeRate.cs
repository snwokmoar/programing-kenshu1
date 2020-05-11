using System;
namespace Exchange
{
    public class ExchangeRate
    {
        public double? Rate { set; get; } = null;
        public string NumeratorOfRate { get; }
        public string DenominatorOfRate { get; }

        //コンストラクター
        public ExchangeRate(string numerator, string denominator)
        {
            this.NumeratorOfRate = numerator;
            this.DenominatorOfRate = denominator;
        }
    }

}
