using HtmlAgilityPack;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Stooq
{
    public class StooqService
    {
        public static double GetStockPrice(string symbol)
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                string url = $"https://www.marketwatch.com/investing/stock/{symbol}";
                var html = client.DownloadString(url);

                // Or you can get the file content without saving it
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var element = doc.GetElementbyId("maincontent");
                element = element.SelectSingleNode("//*[contains(@class, 'value') and contains(@class, 'negative')]");
                string text = element.InnerText;

                return double.Parse(text);
            }
        }
        
    }
}
