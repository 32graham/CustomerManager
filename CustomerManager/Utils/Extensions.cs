namespace CustomerManager.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }

        public static bool Between(this DateTime value, DateTime date1, DateTime date2)
        {
            return value >= date1 && value <= date2
                || value <= date1 && value >= date2;
        }

        public static DateTime AddYears(this DateTime value, int? years)
        {
            return value.AddYears(years ?? 0);
        }

        public static DateTime AddMonths(this DateTime value, int? months)
        {
            return value.AddMonths(months ?? 0);
        }

        public static DateTime AddWeeks(this DateTime value, int? weeks)
        {
            return value.AddDays(WeeksToDays(weeks));
        }

        public static DateTime AddDays(this DateTime value, int? days)
        {
            return value.AddDays(days ?? 0);
        }

        public static DateTime AddHours(this DateTime value, int? hours)
        {
            return value.AddHours(hours ?? 0);
        }

        public static DateTime AddMinutes(this DateTime value, int? minutes)
        {
            return value.AddMinutes(minutes ?? 0);
        }

        public static DateTime AddSeconds(this DateTime value, int? seconds)
        {
            return value.AddSeconds(seconds ?? 0);
        }

        public static DateTime AddTime(
            this DateTime value,
            int? years = null,
            int? months = null,
            int? weeks = null,
            int? days = null,
            int? hours = null,
            int? minutes = null,
            int? seconds = null)
        {
            value = value.AddYears(years);
            value = value.AddMonths(months);
            value = value.AddWeeks(weeks);
            value = value.AddDays(days);
            value = value.AddHours(hours);
            value = value.AddMinutes(minutes);
            value = value.AddSeconds(seconds);
            return value;
        }

        public static bool Within(
            this DateTime value,
            int? years = null,
            int? months = null,
            int? weeks = null,
            int? days = null,
            int? hours = null,
            int? minutes = null,
            int? seconds = null)
        {
            var start = DateTime.Now.AddTime(
                -years,
                -months,
                -weeks,
                -days,
                -hours,
                -minutes,
                -seconds);

            var end = DateTime.Now.AddTime(
                years,
                months,
                weeks,
                days,
                hours,
                minutes,
                seconds);

            return value.Between(start, end);
        }

        private static int WeeksToDays(int? weeks)
        {
            return weeks ?? 0 * 7;
        }

        public static bool Between(this DateTime? value, DateTime date1, DateTime date2)
        {
            return value.ToNonNullable().Between(date1, date2);
        }

        public static DateTime AddYears(this DateTime? value, int? years)
        {
            return value.ToNonNullable().AddYears(years);
        }

        public static DateTime AddMonths(this DateTime? value, int? months)
        {
            return value.ToNonNullable().AddMonths(months);
        }

        public static DateTime AddWeeks(this DateTime? value, int? weeks)
        {
            return value.ToNonNullable().AddWeeks(weeks);
        }

        public static DateTime AddDays(this DateTime? value, int? days)
        {
            return value.ToNonNullable().AddDays(days);
        }

        public static DateTime AddHours(this DateTime? value, int? hours)
        {
            return value.ToNonNullable().AddHours(hours);
        }

        public static DateTime AddMinutes(this DateTime? value, int? minutes)
        {
            return value.ToNonNullable().AddMinutes(minutes);
        }

        public static DateTime AddSeconds(this DateTime? value, int? seconds)
        {
            return value.ToNonNullable().AddSeconds(seconds);
        }

        public static DateTime AddTime(
            this DateTime? value,
            int? years = null,
            int? months = null,
            int? weeks = null,
            int? days = null,
            int? hours = null,
            int? minutes = null,
            int? seconds = null)
        {
            return value.ToNonNullable().AddTime(
                years,
                months,
                weeks,
                days,
                hours,
                minutes,
                seconds);
        }

        public static bool Within(
            this DateTime? value,
            int? years = null,
            int? months = null,
            int? weeks = null,
            int? days = null,
            int? hours = null,
            int? minutes = null,
            int? seconds = null)
        {
            return value.ToNonNullable().Within(
                years,
                months,
                weeks,
                days,
                hours,
                minutes,
                seconds);
        }

        private static DateTime ToNonNullable(this DateTime? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return (DateTime)value;
        }
    }
}
