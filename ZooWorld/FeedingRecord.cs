using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld
{
    // single record created and kept privately by Animal.
    public class FeedingRecord
    {
        private int day;
        private int bowls;

        public FeedingRecord(int day, int bowls)
        {
            if (day < 0) { throw new ArgumentOutOfRangeException(nameof(day)); }
            if (bowls < 0) { throw new ArgumentOutOfRangeException(nameof(bowls)); }
            this.day = day;
            this.bowls = bowls;
        }

        public override string ToString()
        {
            if(bowls == 0) { return $"Died on day {day} due to starvation"; }
            return $"Fed {bowls} on day: {day}";
        }
    }
}
