namespace OnlineSpreadsheet.Utilities.Common
{
    using System;
    using System.Globalization;

    public static class DateTimeUtilities
    {
        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FromWorkdays(int workDays)
        {
            DateTime tmpDate = DateTime.Now;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);

                if ((tmpDate.DayOfWeek < DayOfWeek.Saturday) &&
                    (tmpDate.DayOfWeek > DayOfWeek.Sunday) &&
                    (!tmpDate.IsHoliday()))
                {
                    --workDays;
                }
            }

            return tmpDate;
        }

        public static DateTime Min(DateTime first, DateTime second)
        {
            return new DateTime(Math.Min(first.Ticks, second.Ticks));
        }

        public static DateTime AddWorkdays(this DateTime originalDate, int workDays)
        {
            DateTime tmpDate = originalDate;
            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(1);

                if ((tmpDate.DayOfWeek < DayOfWeek.Saturday) &&
                    (tmpDate.DayOfWeek > DayOfWeek.Sunday) &&
                    (!tmpDate.IsHoliday()))
                {
                    --workDays;
                }
            }

            return tmpDate;
        }

        public static DateTime SubtractWorkdays(this DateTime originalDate, int workDays)
        {
            var tmpDate = originalDate;

            while (workDays > 0)
            {
                tmpDate = tmpDate.AddDays(-1);

                if ((tmpDate.DayOfWeek < DayOfWeek.Saturday) &&
                    (tmpDate.DayOfWeek > DayOfWeek.Sunday) &&
                    (!tmpDate.IsHoliday()))
                {
                    --workDays;
                }
            }

            return tmpDate;
        }

        public static int GetWorkdaysDifference(DateTime endDate, DateTime startDate)
        {
            DateTime tempDate = startDate;
            int numberOfDays = 0;

            while (tempDate <= endDate)
            {
                if (tempDate.DayOfWeek < DayOfWeek.Saturday &&
                    tempDate.DayOfWeek > DayOfWeek.Sunday &&
                    (!tempDate.IsHoliday()))
                {
                    numberOfDays++;
                }

                tempDate = tempDate.AddDays(1);
            }

            return numberOfDays;
        }

        private static bool IsHoliday(this DateTime originalDate)
        {
            return false;
        }
    }
}
