using System;
namespace Exchange
{
    //為替レート登録画面
    static class RegistrationMenu
    {
        public static void Show(params Currency[] Currencies)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("通貨換算アプリケーション");
                Console.WriteLine("為替レート登録画面");
                //扱う通貨を順に表示
                for (int i = 0; i < Currencies.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Currencies[i].NameOfCurrency}/JPY");
                }
                Console.WriteLine($"{Currencies.Length + 1}. メインメニューに戻る");
                Console.WriteLine();
                Console.Write("登録したい通貨を入力してください(数値):");
                　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
                //入力
                var input = Console.ReadLine();
                int number;//わかりやすい名前に、何番目の通貨か？

                //入力値が整数値でない場合エラー
                if (!int.TryParse(input, out number))
                {
                    ErrorMessage.Show();//エラーの表記変える
                    continue;
                }

                //メインメニューに戻る
                if (number == Currencies.Length + 1)
                {
                    break;
                }

                //通貨登録
                while (loop)
                {
                    //メニューにない番号を選んでいないかチェック
                    try
                    {
                        Console.Write($"レート{Currencies[number - 1].NameOfCurrency}/JPYを入力してください:");　//難しく書きすぎ素直に
                    }
                    catch (IndexOutOfRangeException)
                    {
                        ErrorMessage.Show();
                        break;
                    }

                    //入力
                    input = Console.ReadLine();
                    double rate;

                    //入力が数値でない場合エラー
                    if (!double.TryParse(input, out rate))
                    {
                        ErrorMessage.Show();//素直に書くcw使う
                        continue;
                    }

                    Currencies[number - 1].ExchangeRate = rate;
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
