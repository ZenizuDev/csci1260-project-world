using System;
using System.Collections.Generic;
using System.Text;

namespace ZooWorld
{
    // Manager class: holds the animals that Program builds and passes in.
    public class Zoo
    {
        private int totalFood;
        private string name;
        private List<Animal> animals = new List<Animal>();
        public int TotalFood { get { return totalFood; } }
        public string Name { get { return name; } }
        public int Count { get { return animals.Count; } }

        public Zoo(string name, int totalFood)
        {
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentException("Zoo name not found"); }
            if (totalFood < 0) { throw new ArgumentOutOfRangeException(nameof(totalFood)); }
            this.name = name.Trim();
            this.totalFood = totalFood;
        }

        public void Add(Animal animal)
        {
            if (animal is null) { throw new ArgumentNullException(nameof(animal)); }
            animals.Add(animal);
        }

        public string DescribeAll()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Animal animal in animals)
                sb.AppendLine(animal.Describe());
            return sb.ToString().TrimEnd();
        }

        public string FlightReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Animal animal in animals)
            {
                if (animal is ICanFly flyer)
                    sb.AppendLine($"{animal.Name}: {flyer.FlightPattern()}");
            }
            return sb.ToString().TrimEnd();
        }

        public string FeedAll(int day)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Animal animal in animals)
            {
                if (!animal.IsAlive) { continue; }
                int remaining = animal.Feed(totalFood, day);
                sb.AppendLine(remaining == totalFood
                    ? $"{animal.Name} could not be fed and died (food left: {totalFood})."
                    : $"{animal.Name} was fed (food left: {remaining}).");
                totalFood = remaining;
            }
            return sb.ToString().TrimEnd();
        }

        public string FeedingHistories()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Animal animal in animals)
                sb.AppendLine(animal.FeedingHistory());
            return sb.ToString().TrimEnd();
        }
    }
}