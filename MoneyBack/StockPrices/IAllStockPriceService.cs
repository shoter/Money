namespace MoneyBack.StockPrices
{
    public interface IAllStockPriceService
    {
        decimal GetStockPrice(StockPriceType stockType, string symbol);
    }
}
