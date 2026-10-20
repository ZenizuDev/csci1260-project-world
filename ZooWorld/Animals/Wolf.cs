using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld.Animals
{
    // Base class for the wolf, a mammal that cannot fly
    public class Wolf : Mammal
    {
        private int speed;
        public int Speed { get { return speed; } }

        public Wolf(string name, int foodCost, double weight, string furColor, string furType, int speed)
            : base("Wolf", name, foodCost, weight, furColor, furType)
        {
            if (speed <= 0) { throw new ArgumentOutOfRangeException(); }
            this.speed = speed;
        }
        public override string GetNoise() => "Howl similar to dogs for long range communication";
        public override string GetSpeed() => $"runs at {speed} mph";

        public override string Describe()
        {
            return base.Describe() + ". Tend to hunt large animals across miles with their packs.";
        }
    }
}
