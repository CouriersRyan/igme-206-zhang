/*
 * Ryan L. Zhang
 * HW 1: Character Story
 * https://docs.google.com/document/d/1FL56QqpNtMweNRlBtU3jUyMp3C6c7ABd8IhM5ifgfF4/edit?usp=sharing
 */
using System;

namespace HW_CharacterStory_Zhang
{
    internal class Program
    {
        /// <summary>
        /// Prints a story about a character that uses variables to represent stats, and stats change between the beginning and the end.
        /// </summary>
        static void Main(string[] args)
        {
            // Fixed Base Values
            const double MaxHealth = 20.0;
            const int BaseSpeed = 10;
            const int SpeedBoostModifier = 2;
            const int DynamitePower = 15;

            // Starting Character Stats
            string characterName = "Fish Omega-3";
            double currentHealth = MaxHealth;
            int speedBoosts = 2;
            double mapCompletion = 40.6;
            string equipment = "Dynamite";

            // Prints the Title of the story to console.
            Console.WriteLine("==== Fish 2 - The International Salmon Conspiracy, Act 3: Escape the Hitman Shark ====");
            Console.WriteLine();

            // Prints Part 1, the introduction to the main character and their stats.
            // Introductory sentence
            Console.WriteLine("=== Introduction ===");
            Console.WriteLine("Our intrepid hero " + characterName + " is being chased by the Hitman Shark sent by the Salmon Corporation.");
            Console.WriteLine("Will he be able to escape a grim fate?");
            Console.WriteLine();

            // Stats
            Console.WriteLine("--- Character Stats ---");
            Console.WriteLine("Max Health: " + MaxHealth);
            Console.WriteLine("Current Health: " + currentHealth);
            Console.WriteLine("Speed Boosts: " + speedBoosts);
            Console.WriteLine("Map Completion: " + mapCompletion + "%");
            Console.WriteLine("Equipment: " + equipment);
            Console.WriteLine();
            Console.WriteLine();

            // Prints Part 2, with character actions and calculations.
            // At least 5 unique mathematical expressions and 5 unique values printed.
            // At least 1 use of % operator
            // At least 2 must update character's original stats
            Console.WriteLine("==== The Chase ====");
            Console.WriteLine(characterName + " is running away at a speed of " + BaseSpeed + "!");
            Console.WriteLine();

            Console.WriteLine("Oh no! The Hitman Shark is catching up!");
            // Mathematical Expression 1 & Update to Character Stats 1
            speedBoosts--;
            Console.WriteLine(characterName + " uses a Speed Boost! Reducing the remaining amount to " + speedBoosts + ".");
            // Mathematical Expression 2
            Console.WriteLine(characterName + "'s has been increased to " + (BaseSpeed * SpeedBoostModifier) + ".");
            Console.WriteLine();

            Console.WriteLine(characterName + " runs into a sealed off cave! He uses " + equipment + " to make an exit!");
            // Mathematical Expression 3 & Update to Character Stats 2
            currentHealth -= DynamitePower / 2;
            Console.WriteLine(characterName + " and Hitman Shark were both caught in the blast! They split the damage!");
            Console.WriteLine(characterName + " takes " + DynamitePower / 2 + " damage from the blast! His health has been reduced to " + currentHealth + ".");
            // Mathematical Expression 4 & '%' operator use
            Console.WriteLine("He takes more damage! The Hitman Shark takes " + (DynamitePower / 2  +  DynamitePower % 2) + " damage.");
            Console.WriteLine();

            Console.WriteLine(characterName + " escapes the Hitman Shark.");
            // Mathematical Expression 5 & Update to Character Stats 3
            mapCompletion += (BaseSpeed * SpeedBoostModifier) - (MaxHealth - currentHealth);
            Console.WriteLine("Map Completion status has increased! New Completion Rating: " + mapCompletion + "%");
            Console.WriteLine();
            Console.WriteLine();

            // Prints the conclusion and final values for the character's stats.

            // Conclusion
            Console.WriteLine("=== Conclusion ===");
            Console.WriteLine("Having escape the clutches of the Hitman Shark, our intrepid hero " + characterName + " continues on his journey.");
            Console.WriteLine("What deadly foe will the Salmon Corporation throw at him next?");
            Console.WriteLine();

            // Stats
            Console.WriteLine("--- Character Stats ---");
            Console.WriteLine("Max Health: " + MaxHealth);
            Console.WriteLine("Current Health: " + currentHealth);
            Console.WriteLine("Speed Boosts: " + speedBoosts);
            Console.WriteLine("Map Completion: " + mapCompletion + "%");
            Console.WriteLine("Equipment: " + equipment);
            Console.WriteLine();
            Console.WriteLine();

            // Prints The End
            Console.WriteLine("=================== The End ===================");
        }
    }
}
