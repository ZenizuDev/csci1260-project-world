using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZooWorld
{
    // Animal base class, holds information all animals need and abstract functions to be overwritten later
    public abstract class Animal
    {
        private bool alive = true;
        private string type;
        private string name;
        private int foodCost;
        private double weight;
        private List<FeedingRecord> feedingRecords = new();
        public bool IsAlive { get {  return alive; } }
        public string Type { get { return type; } }
        public string Name { get { return name; } }
        public int FoodCost { get { return foodCost; } }
        public double Weight { get { return weight; } }
        protected Animal(string type, string name, int foodCost, double weight )
        {
            
            if(string.IsNullOrWhiteSpace(type)) { throw new ArgumentNullException("Type not found"); }
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException("Name not found"); }
            if (foodCost <= 0) { throw new ArgumentOutOfRangeException(nameof(foodCost)); }
            if (weight <= 0) { throw new ArgumentOutOfRangeException(nameof(weight)); }
            this.type = type;
            this.name = name;
            this.foodCost = foodCost;
            this.weight = weight;
        }
        public int Feed(int TotalFood, int day)
        {
            if (!alive) { return TotalFood; }
            if (FoodCost > TotalFood) 
            {
                alive = false;
                feedingRecords.Add(new FeedingRecord(day, 0));
                return TotalFood; 
            }
            else 
            {
                GainWeight(FoodCost * .4);
                feedingRecords.Add(new FeedingRecord(day,foodCost));
                return TotalFood - FoodCost; 
            }
            
        }
        public string FeedingHistory()
        {
            if (feedingRecords.Count == 0) { return $"{name} has not been fed yet."; }
            return $"{name}: " + string.Join("; ", feedingRecords);
        }
        private void GainWeight(double Amount)
        {
            if (Amount < 0) { return; }
            weight += Amount;
        }
        public abstract string GetNoise();
        public abstract string GetSpeed();
        public virtual string Describe()
        {
            return $"{name} the {type} eats {foodCost} bowls of food a day, and weighs {double.Round(weight,2)} pounds. Special traits include: {string.Join(", ", new string[] { GetNoise(), GetSpeed() })}";
        }
    }
}