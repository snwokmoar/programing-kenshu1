using System;

namespace Exchange
{
    //本体
    class Program
    {
        static void Main(string[] args)
        {
            //ここに通貨を追加すれば、扱える通貨が自動で増えます。他の部分の書き換えは必要ありません。
            Currency USD = new Currency("USD");
            Currency EUR = new Currency("EUR");
            Currency GBP = new Currency("GBP");
            //Currency XBT = new Currency("XBT");   //例
            MainMenu.Show(USD, EUR, GBP/*, XBT*/);
        }
    }
}

