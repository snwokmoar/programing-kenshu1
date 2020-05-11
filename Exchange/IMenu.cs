using System;
namespace Exchange
{
    public interface IMenu
    {
        void Show(params ExchangeRate[] ListOfRate);
    }
}
