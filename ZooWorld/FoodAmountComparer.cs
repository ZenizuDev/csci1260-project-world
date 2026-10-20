using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld
{
    // Sorts records from least food to most food.
    public class FoodAmountComparer : IComparer<ActivityRecord>
    {
        public int Compare(ActivityRecord? x, ActivityRecord? y)
        {
            if (x is null && y is null) { return 0; }
            if (x is null) { return -1; }
            if (y is null) { return 1; }
            return x.FoodGiven.CompareTo(y.FoodGiven);
        }
    }
}
