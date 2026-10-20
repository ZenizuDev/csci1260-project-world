using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld
{
    // A single record of activity that the zoo does.
    public class ActivityRecord : IEquatable<ActivityRecord>, IComparable<ActivityRecord>
    {
        private int day;
        private string animalFed;
        private int foodGiven;
        public int Day { get { return day; } }
        public string AnimalFed { get { return animalFed; } }
        public int FoodGiven { get { return foodGiven; } }

        public ActivityRecord(int Day, string AnimalFed, int FoodGiven)
        {
            if (Day < 0) { throw new ArgumentOutOfRangeException(nameof(Day)); }
            if (String.IsNullOrEmpty(AnimalFed)) { throw new ArgumentNullException(nameof(AnimalFed)); }
            if (FoodGiven < 0) { throw new ArgumentOutOfRangeException(nameof(FoodGiven)); }
            this.day = Day;
            this.animalFed = AnimalFed;
            this.foodGiven = FoodGiven;
        }
        public bool Equals(ActivityRecord? compare)
        {
            return compare is ActivityRecord && animalFed == compare.animalFed && day == compare.day;
        }
        public override int GetHashCode() { return HashCode.Combine(animalFed, day); }

        public int CompareTo(ActivityRecord? other)
        {
            if (other is null) { return 1; }
            int result = string.Compare(animalFed, other.animalFed);
            return result != 0 ? result : day.CompareTo(other.day);
        }
        public override string ToString()
        {
            if(foodGiven == 0)
            {
                return $"{animalFed} could not be fed and has died. :(";
            }
            return $"Day {day}: {animalFed} was given {foodGiven} bowls of food.";
        }
    }
}
