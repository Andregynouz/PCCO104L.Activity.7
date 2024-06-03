using System;

namespace DnDCampaign
{
    public class Character
    {

        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }


        private int Health { get; set; }
        private int Mana { get; set; }
        private int Experience { get; set; }


        public Character()
        {
            Name = "Unknown";
            Class = "Adventurer";
            Level = 1;
            Health = 100;
            Mana = 50;
            Experience = 0;
        }

        public Character(string name, string characterClass)
        {
            Name = name;
            Class = characterClass;
            Level = 1;
            Health = 100;
            Mana = 50;
            Experience = 0;
        }

        public Character(string name, string characterClass, int level)
        {
            Name = name;
            Class = characterClass;
            Level = level;
            Health = 100 + (level - 1) * 10;
            Mana = 50 + (level - 1) * 5;
            Experience = (level - 1) * 1000;
        }


        public void DisplayCharacterInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine($"Mana: {Mana}");
            Console.WriteLine($"Experience:    {Experience}");
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
            Console.WriteLine($"{Name} gained {amount} experience points!");


            while (Experience >= Level * 1000)
            {
                LevelUp();
            }
        }


        private void LevelUp()
        {
            Level++;
            Health += 10;
            Mana += 5;
            Console.WriteLine($"{Name} leveled up! Now at level {Level}.");
        }

        private void TakeDamage(int amount)
        {
            Health -= amount;
            Console.WriteLine($"{Name} took {amount} damage. Health is now {Health}.");

            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has fallen in battle!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Character char1 = new Character();
            Character char2 = new Character("Aragorn", "Ranger");
            Character char3 = new Character("Gandalf", "Wizard", 10);

            char1.DisplayCharacterInfo();
            char2.DisplayCharacterInfo();
            char3.DisplayCharacterInfo();

            char2.GainExperience(2000);
            char2.DisplayCharacterInfo();
        }
    }
}