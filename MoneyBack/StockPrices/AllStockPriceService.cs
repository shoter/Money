using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.StockPrices
{
    public class AllStockPriceService : IAllStockPriceService
    {
        private Dictionary<StockPriceType, IStockPriceService> stockPriceServices = new Dictionary<StockPriceType, IStockPriceService>();

        public AllStockPriceService(IStockPriceService[] stockPriceServices)
        {
            foreach (var ss in stockPriceServices)
            {
                this.stockPriceServices.Add(ss.StockPriceType, ss);
            }
        }
        public decimal GetStockPrice(StockPriceType stockType, string symbol)
        {
            decimal price = stockPriceServices[stockType].GetStockPrice(symbol);
            Debug.WriteLine($"AllStockPriceService:GetStockPrice({stockType}, {symbol}) = {price}");
            return price;

        }
    }
}
