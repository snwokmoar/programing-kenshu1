using System;
namespace Exchange
{
    //メインメニュー
    class MainMenu : IMenu
    {
        void IMenu.Show()
        {
            Show();
        }

        public static void Show()
        {
            bool loop = true;
            while (loop)   //true
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

                //入力値が整数値でない場合エラー
                if (!int.TryParse(input, out number))
                {
                    ErrorMessage.Show();
                    continue;
                }

                switch (number)
                {
                    case 1:
                        RegistrationMenu.Show(Currencies);
                        continue;
                    case 2:
                        ExchangeMenu.Show(Currencies);
                        continue;
                    case 3:
                        return;
                }
                //どのケースにも当てはまらない場合、エラーを返す。
                ErrorMessage.Show();
            }
        }
    }
}
