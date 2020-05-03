using System;
namespace Exchange
{
    //為替レート登録画面
    static class RegistrationMenu
    {
        public static void show(params Currency[] Currencies)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("通貨換算アプリケーション");
                Console.WriteLine("為替レート登録画面");
                for (int i = 0; i < Currencies.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Currencies[i].NameOfCurrency}/JPY");
                }
                Console.WriteLine($"{Currencies.Length + 1}. メインメニューに戻る");
                Console.WriteLine();
                Console.Write("登録したい通貨を入力してください(数値):");

                var input = Console.ReadLine();
                int number;
                if (!int.TryParse(input, out number))
                {
                    ErrorMessage.show();
                    continue;
                }
                if (number == Currencies.Length + 1)
                {
                    break;
                }
                while (loop)
                {
                    try
                    {
                        Console.Write($"レート{Currencies[number - 1].NameOfCurrency}/JPYを入力してください:");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        ErrorMessage.show();
                        break;
                    }
                    input = Console.ReadLine();
                    double r;
                    if (!double.TryParse(input, out r))
                    {
                        ErrorMessage.show();
                        continue;
                    }
                    Currencies[number - 1].ExchangeRate = r;
                    Console.WriteLine();
                    Console.WriteLine($"登録レート: {Currencies[number - 1].ExchangeRate} {Currencies[number - 1].NameOfCurrency}/JPY");
                    Console.Write("Enterで戻る");
                    Console.ReadLine();
                    break;
                }

            }
        }
    }
}
