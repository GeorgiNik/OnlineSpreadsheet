namespace LibertyGlobalBP.Utilities.Common.Comparers
{
    using System;
    using System.Collections.Generic;

    public class DateTimeWeekComparer : EqualityComparer<DateTime>
    {
        public override bool Equals(DateTime x, DateTime y)
        {
            return (DateTimeUtilities.GetIso8601WeekOfYear(x) ==
                   DateTimeUtilities.GetIso8601WeekOfYear(y)) &&
                   x.Year == y.Year;
        }

        public override int GetHashCode(DateTime obj)
        {
            return 0;
        }
    }
}
