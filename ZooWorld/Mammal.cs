using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld
{
    // Mammal class, extends animal, adds furcolor, furtype
    public abstract class Mammal : Animal
    {
        private string furColor = string.Empty;
        private string furType = string.Empty;
        public string FurColor { get { return furColor; } }
        public string FurType { get { return furType; } }
        protected Mammal(string type, string name, int foodCost, double weight,string FurColor, string FurType) : base(type, name, foodCost, weight)
        {
            if (string.IsNullOrEmpty(FurColor)) { throw new ArgumentNullException("Fur color not found"); }
            if (string.IsNullOrEmpty(FurType)) { throw new ArgumentNullException("Fur type not found"); }
            this.furType = FurType;
            this.furColor = FurColor;
        }
        public override string Describe()
        {
            return base.Describe() + $", {furType} {furColor} fur";
        }
    }
}
