using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyBack.Bankier.Models;
using MoneyBack.Requests;

namespace MoneyBack.Bankier
{
    public class BankierConnection : IBankierConnection
    {
        public async Task<GetDataResponse> GetData(string symbol, bool intraday, bool today)
        {
            var jsonObject = await new JsonRequest("http://www.bankier.pl/new-charts/get-data")
                .AddArgument("symbol", symbol)
                .AddArgument("intraday", intraday.ToString().ToLower())
                .AddArgument("type", "area")
                .Get();

            var response = new GetDataResponse(jsonObject);
            return response;
        }

        public GetDataResponse GetData(string symbol, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }
    }
}
