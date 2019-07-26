using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBack.Bankier.Models
{
    public class ProfileData
    {
        public double changePercentValue { get; set; }
        public double changeValue { get; set; }
        public DateTime EndDate { get; set; }
        public double Interval { get; set; }
        public double Max { get; set; }
        public DateTime MaxDate { get; set; }
        public double Min { get; set; }
        public DateTime MinDate { get; set; }
        public double PreviousClose { get; set; }
        public DateTime PreviousCloseDate { get; set; }
        public DateTime StartDate { get; set; }
        public double ValueAverage { get; set; }
        public double ValueSum { get; set; }
        public double VolumeAverage { get; set; }
        public double VolumeSum { get; set; }
        public double TurnoverAverage { get; set; }
        public double TurnoverSum { get; set; }

        public ProfileData(dynamic jsonObject) 
        {
            changeValue = jsonObject.changeValue;
            EndDate = BankierCommon.ParseDate(jsonObject.endDate);
            StartDate = BankierCommon.ParseDate(jsonObject.startDate);
            Interval = jsonObject.interval;
            Max = jsonObject.max;
            MaxDate = BankierCommon.ParseDateShort(jsonObject.maxValueDate);
            Min = jsonObject.min;
            MinDate = BankierCommon.ParseDateShort(jsonObject.minValueDate);
            PreviousClose = jsonObject.prevCloseDB[1];
            PreviousCloseDate = BankierCommon.ParseDateShort(jsonObject.prevCloseDate);
            ValueAverage = jsonObject.valueAverage;
            ValueSum = jsonObject.valueSum;
        }

    }
}
