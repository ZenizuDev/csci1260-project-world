using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld
{
    // Sorts records from the most recent day to the oldest.
    public class NewestFirstComparer : IComparer<ActivityRecord>
    {
        public int Compare(ActivityRecord? x, ActivityRecord? y)
        {
            if (x is null && y is null) { return 0; }
            if (x is null) { return 1; }
            if (y is null) { return -1; }
            return y.Day.CompareTo(x.Day);
        }
    }
}