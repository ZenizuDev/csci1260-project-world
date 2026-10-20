using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld.Animals
{
    public class Bat : Mammal, ICanFly
    {
        // base class for the bat, a mammal that can fly
        private int flySpeed;
        private string? flightPattern;
        public int FlySpeed { get { return flySpeed; } }
        public string FlyPattern { get{
                if (String.IsNullOrEmpty(flightPattern)){return "has no distinct flight pattern";}
                return flightPattern;} }

        public Bat(string name, int foodCost, double weight, string furColor,string furType,int flySpeed, string? flightPattern) : base("Bat", name, foodCost, weight, furColor, furType)
        {
            if(flySpeed <= 0) { throw new ArgumentOutOfRangeException(nameof(flySpeed)); }
            this.flySpeed = flySpeed;
            this.flightPattern = flightPattern;
        }
        public override string GetSpeed() => $"flies at {flySpeed} mph";
        public override string GetNoise() => "chirps ultrasonically to \"see\" and fly";
        public string FlightPattern() => FlyPattern;
        public override string Describe()
        {
            return base.Describe() + $", {FlightPattern()}. Hunts using echolocation.";
        }
    }
}
