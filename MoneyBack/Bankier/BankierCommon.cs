using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Bankier
{
    public static class BankierCommon
    {
        public static DateTime ParseDate(dynamic date)
        {
            return DateTime.ParseExact(date.ToString(), "yyyy-MM-dd HH:mm", null); 
        }
        public static DateTime ParseDateShort(dynamic date)
        {
            return DateTime.ParseExact(date.ToString(), "yy-MM-dd HH:mm", null);
        }

        public static DateTime ParseEpochTime(dynamic epochTime)
        {
            var seconds = (long)epochTime;
            return epoch.AddMilliseconds(seconds);
        }

        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}
