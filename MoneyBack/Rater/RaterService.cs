using HtmlAgilityPack;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Rater
{
    public class RaterService
    {
        public static decimal UsdToPlnRate()
        {
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                string url = $"https://wise.com/gb/currency-converter/usd-to-pln-rate?amount=1";
                var html = client.DownloadString(url);

                // Or you can get the file content without saving it
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var element = doc.GetElementbyId("rate");
                string text = element.Attributes["value"].Value;

                return decimal.Parse(text);
            }
        }
        
    }
}
