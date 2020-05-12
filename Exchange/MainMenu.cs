using System;
using System.Collections.Generic;
namespace Exchange
{
    class MainMenu : IMenu
    {
        //メインメニュー
        public void Show(params ExchangeRate[] ListOfRate)
        {
            while (true)
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

                //入力
                var input = Console.ReadLine();

                var nextMenu = new Dictionary<string, IMenu>()
                {
                    { "1", new RegistrationMenu()},
                    { "2", new ExchangeMenu()},
                    { "3", new ExitApplication()}
                };

                //選んだ番号が選択肢にあるかチェック
                if (nextMenu.ContainsKey(input))
                {
                    nextMenu[input].Show(ListOfRate);
                }
                else
                {
                    Console.WriteLine($"入力値がメニューの選択肢にありません。入力値: {input}");
                    Console.Write("Enterで戻る");
                    Console.ReadLine();
                    continue;
                }
            }
        }


        //アプリケーション終了用
        private class ExitApplication : IMenu
        {
            public void Show(params ExchangeRate[] ListOfRate)
            {
                while (true)
                {
                    Console.Write("本当に終了しますか? [y:n]:");

                    var input = Console.ReadLine();

                    if (input == "y")
                    {
                        //アプリケーションを終了
                        Environment.Exit(0);
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
    }
}
