using System;
namespace Exchange
{
    //通貨の名前、レートを保持するクラス
    class Currency
    {
        private double exchangeRate = 0;
        private readonly string nameOfCurrency;

        //コンストラクター
        public Currency(string str)
        {
            nameOfCurrency = str;
        }

        public double ExchangeRate
        {
            set { this.exchangeRate = value; }
            get { return this.exchangeRate; }
        }
        public string NameOfCurrency
        {
            get { return this.nameOfCurrency; }
        }

        public double ExchangeFromJPY(double yen)
        {
            return this.ExchangeRate * yen;
        }
    }
}
