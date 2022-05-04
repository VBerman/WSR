using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Extensions
{
    public static class TimeSpanExtension
    {
        public static string ToCorrectString(this TimeSpan? timeSpan)
        {
            if (!timeSpan.HasValue)
            {
                return "";
            }
            else
            {
                var valueTimeSpan = timeSpan.Value;
                return valueTimeSpan.Days.ToString() + "д " + valueTimeSpan.Hours + "ч " + valueTimeSpan.Minutes + "м " + valueTimeSpan.Seconds + "с";
            }
        }
    }
}
