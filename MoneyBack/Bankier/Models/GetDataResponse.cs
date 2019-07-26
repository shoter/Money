using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Bankier.Models
{
    public class GetDataResponse
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double Interval { get; set; }
        public bool Intraday { get; set; }
        public ProfileData ProfileData { get; set; }
        public List<IntervalDetail> Intervals { get; set; } = new List<IntervalDetail>();

        public double ActualPrice => Intervals.Last().Price;
        public GetDataResponse(dynamic jsonObject) 
        {
            Interval = jsonObject.interval;
            ProfileData = new ProfileData(jsonObject.profileData);
            if (jsonObject.date_from.Value != null)
                DateFrom = BankierCommon.ParseEpochTime(jsonObject.date_from);
            if (jsonObject.date_to.Value != null)
                DateTo = BankierCommon.ParseEpochTime(jsonObject.date_to);

            if (jsonObject.intraday != null)
                Intraday = jsonObject.intraday;

            for (int i = 0; i < jsonObject.main.Count; ++i)
            {
                Intervals.Add(new IntervalDetail()
                {
                    Date = BankierCommon.ParseEpochTime(jsonObject.main[i][0]),
                    Price = jsonObject.main[i][1],
                    Volume = jsonObject.volume[i][1]
                });
            }
        }

    }
}
