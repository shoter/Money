using MoneyBack.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            new JsonRequest("http://www.bankier.pl/new-charts/get-data")
                .AddArgument("symbol", "GRUPAAZOTY")
                .AddArgument("intraday", "true")
                .AddArgument("type", "area")
                .Get().Wait();
        }
    }
}
