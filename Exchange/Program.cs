using System;

namespace Exchange
{
    //本体
    class Program
    {
        static void Main(string[] args)
        {
            var USD_JPY = new ExchangeRate("USD", "JPY");
            var EUR_JPY = new ExchangeRate("EUR", "JPY");
            var GBP_JPY = new ExchangeRate("GBP", "JPY");

            var MainMenu = new MainMenu();
            MainMenu.Show(USD_JPY, EUR_JPY, GBP_JPY);
        }
    }
}

