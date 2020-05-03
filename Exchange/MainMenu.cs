using System;
namespace Exchange
{
    //メインメニュー
    static class MainMenu
    {
        public static void show(params Currency[] Currencies)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("通貨換算アプリケーション");
                Console.WriteLine();
                Console.WriteLine("メインメニュー");
                Console.WriteLine("1. 為替レート登録");
                Console.WriteLine("2. 通貨換算");
                Console.WriteLine("3. 終了");
                Console.WriteLine();
                Console.Write("入力:");

                var input = Console.ReadLine();
                int number;
                if (!int.TryParse(input, out number))
                {
                    ErrorMessage.show();
                    continue;
                }

                switch (number)
                {
                    case 1:
                        RegistrationMenu.show(Currencies);
                        continue;
                    case 2:
                        ExchangeMenu.show(Currencies);
                        continue;
                    case 3:
                        return;
                }
                ErrorMessage.show();
            }
        }
    }
}
