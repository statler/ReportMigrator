using System;
using System.Collections.Generic;

namespace cpShared.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfDay(this DateTime theDate)
        {
            return theDate.Date;
        }

        public static DateTime StartOfNextDay(this DateTime theDate)
        {
            return theDate.Date.AddDays(1);
        }

        public static DateTime FirstDateInWeek(this DateTime dt, DayOfWeek weekStartDay)
        {
            while (dt.DayOfWeek != weekStartDay)
                dt = dt.AddDays(-1);
            return dt;
        }

        public static DateTime StartOfMonth(this DateTime dt)
        {
            return (new DateTime(dt.Year, dt.Month, 1)).Date;
        }

        public static DateTime EndOfMonth(this DateTime dt)
        {
            DateTime som = new DateTime(dt.Year, dt.Month, 1);

            return som.AddMonths(1).AddDays(-1).Date;
        }

        public static bool IsSameMonth(this DateTime dt, DateTime endDate)
        {
            DateTime som = new DateTime(dt.Year, dt.Month, 1);

            return (dt.Month == endDate.Month) && (dt.Year == endDate.Year);
        }


        public static IEnumerable<DateTime> MonthsBetween(this DateTime startDate, DateTime endDate)
        {
            if (startDate == DateTime.MinValue || endDate == DateTime.MinValue) yield return DateTime.MinValue;
            else
            {
                DateTime iterator;
                DateTime limit;

                if (endDate > startDate)
                {
                    iterator = new DateTime(startDate.Year, startDate.Month, 1);
                    limit = endDate;
                }
                else
                {
                    iterator = new DateTime(endDate.Year, endDate.Month, 1);
                    limit = startDate;
                }

                while (iterator <= limit)
                {
                    yield return iterator.EndOfMonth();
                    iterator = iterator.AddMonths(1);
                }
            }
        }

        public static DateTime? SQLDateTimeSafe(this DateTime? dt)
        {
            if (dt == null)
            {
                return null;
            }
            else
            {
                var sqlSafeTime = ((DateTime)dt).CompareTo(System.Data.SqlTypes.SqlDateTime.MinValue.Value) <= 0 ? null : (DateTime?)dt;
                if (sqlSafeTime == null)
                {
                    return null;
                }
                else
                {
                    sqlSafeTime = ((DateTime)sqlSafeTime).CompareTo(System.Data.SqlTypes.SqlDateTime.MaxValue.Value) >= 0 ? null : (DateTime?)sqlSafeTime;
                    return sqlSafeTime;
                }

            }

        }
    }
}
