using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld.Animals
{
    public class Bobcat : Mammal
    {
        // base class for the bobcat, a mammal that cannot fly
        private int speed;
        public int Speed { get { return speed; } }

        public Bobcat(string name, int foodCost, double weight, string furColor, string furType, int speed)
            : base("Bobcat", name, foodCost, weight, furColor, furType)
        {
            if (speed <= 0) { throw new ArgumentOutOfRangeException(nameof(speed)); }
            this.speed = speed;
        }
        public override string GetNoise() => "can make human like screams or bird like chirps";
        public override string GetSpeed() => $"runs at {speed} mph";

        public override string Describe()
        {
            return base.Describe() + ". Hunts alone.";
        }
    }
}
