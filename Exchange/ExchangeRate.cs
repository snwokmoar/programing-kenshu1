using System;
namespace Exchange
{
    class ExchangeRate
    {
        public double Rate { set; get; } = 0;
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
