namespace LibertyGlobalBP.Utilities.Common.Comparers
{
    using System;
    using System.Collections.Generic;

    public class DateTimeDayComparer : EqualityComparer<DateTime>
    {
        public override bool Equals(DateTime x, DateTime y)
        {
            return x.Day == y.Day &&
                   x.Month == y.Month &&
                   x.Year == y.Year;
        }

        public override int GetHashCode(DateTime obj)
        {
            return 0;
        }
    }
}
