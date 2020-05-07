using System;
namespace Exchange
{
    //通貨の名前、レートを保持するクラス
    class Currency
    {
        public double ExchangeRate { set; get; } = 0;
        public string NameOfCurrency { get; }

        //コンストラクター
        public Currency(string str)
        {
            this.NameOfCurrency = str;
        }

        //外貨に換算した金額を返す関数
        public double ExchangeFromJPY(double yen)
        {
            return this.ExchangeRate * yen;
        }
    }
}
