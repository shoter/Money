using System.Threading.Tasks;

namespace MoneyBack.StockPrices
{
    public interface IAllStockPriceService
    {
        Task<decimal> GetStockPrice(StockPriceType stockType, string symbol);
    }
}
