namespace LibertyGlobalBP.Utilities.Common.Comparers
{
    using System;
    using System.Collections.Generic;

    public class DateTimeYearComparer : EqualityComparer<DateTime>
    {
        public override bool Equals(DateTime x, DateTime y)
        {
            return x.Year == y.Year;
        }

        public override int GetHashCode(DateTime obj)
        {
            return 0;
        }
    }
}
