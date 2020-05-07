using System;
namespace Exchange
{
    //通貨換算画面
    static class ExchangeMenu
    {
        public static void Show(params Currency[] Currencies)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("通貨換算アプリケーション");
                Console.WriteLine("通貨換算画面");
                //扱う通貨を順に表示
                for (int i = 0; i < Currencies.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Currencies[i].NameOfCurrency}/JPY");
                }
                Console.WriteLine($"{Currencies.Length + 1}. メインメニューに戻る");
                Console.WriteLine();
                Console.Write("換算したい通貨を入力してください(数値):");

                //入力
                var input = Console.ReadLine();
                int number;

                //入力値が整数値でない場合エラー
                if (!int.TryParse(input, out number))
                {
                    ErrorMessage.Show();
                    continue;
                }

                //メインメニューに戻る
                if (number == Currencies.Length + 1)
                {
                    break;
                }

                //通貨換算
                while (loop)
                {
                    Console.WriteLine();

                    //メニューにない番号を選んでいないかチェック
                    try
                    {
                        Console.WriteLine($"{Currencies[number - 1].NameOfCurrency}に換算");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        ErrorMessage.Show();
                        break;
                    }

                    //レートを登録していないと思われる通貨を選択した場合、警告を表示
                    if (Currencies[number - 1].ExchangeRate == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("##警告## 選択した通貨の換算レートが登録されていない可能性があります。");
                        Console.WriteLine($"(換算レート {Currencies[number - 1].ExchangeRate} {Currencies[number - 1].NameOfCurrency}/JPY)");
                    }

                    //入力
                    Console.WriteLine();
                    Console.Write("金額を入力してください(円):");
                    input = Console.ReadLine();
                    double yen;

                    //入力値が数値でない場合、エラー
                    if (!double.TryParse(input, out yen))
                    {
                        ErrorMessage.Show();
                        continue;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"{yen}円は {Currencies[number - 1].ExchangeFromJPY(yen)} {Currencies[number - 1].NameOfCurrency} " +
                                      $"(換算レート {Currencies[number - 1].ExchangeRate} {Currencies[number - 1].NameOfCurrency}/JPY)");
                    Console.Write("Enterで戻る");
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
