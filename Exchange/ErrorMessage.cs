using System;
namespace Exchange
{
    //想定していない入力に対するエラー
    static class ErrorMessage
    {
        public static void show()
        {
            Console.WriteLine();
            Console.WriteLine($"入力値が無効です。");
            Console.Write("Enterで戻る");
            Console.ReadLine();
        }
    }
}
