using MoneyBack.StockPrices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Bankier
{
    public class BankierStockPriceService : IStockPriceService
    {

        private IBankierConnection bankierConnection;

        public BankierStockPriceService(IBankierConnection bankierConnection)
        {
            this.bankierConnection = bankierConnection;
        }

        StockPriceType IStockPriceService.StockPriceType => StockPriceType.Bankier;

        public async Task<decimal> GetStockPrice(string symbol)
        {
            return (await bankierConnection.GetData(symbol, true, true)).ActualPrice;
        }
    }
}
