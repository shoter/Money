using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.StockPrices
{
    public interface IStockPriceService
    {
        StockPriceType StockPriceType { get; }

        Task<decimal> GetStockPrice(string symbol);
    }
}
