using MoneyBack.Requests;
using MoneyBack.Stooq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //new JsonRequest("http://www.bankier.pl/new-charts/get-data")
            //    .AddArgument("symbol", "GRUPAAZOTY")
            //    .AddArgument("intraday", "true")
            //    .AddArgument("type", "area")
            //    .Get().Wait();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
             | SecurityProtocolType.Tls11
             | SecurityProtocolType.Tls12
             | SecurityProtocolType.Ssl3;


            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine(StooqService.GetStockPrice("dis"));
                Thread.Sleep(1000);
            }
        }
    }
}
