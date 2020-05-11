using System;
namespace Exchange
{ 
    class RegistrationMenu : IMenu
    {
        //為替レート登録画面
        public void Show(params ExchangeRate[] ListOfRate)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("通貨換算アプリケーション");
                Console.WriteLine();
                Console.WriteLine("為替レート登録画面");
                //扱う通貨を順に表示
                int count = 1;
                foreach (ExchangeRate rate in ListOfRate)
                {
                    Console.WriteLine($"{count}. {rate.NumeratorOfRate}/{rate.DenominatorOfRate}");
                    ++count;
                }
                Console.WriteLine($"{count}. メインメニューに戻る");
                Console.WriteLine();
                Console.Write("登録したい通貨の番号を入力してください:");
                　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
                //入力
                var input = Console.ReadLine();
                int selectNumber;

                //入力値が整数値でない場合エラー
                if (!int.TryParse(input, out selectNumber))
                {
                    Console.WriteLine($"入力が整数値ではありません。入力値: {input}");
                    Console.Write("Enterで戻る");
                    Console.ReadLine();
                    continue;
                }

                //メインメニューに戻る
                if (selectNumber == count)
                {
                    return;
                }

                //選んだ番号が選択肢にあるかチェック
                if (0 < selectNumber || selectNumber < count)
                {
                    Registration(ListOfRate[--selectNumber]);
                }
                else
                {
                    Console.WriteLine($"入力はメニューの選択肢にありません。入力値: {selectNumber}");
                    Console.Write("Enterで戻る");
                    Console.ReadLine();
                    continue;
                }

                while (true)
                {
                    Console.WriteLine();
                    Console.Write("続けてレートを登録しますか? [y:n]:");

                    input = Console.ReadLine();

                    if (input == "y")
                    {
                        break;
                    }
                    else if (input == "n")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"'y'か'n'を入力してください。入力値: {input}");
                    }
                }
            }
        }

        //レート登録用関数
        public static void Registration(ExchangeRate x)
        {
            //通貨登録
            while (true)
            {
                Console.Write($"レート{x.NumeratorOfRate}/{x.DenominatorOfRate}を入力してください(空欄のままEnterで登録せずに戻る):"); 
             
                //入力
                var input = Console.ReadLine();

                //入力が空欄のとき戻る
                if (input == "")
                {
                    return;
                }

                double rate;

                //入力が数値でない場合エラー
                if (!double.TryParse(input, out rate))
                {
                    Console.WriteLine($"入力値は数値ではありません。入力値: {input}");
                    Console.Write("Enterで戻る");
                    Console.ReadLine();
                    continue;
                }

                //既にレートが登録されている場合に上書きして良いか確認する
                if (x.Rate != null)
                {
                    while (true)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"既にレートが登録されていますが上書きしますか? [y:n]");
                        Console.Write($"(既に登録されているレート {x.Rate} {x.NumeratorOfRate}/{x.DenominatorOfRate}):");

                        input = Console.ReadLine();
                        if (input == "y")
                        {
                            break;
                        }
                        else if (input == "n")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"'y'か'n'を入力してください。入力値: {input}");
                        }
                    }
                }

                x.Rate = rate;
                Console.WriteLine();
                Console.WriteLine($"登録レート: {x.Rate} {x.NumeratorOfRate}/{x.DenominatorOfRate}");
                break;
            }
        }
    }
}
