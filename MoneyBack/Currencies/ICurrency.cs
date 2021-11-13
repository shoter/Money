namespace MoneyBack.Currencies
{
    public interface ICurrency
    {
        string Symbol { get; }

        string FormatPrice(decimal? price);
        
    }
}
