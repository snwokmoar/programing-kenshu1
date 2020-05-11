using System;
namespace Exchange
{
    //通貨換算画面
    class ExchangeMenu : IMenu
    {
        public void Show(params ExchangeRate[] ListOfRate)
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("通貨換算アプリケーション");
                Console.WriteLine();
                Console.WriteLine("通貨換算画面");
                //扱う通貨を順に表示
                int count = 1;
                foreach (ExchangeRate rate in ListOfRate)
                {
                    Console.WriteLine($"{count}. {rate.NumeratorOfRate}/{rate.DenominatorOfRate}");
                    ++count;
                }
                Console.WriteLine($"{count}. メインメニューに戻る");
                Console.WriteLine();
                Console.Write("換算したい通貨を入力してください(数値):");

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

                //選択した番号がメニューの選択肢にあるかチェック
                if (0 < selectNumber || selectNumber < count)
                {
                    ExchangeMoney(ListOfRate[--selectNumber]);
                }
                else
                {
                    Console.WriteLine($"入力はメニューの選択肢にありません。入力値: {input}");
                    Console.Write("Enterで戻る");
                    Console.ReadLine();
                    continue;
                }
            }
        }


        //通貨換算用関数
        private void ExchangeMoney(ExchangeRate x)
        {
            Console.Clear();
            Console.WriteLine($"{x.NumeratorOfRate}に換算");

            //レートを登録していない通貨を選択した場合、警告を表示 (初期登録レート null)
            if (x.Rate == null)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("##警告## 選択した通貨の換算レートが登録されていません。");
                    Console.Write("レートを登録しますか？[y:n]:");
                    var input = Console.ReadLine();
                    if (input == "y")
                    {
                        RegistrationMenu.Registration(x);
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

            //通貨換算
            while (true)
            {
                //入力
                Console.WriteLine();
                Console.Write($"金額({x.DenominatorOfRate})を入力してください(空欄のままEnterで通貨選択画面に戻る):");
                var input = Console.ReadLine();

                //入力が空欄の場合、通貨選択画面に戻る
                if(input == "")
                {
                    return;
                }

                double inputAmount;

                //入力値が数値でない場合、エラー
                if (!double.TryParse(input, out inputAmount))
                {
                    Console.WriteLine($"入力値は数値ではありません。入力値: {input}");
                    Console.Write("Enterで戻る");
                    Console.ReadLine();
                    continue;
                }

                Console.WriteLine($"{inputAmount} {x.DenominatorOfRate}は {x.Rate * inputAmount} {x.NumeratorOfRate} " +
                                  $"(換算レート {x.Rate} {x.NumeratorOfRate}/{x.DenominatorOfRate})");
            }
        }
    }
}
