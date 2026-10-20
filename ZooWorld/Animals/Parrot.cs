using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld.Animals
{
    public class Parrot : Animal, ICanFly
    {
        // Base class for the parrot, a non-mammal that can fly
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

        public Parrot(string name, int foodCost, double weight, int flySpeed, string? flightPattern) : base("Parrot", name, foodCost, weight)
        {
            if (flySpeed <= 0) { throw new ArgumentOutOfRangeException(); }
            this.flySpeed = flySpeed;
            this.flightPattern = flightPattern;
        }
        public override string GetSpeed() => $"flies at {flySpeed} mph";
        public override string GetNoise() => "can mimic sounds and even speech";
        public string FlightPattern() => FlyPattern;
        public override string Describe()
        {
            return base.Describe() + $", {FlightPattern()}. Forages with its amazing eyesight.";
        }
    }
}
