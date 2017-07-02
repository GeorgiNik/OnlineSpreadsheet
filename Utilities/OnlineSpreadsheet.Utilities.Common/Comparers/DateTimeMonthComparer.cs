namespace OnlineSpreadsheet.Utilities.Common.Comparers
{
    using System;
    using System.Collections.Generic;

    public class DateTimeMonthComparer : EqualityComparer<DateTime>
    {
        public override bool Equals(DateTime x, DateTime y)
        {
            return x.Month == y.Month &&
                   x.Year == y.Year;
        }

        public override int GetHashCode(DateTime obj)
        {
            return 0;
        }
    }
}
