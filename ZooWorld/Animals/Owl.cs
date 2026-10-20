using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld.Animals
{
    public class Owl : Animal, ICanFly
    {
        // base class for the owl, a non-mammal that can fly
        private int flySpeed;
        private string? flightPattern;
        public int FlySpeed { get { return flySpeed; } }
        public string FlyPattern
        {
            get
            {
                if (String.IsNullOrEmpty(flightPattern)) { return "has no distinct flight pattern"; }
                return flightPattern;
            }
        }

        public Owl(string name, int foodCost, double weight, int flySpeed, string? flightPattern) : base("Owl", name, foodCost, weight)
        {
            if (flySpeed <= 0) { throw new ArgumentOutOfRangeException(nameof(flySpeed)); }
            this.flySpeed = flySpeed;
            this.flightPattern = flightPattern;
        }
        public override string GetSpeed() => $"flies at {flySpeed} mph";
        public override string GetNoise() => "hoots and screeches to communicate";
        public string FlightPattern() => FlyPattern;
        public override string Describe()
        {
            return base.Describe() + $", {FlightPattern()}. Hunts using nearly silent flight.";
        }
    }
}
