using MoneyBack.Bankier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Bankier
{
    public interface IBankierConnection
    {
        Task<GetDataResponse> GetData(string symbol, bool intraday, bool today);
        GetDataResponse GetData(string symbol, DateTime dateFrom, DateTime dateTo);
    }
}
