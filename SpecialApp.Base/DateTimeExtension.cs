using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialApp.Base
{
    public static class DateTimeExtension
    {
        public static int GetDifferenceInYears(this DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) + (((end.Month > start.Month) || ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }

        public static int GetDifferenceInDays(this DateTime start, DateTime end) => (end - start).Days;
    }
}
