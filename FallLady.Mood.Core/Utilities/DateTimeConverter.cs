namespace FallLady.Mood.Core.Utilities
{
    using System;
    using System.Globalization;
    public static class DateTimeConverter
    {
        public static string FirstDayOfMonth(this DateTime dateTime)
        {
            var date = DateTime.Parse(dateTime.ToPersianDate());
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            return firstDayOfMonth.ToString("yyyy/MM/dd");
        }

        public static string LastDayOfMonth(this DateTime dateTime)
        {
            var date = DateTime.Parse(dateTime.ToPersianDate());
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            return lastDayOfMonth.ToString("yyyy/MM/dd");
        }

        public static DateTime FirstMonthOfYear(this DateTime dateTime)
        {
            var firstMonthOfYear = new DateTime(dateTime.Year, 1, 1);
            return firstMonthOfYear;
        }

        public static DateTime LastMonthOfYear(this DateTime dateTime)
        {
            var lastMonthOfYear = dateTime.AddMonths(-1).AddDays(-1);
            return lastMonthOfYear;
        }

        public static string ToPersian(this DateTime datetime)
        {
            var calendar = new PersianCalendar();
            var year = calendar.GetYear(datetime).ToString();
            var month = calendar.GetMonth(datetime).ToString().PadLeft(2, '0');
            var day = calendar.GetDayOfMonth(datetime).ToString().PadLeft(2, '0');
            var hour = calendar.GetHour(datetime).ToString().PadLeft(2, '0');
            var minute = calendar.GetMinute(datetime).ToString().PadLeft(2, '0');

            return $"{year}/{month}/{day} {hour}:{minute}";
        }
        public static string ToTime(this DateTime datetime)
        {
            var calendar = new PersianCalendar();
            var hour = calendar.GetHour(datetime).ToString().PadLeft(2, '0');
            var minute = calendar.GetMinute(datetime).ToString().PadLeft(2, '0');

            return $"{hour}:{minute}";
        }

        public static string ToPersianDate(this DateTime datetime)
        {

            return ToPersian(datetime)
                .Substring(0,
                    10);



        }

        public static string ToPersianDateNullable(this DateTime? datetime)
        {

            if (datetime == null)
            {
                return "-";
            }
            else
            {
                return ToPersian(datetime)
                    .Substring(0,
                        10);
            }

        }

        public static string ToPersian(this DateTime? datetime)
        {
            return datetime?.ToPersian();
        }

        public static DateTime? PersianDateToChristianDate(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            var items = value.Split('/');
            if (items.Length != 3)
                return null;

            var calendar = new PersianCalendar();
            return calendar.ToDateTime(int.Parse(items[0]),
                int.Parse(items[1]),
                int.Parse(items[2]),
                0,
                0,
                0,
                0);
        }
        public static string ToPersianFirstOfMonth(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy/MM/01", new CultureInfo("fa-IR"));
        }
        public static DateTime? ToDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            string[] allFormats ={"yyyy/MM/dd HH:mm:ss","yyyy/M/d HH:mm:ss",
                "dd/MM/yyyy HH:mm:ss","d/M/yyyy HH:mm:ss",
                "dd/M/yyyy HH:mm:ss","d/MM/yyyy HH:mm:ss","yyyy-MM-dd HH:mm:ss",
                "yyyy-M-d HH:mm:ss","dd-MM-yyyy HH:mm:ss","d-M-yyyy HH:mm:ss",
                "dd-M-yyyy HH:mm:ss","d-MM-yyyy HH:mm:ss","yyyy MM dd HH:mm:ss",
                "yyyy M d HH:mm:ss","dd MM yyyy HH:mm:ss","d M yyyy HH:mm:ss",
                "dd M yyyy HH:mm:ss","d MM yyyy HH:mm:ss"};

            var date = DateTime.ParseExact(value, allFormats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
            return date;
        }
    }
}
