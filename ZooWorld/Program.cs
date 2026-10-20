using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ZooWorld.Animals;

namespace ZooWorld
{
    // Entry point: builds objects, passes them to Zoo, and prints all five sections.
    public class Program
    {
        private const string DataFile = "Animals.txt";
        private const string LogFile = "Activity_Log.txt";

        public static void Main()
        {
            try
            {
                Zoo zoo = new Zoo("Zoo of animals and such", 60);
                List<Animal> animals = new List<Animal>();
                List<string> loadMessages = new List<string>();

                LoadAnimals(animals, loadMessages);
                foreach (Animal animal in animals)
                    zoo.Add(animal);
                int day = 0;
                Section1(zoo, day);
                Section2();
                Section3(animals, zoo);
                Section4();
                Section5(zoo, loadMessages);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        private static void Section1(Zoo zoo,int day)
        {
            Console.WriteLine("=== 1. Classes, UML, and Relationships ===");
            Console.WriteLine($"{zoo.Name} holds {zoo.Count} animals.");

            Console.WriteLine(zoo.FeedAll(day));
            day++;
            Console.WriteLine(zoo.FeedAll(day));
            day++;
            Console.WriteLine(zoo.FeedAll(day));
            day++;
            Console.WriteLine("Feeding histories:");
            Console.WriteLine(zoo.FeedingHistories());

            try
            {
                Wolf bad = new Wolf("Ghost", -5, 40, "gray", "thick", 40);
                Console.WriteLine(bad.Describe());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Constructor rejected bad input: {ex.Message}");
            }
            Console.WriteLine();
        }

        private static void Section2()
        {
            Console.WriteLine("=== 2. Inheritance and Abstraction ===");
            Wolf wolf = new Wolf("Demo", 10, 40, "gray", "thick", 40);
            Parrot parrot = new Parrot("Demo", 3, 0.9, 25, "straight");
            Console.WriteLine(wolf.Describe());
            Console.WriteLine(parrot.Describe());
            Console.WriteLine($"Abstract methods for each class: wolf {wolf.GetNoise()}; parrot {parrot.GetNoise()}.");
            Console.WriteLine();
        }

        private static void Section3(List<Animal> animals, Zoo zoo)
        {
            Console.WriteLine("=== 3. Polymorphism and Interfaces ===");
            Console.WriteLine("-----");
            foreach (Animal animal in animals)
                Console.WriteLine(animal.Describe());

            Console.WriteLine("-----");
            Bat bat = new Bat("Echo", 2, 0.1, "brown", "short", 20, "erratic");
            Parrot parrot = new Parrot("Rio", 3, 0.9, 25, "straight");
            Console.WriteLine(Launch(bat));
            Console.WriteLine(Launch(parrot));

            Console.WriteLine("-----");
            Console.WriteLine(zoo.FlightReport());
            Console.WriteLine();
        }

        private static void Section4()
        {
            Console.WriteLine("=== 4. Built in Contracts and Collections ===");
            List<ActivityRecord> records = new List<ActivityRecord>
            {
                new ActivityRecord(1, "Wolf", 4),
                new ActivityRecord(2,"Owl", 3),
                new ActivityRecord(1,"Bat", 1),
                new ActivityRecord(3,"Wolf", 5),
                new ActivityRecord(2,"Owl", 4)
            };

            Console.WriteLine($"Records in list: {records.Count}");
            HashSet<ActivityRecord> unique = new HashSet<ActivityRecord>();
            Console.WriteLine($"Hashset count before loading: {unique.Count}");
            foreach (ActivityRecord record in records)
                unique.Add(record);
            Console.WriteLine($"Hashset count after loading: {unique.Count}");

            records.Sort();
            Console.WriteLine("--- name, then date ---");
            Console.WriteLine(ListToString(records));

            records.Sort(new FoodAmountComparer());
            Console.WriteLine("--- food amount least first ---");
            Console.WriteLine(ListToString(records));

            records.Sort(new NewestFirstComparer());
            Console.WriteLine("--- date, newest first ---");
            Console.WriteLine(ListToString(records));
            Console.WriteLine();
        }

        private static void Section5(Zoo zoo, List<string> loadMessages)
        {
            Console.WriteLine("=== 5. Exceptions and Files ===");
            foreach (string message in loadMessages)
                Console.WriteLine(message);

            try
            {
                zoo.Add(null!);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Caught on purpose: {ex.Message}");
            }

            ActivityLog log = new ActivityLog(LogFile);
            try
            {
                using (log)
                {
                    Console.WriteLine(log.Log(new ActivityRecord(0, "Wolf", 4)));
                    Console.WriteLine(log.Log(new ActivityRecord(0, "Owl", 3)));
                    throw new InvalidOperationException("Feeding station jammed.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Caught inside the log demo: {ex.Message}");
            }

            log.Dispose();

            Console.WriteLine("--- Finished log file ---");
            foreach (string line in new FileReader(LogFile).ReadAllLines())
                Console.WriteLine(line);
        }

        private static void LoadAnimals(List<Animal> animals, List<string> messages)
        {
            string[] lines;
            try
            {
                lines = new FileReader(DataFile).ReadAllLines();
            }
            catch (FileNotFoundException ex)
            {
                messages.Add($"Data file missing: {ex.Message}");
                return;
            }

            int lineNumber = 0;
            foreach (string line in lines)
            {
                lineNumber++;
                if (string.IsNullOrWhiteSpace(line)) { continue; }

                try
                {
                    animals.Add(ParseAnimal(line));
                }
                catch (Exception ex) when (ex is ArgumentException || ex is FormatException || ex is OverflowException)
                {
                    messages.Add($"Line {lineNumber} skipped: {ex.Message}");
                }
            }
            messages.Add($"Loaded {animals.Count} animals from {lineNumber} lines.");
        }

        private static Animal ParseAnimal(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length < 4)
                throw new FormatException("Line has too few fields.");

            string type = parts[0].Trim();
            string name = parts[1].Trim();
            int foodCost = int.Parse(parts[2].Trim());
            double weight = double.Parse(parts[3].Trim());

            switch (type)
            {
                case "Bat":
                    RequireFields(parts, 8);
                    return new Bat(name, foodCost, weight, parts[4].Trim(), parts[5].Trim(),
                        int.Parse(parts[6].Trim()), parts[7].Trim());
                case "Bobcat":
                    RequireFields(parts, 7);
                    return new Bobcat(name, foodCost, weight, parts[4].Trim(), parts[5].Trim(),
                        int.Parse(parts[6].Trim()));
                case "Wolf":
                    RequireFields(parts, 7);
                    return new Wolf(name, foodCost, weight, parts[4].Trim(), parts[5].Trim(),
                        int.Parse(parts[6].Trim()));
                case "Owl":
                    RequireFields(parts, 6);
                    return new Owl(name, foodCost, weight,
                        int.Parse(parts[4].Trim()), parts[5].Trim());
                case "Parrot":
                    RequireFields(parts, 6);
                    return new Parrot(name, foodCost, weight,
                        int.Parse(parts[4].Trim()), parts[5].Trim());
                default:
                    throw new ArgumentException($"Unknown animal type '{type}'.");
            }
        }

        private static void RequireFields(string[] parts, int expected)
        {
            if (parts.Length != expected)
                throw new FormatException($"{parts[0]} needs {expected} fields but has {parts.Length}.");
        }

        private static string Launch(ICanFly flyer)
        {
            return $"Launching: {flyer.FlightPattern()}";
        }

        private static string ListToString(List<ActivityRecord> records)
        {
            return string.Join("\n", records);
        }
    }
}